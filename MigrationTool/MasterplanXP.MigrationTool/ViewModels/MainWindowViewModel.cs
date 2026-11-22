using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
using Avalonia;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterplanXP.MigrationTool.Services;
using MasterplanXP.MigrationTool.Services.Utils;
using MasterplanXP.MigrationTool.Models.Legacy;

namespace MasterplanXP.MigrationTool.ViewModels
{
    /// <summary>
    /// ViewModel for the main migration window.
    /// Handles the dual-pane file selection logic, folder scanning, and migration.
    /// </summary>
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string? _selectedAvailableFile;

        [ObservableProperty]
        private string? _selectedStagedFile;

        [ObservableProperty]
        private string? _selectedFolderPath;

        [ObservableProperty]
        private string _migrationStatus = "Ready";

        /// <summary>
        /// "Compress images" switch (default ON). Shrinks images to a size cap for their role and keeps
        /// transparency; see Services/Utils/ImageCompression.cs. (Renamed from UseJpeg, which saved
        /// every image as JPEG and lost transparency.)
        /// </summary>
        [ObservableProperty]
        private bool _compressImages = true;

        /// <summary>"Image size" choice used when compressing: Low, Regular (default) or High.</summary>
        [ObservableProperty]
        private ImageSizeLevel _imageSizeLevel = ImageSizeLevel.Regular;

        /// <summary>The choices shown in the "Image size" list.</summary>
        public ImageSizeLevel[] ImageSizeLevels { get; } = (ImageSizeLevel[])Enum.GetValues(typeof(ImageSizeLevel));

        /// <summary>
        /// "Audit file types" switch (default OFF). When on, Migrate only READS the staged files and
        /// writes a report to migration_log.txt: every .NET type the files contain, and any type the
        /// security allow-list would refuse. Nothing is converted and nothing is refused.
        /// Run this once over your real files to confirm the allow-list (TypeAllowList) covers them.
        /// </summary>
        [ObservableProperty]
        private bool _auditTypes = false;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(MigrateCommand))]
        private bool _isDarkTheme = true;

        [ObservableProperty]
        private string _stagedFilesHeader = "Staged for Migration";

        /// <summary>
        /// Files available for migration (Left Pane).
        /// </summary>
        public ObservableCollection<string> AvailableFiles { get; } = new();

        /// <summary>
        /// Files staged for migration (Right Pane).
        /// </summary>
        public ObservableCollection<string> StagedFiles { get; } = new();

        public MainWindowViewModel()
        {
            // Initialize listeners
            StagedFiles.CollectionChanged += (s, e) => 
            {
                MigrateCommand.NotifyCanExecuteChanged();
                RemoveAllFilesCommand.NotifyCanExecuteChanged();   // "« Remove All" needs staged files
                UpdateStagedHeader();
            };

            // "Add All »" is only enabled while there is something in the Available list.
            AvailableFiles.CollectionChanged += (s, e) => AddAllFilesCommand.NotifyCanExecuteChanged();

            // Set up diagnostic logging to a file in the application directory
            try
            {
                LogSystem.LogFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "migration_log.txt");
                LogSystem.Trace($"--- Migration Tool {Program.VersionText} Started ---");
            }
            catch { }
        }

        private void UpdateStagedHeader()
        {
            int count = StagedFiles.Count;
            StagedFilesHeader = count > 0 ? $"Staged for Migration ({count} files selected)" : "Staged for Migration";
        }

        /// <summary>
        /// Scans the selected folder for .library and .masterplan files.
        /// </summary>
        /// <param name="path">The directory path to scan.</param>
        public void ScanFolder(string path)
        {
            if (!Directory.Exists(path)) return;

            SelectedFolderPath = path;
            AvailableFiles.Clear();
            StagedFiles.Clear();
            MigrationStatus = "Folder scanned.";
            LogSystem.Trace($"Scanned folder: {path}");

            // Listed alphabetically (ignoring case). Windows usually returns files in that order, but
            // it is not guaranteed; sorting here also matches where Remove puts files back
            // (see InsertSorted).
            var files = Directory.EnumerateFiles(path, "*.*", SearchOption.TopDirectoryOnly)
                // Extensions are matched ignoring upper/lower case, so "MONSTERS.LIBRARY" or
                // "Campaign.MasterPlan" are listed too (Windows file names are not case-sensitive).
                .Where(f => f.EndsWith(".library", StringComparison.OrdinalIgnoreCase)
                         || f.EndsWith(".masterplan", StringComparison.OrdinalIgnoreCase))
                .OrderBy(f => Path.GetFileName(f), FileNameOrder);

            foreach (var file in files)
            {
                AvailableFiles.Add(Path.GetFileName(file));
            }
        }

        /// <summary>
        /// Moves selected files from the available list to the staged list.
        /// </summary>
        [RelayCommand]
        private void AddFile(System.Collections.IList? items)
        {
            if (items == null) return;

            var list = items.Cast<string>().ToList();
            foreach (var item in list)
            {
                StagedFiles.Add(item);
                AvailableFiles.Remove(item);
            }
        }

        /// <summary>
        /// Moves selected files from the staged list back to the available list.
        /// </summary>
        [RelayCommand]
        private void RemoveFile(System.Collections.IList? items)
        {
            if (items == null) return;

            var list = items.Cast<string>().ToList();
            foreach (var item in list)
            {
                // Put the file back in its alphabetical place (it used to go to the end of the list).
                InsertSorted(AvailableFiles, item);
                StagedFiles.Remove(item);
            }
        }

        /// <summary>
        /// "Add All »": moves every file from the Available list to the Staged list.
        /// Enabled only while the Available list has files.
        /// </summary>
        [RelayCommand(CanExecute = nameof(CanAddAllFiles))]
        private void AddAllFiles()
        {
            // Copy first: the list cannot be changed while it is being looped over.
            var list = AvailableFiles.ToList();
            foreach (var item in list)
            {
                StagedFiles.Add(item);
                AvailableFiles.Remove(item);
            }
        }

        private bool CanAddAllFiles() => AvailableFiles.Count > 0;

        /// <summary>
        /// "« Remove All": moves every staged file back to the Available list, in alphabetical order.
        /// Enabled only while the Staged list has files.
        /// </summary>
        [RelayCommand(CanExecute = nameof(CanRemoveAllFiles))]
        private void RemoveAllFiles()
        {
            var list = StagedFiles.ToList();
            foreach (var item in list)
            {
                InsertSorted(AvailableFiles, item);
                StagedFiles.Remove(item);
            }
        }

        private bool CanRemoveAllFiles() => StagedFiles.Count > 0;

        /// <summary>
        /// The order file names are listed in: alphabetical, ignoring upper/lower case.
        /// Used by the folder scan and by InsertSorted, so both always agree.
        /// </summary>
        private static readonly StringComparer FileNameOrder = StringComparer.CurrentCultureIgnoreCase;

        /// <summary>
        /// Inserts a file name into an (already alphabetical) list at its alphabetical position,
        /// so the Available list stays in order however files are moved back and forth.
        /// </summary>
        private static void InsertSorted(ObservableCollection<string> list, string item)
        {
            int index = 0;
            while ((index < list.Count) && (FileNameOrder.Compare(list[index], item) <= 0))
                ++index;

            list.Insert(index, item);
        }

        /// <summary>
        /// Executes the migration process for staged files.
        /// Enabled only when files are staged.
        /// </summary>
        [RelayCommand(CanExecute = nameof(CanMigrate))]
        private async Task Migrate()
        {
            if (string.IsNullOrEmpty(SelectedFolderPath)) return;

            // Clear log for fresh run
            try { if (File.Exists(LogSystem.LogFile)) File.WriteAllText(LogSystem.LogFile, ""); } catch { }

            // The version again here: the line above just emptied the log, so the "Started" line with
            // the version is gone, and every log should say which tool version did the conversion.
            LogSystem.Trace($"Migration process started (Migration Tool {Program.VersionText}).");

            // Security allow-list for reading old files (see TypeAllowList). Audit mode reads the
            // files and reports their types without converting or refusing anything; it returns
            // before anything is written or moved, so an audit changes nothing.
            LegacySerializationBinder.ResetLog();
            if (AuditTypes)
            {
                await RunAudit();
                return;
            }
            LegacySerializationBinder.Mode = BinderMode.Enforce;

            // WHERE CONVERTED FILES GO (decided with the user, 2026-11-16):
            //  - Each converted file is written BESIDE its original, in the selected folder
            //    (Monsters.library -> Monsters.mpxlib). Masterplan M14 loads libraries only from its
            //    Libraries folder itself, so a library converted there is found straight away.
            //    (They used to go into a "Converted" subfolder, which M14 never reads.)
            //  - An existing .mpxlib / .mpxplan is NEVER overwritten: it may contain changes made in
            //    M14 since an earlier conversion. Such files are skipped and stay staged.
            //  - After a LIBRARY converts successfully, the old .library is moved into a
            //    "LibraryArchive" subfolder, so the folder holds only new-format libraries and M14
            //    stops reporting it as unconverted. Old PROJECTS (.masterplan) are left where they are.
            string targetFolder = SelectedFolderPath;
            string archiveFolder = Path.Combine(SelectedFolderPath, "LibraryArchive");

            int count = StagedFiles.Count;
            int success = 0;
            int skipped = 0;
            int archiveFailures = 0;

            MigrationStatus = $"Starting migration of {count} files...";
            LibraryConversionService.Instance.CompressImages = CompressImages;
            LibraryConversionService.Instance.ImageSizeLevel = ImageSizeLevel;
            await Task.Delay(1000); 

            var filesToMigrate = StagedFiles.ToList();

            foreach (var fileName in filesToMigrate)
            {
                string sourcePath = Path.Combine(SelectedFolderPath, fileName);
                string extension = Path.GetExtension(fileName).ToLower();
                LegacySerializationBinder.CurrentFile = fileName;
                string fileNameOnly = Path.GetFileNameWithoutExtension(fileName);
                
                LogSystem.Trace($"Processing file: {fileName}");

                // Never overwrite a converted file that already exists (see the note above).
                string newExtension = (extension == ".masterplan") ? ".mpxplan" : ".mpxlib";
                string existingTarget = Path.Combine(targetFolder, Path.ChangeExtension(fileName, newExtension));
                if (File.Exists(existingTarget))
                {
                    skipped++;
                    LogSystem.Trace($"Skipped (already converted, {Path.GetFileName(existingTarget)} exists): {fileName}");
                    MigrationStatus = $"Skipped: {fileNameOnly} (already converted)";
                    await Task.Delay(500);
                    continue; // stays in the Staged list
                }

                // Update status on UI thread
                MigrationStatus = $"Converting: {fileNameOnly}";
                
                // Give the UI a chance to render the status change and update the list
                await Task.Delay(500); 

                bool ok = await Task.Run(() =>
                {
                    try
                    {
                        if (extension == ".library")
                        {
                            var lib = Serialisation<Library>.Load(sourcePath, SerialisationMode.Binary);
                            if (lib != null)
                            {
                                // Bring older-format files up to date first, exactly as Masterplan
                                // itself did right after loading a library (Session.LoadLibrary).
                                // BinaryFormatter does not run constructors or field initialisers, so
                                // a list added in a later Masterplan version (e.g. Artifacts) is null
                                // in older files; Update() fills such gaps in. Without this, older
                                // libraries crashed in MapToLibraryDto (NullReferenceException).
                                lib.Update();

                                string targetPath = Path.Combine(targetFolder, Path.ChangeExtension(fileName, ".mpxlib"));
                                return LibraryConversionService.Instance.SaveXLibrary(lib, targetPath);
                            }
                            else
                            {
                                LogSystem.Trace($"Serialisation.Load returned null for library: {fileName}");
                                return false;
                            }
                        }
                        else if (extension == ".masterplan")
                        {
                            var project = Serialisation<Project>.Load(sourcePath, SerialisationMode.Binary);
                            if (project != null)
                            {
                                // Same upgrade step for projects (it also updates the project's own
                                // library); see the comment on lib.Update() above.
                                project.Update();

                                string targetPath = Path.Combine(targetFolder, Path.ChangeExtension(fileName, ".mpxplan"));
                                return LibraryConversionService.Instance.SaveXProject(project, targetPath);
                            }
                            else
                            {
                                LogSystem.Trace($"Serialisation.Load returned null for project: {fileName}");
                                return false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogSystem.Trace($"Background error migrating {fileName}: {ex.Message}");
                        return false;
                    }
                    return false;
                });

                if (ok)
                {
                    success++;
                    StagedFiles.Remove(fileName);
                    LogSystem.Trace($"Successfully converted: {fileName}");

                    // Libraries only: move the converted original into LibraryArchive.
                    if (extension == ".library" && !MoveToArchive(sourcePath, archiveFolder))
                        archiveFailures++;
                }
                else
                {
                    MigrationStatus = $"Failed: {fileNameOnly}";
                    await Task.Delay(1000);
                }

                // Final yield to ensure UI message queue is processed
                await Task.Yield();
            }

            string summary = $"Migration complete: {success} of {count} files converted.";
            if (skipped > 0)
                summary += $" {skipped} skipped (already converted: a .mpxlib / .mpxplan with the same name exists).";
            if (archiveFailures > 0)
                summary += $" {archiveFailures} original(s) could not be moved to LibraryArchive (see migration_log.txt).";
            MigrationStatus = summary;
            LogSystem.Trace($"Migration summary: {success}/{count} files successful, {skipped} skipped, {archiveFailures} archive move failures.");
        }

        /// <summary>
        /// Moves a converted old library into <paramref name="archiveFolder"/> (created if needed).
        /// If a file with the same name is already archived, the new one becomes "Name (2).library",
        /// "Name (3).library", ... so nothing in the archive is ever overwritten.
        /// Returns false (and logs why) if the move fails; the converted .mpxlib is kept either way.
        /// </summary>
        private static bool MoveToArchive(string sourcePath, string archiveFolder)
        {
            try
            {
                Directory.CreateDirectory(archiveFolder);

                string name = Path.GetFileNameWithoutExtension(sourcePath);
                string ext = Path.GetExtension(sourcePath);
                string target = Path.Combine(archiveFolder, name + ext);
                for (int n = 2; File.Exists(target); n++)
                    target = Path.Combine(archiveFolder, $"{name} ({n}){ext}");

                File.Move(sourcePath, target);
                LogSystem.Trace($"Archived original: {sourcePath} -> {target}");
                return true;
            }
            catch (Exception ex)
            {
                LogSystem.Trace($"Could not move {sourcePath} to {archiveFolder}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// "Audit file types" run: reads every staged file with the binder in Audit mode (nothing is
        /// refused, nothing is written) and logs every type found plus the ones Enforce mode would
        /// refuse. If "would refuse" is empty, the allow-list covers all of these files.
        /// </summary>
        private async Task RunAudit()
        {
            // Migrate (the only caller) already checks this, but the compiler cannot see that from
            // here and warned that Path.Combine below might get null (CS8604). No folder means
            // nothing to audit.
            if (string.IsNullOrEmpty(SelectedFolderPath)) return;

            LegacySerializationBinder.Mode = BinderMode.Audit;
            LogSystem.Trace("Audit run started (files are read only; nothing is converted).");

            var filesToAudit = StagedFiles.ToList();
            int read = 0;
            var unreadable = new System.Collections.Generic.List<string>();   // listed in the summary

            foreach (var fileName in filesToAudit)
            {
                string sourcePath = Path.Combine(SelectedFolderPath, fileName);
                string extension = Path.GetExtension(fileName).ToLower();
                MigrationStatus = $"Auditing: {Path.GetFileNameWithoutExtension(fileName)}";
                LegacySerializationBinder.CurrentFile = fileName;

                bool ok = await Task.Run(() =>
                {
                    if (extension == ".library")
                        return Serialisation<Library>.Load(sourcePath, SerialisationMode.Binary) != null;
                    if (extension == ".masterplan")
                        return Serialisation<Project>.Load(sourcePath, SerialisationMode.Binary) != null;
                    return false;
                });

                if (ok)
                {
                    read++;
                }
                else
                {
                    unreadable.Add(fileName);
                    LogSystem.Trace($"Audit: could not read {fileName} (see the errors above).");
                }
            }

            // The report: every type seen, then the ones the allow-list would refuse.
            LogSystem.Trace($"Audit: {read} of {filesToAudit.Count} files read.");
            LogSystem.Trace($"Audit: {LegacySerializationBinder.SeenTypes.Count} distinct types seen:");
            foreach (string type in LegacySerializationBinder.SeenTypes)
                LogSystem.Trace("    " + type);

            if (LegacySerializationBinder.RefusedTypes.Count == 0)
            {
                LogSystem.Trace("Audit: no types would be refused. The allow-list covers these files.");
            }
            else
            {
                LogSystem.Trace($"Audit: {LegacySerializationBinder.RefusedTypes.Count} type(s) WOULD BE REFUSED in normal mode:");
                foreach (string refused in LegacySerializationBinder.RefusedTypes)
                    LogSystem.Trace("    " + refused);
            }

            // Data from removed features (old classes that no longer exist), dropped via the
            // RemovedLegacyType stand-in so the rest of each file could still be read.
            if (LegacySerializationBinder.DiscardedTypes.Count != 0)
            {
                LogSystem.Trace($"Audit: {LegacySerializationBinder.DiscardedTypes.Count} removed-feature type(s) DISCARDED (their data is dropped):");
                foreach (string discarded in LegacySerializationBinder.DiscardedTypes)
                    LogSystem.Trace("    " + discarded);
            }

            // Files that could not be read at all, gathered here so they are not lost among the
            // error details above (each one's cause is logged just before its "could not read" line).
            if (unreadable.Count != 0)
            {
                LogSystem.Trace($"Audit: {unreadable.Count} file(s) COULD NOT BE READ:");
                foreach (string name in unreadable)
                    LogSystem.Trace("    " + name);
            }

            // Back to normal for the next run.
            LegacySerializationBinder.Mode = BinderMode.Enforce;
            MigrationStatus = $"Audit complete: {read} of {filesToAudit.Count} files read, "
                            + $"{LegacySerializationBinder.SeenTypes.Count} types seen, "
                            + $"{LegacySerializationBinder.RefusedTypes.Count} would be refused (see migration_log.txt).";
        }

        private bool CanMigrate() => StagedFiles.Count > 0;

        /// <summary>
        /// Toggles between Dark and Light theme.
        /// </summary>
        [RelayCommand]
        private void ToggleTheme()
        {
            var app = Application.Current;
            if (app != null)
            {
                // IsDarkTheme is updated by the ToggleSwitch binding before this command runs
                app.RequestedThemeVariant = IsDarkTheme ? ThemeVariant.Dark : ThemeVariant.Light;
            }
        }
    }
}
