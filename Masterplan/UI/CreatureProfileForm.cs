using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class CreatureProfileForm : Form
	{
		public CreatureProfileForm(ICreature creature)
		{
			InitializeComponent();

			fCreature = creature;
			fRole = creature.Role;

			// Populate size
			foreach (CreatureSize size in Enum.GetValues(typeof(CreatureSize)))
				SizeBox.Items.Add(size);

			// Populate origin
			Array origins = Enum.GetValues(typeof(CreatureOrigin));
			foreach (CreatureOrigin origin in origins)
				OriginBox.Items.Add(origin);

			// Populate type
			Array types = Enum.GetValues(typeof(CreatureType));
			foreach (CreatureType type in types)
				TypeBox.Items.Add(type);

			if (fCreature is NPC)
			{
				List<Guid> template_ids = new List<Guid>();
				foreach (CreatureTemplate template in Session.Templates)
				{
					if (template.Type == CreatureTemplateType.Class)
						template_ids.Add(template.ID);
				}

				foreach (CreatureTemplate template in Session.Project.Library.Templates)
				{
					if (template.Type == CreatureTemplateType.Class)
					{
						if (template_ids.Contains(template.ID))
							continue;

						template_ids.Add(template.ID);
					}
				}

				foreach (Guid template_id in template_ids)
				{
					CreatureTemplate template = Session.FindTemplate(template_id, SearchType.Global);
					TemplateBox.Items.Add(template);
				}

				RoleLbl.Enabled = false;
				RoleBtn.Enabled = false;

				CatLbl.Enabled = false;
				CatBox.Enabled = false;
			}
			else if (fCreature is CustomCreature)
			{
				TemplateLbl.Enabled = false;
				TemplateBox.Enabled = false;

				CatLbl.Enabled = false;
				CatBox.Enabled = false;
			}
			else
			{
				TemplateLbl.Enabled = false;
				TemplateBox.Enabled = false;

				// Populate categories
				List<string> cats = new List<string>();
				foreach (Creature c in Session.Creatures)
				{
					string cat = c.Category;
					if ((cat != "") && (!cats.Contains(cat)))
						cats.Add(cat);
				}
				foreach (string cat in cats)
					CatBox.Items.Add(cat);
			}

			NameBox.Text = fCreature.Name;
			LevelBox.Value = fCreature.Level;
			SizeBox.SelectedItem = fCreature.Size;
			OriginBox.SelectedItem = fCreature.Origin;
			TypeBox.SelectedItem = fCreature.Type;
			KeywordBox.Text = fCreature.Keywords;

			if (fCreature is NPC)
			{
				NPC npc = fCreature as NPC;
				CreatureTemplate ct = Session.FindTemplate(npc.TemplateID, SearchType.Global);

				if (ct != null)
				{
					TemplateBox.SelectedItem = ct;
				}
				else
				{
					TemplateBox.SelectedIndex = 0;
				}

				CatBox.Text = "NPC";
			}
			else if (fCreature is CustomCreature)
			{
				CatBox.Text = "Custom Creature";
			}
			else
			{
				RoleBtn.Text = fCreature.Role.ToString();
				CatBox.Text = fCreature.Category;
			}
		}

		public ICreature Creature
		{
			get { return fCreature; }
		}
		ICreature fCreature = null;

		IRole fRole = null;

		private void RoleBtn_Click(object sender, EventArgs e)
		{
			RoleForm dlg = new RoleForm(fCreature.Role, ThreatType.Creature);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fRole = dlg.Role;
				RoleBtn.Text = fRole.ToString();
			}
		}

		private void TemplateBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			CreatureTemplate ct = TemplateBox.SelectedItem as CreatureTemplate;
			if (ct != null)
			{
				RoleBtn.Text = ct.Role.ToString();
			}
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fCreature.Name = NameBox.Text;
			fCreature.Level = (int)LevelBox.Value;
			fCreature.Size = (CreatureSize)SizeBox.SelectedItem;
			fCreature.Origin = (CreatureOrigin)OriginBox.SelectedItem;
			fCreature.Type = (CreatureType)TypeBox.SelectedItem;
			fCreature.Keywords = KeywordBox.Text;

			if (fCreature is NPC)
			{
				CreatureTemplate ct = TemplateBox.SelectedItem as CreatureTemplate;

				NPC npc = fCreature as NPC;
				npc.TemplateID = (ct != null) ? ct.ID : Guid.Empty;
			}
			else
			{
				fCreature.Role = fRole;
				fCreature.Category = CatBox.Text;

				if (fCreature.Role is Minion)
					fCreature.HP = 1;
			}
		}
	}
}
