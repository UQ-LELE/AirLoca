using System;

namespace AirLoca.Entities
{
    public class Reservation 
    {
        public int IdReservation { get; set; }
        public DateTime DateReservation { get; set; }
        public DateTime DateDebut { get; set; }

        public DateTime DateFin { get; set; }
        public double PrixTotal { get; set; }

        public int NbJour { get; set; }
    }

}