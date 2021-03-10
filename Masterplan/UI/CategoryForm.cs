using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class CategoryForm : Form
	{
		public CategoryForm(List<string> categories, string selected_category)
		{
			InitializeComponent();

			foreach (string cat in categories)
				CategoryBox.Items.Add(cat);

			CategoryBox.Text = selected_category;
		}

		public string Category
		{
			get { return CategoryBox.Text; }
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
		}
	}
}
