using System;
using System.Collections.Generic;

namespace Masterplan.Data
{
	/// <summary>
	/// Functional or class template.
	/// </summary>
	public enum CreatureTemplateType
	{
		/// <summary>
		/// Functional template.
		/// </summary>
		Functional,

		/// <summary>
		/// Class template.
		/// </summary>
		Class
	}

	/// <summary>
	/// Class representing a functional or class template.
	/// </summary>
	[Serializable]
	public class CreatureTemplate
	{
		/// <summary>
		/// Gets or sets the name of the template.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the unique ID of the template.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the template type.
		/// </summary>
		public CreatureTemplateType Type
		{
			get { return fType; }
			set { fType = value; }
		}
		CreatureTemplateType fType = CreatureTemplateType.Functional;

		/// <summary>
		/// Gets or sets the role the template fulfills.
		/// </summary>
		public RoleType Role
		{
			get { return fRole; }
			set { fRole = value; }
		}
		RoleType fRole = RoleType.Artillery;

		/// <summary>
		/// Gets or sets whether the template is a Leader.
		/// </summary>
		public bool Leader
		{
			get { return fLeader; }
			set { fLeader = value; }
		}
		bool fLeader = false;

		/// <summary>
		/// Gets or sets special senses the template provides.
		/// </summary>
		public string Senses
		{
			get { return fSenses; }
			set { fSenses = value; }
		}
		string fSenses = "";

		/// <summary>
		/// Gets or sets special movement the template provides.
		/// </summary>
		public string Movement
		{
			get { return fMovement; }
			set { fMovement = value; }
		}
		string fMovement = "";

		/// <summary>
		/// Gets or sets the number of HP per level the template provides.
		/// </summary>
		public int HP
		{
			get { return fHP; }
			set { fHP = value; }
		}
		int fHP = 0;

		/// <summary>
		/// Gets or sets the initiative modifier the template provides.
		/// </summary>
		public int Initiative
		{
			get { return fInitiative; }
			set { fInitiative = value; }
		}
		int fInitiative = 0;

		/// <summary>
		/// Gets or sets the AC modifier the template provides.
		/// </summary>
		public int AC
		{
			get { return fAC; }
			set { fAC = value; }
		}
		int fAC = 0;

		/// <summary>
		/// Gets or sets the Fortitude modifier the template provides.
		/// </summary>
		public int Fortitude
		{
			get { return fFortitude; }
			set { fFortitude = value; }
		}
		int fFortitude = 0;

		/// <summary>
		/// Gets or sets the Reflex modifier the template provides.
		/// </summary>
		public int Reflex
		{
			get { return fReflex; }
			set { fReflex = value; }
		}
		int fReflex = 0;

		/// <summary>
		/// Gets or sets the Will modifier the template provides.
		/// </summary>
		public int Will
		{
			get { return fWill; }
			set { fWill = value; }
		}
		int fWill = 0;

		/// <summary>
		/// Gets or sets the regeneration provided by the template.
		/// </summary>
		public Regeneration Regeneration
		{
			get { return fRegeneration; }
			set { fRegeneration = value; }
		}
		Regeneration fRegeneration = null;

		/// <summary>
		/// Gets or sets the list of auras provided by the template.
		/// </summary>
		public List<Aura> Auras
		{
			get { return fAuras; }
			set { fAuras = value; }
		}
		List<Aura> fAuras = new List<Aura>();

		/// <summary>
		/// Gets or sets the list of powers provided by the template.
		/// </summary>
		public List<CreaturePower> CreaturePowers
		{
			get { return fCreaturePowers; }
			set { fCreaturePowers = value; }
		}
		List<CreaturePower> fCreaturePowers = new List<CreaturePower>();

		/// <summary>
		/// Gets or sets the list of resistances / vulnerabilities / immunities provided by the template.
		/// </summary>
		public List<DamageModifierTemplate> DamageModifierTemplates
		{
			get { return fDamageModifierTemplates; }
			set { fDamageModifierTemplates = value; }
		}
		List<DamageModifierTemplate> fDamageModifierTemplates = new List<DamageModifierTemplate>();

		/// <summary>
		/// Gets or sets the resistances provided by the template.
		/// </summary>
		public string Resist
		{
			get { return fResist; }
			set { fResist = value; }
		}
		string fResist = "";

		/// <summary>
		/// Gets or sets the vulnerabilities provided by the template.
		/// </summary>
		public string Vulnerable
		{
			get { return fVulnerable; }
			set { fVulnerable = value; }
		}
		string fVulnerable = "";

		/// <summary>
		/// Gets or sets the immunities provided by the template.
		/// </summary>
		public string Immune
		{
			get { return fImmune; }
			set { fImmune = value; }
		}
		string fImmune = "";

		/// <summary>
		/// Gets or sets the tactics.
		/// </summary>
		public string Tactics
		{
			get { return fTactics; }
			set { fTactics = value; }
		}
		string fTactics = "";

		/// <summary>
		/// [Elite] [role] [(L)]
		/// </summary>
		public string Info
		{
			get
			{
				string start = (fType == CreatureTemplateType.Functional) ? "Elite " : "";
				string leader = (fLeader) ? " (L)" : "";

				return start + fRole + leader;
			}
		}

		/// <summary>
		/// Creates a copy of the template.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public CreatureTemplate Copy()
		{
			CreatureTemplate t = new CreatureTemplate();

			t.Name = fName;
			t.ID = fID;
			t.Type = fType;
			t.Role = fRole;
			t.Leader = fLeader;
			t.Senses = fSenses;
			t.Movement = fMovement;

			t.HP = fHP;
			t.Initiative = fInitiative;
			t.AC = fAC;
			t.Fortitude = fFortitude;
			t.Reflex = fReflex;
			t.Will = fWill;

			t.Regeneration = (fRegeneration != null) ? fRegeneration.Copy() : null;

			foreach (Aura aura in fAuras)
				t.Auras.Add(aura.Copy());

			foreach (CreaturePower cp in fCreaturePowers)
				t.CreaturePowers.Add(cp.Copy());

			foreach (DamageModifierTemplate dmt in fDamageModifierTemplates)
				t.DamageModifierTemplates.Add(dmt.Copy());

			t.Resist = fResist;
			t.Vulnerable = fVulnerable;
			t.Immune = fImmune;
			t.Tactics = fTactics;

			return t;
		}

		/// <summary>
		/// Returns the name of the template.
		/// </summary>
		/// <returns>Returns the name of the template.</returns>
		public override string ToString()
		{
			return fName;
		}
	}
}
