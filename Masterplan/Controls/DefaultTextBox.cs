using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Masterplan.Controls
{
	/// <summary>
	/// Text box which supports default text.
	/// </summary>
	public partial class DefaultTextBox : TextBox
	{
		/// <summary>
		/// Default constructor
		/// </summary>
		public DefaultTextBox()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Gets or sets the default text to be shown in the text box.
		/// </summary>
		[
		DefaultValue(""),
		Description("The default text to be shown in the text box."),
		Category("Appearance")
		]
		public string DefaultText
		{
			get { return fDefaultText; }
			set
			{
				if (Text == fDefaultText)
					Text = "";

				fDefaultText = value;

				if (Text == "")
					Text = fDefaultText;
			}
		}
		string fDefaultText = "";

		bool fUpdating = false;

		/// <summary>
		/// Sets the default text on the control.
		/// </summary>
		/// <param name="e">Event arguments.</param>
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);

			if ((!fUpdating) && (!Focused))
			{
				if (Text == "")
					Text = fDefaultText;
			}
		}

		/// <summary>
		/// Removes the default text from the control, if present, and selects the contents.
		/// </summary>
		/// <param name="e">Event arguments.</param>
		protected override void OnEnter(EventArgs e)
		{
			base.OnEnter(e);

			if (Text == fDefaultText)
			{
				fUpdating = true;
				Text = "";
				fUpdating = false;
			}

			SelectAll();
		}

		/// <summary>
		/// Updates the control with the default text.
		/// </summary>
		/// <param name="e">Event arguments.</param>
		protected override void OnLeave(EventArgs e)
		{
			base.OnLeave(e);

			if (Text == "")
			{
				fUpdating = true;
				Text = fDefaultText;
				fUpdating = false;
			}
		}

        /// <summary>
        /// Ensures that Ctrl-A selects all text.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if ((e.Modifiers & Keys.Control) == Keys.Control)
            {
                if (e.KeyCode == Keys.A)
                {
                    SelectAll();
                    return;
                }
            }

            base.OnKeyDown(e);
        }
	}
}
