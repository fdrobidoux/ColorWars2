using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Remotion.Linq.Clauses.Expressions;

namespace ColorWars2.Models.Game.Stats
{
    /// <summary>
    /// Rouge
    /// </summary>
    [NotMapped]
    public class Rouge : MainStat
    {
        public Rouge(int _base, SubStat atk, SubStat dex, SubStat def, int bLevelUp, int bCombat, int bClasse)
                : base(_base, atk, dex, def, bLevelUp, bCombat, bClasse) { }

        /// <summary><list type="bullet">
        /// <listheader>Affecte :</listheader>
        /// <item>Puissance des actions physiques.</item>
        /// </list></summary>
        public SubStat Force
        {
            get { return AtkSubStat; }
            set { AtkSubStat = value; }
        }

        /// <summary><list type="bullet">
        /// <listheader>Affecte :</listheader>
        /// <item>Points de moral.</item>
        /// <item>Résistance à la saturation.</item>
        /// </list></summary>
        public SubStat Volonté
        {
            get { return DexSubStat; }
            set { DexSubStat = value; }
        }

        /// <summary><list type="bullet">
        /// <listheader>Affecte :</listheader>
        /// <item>Nb de points de vie.</item>
        /// <item>Résistance aux éléments.</item>
        /// </list></summary>
        public SubStat Constitution
        {
            get { return DefSubStat; }
            set { DefSubStat = value; }
        }
    }

    /// <summary>
    /// Vert
    /// </summary>
    [NotMapped]
    public class Vert : MainStat
    {
        public Vert(int _base, SubStat atk, SubStat dex, SubStat def, int bLevelUp, int bCombat, int bClasse)
                : base(_base, atk, dex, def, bLevelUp, bCombat, bClasse) {}

        /// <summary><list type="bullet">
        /// <listheader>Affecte :</listheader>
        /// <item>Ordre pour faire une action.</item>
        /// <item>Le nb de fois qu'une action sera fait durant un tour, pour les habiletés appliquables.</item>
        /// </list></summary>
        public SubStat Vitesse
        {
            get { return AtkSubStat; }
            set { AtkSubStat = value; }
        }

        /// <summary><list type="bullet">
        /// <listheader>Affecte :</listheader>
        /// <item>Chance à toucher l'ennemi avec toute action.</item>
        /// <item>Chance d'un coup critique.</item>
        /// </list></summary>
        public SubStat Précision
        {
            get { return DexSubStat; }
            set { DexSubStat = value; }
        }

        /// <summary><list type="bullet">
        /// <listheader>Affecte :</listheader>
        /// <item>Taux de chance d'éviter une action.</item>
        /// <item>Résistance aux pièges.</item>
        /// </list></summary>
        public SubStat Évasion
        {
            get { return DefSubStat; }
            set { DefSubStat = value; }
        }
    }

    /// <summary>
    /// Bleu
    /// </summary>
    [NotMapped]
    public class Bleu : MainStat
    {
        public Bleu(int _base, SubStat atk, SubStat dex, SubStat def, int bLevelUp, int bCombat, int bClasse) 
            : base(_base, atk, dex, def, bLevelUp, bCombat, bClasse) {}

        /// <summary><list type="bullet">
        /// <listheader>Affecte :</listheader>
        /// <item>Puissance de beaucoup d'actions magiques appliquables.</item>
        /// </list></summary>
        public SubStat Intelligence
        {
            get { return AtkSubStat; }
            set { AtkSubStat = value; }
        }

        /// <summary><list type="bullet">
        /// <listheader>Affecte :</listheader>
        /// <item>Taux de chance d'effectuer les effets secondaires pour la plupart des actions</item>
        /// </list></summary>
        public SubStat Sagesse
        {
            get { return DexSubStat; }
            set { DexSubStat = value; }
        }

        /// <summary><list type="bullet">
        /// <listheader>Affecte :</listheader>
        /// <item>Taux de chance d'éviter les changements de status ainsi que les effets secondaires.</item>
        /// <item>Résistance à certains effets.</item>
        /// </list></summary>
        public SubStat Lucidité
        {
            get { return DefSubStat; }
            set { DefSubStat = value; }
        }
    }
}
