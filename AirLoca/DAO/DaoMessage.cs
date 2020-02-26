using AirLoca.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AirLoca.DAO
{
    public class DaoMessage : DataAccess
    {
        public DaoMessage() : base()
        {

        }
         

        //public List<Messagerie> GetMessagerie(int idClient)
        //{
        //    List<Messagerie> Messages = null;

        //    try
        //    {

        //        SqlParameter[] sqlParameters = new SqlParameter[1];

        //        SqlParameter paramIdClient = new SqlParameter
        //        { ParameterName = "@IdClient", Value = idClient };
        //        sqlParameters[0] = paramIdClient;

        //        base.GetDataReader("sp_getMessage", sqlParameters.ToArray());

        //        //on créé un client avec instruction conditionnelle; HasRows = s'il a encore une ligne
        //        if (base.sqlDataReader.HasRows)
        //            Messages = new List<Messagerie>();

        //        while (base.sqlDataReader.Read())
        //        {
        //            int idExp = Convert.ToInt32(sqlDataReader["IdExpediteur"]);
        //            int idDest = Convert.ToInt32(sqlDataReader["IdDestinataire"]);
        //            int idContact = Convert.ToInt32(sqlDataReader["IdClient"]);
        //            string msg = sqlDataReader["Message"].ToString();
        //            string nom = sqlDataReader["Nom"].ToString();
        //            string prenom = sqlDataReader["Prenom"].ToString();
        //            string nomHebergement = sqlDataReader["NomHebergement"].ToString();
        //            int idHebergement = Convert.ToInt32(sqlDataReader["IdHebergement"]);
        //            bool statutMessage = Convert.ToBoolean(sqlDataReader["Statut"]);                   
        //            DateTime dateMessage = Convert.ToDateTime(sqlDataReader["Date"]);

        //            Messagerie message = new Messagerie
        //            {
        //                IdDestinataire = idDest,
        //                IdExpediteur = idExp,
        //                Message = msg,
        //                Date = dateMessage,
        //                Statut = statutMessage,
        //                IdHebergement = idHebergement,
        //                NomContact = nom,
        //                PrenomContact = prenom,
        //                NomHebergement = nomHebergement,
        //                IdContact = idContact
        //            };

        //            Messages.Add(message);
                    
        //        }

        //        base.sqlDataReader.Close();
        //        base.sqlConnection.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        IsError = true;
        //        ErrorMsg = ex.Message;
        //        //transmission de l'erreur au niveau supérieur (ici elle peut venir de DataAccess, puis elle ira vers 
        //        throw ex;
        //    }

        //    return Messages;
        //}

            public List<Messagerie> GetAllMessage(int idClient)
        {
            List<Messagerie> Messages = null;

            try
            {

                SqlParameter[] sqlParameters = new SqlParameter[1];

                SqlParameter paramIdClient = new SqlParameter
                { ParameterName = "@IdClient", Value = idClient };
                sqlParameters[0] = paramIdClient;

                base.GetDataReader("sp_getMessage", sqlParameters.ToArray());

                //on créé un client avec instruction conditionnelle; HasRows = s'il a encore une ligne
                if (base.sqlDataReader.HasRows)
                    Messages = new List<Messagerie>();

                while (base.sqlDataReader.Read())
                {
                    int idContact = Convert.ToInt32(sqlDataReader["IdContact"]);
                    string nom = sqlDataReader["Nom"].ToString();
                    string prenom = sqlDataReader["Prenom"].ToString();
                    string nomHebergement = sqlDataReader["NomHebergement"].ToString();
                    int idHebergement = Convert.ToInt32(sqlDataReader["IdHebergement"]);

                    Messagerie message = new Messagerie
                    {
                        
                        IdHebergement = idHebergement,
                        NomContact = nom,
                        PrenomContact = prenom,
                        NomHebergement = nomHebergement,
                        IdContact = idContact
                    };

                    Messages.Add(message);

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

            return Messages;
        }

        public List<Messagerie> GetMyMessage(int idClient, int idContact, int idHebergement)
        {
            List<Messagerie> Messages = null;

            try
            {

                SqlParameter[] sqlParameters = new SqlParameter[3];

                SqlParameter paramIdClient = new SqlParameter
                { ParameterName = "@IdClient", Value = idClient };
                sqlParameters[0] = paramIdClient;

                SqlParameter paramIdHebergement = new SqlParameter
                { ParameterName = "@IdHebergement", Value = idHebergement };
                sqlParameters[1] = paramIdHebergement;

                SqlParameter paramIdContact = new SqlParameter
                { ParameterName = "@IdContact", Value = idContact };
                sqlParameters[2] = paramIdContact;

                base.GetDataReader("sp_MyMessage", sqlParameters.ToArray());

                //on créé un client avec instruction conditionnelle; HasRows = s'il a encore une ligne
                if (base.sqlDataReader.HasRows)
                    Messages = new List<Messagerie>();

                while (base.sqlDataReader.Read())
                {
                    string nomHebergement = sqlDataReader["NomHebergement"].ToString();
                    string nom = sqlDataReader["Nom"].ToString();
                    string prenom = sqlDataReader["Prenom"].ToString();
                    DateTime  date = Convert.ToDateTime(sqlDataReader["Date"]);
                    string monMessage = sqlDataReader["Message"].ToString();
                    int idExpediteur = Convert.ToInt32(sqlDataReader["IdExpediteur"]);
                    int idDestinataire = Convert.ToInt32(sqlDataReader["IdDestinataire"]);

                    Messagerie message = new Messagerie
                    {
                        IdHebergement = idHebergement,
                        NomHebergement = nomHebergement,
                        Message = monMessage,
                        NomContact = nom,
                        PrenomContact = prenom,
                        Date = date,
                        IdExpediteur = idExpediteur,
                        IdDestinataire = idDestinataire,
                        IdContact = idContact
                    };

                    Messages.Add(message);

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

            return Messages;
        }

        public void AddMessage(int idDestinataire, int idExpediteur, string message, bool statut, DateTime date, int idHebergement)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[6];

                SqlParameter paramDestinataire = new SqlParameter
                { ParameterName = "@IdDestinataire", Value = idDestinataire };
                sqlParameters[0] = paramDestinataire;

                SqlParameter paramExpediteur = new SqlParameter
                { ParameterName = "@IdExpediteur", Value = idExpediteur};
                sqlParameters[1] = paramExpediteur;


                SqlParameter paramMessage = new SqlParameter
                { ParameterName = "@Message",Value = message };
                sqlParameters[2] = paramMessage;

                SqlParameter paramStatut = new SqlParameter
                { ParameterName = "@Statut", Value = statut };
                sqlParameters[3] = paramStatut;

                SqlParameter paramDate = new SqlParameter
                { ParameterName = "@Date", Value = date };
                sqlParameters[4] = paramDate;

                SqlParameter paramIdHebergement = new SqlParameter
                { ParameterName = "@IdHebergement", Value = idHebergement };
                sqlParameters[5] = paramIdHebergement;


                base.ExecuteQuery("sp_MessageAdd", sqlParameters);


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