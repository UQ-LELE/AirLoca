using AirLoca.Entities;
using System;

namespace AirLoca
{
    public partial class BackOffice : System.Web.UI.MasterPage
    {

        public Client client { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["client"] != null)
            {
                client = (Client)Session["client"];
            }

            if (client == null)
            {
                Response.Redirect("Connexion.apsx");
            }

        }

        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}