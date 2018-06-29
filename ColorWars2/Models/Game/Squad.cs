using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ColorWars2.Models.Game
{
    /// <summary>
    /// La classe Squad.
    /// </summary>
    public class Squad
    {
        [Key]
        public int Id { get; private set; }

        [ScaffoldColumn(false)]
        public string UserId { get; set; }
        public virtual object User { get; set; }

        [MaxLength(5)]
        public virtual IList<Couleur> Couleurs { get; set; }

        private Squad() {}

        public Squad(Squad squadTemp, string pUserId)
        {
            foreach (var creerCouleurViewModel in squadTemp.Couleurs)
            {
                Couleurs.Add(new Couleur(creerCouleurViewModel, pUserId));
            }

            UserId = pUserId;
        }
    }
}
