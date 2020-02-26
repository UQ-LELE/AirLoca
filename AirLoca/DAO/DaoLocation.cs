using AirLoca.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AirLoca.DAO
{
    public class DaoLocation : DataAccess
    {
        public DaoLocation()
        {

        }

        public List<Hebergement> GetLocation(int idClient)
        {
            List<Hebergement> locations = null;

            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];

                SqlParameter paramIdClient = new SqlParameter
                { ParameterName = "@IdClient", Value = idClient };
                sqlParameters[0] = paramIdClient;

                base.GetDataReader("sp_getLoc", sqlParameters);


                //on créé un client avec instruction conditionnelle; HasRows = s'il a encore une ligne
                if (base.sqlDataReader.HasRows)
                    locations = new List<Hebergement>();

                while (base.sqlDataReader.Read())
                {
                    int idHebergement = Convert.ToInt32(sqlDataReader["IdHebergement"]);
                    string nomHebergement = sqlDataReader["NomHebergement"].ToString();
                    string type = sqlDataReader["Type"].ToString();
                    string description = sqlDataReader["Description"].ToString();
                    string photo = sqlDataReader["Photo"].ToString();
                    string statut = sqlDataReader["Statut"].ToString();
                    double prixDeBase = Convert.ToDouble(sqlDataReader["PrixDeBase"]);


                    string nom = sqlDataReader["Nom"].ToString();
                    string numero = sqlDataReader["Numero"].ToString();
                    string voie = sqlDataReader["Voie"].ToString();
                    string ville = sqlDataReader["Ville"].ToString();
                    string codePostal = sqlDataReader["CodePostal"].ToString();

                    Hebergement location = new Hebergement();
                    location.IdHebergement = idHebergement;
                    location.Nom = nomHebergement;
                    location.Type = type;
                    location.Description = description;
                    location.Photo = photo;
                    location.Staut = statut;
                    location.PrixDeBase = prixDeBase;
                    location.Adresse.NomAdresse = nom;
                    location.Adresse.Numero = numero;
                    location.Adresse.Voie = voie;
                    location.Adresse.Ville = ville;
                    location.Adresse.CodePostal = codePostal;

                    locations.Add(location);

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

            return locations;
        }

        public void AddLocation(int idClient, string nomHebergement, string type, string description, string photo, bool statut, string nomAdresse, string numero, string voie, string ville, string codePostal, int prixDeBase)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[12];

                SqlParameter paramIdClient = new SqlParameter
                { ParameterName = "@IdClient", Value = idClient };
                sqlParameters[0] = paramIdClient;

                SqlParameter paramNomHebergement = new SqlParameter
                { ParameterName = "@NomHebergement", Value = nomHebergement };
                sqlParameters[1] = paramNomHebergement;

                SqlParameter paramType = new SqlParameter
                { ParameterName = "@Type", Value = type };
                sqlParameters[2] = paramType;

                SqlParameter paramDescription = new SqlParameter
                { ParameterName = "@Description", Value = description };
                sqlParameters[3] = paramDescription;

                SqlParameter paramPhoto = new SqlParameter
                { ParameterName = "@Photo", Value = photo };
                sqlParameters[4] = paramPhoto;

                SqlParameter paramStatut = new SqlParameter
                { ParameterName = "@Statut", Value = statut };
                sqlParameters[5] = paramStatut;

                SqlParameter paramNomAdresse = new SqlParameter
                { ParameterName = "@NomAdresse", Value = nomAdresse };
                sqlParameters[6] = paramNomAdresse;

                SqlParameter paramNumero = new SqlParameter
                { ParameterName = "@Numero", Value = numero };
                sqlParameters[7] = paramNumero;

                SqlParameter paramVoie = new SqlParameter
                { ParameterName = "@Voie", Value = voie };
                sqlParameters[8] = paramVoie;

                SqlParameter paramVille = new SqlParameter
                { ParameterName = "@Ville", Value = ville };
                sqlParameters[9] = paramVille;

                SqlParameter paramCodePostal = new SqlParameter
                { ParameterName = "@CodePostal", Value = codePostal };
                sqlParameters[10] = paramCodePostal;

                SqlParameter paramPrixDeBase = new SqlParameter
                { ParameterName = "@PrixDeBase", Value = prixDeBase };
                sqlParameters[11] = paramPrixDeBase;

                base.ExecuteQuery("sp_AddLoc", sqlParameters);

                base.sqlConnection.Close();
            }
            catch (Exception ex)
            {
                IsError = true;
                ErrorMsg = ex.Message;
            }

        }

        public void UpLocation(int idClient, string nomHebergement, string type, string description, bool statut, string nomAdresse, string numero, string voie, string ville, string codePostal, int prixDeBase, int idHebergement)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[12];

                SqlParameter paramIdClient = new SqlParameter
                { ParameterName = "@IdClient", Value = idClient };
                sqlParameters[0] = paramIdClient;

                SqlParameter paramNomHebergement = new SqlParameter
                { ParameterName = "@NomHebergement", Value = nomHebergement };
                sqlParameters[1] = paramNomHebergement;

                SqlParameter paramType = new SqlParameter
                { ParameterName = "@Type", Value = type };
                sqlParameters[2] = paramType;

                SqlParameter paramDescription = new SqlParameter
                { ParameterName = "@Description", Value = description };
                sqlParameters[3] = paramDescription;

                SqlParameter paramStatut = new SqlParameter
                { ParameterName = "@Statut", Value = statut };
                sqlParameters[4] = paramStatut;

                SqlParameter paramNomAdresse = new SqlParameter
                { ParameterName = "@NomAdresse", Value = nomAdresse };
                sqlParameters[5] = paramNomAdresse;

                SqlParameter paramNumero = new SqlParameter
                { ParameterName = "@Numero", Value = numero };
                sqlParameters[6] = paramNumero;

                SqlParameter paramVoie = new SqlParameter
                { ParameterName = "@Voie", Value = voie };
                sqlParameters[7] = paramVoie;

                SqlParameter paramVille = new SqlParameter
                { ParameterName = "@Ville", Value = ville };
                sqlParameters[8] = paramVille;

                SqlParameter paramCodePostal = new SqlParameter
                { ParameterName = "@CodePostal", Value = codePostal };
                sqlParameters[9] = paramCodePostal;

                SqlParameter paramPrixDeBase = new SqlParameter
                { ParameterName = "@PrixDeBase", Value = prixDeBase };
                sqlParameters[10] = paramPrixDeBase;

                SqlParameter paramIdHebergement = new SqlParameter
                { ParameterName = "@IdHebergement", Value = idHebergement };
                sqlParameters[11] = paramIdHebergement;

                base.ExecuteQuery("sp_upLoc", sqlParameters);


                base.sqlConnection.Close();
            }
            catch (Exception ex)
            {
                IsError = true;
                ErrorMsg = ex.Message;
            }
        }

        public void DeleteLocation(int idHebergement)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];

                SqlParameter paramIdHebergement = new SqlParameter
                { ParameterName = "@IdClient", Value = idHebergement };
                sqlParameters[0] = paramIdHebergement;

                base.ExecuteQuery("sp_DeleteLoc", sqlParameters);

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
