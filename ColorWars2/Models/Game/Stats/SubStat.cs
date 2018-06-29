using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColorWars2.Models.Game.Stats
{
    /// <summary>
    /// Sous-Stat
    /// </summary>
    [NotMapped]
    public class SubStat : GenericStat
    {
        public const int CREATION_BASE = 5;
        public const int PERCENT_MULTIPLE = 5;

        /// Le pourcentage de MainStat ajouté sur la valeur totale du SubStat.
        public double Percent { get; protected set; }
        /// Le bonus de poucentage du MainStat attribué durant un combat.
        public double BonusPercent { get; protected set; }
        /// Le bonus calculé par rapport au pourcentage fois la valeur totale du main stat.
        public int BonusCalc { get; protected set; }
        /// Total calculé du stat.
        public new int Total => base.Total + BonusCalc;

        /// Constructeur privé pour EF7.
        private SubStat() : base() {}

        /// <summary>
        /// Crée un Sous-Stat à l'aide des 
        /// </summary>
        /// <param name="_base">La valeur de base assignée lors de la création du personnage.</param>
        /// <param name="bLevelup"></param>
        /// <param name="bCombat"></param>
        /// <param name="percent">Le pourcentage de MainStat ajouté sur la valeur totale du SubStat.</param>
        /// <param name="bPercent"> Le bonus de poucentage du MainStat attribué durant un combat.</param>
        public SubStat(int _base, double percent = 0, double bPercent = 0, int bLevelup = 0, int bCombat = 0) : base(_base, bLevelup, bCombat)
        {
            Percent = percent;
            BonusPercent = bPercent;
        }

        public SubStat(SubStat subStat, int mainStatTotal) 
            : this(subStat.Base, subStat.Percent, subStat.BonusPercent, subStat.BonusLevelUp, subStat.BonusCombat)
        {
            UpdateBonusMainStatPercent(mainStatTotal);
        }

        public void UpdateBonusMainStatPercent(int mainStatTotal)
        {
            BonusCalc = (int) Math.Round((mainStatTotal * (Percent + BonusPercent)) / 100);
        }

        public override void ResetAllCombatBonuses()
        {
            base.ResetAllCombatBonuses();
            BonusPercent = 0;
        }
    }
}