using AirLoca.DAO;
using AirLoca.Entities;
using System;
using System.Web.UI;

namespace AirLoca
{
    public partial class MesCoordonnees : PageBase
    {
        public string TabCoordonnees { get; set; }
        public string TabLogin { get; set; }

        private Client client;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                TabCoordonnees = "active";
                client = (Client)Session["client"];
                if (!IsPostBack)
                {

                    if (client != null)
                    {
                        this.txtNom.Text = client.Nom;
                        this.txtPrenom.Text = client.Prenom;
                        this.txtEmail.Text = client.Email;
                        this.txtTelephone.Text = client.Telephone;
                        this.txtNumero.Text = client.Adresse.Numero;
                        this.txtVoie.Text = client.Adresse.Voie;
                        this.txtVille.Text = client.Adresse.Ville;
                        this.txtCodePostal.Text = client.Adresse.CodePostal;

                    }
                    else
                    {
                        Response.Redirect("Connexion.aspx");
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        protected void btnValidateCoord_Click(object sender, EventArgs e)
        {
            try {
                int idClient = client.IdClient;
                string nom = this.txtNom.Text.Trim();
                string prenom = this.txtPrenom.Text.Trim();
                string email = this.txtEmail.Text.Trim();
                string telephone = this.txtTelephone.Text.Trim();

                string voie = this.txtVoie.Text.Trim();
                string codePostal = this.txtCodePostal.Text.Trim();
                string ville = this.txtVille.Text.Trim();
                string numero = this.txtNumero.Text.Trim();
                string nomAdresse = null;

                client.Adresse.Numero = numero;
                client.Adresse.Voie = voie;
                client.Adresse.Ville = ville;
                client.Adresse.CodePostal = codePostal;
                client.Nom = nom;
                client.Prenom = prenom;
                client.Email = email;
                client.Telephone = telephone;

                Session["client"] = client;


                DaoClient upclient = new DaoClient();
                upclient.upClient(idClient, nom, prenom, telephone, email, nomAdresse, numero, voie, ville, codePostal);

                Session["notify"] = "coordModify";
                Response.Redirect("MesCoordonnees.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnModifyCoord_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnModifyCoord.Visible = false;
                this.btnValidateCoord.Visible = true;
                this.fieldsetCoord.Disabled = false;

                TabLogin = "";
                TabCoordonnees = "active";
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnModifyPass_Click1(object sender, EventArgs e)
        {
            try
            {
                this.btnModifyPass.Visible = false;
                this.btnValidatePass.Visible = true;
                this.fieldsetLogin.Disabled = false;

                TabCoordonnees = "";
                TabLogin = "active";
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnValidatePass_Click1(object sender, EventArgs e)
        {
            try
            {
                string password = this.txtPassword2.Text.Trim();
                int idClient = client.IdClient;

                DaoClient upclient = new DaoClient();
                upclient.upPassword(idClient, password);

                Session["notify"] = "pwModify";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Response.Redirect("MesCoordonnees.aspx");
            }

        }
    }
}