using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AirLoca.DAO
{
    public class DataAccess
    {

        public SqlConnection sqlConnection;
        public SqlDataReader sqlDataReader;
        public bool IsError { get; set; }
        public string ErrorMsg { get; set; }

        public DataAccess()
        {
            //on définit la chaîne de connection à la base
            string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=AirLoca;Integrated Security=True";
            


            //objet pour se connecter à la base de donnée
            sqlConnection = new SqlConnection(connectionString);




        }

        //ici on récupère seulement le DataReader selon la requête qui est en paramêtre sqlQuery; c'est un module générique <-- version old
        //ici on récupère le DataReader selon les paramètre sqlQuery et sql parameters.
        public bool GetDataReader(string sqlQuery, SqlParameter[] sqlParamenters)
        {
            //objet pour executer la requete
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            sqlDataReader = null;
            IsError = false;
            ErrorMsg = "";

            try
            {
                //on se connecte à la base de donnée
                sqlConnection.Open();

                if (sqlParamenters != null && sqlParamenters.Length > 0)
                {
                    sqlCommand.Parameters.AddRange(sqlParamenters);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                }

                //on execute l'opération sql qui nous renvoie un tableau
                //les données sont stocjer dans un objet de type DataReader
                //execute.reader() car ici on recupere des information (select from), si "insert" "update" "delete", alors pas de renvoie, on utilise un execute.NonQuery().
                sqlDataReader = sqlCommand.ExecuteReader();

            }
            catch (Exception ex)
            {
                IsError = true;
                ErrorMsg = ex.Message;
                //transmission de l'erreur au niveau supérieur (c.a.d. par exemple sur DaoClient qui utilise le DataAccess
                throw ex;
            }
            return IsError;
        }

        public bool ExecuteQuery(string sqlQuery, SqlParameter[] sqlParamenters)
        {
            //objet pour executer la requete
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            IsError = false;
            ErrorMsg = "";

            try
            {
                //on se connecte à la base de donnée
                sqlConnection.Open();

                if (sqlParamenters != null && sqlParamenters.Length > 0)
                {
                    sqlCommand.Parameters.AddRange(sqlParamenters);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                }

                //on execute l'opération sql qui nous renvoie un tableau
                //les données sont stocjer dans un objet de type DataReader
                //execute.reader() car ici on recupere des information (select from), si "insert" "update" "delete", alors pas de renvoie, on utilise un execute.NonQuery().
                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                IsError = true;
                ErrorMsg = ex.Message;
            }
            return IsError;
        }
    }
}