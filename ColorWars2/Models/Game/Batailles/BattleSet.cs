using System;
using ColorWars2.Models.Game;

namespace ColorWars2.Models.Game.Battles
{
    /// <summary>
    ///     PlayerSets
    /// </summary>
    public class BattleSet
    {
        // Première partie de la clé composite.
        public string UserId { get; set; }
        public virtual object User { get; set; }

        // Deuxième partie de la clé composite.
        public int BatailleId { get; set; }
        public virtual Bataille Bataille { get; set; }

        public int SquadId { get; set; }
        public virtual Squad Squad { get; set; }

        public bool EstGagnant { get; set; }
    }
}