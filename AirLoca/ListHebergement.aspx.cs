using AirLoca.DAO;
using AirLoca.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirLoca
{
    public partial class ListHebergement : System.Web.UI.Page
    {
        private Client client;
        private List<Hebergement> hebergements;
        private List<Hebergement> clientFavoris;
        public string departement { get; set; }
        public string typeHebergement { get; set; }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            try
            {
                client = (Client)Session["client"];

                if (client != null)
                {
                    Page.MasterPageFile = "~/BackOffice.Master";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    if (client != null)
                    {
                        clientFavoris = LoadFavoris(); ;
                    }

                    if (Session["recherche"] != null)
                    {
                        Dictionary<string, string> dictionnaireRecherche = new Dictionary<string, string>();
                        dictionnaireRecherche = (Dictionary<string, string>)Session["recherche"];

                        departement = dictionnaireRecherche["departement"];
                        typeHebergement = dictionnaireRecherche["type"];

                        hebergements = LoadHebergements(typeHebergement, departement);
                        if(hebergements != null && hebergements.Count() > 0)
                        {
                            this.Found.Visible = true;
                            this.lvwHebergement.DataSource = hebergements;
                            this.lvwHebergement.DataBind();
                        }
                        else
                        {
                            this.NotFound.Visible = true;
                        }

                        Session.Remove("recherche");
                    }
                    else
                    {
                        hebergements = LoadHebergements();

                        this.lvwHebergement.DataSource = hebergements;
                        this.lvwHebergement.DataBind();
                    }


                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LvwHebergement_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListViewItemType.DataItem)
                {
                    if (client != null)
                    {
                        if (clientFavoris != null)
                        {
                            LinkButton lbtFavoris = (LinkButton)e.Item.FindControl("lbtFavoris");

                            Hebergement hebergement = (Hebergement)e.Item.DataItem;

                            var fav = from h in clientFavoris
                                      where h.IdHebergement == hebergement.IdHebergement
                                      select h;

                            if (fav != null && fav.Count() > 0)
                            {
                                lbtFavoris.CssClass = "btn btn-warning";
                                lbtFavoris.Enabled = false;
                            }
                        }


                    }

                }
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
                client = (Client)Session["client"];

                DaoFavoris daoFavoris = new DaoFavoris();
                return daoFavoris.GetFavoris(client.IdClient);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public List<Hebergement> LoadHebergements()
        {
            return LoadHebergements("", "");
        }


        public List<Hebergement> LoadHebergements(string departement, string typeHebergement)
        {
            try
            {
                DaoHebergement daoHebergement = new DaoHebergement();
                return daoHebergement.GetHebergement(departement, typeHebergement);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void lvwHebergement_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            try
            {
                this.dtpHebergement.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

                this.lvwHebergement.DataSource = LoadHebergements();
                this.lvwHebergement.DataBind();
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

        protected void lbtNom_Click(object sender, EventArgs e)
        {
            try
            {
                string arg = ((LinkButton)sender).CommandArgument;
                int Index = Convert.ToInt32(arg);

                hebergements = LoadHebergements(null, null);

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

        protected void lbtFavoris_Click(object sender, EventArgs e)
        {
            try
            {

                string arg = ((LinkButton)sender).CommandArgument;
                int Index = Convert.ToInt32(arg);

                DaoFavoris daoFavoris = new DaoFavoris();
                daoFavoris.AddFavorite(client.IdClient, Index);

                Session["notify"] = "favoris";
                Response.Redirect("MesFavoris.aspx");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}