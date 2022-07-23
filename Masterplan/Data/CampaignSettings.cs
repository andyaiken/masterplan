using System;

namespace Masterplan.Data
{
	/// <summary>
	/// Class to hold campaign-specific modifications.
	/// </summary>
	[Serializable]
	public class CampaignSettings
	{
		/// <summary>
		/// Gets or sets the HP modifier.
		/// </summary>
		public double HP
		{
			get { return fHP; }
			set { fHP = value; }
		}
		double fHP = 1.0;

		/// <summary>
		/// Gets or sets the XP modifier.
		/// </summary>
		public double XP
		{
			get { return fXP; }
			set { fXP = value; }
		}
		double fXP = 1.0;

		/// <summary>
		/// Gets or sets the bonus to attacks.
		/// </summary>
		public int AttackBonus
		{
			get { return fAttackBonus; }
			set { fAttackBonus = value; }
		}
		int fAttackBonus = 0;

		/// <summary>
		/// Gets or sets the damage multiplier.
		/// </summary>
		public double Damage
		{
			get { if (fDamage == 0) fDamage = 1; return fDamage; }
			set { if (value == 0) value = 1; fDamage = value; }
		}
		double fDamage = 1.0;

		/// <summary>
		/// Gets or sets the bonus to AC.
		/// </summary>
		public int ACBonus
		{
			get { return fACBonus; }
			set { fACBonus = value; }
		}
		int fACBonus = 0;

		/// <summary>
		/// Gets or sets the bonus to non-AC defences.
		/// </summary>
		public int NADBonus
		{
			get { return fNADBonus; }
			set { fNADBonus = value; }
		}
		int fNADBonus = 0;
	}
}
