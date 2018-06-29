using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColorWars2.Models.Game.Stats
{
    /// <summary>
    ///     Stat générique.
    /// </summary>
    [NotMapped]
    public class GenericStat
    {
        /// La valeur de base assignée lors de la création du personnage.
        public int Base { get; protected set; }
        public int BonusLevelUp { get; protected set; }
        public int BonusCombat { get; protected set; }

        /// Total calculé du stat.
        public virtual int Total => Base + BonusLevelUp + BonusCombat;

        /// <summary>
        /// Constructeur de base.
        /// </summary>
        protected GenericStat() { }

        /// <summary>
        /// Constructeur qui assigne les propriétés non-virtuelles du Stat.
        /// </summary>
        /// <param name="_base">La valeur de base assignée lors de la création du personnage.</param>
        /// <param name="bLevelUp"></param>
        /// <param name="bCombat"></param>
        protected GenericStat(int _base, int bLevelUp = 0, int bCombat = 0)
        {
            Base = _base;
            BonusLevelUp = bLevelUp;
            BonusCombat = bCombat;
        }

        /// Ajoute des points pour le level up.
        /// TODO: Un check si la valeur à ajouter est négative.
        public void AddLevelUpBonus(int add) => BonusLevelUp += add;

        /// Modifie les points reçus par rapport à la bataille.
        public void AddCombatBonus(int add) => BonusCombat += add;

        /// Remet les points de combat à zéro.
        public virtual void ResetAllCombatBonuses() => BonusCombat = 0;
    }
}