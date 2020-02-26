using AirLoca.Entities;
using System;
using System.Collections.Generic;

namespace AirLoca.DAO
{
    public class DaoDepartement : DataAccess
    {
        public DaoDepartement() : base()
        {

        }

        public List<Departement> GetDepartement()
        {
            List<Departement> departements = null;

            try
            {
                base.GetDataReader("select code_departement, nom_departement from departements", null);

                if (base.sqlDataReader.HasRows)
                    departements = new List<Departement>();

                while (sqlDataReader.Read())
                {
                    string nomDepartement = (string)sqlDataReader["nom_departement"];
                    string codeDepartement = (string)sqlDataReader["code_departement"];


                    Departement departement = new Departement();
                    departement.NomDepartement = nomDepartement;
                    departement.CodeDepartement = codeDepartement;

                    departements.Add(departement);
                }

                base.sqlDataReader.Close();
                base.sqlConnection.Close();
            }
            catch (Exception ex)
            {
                IsError = true;
                ErrorMsg = ex.Message;

            }
            return departements;
        }
    }
}