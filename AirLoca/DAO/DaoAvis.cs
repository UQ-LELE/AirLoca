using AirLoca.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AirLoca.DAO
{
    public class DaoAvis : DataAccess
    {
        public DaoAvis() : base()
        {

        }

        public void AddAvis(int idClient, int idHergement, int note, string commentaire, bool statut, DateTime date)
        {

            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[6];

                SqlParameter paramIdClient = new SqlParameter
                { ParameterName = "@IdClient", Value = idClient };
                sqlParameters[0] = paramIdClient;

                SqlParameter paramIdHebergement = new SqlParameter
                { ParameterName = "@IdHebergement", Value = idHergement };
                sqlParameters[1] = paramIdHebergement;


                SqlParameter paramNote = new SqlParameter
                { ParameterName = "@Note", Value = note };
                sqlParameters[2] = paramNote;

                SqlParameter paramCommentaire = new SqlParameter
                { ParameterName = "@Commentaire", Value = commentaire };
                sqlParameters[3] = paramCommentaire;

                SqlParameter paramStatut = new SqlParameter
                { ParameterName = "@Statut", Value = statut };
                sqlParameters[4] = paramStatut;

                SqlParameter paramDate = new SqlParameter
                { ParameterName = "@Date", Value = date };
                sqlParameters[5] = paramDate;

                base.ExecuteQuery("sp_AddAvis", sqlParameters);


                base.sqlConnection.Close();
            }
            catch (Exception ex)
            {
                IsError = true;
                ErrorMsg = ex.Message;
            }

        }


        public List<Avis> GetAvis(int idHebergement)
        {
            List<Avis> avis = new List<Avis>();


            try
            {

                SqlParameter[] sqlParameters = new SqlParameter[1];

                SqlParameter paramIdHebergement = new SqlParameter
                { ParameterName = "@IdHebergement", Value = idHebergement };
                sqlParameters[0] = paramIdHebergement;

                base.GetDataReader("sp_getAvis", sqlParameters);


                if (base.sqlDataReader.HasRows)
                    avis = new List<Avis>();

                while (base.sqlDataReader.Read())
                {
                    string nom = sqlDataReader["Nom"].ToString();
                    string prenom = sqlDataReader["Prenom"].ToString();
                    string commentaire = sqlDataReader["Commentaire"].ToString();
                    int note = Convert.ToInt32(sqlDataReader["Note"]);
                    DateTime date = Convert.ToDateTime(sqlDataReader["Date"]);

                    Avis avi = new Avis();

                    avi.Commentaire = commentaire;
                    avi.Note = note;
                    avi.Date = date;
                    avi.Prenom = prenom;
                    avi.Nom = nom[0];

                    avis.Add(avi);
                }

                base.sqlDataReader.Close();
                base.sqlConnection.Close();
            }
            catch (Exception ex)
            {
                IsError = true;
                ErrorMsg = ex.Message;
                throw ex;
            }

            return avis;
        }
    }
}