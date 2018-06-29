using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ColorWars2.Models.Game.Battles
{
    /// <summary>
    ///     Batailles
    /// </summary>
    public class Bataille
    {
        [Key]
        public int Id { get; set; }

        [Range(2, 2)]
        public IList<BattleSet> BattleSets { get; set; }

        public virtual IList<Tour> Tours { get; set; }

        public int EtatBataille { get; set; }

        public enum Etat
        {
            Proposé,
            EnCours,
            JoueurUnGagne,
            JoueurDeuxGagne
        }
    }
}