using System;

namespace AirLoca
{
    public partial class Deconnexion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("client");
            Session["notify"] = "deconnexion";
            Response.Redirect("Default.aspx");
        }
    }
}