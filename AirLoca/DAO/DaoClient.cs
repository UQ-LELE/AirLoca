using AirLoca.Entities;
using System;
using System.Data.SqlClient;

namespace AirLoca.DAO
{
    //pour pouvoir utiliser les méthodes dans DataAccess on fait un héritage de DataAccess grace aux : (deux points) DataAccess  (et c'est public)
    public class DaoClient : DataAccess
    {
        public DaoClient() : base()
        {
        }


        public Client GetClient(string login, string password)
        {
            Client client = null;

            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[2];

                SqlParameter paramLogin = new SqlParameter();
                paramLogin.ParameterName = "@Login";
                paramLogin.Value = login;
                sqlParameters[0] = paramLogin;

                SqlParameter paramPassword = new SqlParameter();
                paramPassword.ParameterName = "@Password";
                paramPassword.Value = password;
                sqlParameters[1] = paramPassword;

                //on execute l'opération sql qui nous renvoie un tableau
                //les données sont stockées dans un objet de type DataReader
                //sp_Client appelle ma procédure SQL avec les paramètres de sqlParameters
                base.GetDataReader("sp_getClient", sqlParameters);


                //on créé un client avec instruction conditionnelle; HasRows = s'il a encore une ligne
                if (base.sqlDataReader.HasRows)
                    client = new Client();

                while (base.sqlDataReader.Read())
                {
                    string nom = sqlDataReader["Nom"].ToString();
                    string prenom = sqlDataReader["Prenom"].ToString();
                    int idClient = Convert.ToInt32(sqlDataReader["IdClient"]);
                    string telephone = sqlDataReader["Telephone"].ToString();
                    string email = sqlDataReader["Email"].ToString();
                    bool type = Convert.ToBoolean(sqlDataReader["Type"]);

                    client.Nom = nom;
                    client.Prenom = prenom;
                    client.IdClient = idClient;
                    client.Email = email;
                    client.Telephone = telephone;
                    client.Type = type;

                    string nomAdresse = sqlDataReader["NomAdresse"].ToString();
                    string numero = sqlDataReader["Numero"].ToString();
                    string voie = sqlDataReader["Voie"].ToString();
                    string ville = sqlDataReader["Ville"].ToString();
                    string codePostal = sqlDataReader["CodePostal"].ToString();

                    client.Adresse.NomAdresse = nomAdresse;
                    client.Adresse.Numero = numero;
                    client.Adresse.Voie = voie;
                    client.Adresse.Ville = ville;
                    client.Adresse.CodePostal = codePostal;

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

            return client;
        }

        public void AddClient(string nom, string prenom, string telephone, string email, string login, string password, bool type, string nomAdresse, string numero, string voie, string ville, string departement)
        {

            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[12];

                SqlParameter paramNom = new SqlParameter();
                paramNom.ParameterName = "@Nom";
                paramNom.Value = nom;
                sqlParameters[0] = paramNom;

                SqlParameter paramPrenom = new SqlParameter();
                paramPrenom.ParameterName = "@Prenom";
                paramPrenom.Value = prenom;
                sqlParameters[1] = paramPrenom;


                SqlParameter paramTelephone = new SqlParameter();
                paramTelephone.ParameterName = "@Telephone";
                paramTelephone.Value = telephone;
                sqlParameters[2] = paramTelephone;

                SqlParameter paramEmail = new SqlParameter();
                paramEmail.ParameterName = "@Email";
                paramEmail.Value = email;
                sqlParameters[3] = paramEmail;

                SqlParameter paramLogin = new SqlParameter();
                paramLogin.ParameterName = "@Login";
                paramLogin.Value = login;
                sqlParameters[4] = paramLogin;

                SqlParameter paramPassword = new SqlParameter();
                paramPassword.ParameterName = "@Password";
                paramPassword.Value = password;
                sqlParameters[5] = paramPassword;

                SqlParameter paramType = new SqlParameter();
                paramType.ParameterName = "@Type";
                paramType.Value = false;
                sqlParameters[6] = paramType;

                SqlParameter paramNomAdresse = new SqlParameter();
                paramNomAdresse.ParameterName = "@NomAdresse";
                paramNomAdresse.Value = nomAdresse;
                sqlParameters[7] = paramNomAdresse;

                SqlParameter paramNumero = new SqlParameter();
                paramNumero.ParameterName = "@Numero";
                paramNumero.Value = numero;
                sqlParameters[8] = paramNumero;

                SqlParameter paramVoie = new SqlParameter();
                paramVoie.ParameterName = "@Voie";
                paramVoie.Value = voie;
                sqlParameters[9] = paramVoie;

                SqlParameter paramVille = new SqlParameter();
                paramVille.ParameterName = "@Ville";
                paramVille.Value = ville;
                sqlParameters[10] = paramVille;

                SqlParameter paramCodePostal = new SqlParameter();
                paramCodePostal.ParameterName = "@CodePostal";
                paramCodePostal.Value = departement;
                sqlParameters[11] = paramCodePostal;

                base.ExecuteQuery("sp_AddClient", sqlParameters);


                base.sqlConnection.Close();
            }
            catch (Exception ex)
            {
                IsError = true;
                ErrorMsg = ex.Message;
            }

        }

        public void upClient(int idClient, string nom, string prenom, string telephone, string email, string nomAdresse, string numero, string voie, string ville, string codePostal)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[10];


                SqlParameter paramNom = new SqlParameter();
                paramNom.ParameterName = "@Nom";
                paramNom.Value = nom;
                sqlParameters[0] = paramNom;

                SqlParameter paramPrenom = new SqlParameter();
                paramPrenom.ParameterName = "@Prenom";
                paramPrenom.Value = prenom;
                sqlParameters[1] = paramPrenom;

                SqlParameter paramTelephone = new SqlParameter();
                paramTelephone.ParameterName = "@Telephone";
                paramTelephone.Value = telephone;
                sqlParameters[2] = paramTelephone;

                SqlParameter paramEmail = new SqlParameter();
                paramEmail.ParameterName = "@Email";
                paramEmail.Value = email;
                sqlParameters[3] = paramEmail;

                SqlParameter paramNomAdresse = new SqlParameter();
                paramNomAdresse.ParameterName = "@NomAdresse";
                paramNomAdresse.Value = nomAdresse;
                sqlParameters[4] = paramNomAdresse;

                SqlParameter paramNumero = new SqlParameter();
                paramNumero.ParameterName = "@Numero";
                paramNumero.Value = numero;
                sqlParameters[5] = paramNumero;

                SqlParameter paramVoie = new SqlParameter();
                paramVoie.ParameterName = "@Voie";
                paramVoie.Value = voie;
                sqlParameters[6] = paramVoie;

                SqlParameter paramVille = new SqlParameter();
                paramVille.ParameterName = "@Ville";
                paramVille.Value = ville;
                sqlParameters[7] = paramVille;

                SqlParameter paramCodePostal = new SqlParameter();
                paramCodePostal.ParameterName = "@CodePostal";
                paramCodePostal.Value = codePostal;
                sqlParameters[8] = paramCodePostal;

                SqlParameter paramIdClient = new SqlParameter();
                paramIdClient.ParameterName = "@IdClient";
                paramIdClient.Value = idClient;
                sqlParameters[9] = paramIdClient;

                base.ExecuteQuery("sp_upClient", sqlParameters);


                base.sqlConnection.Close();
            }
            catch (Exception ex)
            {
                IsError = true;
                ErrorMsg = ex.Message;
            }

        }

        public void upPassword(int idClient, string password)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[2];


                SqlParameter paramIdClient = new SqlParameter();
                paramIdClient.ParameterName = "@IdClient";
                paramIdClient.Value = idClient;
                sqlParameters[0] = paramIdClient;

                SqlParameter paramPassword = new SqlParameter();
                paramPassword.ParameterName = "@Password";
                paramPassword.Value = password;
                sqlParameters[1] = paramPassword;

                base.ExecuteQuery("sp_upPassword", sqlParameters);

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