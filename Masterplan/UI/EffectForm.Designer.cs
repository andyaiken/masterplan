namespace Masterplan.UI
{
	partial class EffectForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.CancelBtn = new System.Windows.Forms.Button();
			this.OKBtn = new System.Windows.Forms.Button();
			this.ConditionBtn = new System.Windows.Forms.RadioButton();
			this.DamageBtn = new System.Windows.Forms.RadioButton();
			this.ConditionBox = new System.Windows.Forms.ComboBox();
			this.DamageBox = new System.Windows.Forms.NumericUpDown();
			this.DamageTypeBox = new System.Windows.Forms.ComboBox();
			this.DurationBox = new System.Windows.Forms.ComboBox();
			this.DurationCreatureBox = new System.Windows.Forms.ComboBox();
			this.CreatureLbl = new System.Windows.Forms.Label();
			this.ModLbl = new System.Windows.Forms.Label();
			this.ModBox = new System.Windows.Forms.NumericUpDown();
			this.TypeLbl = new System.Windows.Forms.Label();
			this.DurationGroup = new System.Windows.Forms.GroupBox();
			this.DamageModTypeLbl = new System.Windows.Forms.Label();
			this.DamageModTypeBox = new System.Windows.Forms.ComboBox();
			this.RegenConditionsBox = new System.Windows.Forms.TextBox();
			this.RegenConditionsLbl = new System.Windows.Forms.Label();
			this.RegenValueLbl = new System.Windows.Forms.Label();
			this.RegenValueBox = new System.Windows.Forms.NumericUpDown();
			this.RegenBtn = new System.Windows.Forms.RadioButton();
			this.DamageModValueLbl = new System.Windows.Forms.Label();
			this.DamageModDirBox = new System.Windows.Forms.ComboBox();
			this.DamageModValueBox = new System.Windows.Forms.NumericUpDown();
			this.DamageModBtn = new System.Windows.Forms.RadioButton();
			this.NoDefencesLbl = new System.Windows.Forms.LinkLabel();
			this.AllDefencesLbl = new System.Windows.Forms.LinkLabel();
			this.WillBox = new System.Windows.Forms.CheckBox();
			this.RefBox = new System.Windows.Forms.CheckBox();
			this.FortBox = new System.Windows.Forms.CheckBox();
			this.ACBox = new System.Windows.Forms.CheckBox();
			this.DefenceModLbl = new System.Windows.Forms.Label();
			this.DefenceBtn = new System.Windows.Forms.RadioButton();
			this.DefenceModBox = new System.Windows.Forms.NumericUpDown();
			this.DamageLbl = new System.Windows.Forms.Label();
			this.ConditionPanel = new System.Windows.Forms.Panel();
			this.DamagePanel = new System.Windows.Forms.Panel();
			this.DefencePanel = new System.Windows.Forms.Panel();
			this.DamageModPanel = new System.Windows.Forms.Panel();
			this.RegenPanel = new System.Windows.Forms.Panel();
			this.PropertiesPanel = new System.Windows.Forms.Panel();
			this.AuraPanel = new System.Windows.Forms.Panel();
			this.AuraRadiusBox = new System.Windows.Forms.NumericUpDown();
			this.AuraRadiusLbl = new System.Windows.Forms.Label();
			this.AuraDetailsLbl = new System.Windows.Forms.Label();
			this.AuraDetailsBox = new System.Windows.Forms.TextBox();
			this.AuraBtn = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.DamageBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ModBox)).BeginInit();
			this.DurationGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.RegenValueBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DamageModValueBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DefenceModBox)).BeginInit();
			this.ConditionPanel.SuspendLayout();
			this.DamagePanel.SuspendLayout();
			this.DefencePanel.SuspendLayout();
			this.DamageModPanel.SuspendLayout();
			this.RegenPanel.SuspendLayout();
			this.PropertiesPanel.SuspendLayout();
			this.AuraPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.AuraRadiusBox)).BeginInit();
			this.SuspendLayout();
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(306, 624);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 3;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(225, 624);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 2;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// ConditionBtn
			// 
			this.ConditionBtn.AutoSize = true;
			this.ConditionBtn.Location = new System.Drawing.Point(3, 3);
			this.ConditionBtn.Name = "ConditionBtn";
			this.ConditionBtn.Size = new System.Drawing.Size(106, 17);
			this.ConditionBtn.TabIndex = 0;
			this.ConditionBtn.TabStop = true;
			this.ConditionBtn.Text = "Apply a condition";
			this.ConditionBtn.UseVisualStyleBackColor = true;
			this.ConditionBtn.CheckedChanged += new System.EventHandler(this.EffectTypeChanged);
			// 
			// DamageBtn
			// 
			this.DamageBtn.AutoSize = true;
			this.DamageBtn.Location = new System.Drawing.Point(3, 3);
			this.DamageBtn.Name = "DamageBtn";
			this.DamageBtn.Size = new System.Drawing.Size(133, 17);
			this.DamageBtn.TabIndex = 2;
			this.DamageBtn.TabStop = true;
			this.DamageBtn.Text = "Apply ongoing damage";
			this.DamageBtn.UseVisualStyleBackColor = true;
			this.DamageBtn.CheckedChanged += new System.EventHandler(this.EffectTypeChanged);
			// 
			// ConditionBox
			// 
			this.ConditionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ConditionBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.ConditionBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.ConditionBox.FormattingEnabled = true;
			this.ConditionBox.Location = new System.Drawing.Point(12, 26);
			this.ConditionBox.Name = "ConditionBox";
			this.ConditionBox.Size = new System.Drawing.Size(345, 21);
			this.ConditionBox.TabIndex = 1;
			// 
			// DamageBox
			// 
			this.DamageBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.DamageBox.Location = new System.Drawing.Point(68, 26);
			this.DamageBox.Name = "DamageBox";
			this.DamageBox.Size = new System.Drawing.Size(289, 20);
			this.DamageBox.TabIndex = 4;
			// 
			// DamageTypeBox
			// 
			this.DamageTypeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.DamageTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.DamageTypeBox.FormattingEnabled = true;
			this.DamageTypeBox.Location = new System.Drawing.Point(68, 52);
			this.DamageTypeBox.Name = "DamageTypeBox";
			this.DamageTypeBox.Size = new System.Drawing.Size(289, 21);
			this.DamageTypeBox.TabIndex = 6;
			// 
			// DurationBox
			// 
			this.DurationBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.DurationBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.DurationBox.FormattingEnabled = true;
			this.DurationBox.Location = new System.Drawing.Point(6, 19);
			this.DurationBox.Name = "DurationBox";
			this.DurationBox.Size = new System.Drawing.Size(351, 21);
			this.DurationBox.TabIndex = 0;
			this.DurationBox.SelectedIndexChanged += new System.EventHandler(this.DurationBox_SelectedIndexChanged);
			// 
			// DurationCreatureBox
			// 
			this.DurationCreatureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.DurationCreatureBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.DurationCreatureBox.FormattingEnabled = true;
			this.DurationCreatureBox.Location = new System.Drawing.Point(84, 46);
			this.DurationCreatureBox.Name = "DurationCreatureBox";
			this.DurationCreatureBox.Size = new System.Drawing.Size(273, 21);
			this.DurationCreatureBox.TabIndex = 2;
			// 
			// CreatureLbl
			// 
			this.CreatureLbl.AutoSize = true;
			this.CreatureLbl.Location = new System.Drawing.Point(6, 49);
			this.CreatureLbl.Name = "CreatureLbl";
			this.CreatureLbl.Size = new System.Drawing.Size(33, 13);
			this.CreatureLbl.TabIndex = 1;
			this.CreatureLbl.Text = "Who:";
			// 
			// ModLbl
			// 
			this.ModLbl.AutoSize = true;
			this.ModLbl.Location = new System.Drawing.Point(6, 75);
			this.ModLbl.Name = "ModLbl";
			this.ModLbl.Size = new System.Drawing.Size(59, 13);
			this.ModLbl.TabIndex = 3;
			this.ModLbl.Text = "Save Mod:";
			// 
			// ModBox
			// 
			this.ModBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ModBox.Location = new System.Drawing.Point(84, 73);
			this.ModBox.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.ModBox.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
			this.ModBox.Name = "ModBox";
			this.ModBox.Size = new System.Drawing.Size(273, 20);
			this.ModBox.TabIndex = 4;
			// 
			// TypeLbl
			// 
			this.TypeLbl.AutoSize = true;
			this.TypeLbl.Location = new System.Drawing.Point(9, 55);
			this.TypeLbl.Name = "TypeLbl";
			this.TypeLbl.Size = new System.Drawing.Size(34, 13);
			this.TypeLbl.TabIndex = 5;
			this.TypeLbl.Text = "Type:";
			// 
			// DurationGroup
			// 
			this.DurationGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.DurationGroup.Controls.Add(this.DurationBox);
			this.DurationGroup.Controls.Add(this.DurationCreatureBox);
			this.DurationGroup.Controls.Add(this.ModBox);
			this.DurationGroup.Controls.Add(this.CreatureLbl);
			this.DurationGroup.Controls.Add(this.ModLbl);
			this.DurationGroup.Location = new System.Drawing.Point(12, 517);
			this.DurationGroup.Name = "DurationGroup";
			this.DurationGroup.Size = new System.Drawing.Size(369, 101);
			this.DurationGroup.TabIndex = 1;
			this.DurationGroup.TabStop = false;
			this.DurationGroup.Text = "Duration";
			// 
			// DamageModTypeLbl
			// 
			this.DamageModTypeLbl.AutoSize = true;
			this.DamageModTypeLbl.Location = new System.Drawing.Point(9, 82);
			this.DamageModTypeLbl.Name = "DamageModTypeLbl";
			this.DamageModTypeLbl.Size = new System.Drawing.Size(34, 13);
			this.DamageModTypeLbl.TabIndex = 20;
			this.DamageModTypeLbl.Text = "Type:";
			// 
			// DamageModTypeBox
			// 
			this.DamageModTypeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.DamageModTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.DamageModTypeBox.FormattingEnabled = true;
			this.DamageModTypeBox.Location = new System.Drawing.Point(68, 79);
			this.DamageModTypeBox.Name = "DamageModTypeBox";
			this.DamageModTypeBox.Size = new System.Drawing.Size(289, 21);
			this.DamageModTypeBox.TabIndex = 21;
			// 
			// RegenConditionsBox
			// 
			this.RegenConditionsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.RegenConditionsBox.Location = new System.Drawing.Point(74, 52);
			this.RegenConditionsBox.Name = "RegenConditionsBox";
			this.RegenConditionsBox.Size = new System.Drawing.Size(283, 20);
			this.RegenConditionsBox.TabIndex = 26;
			// 
			// RegenConditionsLbl
			// 
			this.RegenConditionsLbl.AutoSize = true;
			this.RegenConditionsLbl.Location = new System.Drawing.Point(9, 55);
			this.RegenConditionsLbl.Name = "RegenConditionsLbl";
			this.RegenConditionsLbl.Size = new System.Drawing.Size(59, 13);
			this.RegenConditionsLbl.TabIndex = 25;
			this.RegenConditionsLbl.Text = "Conditions:";
			// 
			// RegenValueLbl
			// 
			this.RegenValueLbl.AutoSize = true;
			this.RegenValueLbl.Location = new System.Drawing.Point(9, 28);
			this.RegenValueLbl.Name = "RegenValueLbl";
			this.RegenValueLbl.Size = new System.Drawing.Size(25, 13);
			this.RegenValueLbl.TabIndex = 23;
			this.RegenValueLbl.Text = "HP:";
			// 
			// RegenValueBox
			// 
			this.RegenValueBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.RegenValueBox.Location = new System.Drawing.Point(74, 26);
			this.RegenValueBox.Name = "RegenValueBox";
			this.RegenValueBox.Size = new System.Drawing.Size(283, 20);
			this.RegenValueBox.TabIndex = 24;
			// 
			// RegenBtn
			// 
			this.RegenBtn.AutoSize = true;
			this.RegenBtn.Location = new System.Drawing.Point(3, 3);
			this.RegenBtn.Name = "RegenBtn";
			this.RegenBtn.Size = new System.Drawing.Size(113, 17);
			this.RegenBtn.TabIndex = 22;
			this.RegenBtn.TabStop = true;
			this.RegenBtn.Text = "Apply regeneration";
			this.RegenBtn.UseVisualStyleBackColor = true;
			this.RegenBtn.CheckedChanged += new System.EventHandler(this.EffectTypeChanged);
			// 
			// DamageModValueLbl
			// 
			this.DamageModValueLbl.AutoSize = true;
			this.DamageModValueLbl.Location = new System.Drawing.Point(9, 55);
			this.DamageModValueLbl.Name = "DamageModValueLbl";
			this.DamageModValueLbl.Size = new System.Drawing.Size(37, 13);
			this.DamageModValueLbl.TabIndex = 18;
			this.DamageModValueLbl.Text = "Value:";
			// 
			// DamageModDirBox
			// 
			this.DamageModDirBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.DamageModDirBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.DamageModDirBox.FormattingEnabled = true;
			this.DamageModDirBox.Location = new System.Drawing.Point(12, 26);
			this.DamageModDirBox.Name = "DamageModDirBox";
			this.DamageModDirBox.Size = new System.Drawing.Size(345, 21);
			this.DamageModDirBox.TabIndex = 17;
			// 
			// DamageModValueBox
			// 
			this.DamageModValueBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.DamageModValueBox.Location = new System.Drawing.Point(68, 53);
			this.DamageModValueBox.Name = "DamageModValueBox";
			this.DamageModValueBox.Size = new System.Drawing.Size(289, 20);
			this.DamageModValueBox.TabIndex = 19;
			// 
			// DamageModBtn
			// 
			this.DamageModBtn.AutoSize = true;
			this.DamageModBtn.Location = new System.Drawing.Point(3, 3);
			this.DamageModBtn.Name = "DamageModBtn";
			this.DamageModBtn.Size = new System.Drawing.Size(260, 17);
			this.DamageModBtn.TabIndex = 16;
			this.DamageModBtn.TabStop = true;
			this.DamageModBtn.Text = "Apply damage resistance / vulnerability / immunity";
			this.DamageModBtn.UseVisualStyleBackColor = true;
			this.DamageModBtn.CheckedChanged += new System.EventHandler(this.EffectTypeChanged);
			// 
			// NoDefencesLbl
			// 
			this.NoDefencesLbl.AutoSize = true;
			this.NoDefencesLbl.Location = new System.Drawing.Point(321, 53);
			this.NoDefencesLbl.Name = "NoDefencesLbl";
			this.NoDefencesLbl.Size = new System.Drawing.Size(33, 13);
			this.NoDefencesLbl.TabIndex = 15;
			this.NoDefencesLbl.TabStop = true;
			this.NoDefencesLbl.Text = "None";
			this.NoDefencesLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.NoDefencesLbl_LinkClicked);
			// 
			// AllDefencesLbl
			// 
			this.AllDefencesLbl.AutoSize = true;
			this.AllDefencesLbl.Location = new System.Drawing.Point(297, 53);
			this.AllDefencesLbl.Name = "AllDefencesLbl";
			this.AllDefencesLbl.Size = new System.Drawing.Size(18, 13);
			this.AllDefencesLbl.TabIndex = 14;
			this.AllDefencesLbl.TabStop = true;
			this.AllDefencesLbl.Text = "All";
			this.AllDefencesLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AllDefencesLbl_LinkClicked);
			// 
			// WillBox
			// 
			this.WillBox.AutoSize = true;
			this.WillBox.Location = new System.Drawing.Point(248, 52);
			this.WillBox.Name = "WillBox";
			this.WillBox.Size = new System.Drawing.Size(43, 17);
			this.WillBox.TabIndex = 13;
			this.WillBox.Text = "Will";
			this.WillBox.UseVisualStyleBackColor = true;
			// 
			// RefBox
			// 
			this.RefBox.AutoSize = true;
			this.RefBox.Location = new System.Drawing.Point(186, 52);
			this.RefBox.Name = "RefBox";
			this.RefBox.Size = new System.Drawing.Size(56, 17);
			this.RefBox.TabIndex = 12;
			this.RefBox.Text = "Reflex";
			this.RefBox.UseVisualStyleBackColor = true;
			// 
			// FortBox
			// 
			this.FortBox.AutoSize = true;
			this.FortBox.Location = new System.Drawing.Point(113, 52);
			this.FortBox.Name = "FortBox";
			this.FortBox.Size = new System.Drawing.Size(67, 17);
			this.FortBox.TabIndex = 11;
			this.FortBox.Text = "Fortitude";
			this.FortBox.UseVisualStyleBackColor = true;
			// 
			// ACBox
			// 
			this.ACBox.AutoSize = true;
			this.ACBox.Location = new System.Drawing.Point(68, 52);
			this.ACBox.Name = "ACBox";
			this.ACBox.Size = new System.Drawing.Size(40, 17);
			this.ACBox.TabIndex = 10;
			this.ACBox.Text = "AC";
			this.ACBox.UseVisualStyleBackColor = true;
			// 
			// DefenceModLbl
			// 
			this.DefenceModLbl.AutoSize = true;
			this.DefenceModLbl.Location = new System.Drawing.Point(9, 28);
			this.DefenceModLbl.Name = "DefenceModLbl";
			this.DefenceModLbl.Size = new System.Drawing.Size(46, 13);
			this.DefenceModLbl.TabIndex = 8;
			this.DefenceModLbl.Text = "Amount:";
			// 
			// DefenceBtn
			// 
			this.DefenceBtn.AutoSize = true;
			this.DefenceBtn.Location = new System.Drawing.Point(3, 3);
			this.DefenceBtn.Name = "DefenceBtn";
			this.DefenceBtn.Size = new System.Drawing.Size(158, 17);
			this.DefenceBtn.TabIndex = 7;
			this.DefenceBtn.TabStop = true;
			this.DefenceBtn.Text = "Apply a modifier to defences";
			this.DefenceBtn.UseVisualStyleBackColor = true;
			this.DefenceBtn.CheckedChanged += new System.EventHandler(this.EffectTypeChanged);
			// 
			// DefenceModBox
			// 
			this.DefenceModBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.DefenceModBox.Location = new System.Drawing.Point(68, 26);
			this.DefenceModBox.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.DefenceModBox.Name = "DefenceModBox";
			this.DefenceModBox.Size = new System.Drawing.Size(289, 20);
			this.DefenceModBox.TabIndex = 9;
			// 
			// DamageLbl
			// 
			this.DamageLbl.AutoSize = true;
			this.DamageLbl.Location = new System.Drawing.Point(9, 28);
			this.DamageLbl.Name = "DamageLbl";
			this.DamageLbl.Size = new System.Drawing.Size(46, 13);
			this.DamageLbl.TabIndex = 3;
			this.DamageLbl.Text = "Amount:";
			// 
			// ConditionPanel
			// 
			this.ConditionPanel.Controls.Add(this.ConditionBox);
			this.ConditionPanel.Controls.Add(this.ConditionBtn);
			this.ConditionPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.ConditionPanel.Location = new System.Drawing.Point(0, 0);
			this.ConditionPanel.Name = "ConditionPanel";
			this.ConditionPanel.Size = new System.Drawing.Size(369, 55);
			this.ConditionPanel.TabIndex = 27;
			// 
			// DamagePanel
			// 
			this.DamagePanel.Controls.Add(this.DamageBox);
			this.DamagePanel.Controls.Add(this.DamageLbl);
			this.DamagePanel.Controls.Add(this.TypeLbl);
			this.DamagePanel.Controls.Add(this.DamageTypeBox);
			this.DamagePanel.Controls.Add(this.DamageBtn);
			this.DamagePanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.DamagePanel.Location = new System.Drawing.Point(0, 55);
			this.DamagePanel.Name = "DamagePanel";
			this.DamagePanel.Size = new System.Drawing.Size(369, 82);
			this.DamagePanel.TabIndex = 28;
			// 
			// DefencePanel
			// 
			this.DefencePanel.Controls.Add(this.DefenceModBox);
			this.DefencePanel.Controls.Add(this.FortBox);
			this.DefencePanel.Controls.Add(this.ACBox);
			this.DefencePanel.Controls.Add(this.RefBox);
			this.DefencePanel.Controls.Add(this.DefenceModLbl);
			this.DefencePanel.Controls.Add(this.WillBox);
			this.DefencePanel.Controls.Add(this.AllDefencesLbl);
			this.DefencePanel.Controls.Add(this.NoDefencesLbl);
			this.DefencePanel.Controls.Add(this.DefenceBtn);
			this.DefencePanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.DefencePanel.Location = new System.Drawing.Point(0, 137);
			this.DefencePanel.Name = "DefencePanel";
			this.DefencePanel.Size = new System.Drawing.Size(369, 78);
			this.DefencePanel.TabIndex = 29;
			// 
			// DamageModPanel
			// 
			this.DamageModPanel.Controls.Add(this.DamageModDirBox);
			this.DamageModPanel.Controls.Add(this.DamageModValueBox);
			this.DamageModPanel.Controls.Add(this.DamageModValueLbl);
			this.DamageModPanel.Controls.Add(this.DamageModTypeBox);
			this.DamageModPanel.Controls.Add(this.DamageModTypeLbl);
			this.DamageModPanel.Controls.Add(this.DamageModBtn);
			this.DamageModPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.DamageModPanel.Location = new System.Drawing.Point(0, 215);
			this.DamageModPanel.Name = "DamageModPanel";
			this.DamageModPanel.Size = new System.Drawing.Size(369, 111);
			this.DamageModPanel.TabIndex = 30;
			// 
			// RegenPanel
			// 
			this.RegenPanel.Controls.Add(this.RegenValueBox);
			this.RegenPanel.Controls.Add(this.RegenValueLbl);
			this.RegenPanel.Controls.Add(this.RegenConditionsLbl);
			this.RegenPanel.Controls.Add(this.RegenConditionsBox);
			this.RegenPanel.Controls.Add(this.RegenBtn);
			this.RegenPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.RegenPanel.Location = new System.Drawing.Point(0, 326);
			this.RegenPanel.Name = "RegenPanel";
			this.RegenPanel.Size = new System.Drawing.Size(369, 82);
			this.RegenPanel.TabIndex = 31;
			// 
			// PropertiesPanel
			// 
			this.PropertiesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.PropertiesPanel.Controls.Add(this.AuraPanel);
			this.PropertiesPanel.Controls.Add(this.RegenPanel);
			this.PropertiesPanel.Controls.Add(this.DamageModPanel);
			this.PropertiesPanel.Controls.Add(this.DefencePanel);
			this.PropertiesPanel.Controls.Add(this.DamagePanel);
			this.PropertiesPanel.Controls.Add(this.ConditionPanel);
			this.PropertiesPanel.Location = new System.Drawing.Point(12, 12);
			this.PropertiesPanel.Name = "PropertiesPanel";
			this.PropertiesPanel.Size = new System.Drawing.Size(369, 499);
			this.PropertiesPanel.TabIndex = 32;
			// 
			// AuraPanel
			// 
			this.AuraPanel.Controls.Add(this.AuraRadiusBox);
			this.AuraPanel.Controls.Add(this.AuraRadiusLbl);
			this.AuraPanel.Controls.Add(this.AuraDetailsLbl);
			this.AuraPanel.Controls.Add(this.AuraDetailsBox);
			this.AuraPanel.Controls.Add(this.AuraBtn);
			this.AuraPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.AuraPanel.Location = new System.Drawing.Point(0, 408);
			this.AuraPanel.Name = "AuraPanel";
			this.AuraPanel.Size = new System.Drawing.Size(369, 82);
			this.AuraPanel.TabIndex = 32;
			// 
			// AuraRadiusBox
			// 
			this.AuraRadiusBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.AuraRadiusBox.Location = new System.Drawing.Point(74, 26);
			this.AuraRadiusBox.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.AuraRadiusBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.AuraRadiusBox.Name = "AuraRadiusBox";
			this.AuraRadiusBox.Size = new System.Drawing.Size(283, 20);
			this.AuraRadiusBox.TabIndex = 24;
			this.AuraRadiusBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// AuraRadiusLbl
			// 
			this.AuraRadiusLbl.AutoSize = true;
			this.AuraRadiusLbl.Location = new System.Drawing.Point(9, 28);
			this.AuraRadiusLbl.Name = "AuraRadiusLbl";
			this.AuraRadiusLbl.Size = new System.Drawing.Size(43, 13);
			this.AuraRadiusLbl.TabIndex = 23;
			this.AuraRadiusLbl.Text = "Radius:";
			// 
			// AuraDetailsLbl
			// 
			this.AuraDetailsLbl.AutoSize = true;
			this.AuraDetailsLbl.Location = new System.Drawing.Point(9, 55);
			this.AuraDetailsLbl.Name = "AuraDetailsLbl";
			this.AuraDetailsLbl.Size = new System.Drawing.Size(42, 13);
			this.AuraDetailsLbl.TabIndex = 25;
			this.AuraDetailsLbl.Text = "Details:";
			// 
			// AuraDetailsBox
			// 
			this.AuraDetailsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.AuraDetailsBox.Location = new System.Drawing.Point(74, 52);
			this.AuraDetailsBox.Name = "AuraDetailsBox";
			this.AuraDetailsBox.Size = new System.Drawing.Size(283, 20);
			this.AuraDetailsBox.TabIndex = 26;
			// 
			// AuraBtn
			// 
			this.AuraBtn.AutoSize = true;
			this.AuraBtn.Location = new System.Drawing.Point(3, 3);
			this.AuraBtn.Name = "AuraBtn";
			this.AuraBtn.Size = new System.Drawing.Size(75, 17);
			this.AuraBtn.TabIndex = 22;
			this.AuraBtn.TabStop = true;
			this.AuraBtn.Text = "Apply aura";
			this.AuraBtn.UseVisualStyleBackColor = true;
			this.AuraBtn.CheckedChanged += new System.EventHandler(this.EffectTypeChanged);
			// 
			// EffectForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(393, 659);
			this.Controls.Add(this.PropertiesPanel);
			this.Controls.Add(this.DurationGroup);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EffectForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Effect";
			this.Shown += new System.EventHandler(this.EffectForm_Shown);
			((System.ComponentModel.ISupportInitialize)(this.DamageBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ModBox)).EndInit();
			this.DurationGroup.ResumeLayout(false);
			this.DurationGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.RegenValueBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DamageModValueBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DefenceModBox)).EndInit();
			this.ConditionPanel.ResumeLayout(false);
			this.ConditionPanel.PerformLayout();
			this.DamagePanel.ResumeLayout(false);
			this.DamagePanel.PerformLayout();
			this.DefencePanel.ResumeLayout(false);
			this.DefencePanel.PerformLayout();
			this.DamageModPanel.ResumeLayout(false);
			this.DamageModPanel.PerformLayout();
			this.RegenPanel.ResumeLayout(false);
			this.RegenPanel.PerformLayout();
			this.PropertiesPanel.ResumeLayout(false);
			this.AuraPanel.ResumeLayout(false);
			this.AuraPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.AuraRadiusBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.RadioButton ConditionBtn;
		private System.Windows.Forms.RadioButton DamageBtn;
		private System.Windows.Forms.ComboBox ConditionBox;
		private System.Windows.Forms.NumericUpDown DamageBox;
		private System.Windows.Forms.ComboBox DamageTypeBox;
		private System.Windows.Forms.ComboBox DurationBox;
		private System.Windows.Forms.ComboBox DurationCreatureBox;
		private System.Windows.Forms.Label CreatureLbl;
		private System.Windows.Forms.Label ModLbl;
		private System.Windows.Forms.NumericUpDown ModBox;
		private System.Windows.Forms.Label TypeLbl;
		private System.Windows.Forms.GroupBox DurationGroup;
		private System.Windows.Forms.Label DamageLbl;
		private System.Windows.Forms.Label DefenceModLbl;
		private System.Windows.Forms.RadioButton DefenceBtn;
		private System.Windows.Forms.NumericUpDown DefenceModBox;
		private System.Windows.Forms.CheckBox WillBox;
		private System.Windows.Forms.CheckBox RefBox;
		private System.Windows.Forms.CheckBox FortBox;
		private System.Windows.Forms.CheckBox ACBox;
		private System.Windows.Forms.LinkLabel NoDefencesLbl;
		private System.Windows.Forms.LinkLabel AllDefencesLbl;
		private System.Windows.Forms.TextBox RegenConditionsBox;
		private System.Windows.Forms.Label RegenConditionsLbl;
		private System.Windows.Forms.Label RegenValueLbl;
		private System.Windows.Forms.NumericUpDown RegenValueBox;
		private System.Windows.Forms.RadioButton RegenBtn;
		private System.Windows.Forms.Label DamageModValueLbl;
		private System.Windows.Forms.ComboBox DamageModDirBox;
		private System.Windows.Forms.NumericUpDown DamageModValueBox;
		private System.Windows.Forms.RadioButton DamageModBtn;
		private System.Windows.Forms.Label DamageModTypeLbl;
		private System.Windows.Forms.ComboBox DamageModTypeBox;
		private System.Windows.Forms.Panel ConditionPanel;
		private System.Windows.Forms.Panel DamagePanel;
		private System.Windows.Forms.Panel DefencePanel;
		private System.Windows.Forms.Panel DamageModPanel;
		private System.Windows.Forms.Panel RegenPanel;
		private System.Windows.Forms.Panel PropertiesPanel;
		private System.Windows.Forms.Panel AuraPanel;
		private System.Windows.Forms.NumericUpDown AuraRadiusBox;
		private System.Windows.Forms.Label AuraRadiusLbl;
		private System.Windows.Forms.Label AuraDetailsLbl;
		private System.Windows.Forms.TextBox AuraDetailsBox;
		private System.Windows.Forms.RadioButton AuraBtn;
	}
}