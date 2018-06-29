using System;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ColorWars2.Models.Game.Stats
{
    /// <summary>
    /// Collection de stats
    /// </summary>
    [NotMapped]
    public class StatCollection
    {
        public Rouge Rouge { get; protected set; }
        public Vert Vert { get; protected set; }
        public Bleu Bleu { get; protected set; }

        private StatCollection() {}

        public StatCollection(Rouge pRouge, Vert pVert, Bleu pBleu)
        {
            Rouge = pRouge;
            Vert = pVert;
            Bleu = pBleu;
        }

        public StatCollection(int bRouge, int bVert, int bBleu): base()
        {
        }

        public StatCollection(string json)
        {
            JsonReader reader = new JsonTextReader(new System.IO.StringReader(json));
            // TODO: Créer les stats par rapport au JSON fourni.
        }
    }
}