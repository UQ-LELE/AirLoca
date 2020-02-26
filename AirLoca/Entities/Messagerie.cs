using System;


namespace AirLoca.Entities
{
    public class Messagerie
    {

        public int IdMessagerie { get; set; }

        public int IdExpediteur { get; set; }

        public int IdDestinataire { get; set; }

        public string Message { get; set; }

        public DateTime Date { get; set; }

        public bool Statut { get; set; }

        public string Sujet { get; set; }

        public int IdHebergement { get; set; }

        public int IdContact { get; set; }

        public string NomContact {get; set;}

        public string PrenomContact { get; set; }

        public string NomHebergement { get; set; }

    }
}