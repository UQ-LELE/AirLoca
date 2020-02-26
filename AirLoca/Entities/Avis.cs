using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirLoca.Entities
{
    public class Avis
    {
        public int IdAvis { get; set; }
        public int IdHebergement { get; set; }
        public int Note { get; set; }

        public string Commentaire { get; set; }

        public bool Statut { get; set; }

        public DateTime Date { get; set; }

        public char Nom { get; set; }
        public string Prenom { get; set; }
    }
}