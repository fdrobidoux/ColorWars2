using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ColorWars.Models.Exceptions;
using ColorWars.Models.Stats;

namespace ColorWars2.Models.Game.Stats
{
    /// <summary>
    /// Main Stat
    /// </summary>
    [NotMapped]
    public abstract class MainStat : GenericStat
    {
        public const int CREATION_BASE = 25;

        /*public new int Base
        {
            get { return base.Base; }
            protected set
            {
                base.Base = value;
            }
        }*/

        /// Bonus pour la classe choisie.
        public int BonusClasse { get; private set; }

        /// Total calculé du stat. 
        public new int Total => base.Total + BonusClasse;

        /// Sous-stat de catégorie Attaque.
        protected SubStat AtkSubStat { get; set; }

        /// Sous-stat de catégorie Dextérité.
        protected SubStat DexSubStat { get; set; }

        /// Sous-stat de catégorie Défense.
        protected SubStat DefSubStat { get; set; }

        protected MainStat() : base() {}

        /// <summary>
        /// Constructeur du MainStat.
        /// </summary>
        /// <param name="_base">La valeur de base assignée lors de la création du personnage.</param>
        /// <param name="atk"></param>
        /// <param name="dex"></param>
        /// <param name="def"></param>
        /// <param name="bClasse"></param>
        /// <param name="bLevelUp"></param>
        /// <param name="bCombat"></param>
        /// <exception cref="TotalPourcentageInvalideException">Si le total </exception>
        protected MainStat(int _base, SubStat atk, SubStat dex, SubStat def, int bClasse = 0, int bLevelUp = 0, int bCombat = 0) 
            : this(_base, new List<SubStat>(3) { atk, dex, def }, bLevelUp, bCombat)
        {
            // TODO: Vérifier si c'est ainsi qu'il faut valider si ça fait un total de 100%.
            if (ValiderSubStatPourcentageTotal(atk.Percent, dex.Percent, def.Percent))
            {
                atk.UpdateBonusMainStatPercent(Base);
                dex.UpdateBonusMainStatPercent(Base);
                def.UpdateBonusMainStatPercent(Base);
                AtkSubStat = atk;
                DexSubStat = dex;
                DefSubStat = def;
            }
            else
            {
                throw new TotalPourcentageInvalideException();
            }

            BonusClasse = bClasse;
        }

        protected MainStat(int _base, IList<SubStat> SubStats, int bLevelUp, int bCombat) 
            : base (_base, bLevelUp, bCombat)
        {
            if (ValiderSubStatPourcentageTotal(SubStats))
            {
                foreach (SubStat sub in SubStats)
                {
                    
                }
            }
        }

        // Si c'est un total d'environ 100 ou que c'est 
        public static bool ValiderSubStatPourcentageTotal(double atk, double dex, double def)
        {
            bool retour = Math.Round(atk + dex + def) == 100;

            return retour;
        }

        public static bool ValiderSubStatPourcentageTotal(IList<SubStat> SubStats)
        {
            bool retour = Math.Round(SubStats.Sum(stat => stat.Percent)) == 100;

            return retour;
        }

        /// <summary>
        /// Réinitialise les bonus de combat pour autant lui-même que pour les sous-stats.
        /// </summary>
        public override void ResetAllCombatBonuses()
        {
            base.ResetAllCombatBonuses();
            AtkSubStat.ResetAllCombatBonuses();
            DexSubStat.ResetAllCombatBonuses();
            DefSubStat.ResetAllCombatBonuses();
        }

        /// <summary>
        /// Retourne le sous-stat au nom demandé
        /// </summary>
        /// <param name="nomSubStat">Le nom du SubStat.</param>
        /// <returns>SubStat: L'instance du SubStat demandé.</returns>
        /// <exception cref="InstanceNotFoundException">Si le SubStat au nom précisé n'existe pas.</exception>
        public SubStat GetSubStat(string nomSubStat)
        {
            var subStat = GetType().GetField(nomSubStat);

            if (subStat != null) {
                return (SubStat) subStat.GetValue(this);
            }

            throw new MissingFieldException();
        }
    }
}