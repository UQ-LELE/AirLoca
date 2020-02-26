using AirLoca.DAO;
using AirLoca.Entities;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace AirLoca
{
    public partial class DetailHebergement : System.Web.UI.Page
    {
        private Client client;
        private List<Hebergement> hebergements;
        private List<Hebergement> mesFavoris;
        private List<Avis> avis;
        public Hebergement detail { get; set; }
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
                client = (Client)Session["client"];
                hebergements = LoadHebergements();

                if (!IsPostBack)
                {

                    if (Request.QueryString != null)
                    {
                        int index = Convert.ToInt32(Request.QueryString["id"]);

                        foreach (Hebergement item in hebergements)
                        {
                            if (item.IdHebergement == index)
                            {
                                Session["detail"] = item;
                            }
                        }
                    }
                    else if (Session["detail"] == null)
                    {
                        Response.Redirect("Default.aspx");
                    }

                    detail = (Hebergement)Session["detail"];
                    this.Image1.ImageUrl = detail.Photo;

                    avis = LoadAvis(detail.IdHebergement);

                    if(avis != null && avis.Count > 0)
                    {
                        this.WithAvis.Visible = true;
                        lvwCommentaire.DataSource = avis;
                        lvwCommentaire.DataBind();
                    }
                    else
                    {
                        this.NoAvis.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Hebergement> LoadHebergements()
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

        private List<Avis> LoadAvis(int idHebergement)
        {
            try
            {
                DaoAvis daoAvis = new DaoAvis();
                return daoAvis.GetAvis(idHebergement);
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
                if (client != null)
                {
                    detail = (Hebergement)Session["detail"];
                    int index = detail.IdHebergement;

                    DaoFavoris favorite = new DaoFavoris();
                    mesFavoris = favorite.GetFavoris(client.IdClient);

                    foreach (Hebergement item in mesFavoris)
                    {
                        if (item.IdHebergement == index)
                        {
                            Response.Redirect("Default.aspx");
                            //ajouter label indiquant que l'hebergement est déjà en favoris ?
                        }
                        else
                        {
                            DaoFavoris daoFavoris = new DaoFavoris();
                            daoFavoris.AddFavorite(client.IdClient, index);

                            Response.Redirect("Favoris.aspx");
                        }
                    }
                }
                else
                {
                    Response.Redirect("Connexion.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnReserver_Click1(object sender, EventArgs e)
        {
            try
            {
                detail = (Hebergement)Session["detail"];
                int index = detail.IdHebergement;
                hebergements = LoadHebergements();

                foreach (Hebergement item in hebergements)
                {
                    if (item.IdHebergement == index)
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
};