using AirLoca.DAO;
using AirLoca.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirLoca
{
    public partial class MesReservation : System.Web.UI.Page
    {
        public string TabReservation { get; set; }

        private Client client;
        protected void Page_Load(object sender, EventArgs e)
        {

            //BackOffice masterPage = (BackOffice)Page.Master;
            //Client client = masterPage.client;
            client = (Client)Session["client"];
            if (!IsPostBack)
            {
                tabReservation = "active";

                this.lvwReservation.DataSource = LoadReservation();
                this.lvwReservation.DataBind();



                if (client != null)
                {
                    
                    if (LoadReservation() != null)
                    {
                        this.WithResa.Visible = true;
                        this.lvwReservation.DataSource = LoadReservation();
                        this.lvwReservation.DataBind();
                    }
                    else
                    {
                        this.NoResa.Visible = true;
                    }

                }
                else
                {
                    Response.Redirect("Connexion.aspx");
                }
            }



        }


        public List<Hebergement> LoadReservation()
        {
            DaoReservation daoReservation = new DaoReservation();
            return daoReservation.GetReservation(client.IdClient);
        }

        protected void btnAnnulerResa_Click(object sender, EventArgs e)
        {
            int idReserv = Convert.ToInt32(((Button)sender).CommandArgument);

            DaoReservation daoFavoris = new DaoReservation();
            daoFavoris.DeleteReservation(client.IdClient, idReserv);

            this.lvwReservation.DataSource = LoadReservation();
            this.lvwReservation.DataBind();
        }

        protected void lbtFavorisResa_Click(object sender, EventArgs e)
        {

        }
    }
}
