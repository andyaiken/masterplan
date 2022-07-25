using System;
using System.Xml;

using Masterplan.Data;

namespace Masterplan.Tools
{
	class EncounterExporter
	{
		public static string ExportXML(Encounter enc)
		{
			XmlDocument doc = new XmlDocument();
			doc.AppendChild(doc.CreateElement(Session.I18N.Encounter));

			XMLHelper.CreateChild(doc, doc.DocumentElement, "Source").InnerText = "Masterplan Adventure Design Studio";

			XmlNode creatures_node = XMLHelper.CreateChild(doc, doc.DocumentElement, "Creatures");
			foreach (EncounterSlot slot in enc.Slots)
			{
				ICreature creature = Session.FindCreature(slot.Card.CreatureID, SearchType.Global);

				foreach (CombatData cd in slot.CombatData)
				{
					XmlNode creature_node = XMLHelper.CreateChild(doc, creatures_node, Session.I18N.Creature);

					string role = "";
					if (creature.Role is Minion)
						role += "Minion";
					foreach (RoleType type in slot.Card.Roles)
					{
						if (role != "")
							role += ", ";

						role += type;
					}
					if (slot.Card.Leader)
						role += " (L)";

					XMLHelper.CreateChild(doc, creature_node, "Name").InnerText = cd.DisplayName;
					XMLHelper.CreateChild(doc, creature_node, Session.I18N.Level).InnerText = slot.Card.Level.ToString();
					XMLHelper.CreateChild(doc, creature_node, "Role").InnerText = role;
					XMLHelper.CreateChild(doc, creature_node, Session.I18N.Size).InnerText = creature.Size.ToString();
					XMLHelper.CreateChild(doc, creature_node, "Type").InnerText = creature.Type.ToString();
					XMLHelper.CreateChild(doc, creature_node, "Origin").InnerText = creature.Origin.ToString();
					XMLHelper.CreateChild(doc, creature_node, "Keywords").InnerText = creature.Keywords;
					XMLHelper.CreateChild(doc, creature_node, Session.I18N.Size).InnerText = creature.Size.ToString();
					XMLHelper.CreateChild(doc, creature_node, "HP").InnerText = slot.Card.HP.ToString();
					XMLHelper.CreateChild(doc, creature_node, "InitBonus").InnerText = slot.Card.Initiative.ToString();
					XMLHelper.CreateChild(doc, creature_node, "Speed").InnerText = slot.Card.Movement;

					XmlNode defences_node = XMLHelper.CreateChild(doc, creature_node, "Defenses");

					XMLHelper.CreateChild(doc, defences_node, Session.I18N.AC).InnerText = slot.Card.AC.ToString();
					XMLHelper.CreateChild(doc, defences_node, "Fortitude").InnerText = slot.Card.Fortitude.ToString();
					XMLHelper.CreateChild(doc, defences_node, "Reflex").InnerText = slot.Card.Reflex.ToString();
					XMLHelper.CreateChild(doc, defences_node, Session.I18N.Will).InnerText = slot.Card.Will.ToString();

					if (slot.Card.Regeneration != null)
					{
						XmlNode regen_node = XMLHelper.CreateChild(doc, creature_node, Session.I18N.Regeneration);

						XMLHelper.CreateChild(doc, regen_node, "Value").InnerText = slot.Card.Regeneration.Value.ToString();
						XMLHelper.CreateChild(doc, regen_node, "Details").InnerText = slot.Card.Regeneration.Details;
					}

					XmlNode dmg_node = XMLHelper.CreateChild(doc, creature_node, "Damage");

					foreach (DamageModifier mod in slot.Card.DamageModifiers)
					{
						if (mod.Value < 0)
						{
							XmlNode mod_node = XMLHelper.CreateChild(doc, dmg_node, Session.I18N.Resist);

							XMLHelper.CreateChild(doc, mod_node, "Type").InnerText = mod.Type.ToString();
							XMLHelper.CreateChild(doc, mod_node, "Details").InnerText = Math.Abs(mod.Value).ToString();
						}
						else if (mod.Value > 0)
						{
							XmlNode mod_node = XMLHelper.CreateChild(doc, dmg_node, Session.I18N.Vulnerable);

							XMLHelper.CreateChild(doc, mod_node, "Type").InnerText = mod.Type.ToString();
							XMLHelper.CreateChild(doc, mod_node, "Details").InnerText = Math.Abs(mod.Value).ToString();
						}
						else
						{
							XmlNode mod_node = XMLHelper.CreateChild(doc, dmg_node, "Immune");

							XMLHelper.CreateChild(doc, mod_node, "Type").InnerText = mod.Type.ToString();
						}
					}

					if (slot.Card.Resist != "")
						XMLHelper.CreateChild(doc, dmg_node, Session.I18N.Resist).InnerText = slot.Card.Resist;
					if (slot.Card.Vulnerable != "")
						XMLHelper.CreateChild(doc, dmg_node, Session.I18N.Vulnerable).InnerText = slot.Card.Vulnerable;
					if (slot.Card.Immune != "")
						XMLHelper.CreateChild(doc, dmg_node, "Immune").InnerText = slot.Card.Immune;

					XmlNode abilities_node = XMLHelper.CreateChild(doc, creature_node, "AbilityModifiers");
					XMLHelper.CreateChild(doc, abilities_node, "Strength").InnerText = creature.Strength.Modifier.ToString();
					XMLHelper.CreateChild(doc, abilities_node, "Constitution").InnerText = creature.Constitution.Modifier.ToString();
					XMLHelper.CreateChild(doc, abilities_node, "Dexterity").InnerText = creature.Dexterity.Modifier.ToString();
					XMLHelper.CreateChild(doc, abilities_node, "Intelligence").InnerText = creature.Intelligence.Modifier.ToString();
					XMLHelper.CreateChild(doc, abilities_node, "Wisdom").InnerText = creature.Wisdom.Modifier.ToString();
					XMLHelper.CreateChild(doc, abilities_node, "Charisma").InnerText = creature.Charisma.Modifier.ToString();

					XMLHelper.CreateChild(doc, creature_node, "Senses").InnerText = slot.Card.Senses;
					XMLHelper.CreateChild(doc, creature_node, "Skills").InnerText = slot.Card.Skills;
					XMLHelper.CreateChild(doc, creature_node, "Equipment").InnerText = slot.Card.Equipment;
					XMLHelper.CreateChild(doc, creature_node, Session.I18N.Tactics).InnerText = slot.Card.Tactics;
				}
			}

			// PCs
			XmlNode heroes_node = XMLHelper.CreateChild(doc, doc.DocumentElement, "PCs");
			foreach (Hero hero in Session.Project.Heroes)
			{
				XmlNode hero_node = XMLHelper.CreateChild(doc, heroes_node, "PC");

				XMLHelper.CreateChild(doc, hero_node, "Name").InnerText = hero.Name;
				XMLHelper.CreateChild(doc, hero_node, "Description").InnerText = hero.Info;
				XMLHelper.CreateChild(doc, hero_node, Session.I18N.Size).InnerText = hero.Size.ToString();
				XMLHelper.CreateChild(doc, hero_node, "HP").InnerText = hero.HP.ToString();
				XMLHelper.CreateChild(doc, hero_node, "InitBonus").InnerText = hero.InitBonus.ToString();

				XmlNode defences_node = XMLHelper.CreateChild(doc, hero_node, "Defenses");

				XMLHelper.CreateChild(doc, defences_node, Session.I18N.AC).InnerText = hero.AC.ToString();
				XMLHelper.CreateChild(doc, defences_node, "Fortitude").InnerText = hero.Fortitude.ToString();
				XMLHelper.CreateChild(doc, defences_node, "Reflex").InnerText = hero.Reflex.ToString();
				XMLHelper.CreateChild(doc, defences_node, Session.I18N.Will).InnerText = hero.Will.ToString();
			}

			return doc.OuterXml;
		}
	}
}
