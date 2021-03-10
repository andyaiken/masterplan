using System;
using System.Collections.Generic;
using System.Xml;

using Utils;

using Masterplan.Compendium;
using Masterplan.Data;

namespace Masterplan.Tools
{
	class CompendiumHelper
	{
		public enum ItemType
		{
			Creature,
			Trap,
			MagicItem
		}

		public class CompendiumItem
		{
			public CompendiumItem(ItemType type, string id, string name, string source_book, string info)
			{
				Type = type;
				ID = id;
				Name = name;
				SourceBook = source_book;
				Info = info;
			}

			public ItemType Type = ItemType.Creature;
			public string ID = "";
			public string Name = "";
			public string SourceBook = "";
			public string Info = "";

			public string URL
			{
				get
				{
					switch (Type)
					{
						case ItemType.Creature:
							return "http://www.wizards.com/dndinsider/compendium/monster.aspx?id=" + ID;
						case ItemType.Trap:
							return "http://www.wizards.com/dndinsider/compendium/trap.aspx?id=" + ID;
						case ItemType.MagicItem:
							return "http://www.wizards.com/dndinsider/compendium/item.aspx?id=" + ID;
					}

					return "";
				}
			}
		}

		public class SourceBook
		{
			public string Name = "";

			public List<CompendiumItem> Creatures = new List<CompendiumItem>();
			public List<CompendiumItem> Traps = new List<CompendiumItem>();
			public List<CompendiumItem> MagicItems = new List<CompendiumItem>();
		}

		public static List<CompendiumItem> GetCreatures()
		{
			List<CompendiumItem> items = new List<CompendiumItem>();

			try
			{
				CompendiumSearch cs = new CompendiumSearch();

				XmlNode node = cs.ViewAll("Monster");

				node = node.FirstChild;
				foreach (XmlNode child in node.ChildNodes)
				{
					string id = XMLHelper.NodeText(child, "ID");
					string name = XMLHelper.NodeText(child, "Name");
					string source_book = XMLHelper.NodeText(child, "SourceBook");

					string level = XMLHelper.NodeText(child, "Level");
					if (level != "")
						level = "Level " + level;
					string group_role = XMLHelper.NodeText(child, "GroupRole");
					string combat_role = XMLHelper.NodeText(child, "CombatRole");
					group_role = group_role.Replace("Standard", "");
					combat_role = combat_role.Replace("No role", "");
					string info = level + " " + group_role + " " + combat_role;

					info = info.Trim();
					info = info.Replace("  ", " ");

					items.Add(new CompendiumItem(ItemType.Creature, id, name, source_book, info));
				}
			}
			catch
			{
				items = null;
			}

			return items;
		}

		public static List<CompendiumItem> GetTraps()
		{
			List<CompendiumItem> items = new List<CompendiumItem>();

			try
			{
				CompendiumSearch cs = new CompendiumSearch();

				XmlNode node = cs.ViewAll("Trap");

				node = node.FirstChild;
				foreach (XmlNode child in node.ChildNodes)
				{
					string id = XMLHelper.NodeText(child, "ID");
					string name = XMLHelper.NodeText(child, "Name");
					string source_book = XMLHelper.NodeText(child, "SourceBook");

					string level = XMLHelper.NodeText(child, "Level");
					if (level != "")
						level = "Level " + level;
					string group_role = XMLHelper.NodeText(child, "GroupRole");
					string type = XMLHelper.NodeText(child, "Type");
					group_role = group_role.Replace("Standard", "");
					string info = level + " " + group_role + " " + type;

					info = info.Trim();
					info = info.Replace("  ", " ");

					items.Add(new CompendiumItem(ItemType.Trap, id, name, source_book, info));
				}
			}
			catch
			{
				items = null;
			}

			return items;
		}

		public static List<CompendiumItem> GetMagicItems()
		{
			List<CompendiumItem> items = new List<CompendiumItem>();

			try
			{
				CompendiumSearch cs = new CompendiumSearch();

				XmlNode node = cs.ViewAll("Item");

				List<string> slots = new List<string>();
				slots.Add("Head");
				slots.Add("Neck");
				slots.Add("Arms");
				slots.Add("Hands");
				slots.Add("Waist");
				slots.Add("Feet");

				node = node.FirstChild;
				foreach (XmlNode child in node.ChildNodes)
				{
					string id = XMLHelper.NodeText(child, "ID");
					string name = XMLHelper.NodeText(child, "Name");
					string source_book = XMLHelper.NodeText(child, "SourceBook");

					string mundane = (XMLHelper.NodeText(child, "IsMundane") == "True") ? "Mundane" : "";
					string level = XMLHelper.NodeText(child, "Level");
					if (level != "")
						level = "Level " + level;
					string category = XMLHelper.NodeText(child, "Category");
					if (slots.Contains(category))
						category += " slot item";
					if ((category == "Alchemical") || (category == "Wondrous") || (category == "Consumable"))
						category += " item";
					if (category == "Whetstones")
						category = "Whetstone";
					string info = mundane + " " + level + " " + category;

					info = info.Trim();
					info = info.Replace("  ", " ");

					items.Add(new CompendiumItem(ItemType.MagicItem, id, name, source_book, info));
				}
			}
			catch
			{
				items = null;
			}

			return items;
		}
	}
}
