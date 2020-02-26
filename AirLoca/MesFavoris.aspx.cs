using AirLoca.DAO;
using AirLoca.Entities;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirLoca
{
    public partial class MesFavoris : Page
    {
        private List<Hebergement> hebergements;
        private Client client;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                client = (Client)Session["client"];

                if (!IsPostBack)
                {
                    if (Session["client"] != null)
                    {
                        this.lvwFavoris.DataSource = LoadFavoris();
                        this.lvwFavoris.DataBind();
                    }
                    else
                    {
                        Session["notify"] = "log";
                        Response.Redirect("Connexion.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Hebergement> LoadHebergements()
        {
            try
            {
                DaoHebergement daoHebergement = new DaoHebergement();
                return daoHebergement.GetHebergement(null, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Hebergement> LoadFavoris()
        {
            try
            {
                Client client = (Client)Session["client"];

                DaoFavoris daoFavoris = new DaoFavoris();
                return daoFavoris.GetFavoris(client.IdClient);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lbtSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(((LinkButton)sender).CommandArgument);

                DaoFavoris daoFavoris = new DaoFavoris();
                daoFavoris.DeleteFavoris(client.IdClient, id);

                this.lvwFavoris.DataSource = LoadFavoris();
                this.lvwFavoris.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lbtNom_Click(object sender, EventArgs e)
        {
            try
            {
                string arg = ((LinkButton)sender).CommandArgument;
                int Index = Convert.ToInt32(arg);

                hebergements = LoadHebergements();

                foreach (Hebergement item in hebergements)
                {
                    if (item.IdHebergement == Index)
                    {
                        Session["detail"] = item;
                        Response.Redirect("DetailHebergement.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnReserver_Click(object sender, EventArgs e)
        {
            try
            {
                string arg = ((Button)sender).CommandArgument;
                int Index = Convert.ToInt32(arg);

                hebergements = LoadHebergements();

                foreach (Hebergement item in hebergements)
                {
                    if (item.IdHebergement == Index)
                    {
                        Session["reservation"] = item;
                        Response.Redirect("Reserver.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }

}