using System;
using System.Windows.Forms;

namespace Masterplan.UI
{
	/// <summary>
	/// Form used to display progress of an action.
	/// </summary>
	public partial class ProgressScreen : Form
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="title">The title of the screen (not shown).</param>
		/// <param name="actions">The number of actions required for 100% completion.</param>
		public ProgressScreen(string title, int actions)
		{
			InitializeComponent();

            Text = title;
			Actions = actions;

			ActionLbl.Text = "Loading...";
			SubActionLbl.Text = "";
		}

		/// <summary>
		/// Gets or sets the number of actions required for completion.
		/// </summary>
		public int Actions
		{
			get
			{
				return fActions;
			}
			set
			{
				fActions = value;

				if (fActions == 0)
				{
					Gauge.Maximum = 1;
					Progress = 1;
				}
				else
				{
					Gauge.Maximum = fActions;
				}
			}
		}
		int fActions = 0;

		/// <summary>
		/// Gets or sets the text for the current action.
		/// </summary>
		public string CurrentAction
		{
			get { return ActionLbl.Text; }
			set
			{
				ActionLbl.Text = value;
				SubActionLbl.Text = "";
				Refresh();
			}
		}

		/// <summary>
		/// Gets or sets the text for the current action.
		/// </summary>
		public string CurrentSubAction
		{
			get { return SubActionLbl.Text; }
			set
			{
				SubActionLbl.Text = value;
				Refresh();
			}
		}

		/// <summary>
		/// Gets or sets the current progress.
		/// </summary>
		public int Progress
		{
			get { return Gauge.Value; }
			set
			{
				Gauge.Value = Math.Min(value, Gauge.Maximum);
				Refresh();
			}
		}
	}
}
