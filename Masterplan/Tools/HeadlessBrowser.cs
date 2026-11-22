using Microsoft.Win32;
using PuppeteerSharp;
using PuppeteerSharp.BrowserData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Masterplan.Tools
{
    /// <summary>
    /// Which browser PNG, JPG and PDF exports try first (Tools > Preferences > Export Browser).
    /// The other one is always tried as a fallback.
    /// </summary>
    public enum ExportBrowser
    {
        /// <summary>The default: Masterplan's own copy of Chromium, downloaded once (~250 MB) to
        /// %LocalAppData%\Masterplan\Chromium. Same browser and results on every PC.</summary>
        DownloadedChromium,

        /// <summary>Microsoft Edge or Google Chrome already installed on the PC: no download, but
        /// some PCs do not allow them to run hidden (e.g. company policies).</summary>
        InstalledBrowser
    }

    /// <summary>
    /// Starts the hidden ("headless") web browser that PNG, JPG and PDF exports use to draw HTML.
    /// </summary>
    /// <remarks>
    /// WHY THIS EXISTS (for new developers):
    /// PuppeteerSharp drives a Chromium-based browser to turn HTML into images and PDFs. The old code
    /// called new BrowserFetcher().DownloadAsync() before every export, which downloads its own copy
    /// of Chromium (about 250-280 MB) into the folder the app was started from. That fails when
    /// Masterplan is installed under Program Files (not writable), and needs internet access.
    ///
    /// There are two kinds of browser we can use:
    ///   - our own Chromium, downloaded ONCE into a per-user folder (%LocalAppData%\Masterplan\Chromium)
    ///     and reused afterwards;
    ///   - Microsoft Edge (ships with every Windows 10/11 PC) or Google Chrome, already installed.
    ///     Both are Chromium-based, so PuppeteerSharp can drive them too.
    /// The user picks which kind is tried FIRST (Preferences.ExportBrowser); if it fails, the other
    /// kind is tried, so exports keep working either way. The browser that worked is remembered for
    /// the rest of the session (as long as the preference is not changed).
    /// A browser can be installed but refuse to start (e.g. a company policy blocks headless mode), so
    /// each candidate is actually launched; a failure is logged and the next candidate is tried.
    /// Puppeteer starts the browser with its own temporary profile, so it does not touch the user's
    /// open Edge/Chrome windows, tabs or settings.
    /// </remarks>
    public static class HeadlessBrowser
    {
        // Path of the browser exe that started successfully in this session (null = not known yet),
        // and the preference that was in effect when it was found. If the user changes the
        // preference, the remembered browser is ignored and the search starts again.
        private static string? sWorkingPath = null;
        private static ExportBrowser sWorkingPreference;

        /// <summary>
        /// Folder of our own Chromium copy: downloaded here once, then reused.
        /// It is per-user and always writable, unlike the program folder.
        /// </summary>
        public static string DownloadFolder
        {
            get
            {
                string local = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(local, "Masterplan", "Chromium");
            }
        }

        #region Background download of Chromium

        // BACKGROUND DOWNLOAD (for new developers):
        // The Chromium download is about 250 MB, so instead of making the user wait on their first
        // export, it starts in the background when they open a window that can export (Libraries, or a
        // creature stat block window): StartBackgroundDownload(). There is only ever ONE download:
        // every caller (including an export that is waiting for it) shares sDownloadTask.
        // The download goes into "<DownloadFolder>.partial" and that folder is only renamed to
        // DownloadFolder once Chromium's exe is there, so a download cut short (app closed, network
        // lost) never looks like a finished install; the leftover .partial folder is deleted next time.
        // Progress (0-100) is in DownloadPercent; DownloadProgressChanged fires on a BACKGROUND
        // thread, so forms must use BeginInvoke before touching controls (see ShowProgressInTitle).

        private static readonly object sDownloadLock = new object();

        // The shared download. Result: the Chromium exe path, or null if the download failed
        // (a failed task is replaced by a new attempt the next time someone asks).
        private static Task<string?>? sDownloadTask = null;

        // HttpClient is meant to be created once and reused. No overall time limit: a 250 MB file
        // can take a long time on a slow connection.
        private static readonly HttpClient sHttp = new HttpClient { Timeout = System.Threading.Timeout.InfiniteTimeSpan };

        /// <summary>
        /// Download progress in percent (0-100) while the download runs; -1 when no download is running.
        /// </summary>
        public static int DownloadPercent { get; private set; } = -1;

        /// <summary>
        /// True while Chromium is being downloaded (or unpacked).
        /// </summary>
        public static bool IsDownloading
        {
            get
            {
                Task<string?>? task = sDownloadTask;
                return task != null && !task.IsCompleted;
            }
        }

        /// <summary>
        /// Raised when DownloadPercent changes, including when the download ends (DownloadPercent = -1).
        /// WARNING: raised on a background thread; use Control.BeginInvoke to update the UI.
        /// </summary>
        public static event EventHandler? DownloadProgressChanged;

        /// <summary>
        /// Starts downloading Chromium in the background if it is needed: only when the Export Browser
        /// preference is "Downloaded Chromium", Chromium is not there yet and no download is running.
        /// Safe to call often (e.g. every time Libraries opens); returns immediately and never throws.
        /// </summary>
        public static void StartBackgroundDownload()
        {
            try
            {
                ExportBrowser preference = Session.Preferences?.ExportBrowser ?? ExportBrowser.DownloadedChromium;
                if (preference != ExportBrowser.DownloadedChromium)
                    return;

                // Not awaited on purpose: it runs in the background. Failures are logged inside.
                _ = EnsureChromiumAsync();
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
            }
        }

        /// <summary>
        /// Shows the download progress in a window's title while the download runs, e.g.
        /// "Libraries - preparing export component... 45%", and puts the normal title back when it
        /// ends. Call once, after the form's normal title is set (usually in its constructor).
        /// </summary>
        public static void ShowProgressInTitle(Form form)
        {
            string baseTitle = form.Text;

            void update()
            {
                if (form.IsDisposed)
                    return;

                int percent = DownloadPercent;
                form.Text = (IsDownloading && percent >= 0)
                    ? $"{baseTitle} - preparing export component... {percent}%"
                    : baseTitle;
            }

            // The event comes from a background thread: hand the update to the form's UI thread.
            EventHandler handler = (sender, e) =>
            {
                try
                {
                    if (form.IsHandleCreated && !form.IsDisposed)
                        form.BeginInvoke((Action)update);
                }
                catch (Exception)
                {
                    // The form closed between the check and BeginInvoke; nothing to update.
                }
            };

            DownloadProgressChanged += handler;
            form.FormClosed += (sender, e) => DownloadProgressChanged -= handler; // no leaks after closing
            form.Shown += (sender, e) => update();
            update();
        }

        /// <summary>
        /// Returns the shared download task: an already-finished one if Chromium is installed, the
        /// running one if a download is in progress, otherwise a new download.
        /// </summary>
        private static Task<string?> EnsureChromiumAsync()
        {
            lock (sDownloadLock)
            {
                // Running, or finished successfully (and the exe is still there): share it.
                if (sDownloadTask != null)
                {
                    if (!sDownloadTask.IsCompleted)
                        return sDownloadTask;

                    string? done = sDownloadTask.Result;
                    if (done != null && File.Exists(done))
                        return sDownloadTask;
                }

                // Already downloaded in an earlier session?
                string? existing = FindDownloadedChromium(DownloadFolder);
                if (existing != null)
                {
                    sDownloadTask = Task.FromResult<string?>(existing);
                    return sDownloadTask;
                }

                // Start a new download on a background thread.
                sDownloadTask = Task.Run(DownloadChromiumAsync);
                return sDownloadTask;
            }
        }

        /// <summary>
        /// The exe of a complete Chromium copy in <paramref name="folder"/>, or null if there is none.
        /// </summary>
        private static string? FindDownloadedChromium(string folder)
        {
            try
            {
                if (!Directory.Exists(folder))
                    return null;

                BrowserFetcher fetcher = new BrowserFetcher(new BrowserFetcherOptions { Path = folder, Browser = SupportedBrowser.Chrome }, null);
                foreach (InstalledBrowser installed in fetcher.GetInstalledBrowsers())
                {
                    string exe = installed.GetExecutablePath();
                    if (File.Exists(exe))
                        return exe;
                }
            }
            catch (Exception ex)
            {
                LogSystem.Trace("HeadlessBrowser: could not check " + folder + ":");
                LogSystem.Trace(ex);
            }

            return null;
        }

        /// <summary>
        /// Downloads and unpacks Chromium into the folder DownloadFolder + ".partial", then renames that
        /// folder to DownloadFolder. Returns the exe path, or null on any failure (logged).
        /// </summary>
        private static async Task<string?> DownloadChromiumAsync()
        {
            string partial = DownloadFolder + ".partial";
            try
            {
                SetProgress(0);

                // Clean up after an earlier attempt that was cut short.
                if (Directory.Exists(partial))
                    Directory.Delete(partial, true);

                // A Chromium folder without a working exe (damaged or incomplete) is replaced.
                if (Directory.Exists(DownloadFolder) && FindDownloadedChromium(DownloadFolder) == null)
                    Directory.Delete(DownloadFolder, true);

                LogSystem.Trace("HeadlessBrowser: downloading Chromium to " + partial);
                BrowserFetcherOptions options = new BrowserFetcherOptions
                {
                    Path = partial,
                    Browser = SupportedBrowser.Chrome,
                    CustomFileDownload = DownloadFileWithProgressAsync // our downloader reports progress
                };
                BrowserFetcher fetcher = new BrowserFetcher(options, null);
                InstalledBrowser installed = await fetcher.DownloadAsync(); // downloads, then unpacks

                if (!File.Exists(installed.GetExecutablePath()))
                    throw new InvalidOperationException("Chromium was downloaded but its exe is missing.");

                // Complete: make it the real install in one step.
                Directory.Move(partial, DownloadFolder);

                string? exe = FindDownloadedChromium(DownloadFolder);
                if (exe == null)
                    throw new InvalidOperationException("Chromium could not be found after moving it to " + DownloadFolder);

                LogSystem.Trace("HeadlessBrowser: Chromium is ready: " + exe);
                return exe;
            }
            catch (Exception ex)
            {
                // Logged in full, but as a plain message (ex.ToString() includes inner exceptions and
                // the stack trace): this is an EXPECTED failure (e.g. no internet access) that is
                // handled by falling back to the installed browser, so it must not set
                // LogSystem.ErrorLogged, which makes beta builds ask about the log on exit.
                LogSystem.Trace("HeadlessBrowser: Chromium download failed (falling back if possible):");
                LogSystem.Trace(ex.ToString());
                return null;
            }
            finally
            {
                SetProgress(-1); // download over (finished or failed): forms restore their titles
            }
        }

        /// <summary>
        /// Our replacement for PuppeteerSharp's own file download (BrowserFetcherOptions.CustomFileDownload),
        /// so we can report progress: streams <paramref name="address"/> into <paramref name="fileName"/>
        /// and updates DownloadPercent from the file size the server reports.
        /// </summary>
        private static async Task DownloadFileWithProgressAsync(string address, string fileName)
        {
            using (HttpResponseMessage response = await sHttp.GetAsync(address, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();
                long? total = response.Content.Headers.ContentLength;

                string? folder = Path.GetDirectoryName(fileName);
                if (!string.IsNullOrEmpty(folder))
                    Directory.CreateDirectory(folder);

                using (Stream input = await response.Content.ReadAsStreamAsync())
                using (FileStream output = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None, 81920, true))
                {
                    byte[] buffer = new byte[81920];
                    long received = 0;
                    int read;
                    while ((read = await input.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        await output.WriteAsync(buffer, 0, read);
                        received += read;

                        if (total.HasValue && total.Value > 0)
                            SetProgress((int)Math.Min(100, received * 100 / total.Value));
                    }
                }
            }
        }

        /// <summary>
        /// Updates DownloadPercent and raises DownloadProgressChanged, only when the value changes
        /// (so listeners get at most about 100 updates per download).
        /// </summary>
        private static void SetProgress(int percent)
        {
            if (percent == DownloadPercent)
                return;

            DownloadPercent = percent;
            try
            {
                DownloadProgressChanged?.Invoke(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
            }
        }

        #endregion

        /// <summary>
        /// Starts a headless browser. The caller must dispose it (use "await using").
        /// </summary>
        /// <param name="viewportWidth">Width of the page in pixels.</param>
        /// <param name="viewportHeight">Height of the page in pixels.</param>
        /// <exception cref="InvalidOperationException">No browser could be started at all.</exception>
        public static async Task<IBrowser> LaunchAsync(int viewportWidth = 1000, int viewportHeight = 800)
        {
            // Read the user's choice each time, so a change in the menu applies to the next export.
            ExportBrowser preference = Session.Preferences?.ExportBrowser ?? ExportBrowser.DownloadedChromium;

            // 1. The browser that worked last time in this session (only if the preference is unchanged).
            if (sWorkingPath != null && sWorkingPreference == preference)
            {
                IBrowser? browser = await TryLaunchAsync(sWorkingPath, viewportWidth, viewportHeight);
                if (browser != null)
                    return browser;
            }
            sWorkingPath = null; // not known, preference changed, or it stopped working: search again

            // 2. The preferred kind of browser first, then the other kind as a fallback.
            IBrowser? found;
            if (preference == ExportBrowser.InstalledBrowser)
                found = await TryInstalledBrowsersAsync(viewportWidth, viewportHeight)
                     ?? await TryDownloadedChromiumAsync(viewportWidth, viewportHeight);
            else
                found = await TryDownloadedChromiumAsync(viewportWidth, viewportHeight)
                     ?? await TryInstalledBrowsersAsync(viewportWidth, viewportHeight);

            if (found != null)
            {
                sWorkingPreference = preference;
                return found;
            }

            throw new InvalidOperationException(
                "Masterplan could not start Microsoft Edge, Google Chrome or its own copy of Chromium, "
                + "which are needed for PNG, JPG and PDF export. See the log file for details.");
        }

        /// <summary>
        /// Tries the installed Edge, then Chrome. Returns null if none of them starts.
        /// On success, remembers the exe in sWorkingPath.
        /// </summary>
        private static async Task<IBrowser?> TryInstalledBrowsersAsync(int width, int height)
        {
            foreach (string path in FindInstalledBrowsers())
            {
                IBrowser? browser = await TryLaunchAsync(path, width, height);
                if (browser != null)
                {
                    sWorkingPath = path;
                    LogSystem.Trace("HeadlessBrowser: using installed browser " + path);
                    return browser;
                }
            }

            LogSystem.Trace("HeadlessBrowser: no installed Edge or Chrome could be started.");
            return null;
        }

        /// <summary>
        /// Tries our own Chromium copy. If it is not there yet this waits for the shared background
        /// download (starting it if nobody has), so an early export never starts a second download.
        /// Returns null if the download fails (e.g. no internet access; already logged) or Chromium
        /// does not start. On success, remembers the exe in sWorkingPath.
        /// </summary>
        private static async Task<IBrowser?> TryDownloadedChromiumAsync(int width, int height)
        {
            string? chromium = await EnsureChromiumAsync();
            if (chromium == null)
                return null;

            IBrowser? browser = await TryLaunchAsync(chromium, width, height);
            if (browser != null)
            {
                sWorkingPath = chromium;
                LogSystem.Trace("HeadlessBrowser: using downloaded Chromium " + chromium);
            }

            return browser;
        }

        /// <summary>
        /// Tries to start the browser at <paramref name="exePath"/> headless.
        /// Returns null (and logs why) if it does not start.
        /// </summary>
        private static async Task<IBrowser?> TryLaunchAsync(string exePath, int width, int height)
        {
            try
            {
                LaunchOptions options = new LaunchOptions
                {
                    ExecutablePath = exePath,
                    Headless = true,
                    DefaultViewport = new ViewPortOptions { Width = width, Height = height }
                };

                return await Puppeteer.LaunchAsync(options);
            }
            catch (Exception ex)
            {
                // Log the FULL exception (inner exceptions and browser output included): the short
                // message is often just "Failed to launch browser!", which does not say why.
                // It is logged as a plain message (ex.ToString()), because a browser that will not
                // start is EXPECTED on some PCs (e.g. Edge here) and handled by trying the next one;
                // it must not set LogSystem.ErrorLogged, which makes beta builds ask about the log
                // on exit. If NO browser starts, the export itself fails and that error is logged.
                LogSystem.Trace("HeadlessBrowser: could not start " + exePath + " (trying the next browser):");
                LogSystem.Trace(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// Lists the installed Edge and Chrome exes on this PC, Edge first (it ships with Windows).
        /// Each exe appears once, and only if the file exists.
        /// </summary>
        internal static List<string> FindInstalledBrowsers()
        {
            string programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            string programFilesX86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            List<string?> candidates = new List<string?>
            {
                // Edge: the registry entry first (it records where Edge really is), then the usual folders.
                GetAppPath("msedge.exe"),
                Path.Combine(programFilesX86, "Microsoft", "Edge", "Application", "msedge.exe"),
                Path.Combine(programFiles, "Microsoft", "Edge", "Application", "msedge.exe"),

                // Chrome: registry, then machine-wide and per-user installs.
                GetAppPath("chrome.exe"),
                Path.Combine(programFiles, "Google", "Chrome", "Application", "chrome.exe"),
                Path.Combine(programFilesX86, "Google", "Chrome", "Application", "chrome.exe"),
                Path.Combine(localAppData, "Google", "Chrome", "Application", "chrome.exe"),
            };

            return candidates
                .Where(path => !string.IsNullOrEmpty(path) && File.Exists(path))
                .Select(path => path!)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
        }

        /// <summary>
        /// Reads where Windows says an exe is installed, from
        /// HKEY_CURRENT_USER or HKEY_LOCAL_MACHINE \SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\(exe).
        /// Returns null if there is no entry (or the registry cannot be read).
        /// </summary>
        private static string? GetAppPath(string exeName)
        {
            string key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\" + exeName;
            foreach (RegistryKey root in new[] { Registry.CurrentUser, Registry.LocalMachine })
            {
                try
                {
                    using (RegistryKey? appKey = root.OpenSubKey(key))
                    {
                        // The (Default) value holds the full exe path, sometimes in quotes.
                        string? path = appKey?.GetValue(null) as string;
                        if (!string.IsNullOrWhiteSpace(path))
                            return path.Trim().Trim('"');
                    }
                }
                catch (Exception ex)
                {
                    LogSystem.Trace("HeadlessBrowser: could not read registry key " + key + ": " + ex.Message);
                }
            }

            return null;
        }

    }
}
