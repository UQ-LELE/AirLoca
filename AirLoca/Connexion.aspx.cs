using AirLoca.DAO;
using AirLoca.Entities;
using System;

namespace AirLoca
{
    public partial class Connexion : PageBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConnexion_Click(object sender, EventArgs e)
        {
            try
            {
                string login = this.txtLogin.Text;
                string password = this.txtPassword.Text;

                DaoClient daoclient = new DaoClient();
                Client client = daoclient.GetClient(login, password);
                Session["client"] = client;

                if (client != null)
                {
                    Session["notify"] = "connexion";
                    string ReturnUrl = Convert.ToString(Request.QueryString["url"]);
                    if (!string.IsNullOrEmpty(ReturnUrl))
                    {
                        Response.Redirect(ReturnUrl);
                    }
                    else
                    {
                        Response.Redirect("MesResas.aspx");
                    }
                }
                else
                {
                    lblError.Visible = true;
                    this.lblError.Text = "Identifiant ou mot de passe incorrect";

                }
            }
            catch (Exception ex)
            {
                //ici on peut récupérer une erreur venu d'une ou plusieur couche en-dessous via throw. ex : il peut ensuite etre transmis dans un label aspx
                string error = ex.Message;
                throw ex;
                //on peut encore renvoyer l'erreur au plus haut niveau, la masterPage
                //(SiteMaster)this.Page.Master;
            }

        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreerCompte.aspx");
        }
    }
}