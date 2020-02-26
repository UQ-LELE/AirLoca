using AirLoca.Entities;
using System;
using System.Web.UI;

namespace AirLoca
{
    public partial class SiteMaster : MasterPage
    {
        public Client client;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["client"] != null)
            {
                client = (Client)Session["client"];
            }

        }


        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        public void AddError(Exception ex)
        {
            //on récupère toutes les erreurs ici, idéal si on veut enregister dans un log les erreurs. (car toutes les pages sont ratachées à la masterpage)
        }
    }
}