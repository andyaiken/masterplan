using System;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class HeroForm : Form
	{
		public HeroForm(Hero h)
		{
			InitializeComponent();

			foreach (CreatureSize size in Enum.GetValues(typeof(CreatureSize)))
				SizeBox.Items.Add(size);

			foreach (HeroRoleType role in Enum.GetValues(typeof(HeroRoleType)))
				RoleBox.Items.Add(role);

			SourceBox.Items.Add("Arcane");
			SourceBox.Items.Add("Divine");
			SourceBox.Items.Add("Elemental");
			SourceBox.Items.Add("Martial");
			SourceBox.Items.Add("Primal");
			SourceBox.Items.Add("Psionic");
			SourceBox.Items.Add("Shadow");

			Application.Idle += new EventHandler(Application_Idle);

			fHero = h.Copy();

			update_hero();
		}

		~HeroForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			PortraitPasteBtn.Enabled = Clipboard.ContainsImage();
			PortraitClear.Enabled = (fHero.Portrait != null);

			EffectRemoveBtn.Enabled = ((SelectedEffect != null) || (SelectedToken != null));
			EffectEditBtn.Enabled = ((SelectedEffect != null) || (SelectedToken != null));
		}

		public Hero Hero
		{
			get { return fHero; }
		}
		Hero fHero = null;

		public OngoingCondition SelectedEffect
		{
			get
			{
				if (EffectList.SelectedItems.Count != 0)
					return EffectList.SelectedItems[0].Tag as OngoingCondition;

				return null;
			}
		}

		public CustomToken SelectedToken
		{
			get
			{
				if (EffectList.SelectedItems.Count != 0)
					return EffectList.SelectedItems[0].Tag as CustomToken;

				return null;
			}
		}

		private void HeroForm_Shown(object sender, EventArgs e)
		{
			NameBox.Focus();
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fHero.Name = NameBox.Text;
			fHero.Player = PlayerBox.Text;
			fHero.Level = (int)LevelBox.Value;

			fHero.Race = RaceBox.Text;
			fHero.Size = (CreatureSize)SizeBox.SelectedItem;

			fHero.Class = ClassBox.Text;
			fHero.ParagonPath = PPBox.Text;
			fHero.EpicDestiny = EDBox.Text;
			fHero.PowerSource = SourceBox.Text;
			fHero.Role = (HeroRoleType)RoleBox.SelectedItem;

			fHero.Languages = LanguageBox.Text;

			fHero.HP = (int)HPBox.Value;

			fHero.AC = (int)ACBox.Value;
			fHero.Fortitude = (int)FortBox.Value;
			fHero.Reflex = (int)RefBox.Value;
			fHero.Will = (int)WillBox.Value;

			fHero.InitBonus = (int)InitBox.Value;

			fHero.PassiveInsight = (int)InsightBox.Value;
			fHero.PassivePerception = (int)PerceptionBox.Value;
		}

		private void PortraitBrowse_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = Program.ImageFilter;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fHero.Portrait = Image.FromFile(dlg.FileName);
				Program.SetResolution(fHero.Portrait);
				image_changed();
			}
		}

		private void PortraitPaste_Click(object sender, EventArgs e)
		{
			if (Clipboard.ContainsImage())
			{
				fHero.Portrait = Clipboard.GetImage();
				Program.SetResolution(fHero.Portrait);
				image_changed();
			}
		}

		private void PortraitClear_Click(object sender, EventArgs e)
		{
			fHero.Portrait = null;
			image_changed();
		}

		private void EffectAddBtn_Click(object sender, EventArgs e)
		{
			OngoingCondition oc = new OngoingCondition();

			EffectForm dlg = new EffectForm(oc, fHero);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fHero.Effects.Add(dlg.Effect);
				update_effects();
			}
		}

		private void EffectAddToken_Click(object sender, EventArgs e)
		{
			CustomToken token = new CustomToken();
			token.Name = "New Token";
			token.Type = CustomTokenType.Token;

			CustomTokenForm dlg = new CustomTokenForm(token);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fHero.Tokens.Add(dlg.Token);
				update_effects();
			}
		}

		private void EffectAddOverlay_Click(object sender, EventArgs e)
		{
			CustomToken overlay = new CustomToken();
			overlay.Name = "New Overlay";
			overlay.Type = CustomTokenType.Overlay;

			CustomOverlayForm dlg = new CustomOverlayForm(overlay);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fHero.Tokens.Add(dlg.Token);
				update_effects();
			}
		}

		private void EffectRemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedEffect != null)
			{
				fHero.Effects.Remove(SelectedEffect);
				update_effects();
			}

			if (SelectedToken != null)
			{
				fHero.Tokens.Remove(SelectedToken);
				update_effects();
			}
		}

		private void EffectEditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedEffect != null)
			{
				int index = fHero.Effects.IndexOf(SelectedEffect);

				EffectForm dlg = new EffectForm(SelectedEffect, fHero);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fHero.Effects[index] = dlg.Effect;
					update_effects();
				}
			}

			if (SelectedToken != null)
			{
				int index = fHero.Tokens.IndexOf(SelectedToken);

				switch (SelectedToken.Type)
				{
					case CustomTokenType.Token:
						{
							CustomTokenForm dlg = new CustomTokenForm(SelectedToken);
							if (dlg.ShowDialog() == DialogResult.OK)
							{
								fHero.Tokens[index] = dlg.Token;
								update_effects();
							}
						}
						break;
					case CustomTokenType.Overlay:
						{
							CustomOverlayForm dlg = new CustomOverlayForm(SelectedToken);
							if (dlg.ShowDialog() == DialogResult.OK)
							{
								fHero.Tokens[index] = dlg.Token;
								update_effects();
							}
						}
						break;
				}
			}
		}

		void image_changed()
		{
			PortraitBox.Image = fHero.Portrait;
		}

		void update_hero()
		{
			NameBox.Text = fHero.Name;
			PlayerBox.Text = fHero.Player;
			LevelBox.Value = fHero.Level;

			RaceBox.Text = fHero.Race;
			SizeBox.SelectedItem = fHero.Size;

			ClassBox.Text = fHero.Class;
			PPBox.Text = fHero.ParagonPath;
			EDBox.Text = fHero.EpicDestiny;
			SourceBox.Text = fHero.PowerSource;
			RoleBox.SelectedItem = fHero.Role;

			LanguageBox.Text = fHero.Languages;

			if (fHero.Portrait != null)
				PortraitBox.Image = fHero.Portrait;

			HPBox.Value = fHero.HP;

			ACBox.Value = fHero.AC;
			FortBox.Value = fHero.Fortitude;
			RefBox.Value = fHero.Reflex;
			WillBox.Value = fHero.Will;

			InitBox.Value = fHero.InitBonus;

			InsightBox.Value = fHero.PassiveInsight;
			PerceptionBox.Value = fHero.PassivePerception;

			update_effects();
		}

		void update_effects()
		{
			EffectList.Items.Clear();

			foreach (OngoingCondition oc in fHero.Effects)
			{
				ListViewItem lvi = EffectList.Items.Add(oc.ToString(null, false));
				lvi.Tag = oc;
				lvi.Group = EffectList.Groups[0];
			}

			foreach (CustomToken ct in fHero.Tokens)
			{
				ListViewItem lvi = EffectList.Items.Add(ct.Name);
				lvi.Tag = ct;
				switch (ct.Type)
				{
					case CustomTokenType.Token:
						lvi.Group = EffectList.Groups[1];
						break;
					case CustomTokenType.Overlay:
						lvi.Group = EffectList.Groups[2];
						break;
				}
			}
		}
	}
}
