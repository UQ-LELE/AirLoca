using AirLoca.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AirLoca.DAO
{
    //pour pouvoir utiliser les méthodes qui sont dans DataAccess on fait un héritage de DataAccess grace aux : (deux points) DataAccess  (et c'est public)

    public class DaoHebergement : DataAccess
    {
        // les deux points (:) base sert à rappeller le constructeur
        public DaoHebergement() : base()
        {

        }

        public List<Hebergement> GetHebergement(string typeHebergement, string departementSelect)
        {
            List<Hebergement> hebergements = null;

            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                if (!string.IsNullOrEmpty(typeHebergement))
                {
                    sqlParameters.Add(new SqlParameter("@Type", typeHebergement));
                }

                if (!string.IsNullOrEmpty(departementSelect))
                {
                    sqlParameters.Add(new SqlParameter("@CodePostal", departementSelect));
                }


                //on execute l'opération sql qui nous renvoie un tableau
                //les données sont stocjer dans un objet de type DataReader
                //execute.reader() car ici on recupere des information (select from), si "insert" "update" "delete", alors pas de renvoie, on utilise un execute.NonQuery().
                base.GetDataReader("sp_getHebergement", sqlParameters.ToArray());
                //select * from Adresse A inner join Hebergement H on H.IdAdresse = A.IdAdresse

                //on créé une liste d'hebergement avec instruction conditionnelle; HasRows = s'il a encore une ligne
                if (base.sqlDataReader.HasRows)
                    hebergements = new List<Hebergement>();

                while (sqlDataReader.Read())
                {
                    string nom = (string)sqlDataReader["Nom"];
                    string description = (string)sqlDataReader["Description"];
                    string photo = (string)sqlDataReader["Photo"];
                    int idClient = Convert.ToInt32(sqlDataReader["IdClient"]);
                    int idHebergement = Convert.ToInt32(sqlDataReader["IdHebergement"]);
                    int idAdresse = Convert.ToInt32(sqlDataReader["IdAdresse"]);
                    string ville = (string)sqlDataReader["Ville"];
                    string departement = (string)sqlDataReader["CodePostal"];
                    string type = (string)sqlDataReader["Type"];
                    double prixDeBase = Convert.ToDouble(sqlDataReader["PrixDeBase"]);


                    Hebergement hebergement = new Hebergement();
                    hebergement.Nom = nom;
                    hebergement.Description = description;
                    hebergement.Photo = photo;
                    hebergement.IdHebergement = idHebergement;
                    hebergement.IdAdresse = idAdresse;
                    hebergement.Adresse.Ville = ville;
                    hebergement.Adresse.CodePostal = departement;
                    hebergement.Type = type;
                    hebergement.IdClient = idClient;
                    hebergement.PrixDeBase = prixDeBase;

                    hebergements.Add(hebergement);
                }

                base.sqlDataReader.Close();
                base.sqlConnection.Close();
            }
            catch (Exception ex)
            {
                IsError = true;
                ErrorMsg = ex.Message;

            }

            return hebergements;
        }

    }

}
