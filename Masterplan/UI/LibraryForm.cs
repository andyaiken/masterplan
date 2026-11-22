#nullable disable

using Masterplan.Data;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

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
                // Do not allow a name whose library file already exists in the Libraries folder,
                // or saving would overwrite another library.
                //
                // NOTE: the old code looked in the wrong place. It passed Assembly.FullName (the assembly's
                // display name, e.g. "Masterplan, Version=14.0.0.0, ...") instead of a folder path, so
                // the check never found anything and duplicate names were always allowed.
                string name = Tools.FileName.TrimInvalidCharacters(NameBox.Text);

                // Keeping the library's current name is always allowed (its own file exists, of course).
                string current = Tools.FileName.TrimInvalidCharacters(fLibrary.Name ?? "");
                if (string.Equals(name, current, StringComparison.OrdinalIgnoreCase))
                {
                    OKBtn.Enabled = true;
                    return;
                }

                // Check the old .library name too: a new .mpxlib with the same name as an unconverted
                // .library would make that old file look "converted" and hide it from the startup warning.
                string filename = Session.LibraryFolder + name + Tools.LegacyFiles.LibraryExtension;
                string legacy_filename = Session.LibraryFolder + name + Tools.LegacyFiles.LegacyLibraryExtension;

                OKBtn.Enabled = !File.Exists(filename) && !File.Exists(legacy_filename);
            }
        }
    }
}
