using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

using Utils;

using Masterplan.Data;
using Masterplan.UI;

namespace Masterplan.Extensibility
{
	class ExtensibilityManager : IApplication
	{
		public ExtensibilityManager(MainForm main_form)
		{
			fMainForm = main_form;

			// Find application directory
			string dir = Application.StartupPath + "\\AddIns";
			Load(dir);
		}

		MainForm fMainForm = null;

		#region Loading add-ins

		public void Load(string path)
		{
			if (File.Exists(path))
			{
				// Load add-ins from this DLL
				Assembly assembly = Assembly.LoadFile(path);
				if (assembly != null)
					load_file(assembly);
			}

			if (Directory.Exists(path))
			{
				DirectoryInfo dir = new DirectoryInfo(path);

				// Find all DLLs in this directory
				FileInfo[] files = dir.GetFiles("*.dll");
				foreach (FileInfo fi in files)
					Load(fi.FullName);

				// Recurse subdirectories
				DirectoryInfo[] subdirs = dir.GetDirectories();
				foreach (DirectoryInfo subdir in subdirs)
					Load(subdir.FullName);
			}

			Session.AddIns.Sort(compare_addins);
		}

		void load_file(Assembly assembly)
		{
			try
			{
				// Load add-ins from this DLL
				Type[] types = assembly.GetTypes();
				foreach (Type t in types)
				{
					if (!is_addin(t))
						continue;

					// Get the default constructor
					ConstructorInfo ci = t.GetConstructor(Type.EmptyTypes);
					if (ci != null)
					{
						IAddIn addin = ci.Invoke(null) as IAddIn;

						if (addin != null)
							install(addin);
					}
				}
			}
			catch (ReflectionTypeLoadException rtle)
			{
				string name = assembly.ManifestModule.Name;
				LogSystem.Trace("The add-in '" + name + "' could not be loaded; contact the developer for an updated version.");

				foreach (Exception ex in rtle.LoaderExceptions)
					Console.WriteLine(ex);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		bool is_addin(Type t)
		{
			foreach (Type i in t.GetInterfaces())
			{
				if (i == null)
					continue;

				if (i == typeof(IAddIn))
					return true;
			}

			return false;
		}

		void install(IAddIn addin)
		{
			bool ok = addin.Initialise(this);

			if (ok)
				Session.AddIns.Add(addin);
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

		public void SaveLibrary(Library lib)
		{
			string filename = Session.GetLibraryFilename(lib);
			bool ok = Serialisation<Library>.Save(filename, lib, SerialisationMode.Binary);
		}

		#endregion

		static int compare_addins(IAddIn x, IAddIn y)
		{
			return x.Name.CompareTo(y.Name);
		}
	}
}
