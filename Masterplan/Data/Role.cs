using System;

namespace Masterplan.Data
{
	/// <summary>
	/// Creature or trap.
	/// </summary>
	public enum ThreatType
	{
		/// <summary>
		/// Creature.
		/// </summary>
		Creature,

		/// <summary>
		/// Trap.
		/// </summary>
		Trap
	}

	/// <summary>
	/// Creature / trap roles.
	/// </summary>
	public enum RoleType
	{
		/// <summary>
		/// Artillery role.
		/// </summary>
		Artillery,

		/// <summary>
		/// Blaster role.
		/// </summary>
		Blaster,

		/// <summary>
		/// Brute role.
		/// </summary>
		Brute,

		/// <summary>
		/// Controller role.
		/// </summary>
		Controller,

		/// <summary>
		/// Lurker role.
		/// </summary>
		Lurker,

		/// <summary>
		/// Obstacle role.
		/// </summary>
		Obstacle,

		/// <summary>
		/// Skirmisher role.
		/// </summary>
		Skirmisher,

		/// <summary>
		/// Soldier role.
		/// </summary>
		Soldier,

		/// <summary>
		/// Warder role.
		/// </summary>
		Warder
	}

	/// <summary>
	/// Standard / elite / solo.
	/// </summary>
	public enum RoleFlag
	{
		/// <summary>
		/// Standard.
		/// </summary>
		Standard,

		/// <summary>
		/// Elite.
		/// </summary>
		Elite,

		/// <summary>
		/// Solo.
		/// </summary>
		Solo
	}

	/// <summary>
	/// Interface for a role.
	/// Classes Minion and ComplexRole implement this interface.
	/// </summary>
	public interface IRole
	{
		/// <summary>
		/// Creates a copy of the role.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		IRole Copy();
	}

	/// <summary>
	/// Minion role.
	/// </summary>
	[Serializable]
	public class Minion : IRole
	{
		/// <summary>
		/// Gets or sets a value indicating whether this minion has a role.
		/// </summary>
		public bool HasRole
		{
			get { return fHasRole; }
			set { fHasRole = value; }
		}
		bool fHasRole = false;

		/// <summary>
		/// Gets or sets the minion role.
		/// </summary>
		public RoleType Type
		{
			get { return fType; }
			set { fType = value; }
		}
		RoleType fType = RoleType.Artillery;

		/// <summary>
		/// Creates a copy of the Minion.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public IRole Copy()
		{
			Minion m = new Minion();

			m.HasRole = fHasRole;
			m.Type = fType;

			return m;
		}

		/// <summary>
		/// Minion
		/// or
		/// Minion [role]
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			if (fHasRole)
				return "Minion " + fType;
			else
				return "Minion";
		}
	}

	/// <summary>
	/// Class representing a creature / trap role.
	/// </summary>
	[Serializable]
	public class ComplexRole : IRole
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public ComplexRole()
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="type">The role to set.</param>
		public ComplexRole(RoleType type)
		{
			fType = type;
		}

		/// <summary>
		/// Gets or sets the role type.
		/// </summary>
		public RoleType Type
		{
			get { return fType; }
			set { fType = value; }
		}
		RoleType fType = RoleType.Artillery;

		/// <summary>
		/// Gets or sets the role modifier (elite / solo).
		/// </summary>
		public RoleFlag Flag
		{
			get { return fFlag; }
			set { fFlag = value; }
		}
		RoleFlag fFlag = RoleFlag.Standard;

		/// <summary>
		/// Gets or sets the Leader role.
		/// </summary>
		public bool Leader
		{
			get { return fLeader; }
			set { fLeader = value; }
		}
		bool fLeader = false;

		/// <summary>
		/// Creates a copy of the role.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public IRole Copy()
		{
			ComplexRole cr = new ComplexRole();

			cr.Type = fType;
			cr.Flag = fFlag;
			cr.Leader = fLeader;

			return cr;
		}

		/// <summary>
		/// [Elite / Solo] [role] [(L)]
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			string flag = "";
			switch (fFlag)
			{
				case RoleFlag.Elite:
					flag = "Elite ";
					break;
				case RoleFlag.Solo:
					flag = "Solo ";
					break;
			}

			string role = fType.ToString();
			string leader = (fLeader) ? " (L)" : "";

			return flag + role + leader;
		}
	}
}
