using System.Collections.Generic;

namespace AirLoca.Entities
{
    public class Hebergement
    {
        public int IdHebergement { get; set; }

        public int IdClient { get; set; }

        public int IdAdresse { get; set; }

        public string Photo { get; set; }

        public string Nom { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public string Staut { get; set; }

        public double PrixDeBase { get; set; }

        public Adresse Adresse { get; set; }

        public Reservation Reservation { get; set; }

        public List<Avis> Avis { get; set; }
        public Hebergement()
        {
            this.Reservation = new Reservation();
            this.Adresse = new Adresse();
            this.Avis = new List<Avis>();
        }
    }

}