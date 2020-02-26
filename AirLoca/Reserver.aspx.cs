using System;

namespace AirLoca
{
    public partial class Reserver : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["client"] != null)
                {
                    Response.Redirect("Paiement.aspx");
                }

                else
                {
                    Session["notify"] = "log";
                    Response.Redirect("Connexion.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}