using AirLoca.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirLoca
{
    public partial class TestGvwResponsive : System.Web.UI.Page
    {
        ArrayList mesFavoris = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            mesFavoris = (ArrayList)Session["favoris"];
            if (!IsPostBack)
            {
                this.GridView1.DataSource = mesFavoris;
                this.GridView1.DataBind();
            }

            if (this.GridView1.Rows.Count > 0)
            {
                //Attribute to show the Plus Minus Button.
                //GridView1.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                //Attribute to hide column in Phone.
                GridView1.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
                GridView1.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";

                //Adds THEAD and TBODY to GridView.
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).CommandArgument);

            foreach (Hebergement item in mesFavoris)
            {
                if (item.IdHebergement == id)
                {
                    mesFavoris.Remove(item);
                    break;
                }
            }

            this.GridView1.DataSource = mesFavoris;
            this.GridView1.DataBind();
        }

        protected void btnDelete_Click1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).CommandArgument);

            foreach (Hebergement item in mesFavoris)
            {
                if (item.IdHebergement == id)
                {
                    mesFavoris.Remove(item);
                    break;
                }
            }

            this.GridView1.DataSource = mesFavoris;
            this.GridView1.DataBind();
        }
    }
    
}