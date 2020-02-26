using System.Collections.Generic;

namespace AirLoca.Entities
{
    public class Client
    {
        public int IdClient { get; set; }

        public bool Type { get; set; }
        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public Adresse Adresse { get; set; }

        public List<Favoris> Favoris { get; set; }

        public List<Avis> Avis { get; set; }

        public Client()
        {
            this.Adresse = new Adresse();
            this.Favoris = new List<Favoris>();
            this.Avis = new List<Avis>();
        }

    }


}