using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ColorWars2.Models.Game.Battles
{
    //
    // Tours
    public class Tour
    {
        [Key]
        public int Id { get; set; }

        public int Num { get; set; }

        public int BatailleId { get; set; }
        public virtual Bataille Bataille { get; set; }

        public List<string> Log { get; set; }

        public int EtatTour { get; set; }

        public enum Etat
        {
            Débuté,
            GaucheDoitJouer,
            DroiteDoitJouer,
            Complété,
            Archivé
        }

        public Tour()
        {
        }

    }
}