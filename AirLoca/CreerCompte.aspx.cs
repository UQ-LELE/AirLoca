using AirLoca.DAO;
using AirLoca.Entities;
using System;
using System.Collections.Generic;

namespace AirLoca
{
    public partial class CreerCompte : System.Web.UI.Page
    {
        public Client client;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public List<Departement> LoadDepartements()
        {
            try
            {
                DaoDepartement daodepartement = new DaoDepartement();
                return daodepartement.GetDepartement();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string nom = this.txtNom.Text.Trim();
                string prenom = this.txtPrenom.Text.Trim();
                string email = this.txtEmail.Text.Trim();
                string telephone = this.txtTelephone.Text.Trim();
                string login = this.txtLogin.Text.Trim();
                string password = this.txtPassword.Text.Trim();
                bool type = false;

                string voie = this.txtVoie.Text.Trim();
                string codePostal = this.txtCodePostal.Text.Trim();
                string ville = this.txtVille.Text.Trim();
                string numero = this.txtNumero.Text.Trim();
                string nomAdresse = "Domicile";

                Client client = new Client();
                client.Nom = nom;
                client.Prenom = prenom;
                client.Telephone = telephone;
                client.Login = login;
                client.Password = password;
                client.Email = email;
                client.Type = type;

                client.Adresse.Numero = numero;
                client.Adresse.Voie = voie;
                client.Adresse.Ville = ville;
                client.Adresse.CodePostal = codePostal;
                client.Adresse.NomAdresse = nomAdresse;

                Session["client"] = client;

                DaoClient daoclient = new DaoClient();
                daoclient.AddClient(nom, prenom, telephone, email, login, password, type, nomAdresse, numero, voie, ville, codePostal);

                Response.Redirect("Connexion.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}