using AirLoca.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AirLoca.DAO
{
    public class DaoReservation : DataAccess
    {
        public DaoReservation() : base()
        {

        }

        public List<Hebergement> GetReservation(int idClient)
        {
            List<Hebergement> reservations = null;

            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];

                SqlParameter paramIdClient = new SqlParameter
                { ParameterName = "@IdClient", Value = idClient };
                sqlParameters[0] = paramIdClient;

                base.GetDataReader("sp_getReserv", sqlParameters);


                //on créé un client avec instruction conditionnelle; HasRows = s'il a encore une ligne
                if (base.sqlDataReader.HasRows)
                    reservations = new List<Hebergement>();

                while (base.sqlDataReader.Read())
                {
                    int idReservation = Convert.ToInt32(sqlDataReader["IdReservation"]);
                    int idHebergement = Convert.ToInt32(sqlDataReader["IdHebergement"]);
                    string nomHebergement = sqlDataReader["Nom"].ToString();

                    int idHebergeur = Convert.ToInt32(sqlDataReader["IdClient"]);
                    string type = sqlDataReader["Type"].ToString();
                    string description = sqlDataReader["Description"].ToString();
                    string photo = sqlDataReader["Photo"].ToString();
                    int prixDeBase = Convert.ToInt32(sqlDataReader["PrixDeBase"]);

                    string numero = sqlDataReader["Numero"].ToString();
                    string voie = sqlDataReader["Voie"].ToString();
                    string ville = sqlDataReader["Ville"].ToString();
                    string codePostal = sqlDataReader["CodePostal"].ToString();

                    DateTime dateReservation = Convert.ToDateTime(sqlDataReader["DateReservation"]);
                    DateTime dateDebut = Convert.ToDateTime(sqlDataReader["DateDebut"]);
                    DateTime dateFin = Convert.ToDateTime(sqlDataReader["DateFin"]);
                    double prixTotal = Convert.ToDouble(sqlDataReader["PrixTotal"]);

                    Hebergement reservation = new Hebergement();
                    reservation.IdHebergement = idHebergement;
                    reservation.Reservation.IdReservation = idReservation;
                    reservation.Reservation.DateReservation = dateReservation;
                    reservation.Reservation.DateDebut = dateDebut;
                    reservation.Reservation.DateFin = dateFin;
                    reservation.Reservation.PrixTotal = prixTotal;
                    reservation.Nom = nomHebergement;
                    reservation.Type = type;
                    reservation.Description = description;
                    reservation.Photo = photo;
                    reservation.Adresse.Numero = numero;
                    reservation.Adresse.Voie = voie;
                    reservation.Adresse.Ville = ville;
                    reservation.Adresse.CodePostal = codePostal;
                    reservation.IdClient = idHebergeur;
                    reservation.PrixDeBase = prixDeBase;

                    reservations.Add(reservation);

                }

                base.sqlDataReader.Close();
                base.sqlConnection.Close();
            }
            catch (Exception ex)
            {
                IsError = true;
                ErrorMsg = ex.Message;
                //transmission de l'erreur au niveau supérieur (ici elle peut venir de DataAccess, puis elle ira vers 
                throw ex;
            }

            return reservations;
        }

        public List<Hebergement> GetReservationLoc(int idHebergement)
        {
            List<Hebergement> reservations = null;

            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];

                SqlParameter paramIdHebergement = new SqlParameter
                { ParameterName = "@IdHebergement", Value = idHebergement };
                sqlParameters[0] = paramIdHebergement;

                base.GetDataReader("sp_getReservLoc", sqlParameters);


                //on créé un client avec instruction conditionnelle; HasRows = s'il a encore une ligne
                if (base.sqlDataReader.HasRows)
                    reservations = new List<Hebergement>();

                while (base.sqlDataReader.Read())
                {


                    DateTime dateDebut = Convert.ToDateTime(sqlDataReader["DateDebut"]);
                    int nbJour = Convert.ToInt32(sqlDataReader["NbJour"]);

                    Hebergement reservation = new Hebergement();
                    reservation.Reservation.DateDebut = dateDebut;
                    reservation.Reservation.NbJour = nbJour;                  

                    reservations.Add(reservation);

                }

                base.sqlDataReader.Close();
                base.sqlConnection.Close();
            }
            catch (Exception ex)
            {
                IsError = true;
                ErrorMsg = ex.Message;
                //transmission de l'erreur au niveau supérieur (ici elle peut venir de DataAccess, puis elle ira vers 
                throw ex;
            }

            return reservations;
        }
        public void AddReservation(int idHebergement, int idClient, DateTime dateReservation, DateTime dateDebut, DateTime dateFin, double prixTotal)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[6];

                SqlParameter paramIdHebergement = new SqlParameter
                { ParameterName = "@IdHebergement", Value = idHebergement };
                sqlParameters[0] = paramIdHebergement;

                SqlParameter paramIdClient = new SqlParameter
                { ParameterName = "@IdClient", Value = idClient };
                sqlParameters[1] = paramIdClient;


                SqlParameter paramDateReservation = new SqlParameter
                { ParameterName = "@DateReservation", Value = dateReservation };
                sqlParameters[2] = paramDateReservation;

                SqlParameter paramDateDebut = new SqlParameter
                { ParameterName = "@DateDebut", Value = dateDebut };
                sqlParameters[3] = paramDateDebut;

                SqlParameter paramDateFin = new SqlParameter
                { ParameterName = "@DateFin", Value = dateFin };
                sqlParameters[4] = paramDateFin;

                SqlParameter paramPrixTotal = new SqlParameter
                { ParameterName = "@PrixTotal", Value = prixTotal };
                sqlParameters[5] = paramPrixTotal;

                base.ExecuteQuery("sp_AddReserv", sqlParameters);

                base.sqlConnection.Close();
            }
            catch (Exception ex)
            {
                IsError = true;
                ErrorMsg = ex.Message;
            }


        }


        public void DeleteReservation(int idClient, int idReservation)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[2];

                SqlParameter paramIdClient = new SqlParameter
                { ParameterName = "@IdClient", Value = idClient };
                sqlParameters[0] = paramIdClient;

                SqlParameter paramIdHebergement = new SqlParameter
                { ParameterName = "@IdReservation", Value = idReservation };
                sqlParameters[1] = paramIdHebergement;

                base.ExecuteQuery("sp_DeleteReserv", sqlParameters);

                base.sqlConnection.Close();
            }
            catch (Exception ex)
            {
                IsError = true;
                ErrorMsg = ex.Message;
            }
        }

    }
}