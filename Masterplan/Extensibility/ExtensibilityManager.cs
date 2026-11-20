#nullable disable

using Masterplan.Data;
using Masterplan.Tools;
using Masterplan.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Masterplan.Extensibility
{
    /// <summary>
    /// Loads add-ins from the AddIns folder beside Masterplan.exe and gives them access to the app
    /// (it is the IApplication that add-ins receive in IAddIn.Initialise).
    /// </summary>
    /// <remarks>
    /// ADD-IN FOLDER LAYOUT (for add-in developers and new Masterplan developers):
    ///   AddIns\MyAddIn.dll            a simple add-in with no other DLLs, or
    ///   AddIns\MyAddIn\MyAddIn.dll    an add-in with its own dependencies (helper DLLs, .deps.json,
    ///                                 native files) in the same folder.
    /// In a subfolder, only the DLL whose name matches the folder is loaded as the add-in; the other
    /// DLLs there are its dependencies, loaded when it needs them (see AddInLoadContext). (The old code
    /// loaded EVERY DLL in every subfolder as a possible add-in, so dependencies were loaded twice and
    /// could not find each other.)
    ///
    /// ROBUSTNESS: each add-in file is loaded on its own inside a try, so a bad, damaged or non-.NET
    /// DLL cannot stop the others or Masterplan's start-up, and this constructor never throws.
    /// Problems are written to the log in full and collected in LoadProblems; MainForm shows them to
    /// the user once (MainForm_Shown).
    /// </remarks>
    class ExtensibilityManager : IApplication
    {
        public ExtensibilityManager(MainForm main_form)
        {
            fMainForm = main_form;

            try
            {
                // The AddIns folder beside the exe. AppPaths is the one place that finds the exe's
                // folder (works in normal and single-file mode); see Tools/AppPaths.cs.
                string dir = AppPaths.InAppFolder("AddIns");
                foreach (string file in FindAddInFiles(dir))
                    LoadAddInFile(file);

                Session.AddIns.Sort(compare_addins);
            }
            catch (Exception ex)
            {
                // Should not happen (each file is handled on its own), but never stop Masterplan starting.
                LogSystem.Trace(ex);
            }
        }

        MainForm fMainForm = null;

        /// <summary>
        /// Add-ins that could not be loaded in this session: file name and a short reason.
        /// The full details are in the log. Empty if everything loaded (or there are no add-ins).
        /// </summary>
        public List<string> LoadProblems { get; } = new List<string>();

        #region Loading add-ins

        /// <summary>
        /// The add-in DLLs to load (see the folder layout in the class remarks): every DLL directly in
        /// the AddIns folder, plus, for each subfolder, the DLL named like the subfolder.
        /// </summary>
        static List<string> FindAddInFiles(string dir)
        {
            List<string> files = new List<string>();
            if (!Directory.Exists(dir))
                return files;

            files.AddRange(Directory.GetFiles(dir, "*.dll").OrderBy(f => f, StringComparer.OrdinalIgnoreCase));

            foreach (string subdir in Directory.GetDirectories(dir).OrderBy(d => d, StringComparer.OrdinalIgnoreCase))
            {
                string main = Path.Combine(subdir, Path.GetFileName(subdir) + ".dll");
                if (File.Exists(main))
                    files.Add(main);
                else
                    LogSystem.Trace("Add-ins: skipped folder " + subdir + " (no " + Path.GetFileName(main) + " in it).");
            }

            return files;
        }

        /// <summary>
        /// Loads one add-in DLL into its own AddInLoadContext and installs every add-in class in it.
        /// Never throws: problems are logged and added to LoadProblems.
        /// </summary>
        void LoadAddInFile(string path)
        {
            string name = Path.GetFileName(path);
            try
            {
                AddInLoadContext context = new AddInLoadContext(path);
                Assembly assembly = context.LoadFromAssemblyPath(path);

                Type[] types;
                try
                {
                    types = assembly.GetTypes();
                }
                catch (ReflectionTypeLoadException rtle)
                {
                    // Some types could not be loaded (usually a missing or wrong-version dependency).
                    // Use the ones that did load, and log why the others did not.
                    LogSystem.Trace("Add-ins: some types in " + name + " could not be loaded:");
                    foreach (Exception loaderEx in rtle.LoaderExceptions.Where(e => e != null))
                        LogSystem.Trace(loaderEx);
                    types = rtle.Types.Where(t => t != null).ToArray();
                }

                int found = 0;
                foreach (Type t in types.Where(is_addin))
                {
                    found++;
                    install(t, name);
                }

                if (found == 0)
                {
                    // Usually a helper DLL placed directly in AddIns\ instead of in the add-in's own
                    // subfolder (see the folder layout above).
                    LogSystem.Trace("Add-ins: " + name + " contains no add-in (no public class implementing IAddIn with a parameterless constructor).");
                    LoadProblems.Add(name + " - contains no add-in (a helper DLL belongs in its add-in's own folder)");
                }
            }
            catch (BadImageFormatException ex)
            {
                // Not a .NET assembly (e.g. a native DLL), or a damaged file.
                LogSystem.Trace("Add-ins: " + path + " is not a .NET add-in:");
                LogSystem.Trace(ex);
                LoadProblems.Add(name + " - not a .NET add-in, or the file is damaged");
            }
            catch (Exception ex)
            {
                LogSystem.Trace("Add-ins: could not load " + path + ":");
                LogSystem.Trace(ex);
                LoadProblems.Add(name + " - " + ex.Message);
            }
        }

        /// <summary>
        /// True if the type is an add-in Masterplan can create: a concrete class implementing IAddIn
        /// with a public parameterless constructor.
        /// </summary>
        static bool is_addin(Type t)
        {
            return typeof(IAddIn).IsAssignableFrom(t)
                && t.IsClass && !t.IsAbstract
                && t.GetConstructor(Type.EmptyTypes) != null;
        }

        /// <summary>
        /// Creates the add-in, calls its Initialise, and adds it to Session.AddIns if it agreed to load.
        /// Problems in the add-in's own code are logged and reported, not thrown.
        /// </summary>
        void install(Type t, string fileName)
        {
            try
            {
                IAddIn addin = (IAddIn)Activator.CreateInstance(t);

                string addinName = addin.Name ?? t.FullName;
                if (Session.AddIns.Any(a => string.Equals(a.Name, addinName, StringComparison.OrdinalIgnoreCase)))
                {
                    LogSystem.Trace("Add-ins: skipped '" + addinName + "' in " + fileName + ": an add-in with that name is already loaded.");
                    LoadProblems.Add(fileName + " - '" + addinName + "' is already loaded");
                    return;
                }

                if (addin.Initialise(this))
                {
                    Session.AddIns.Add(addin);
                    LogSystem.Trace("Add-ins: loaded '" + addinName + "' from " + fileName);
                }
                else
                {
                    // The add-in chose not to load (e.g. a requirement it checks is missing); not an error.
                    LogSystem.Trace("Add-ins: '" + addinName + "' in " + fileName + " chose not to load (Initialise returned false).");
                }
            }
            catch (Exception ex)
            {
                // TargetInvocationException wraps exceptions thrown by the add-in's constructor.
                Exception inner = (ex is TargetInvocationException tie && tie.InnerException != null) ? tie.InnerException : ex;
                LogSystem.Trace("Add-ins: " + t.FullName + " in " + fileName + " failed to start:");
                LogSystem.Trace(inner);
                LoadProblems.Add(fileName + " - " + inner.Message);
            }
        }

        #endregion

        #region IApplication Members

        public Project Project
        {
            get { return Session.Project; }
            set { Session.Project = value; }
        }

        public PlotPoint SelectedPoint
        {
            get { return fMainForm.PlotView.SelectedPoint; }
        }

        public Encounter CurrentEncounter
        {
            get { return Session.CurrentEncounter; }
        }

        public string ProjectFile
        {
            get { return Session.FileName; }
            set { Session.FileName = value; }
        }

        public bool ProjectModified
        {
            get { return Session.Modified; }
            set { Session.Modified = value; }
        }

        public List<Library> Libraries
        {
            get { return Session.Libraries; }
        }

        public List<IAddIn> AddIns
        {
            get { return Session.AddIns; }
        }

        public void UpdateView()
        {
            fMainForm.UpdateView();
        }

        /// <summary>
        /// Lets add-ins save a library. The public signature is unchanged so existing add-ins still work.
        /// It now saves the .mpxlib format; before, it used BinaryFormatter, which fails on .NET 10, so
        /// add-in changes to libraries were never written.
        /// </summary>
        public void SaveLibrary(Library lib)
        {
            Session.SaveLibrary(lib);
        }

        #endregion

        static int compare_addins(IAddIn x, IAddIn y)
        {
            // Ordinal-ignore-case and null-safe: an add-in's Name could be null.
            return string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
        }
    }
}
