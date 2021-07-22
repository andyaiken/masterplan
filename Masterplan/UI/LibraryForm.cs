using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class LibraryForm : Form
	{
		public LibraryForm(Library lib)
		{
			InitializeComponent();

			fLibrary = lib;

			string user = SystemInformation.UserName;
			string machine = SystemInformation.ComputerName;
			InfoLbl.Text = "Note that when you create a library it will be usable only by this user (" + user + ") on this computer (" + machine + ").";

			NameBox.Text = fLibrary.Name;
			NameBox_TextChanged(null, null);
		}

		public Library Library
		{
			get { return fLibrary; }
		}
		Library fLibrary = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fLibrary.Name = NameBox.Text;
		}

		private void NameBox_TextChanged(object sender, EventArgs e)
		{
			if (NameBox.Text == "")
			{
				OKBtn.Enabled = false;
			}
			else
			{
				Assembly ass = Assembly.GetEntryAssembly();
				string dir = Tools.FileName.Directory(ass.FullName);
				DirectoryInfo di = new DirectoryInfo(dir);

				string filename = di + NameBox.Text + ".library";

				OKBtn.Enabled = !File.Exists(filename);
			}
		}
	}
}
