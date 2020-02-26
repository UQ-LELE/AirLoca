using AirLoca.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AirLoca.DAO
{
    public class DaoFavoris : DataAccess
    {
        public DaoFavoris() : base()
        {

        }

        public List<Hebergement> GetFavoris(int idClient)
        {

            List<Hebergement> favoris = null;

            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];

                SqlParameter paramIdClient = new SqlParameter
                { ParameterName = "@IdClient", Value = idClient };
                sqlParameters[0] = paramIdClient;

                base.GetDataReader("sp_getFavoris", sqlParameters);

                if (base.sqlDataReader.HasRows)
                    favoris = new List<Hebergement>();

                while (sqlDataReader.Read())
                {
                    string nom = (string)sqlDataReader["Nom"];
                    string description = (string)sqlDataReader["Description"];
                    string photo = (string)sqlDataReader["Photo"];
                    int idHebergement = Convert.ToInt32(sqlDataReader["IdHebergement"]);

                    Hebergement hebergement = new Hebergement();
                    hebergement.Nom = nom;
                    hebergement.Description = description;
                    hebergement.Photo = photo;
                    hebergement.IdHebergement = idHebergement;

                    favoris.Add(hebergement);
                }

                base.sqlDataReader.Close();
                base.sqlConnection.Close();
            }
            catch (Exception ex)
            {
                IsError = true;
                ErrorMsg = ex.Message;
            }

            return favoris;
        }

        public void AddFavorite(int idClient, int idHebergement)
        {


            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[2];

                SqlParameter paramIdClient = new SqlParameter
                { ParameterName = "@IdClient", Value = idClient };
                sqlParameters[0] = paramIdClient;

                SqlParameter paramIdHebergement = new SqlParameter
                { ParameterName = "@IdHebergement", Value = idHebergement };
                sqlParameters[1] = paramIdHebergement;

                base.ExecuteQuery("sp_AddFavorite", sqlParameters);

                base.sqlConnection.Close();
            }
            catch (Exception ex)
            {
                IsError = true;
                ErrorMsg = ex.Message;
            }
        }

        public void DeleteFavoris(int idClient, int idHebergement)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[2];

                SqlParameter paramIdClient = new SqlParameter
                { ParameterName = "@IdClient", Value = idClient };
                sqlParameters[0] = paramIdClient;

                SqlParameter paramIdHebergement = new SqlParameter
                { ParameterName = "@IdHebergement", Value = idHebergement };
                sqlParameters[1] = paramIdHebergement;

                base.ExecuteQuery("sp_DeleteFavorite", sqlParameters);

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