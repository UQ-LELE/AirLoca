using AirLoca.DAO;
using AirLoca.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirLoca
{
    public partial class MesResas : PageBase
    {
        public string TabReservation { get; set; }
        public string TabHistoResa { get; set; }

        private Client client;
        private List<Hebergement> clientFavoris;
        private List<Hebergement> mesReservations;
        private List<Hebergement> Resas;

        private List<Hebergement> HistoResas;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                client = (Client)Session["client"];
                if (!IsPostBack)
                {
                    TabReservation = "active";
                    clientFavoris = LoadFavoris();
                    mesReservations = LoadReservation();

                    if (client != null)
                    {
                        if (mesReservations != null && mesReservations.Count > 0)
                        {
                            this.WithResa.Visible = true;
                            Resas = new List<Hebergement>();
                            HistoResas = new List<Hebergement>();

                            foreach (Hebergement item in mesReservations)
                            {
                                if (item.Reservation.DateFin > DateTime.Now)
                                {
                                    Resas.Add(item);
                                }
                                else
                                {
                                    HistoResas.Add(item);
                                }
                            }
                            this.lvwReservation.DataSource = Resas;
                            this.lvwReservation.DataBind();

                            this.lvwHistoResa.DataSource = HistoResas;
                            this.lvwHistoResa.DataBind();

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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Hebergement> LoadReservation()
        {
            try
            {
                DaoReservation daoReservation = new DaoReservation();
                return daoReservation.GetReservation(client.IdClient);
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
                DaoFavoris daoFavoris = new DaoFavoris();
                return daoFavoris.GetFavoris(client.IdClient);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void lbtFavorisResa_Click(object sender, EventArgs e)
        {
            try
            {            
                if (client != null)
                {
                    int arg = Convert.ToInt32(((LinkButton)sender).CommandArgument);

                    DaoFavoris daoFavoris = new DaoFavoris();
                    daoFavoris.AddFavorite(client.IdClient, arg);

                    Response.Redirect("MesFavoris.aspx");
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

        protected void btnOkAnnulerResa_Click1(object sender, EventArgs e)
        {
            try
            {

                int idReservation = Convert.ToInt32(this.cancelModal.Value);

                DaoReservation daoReservation = new DaoReservation();
                daoReservation.DeleteReservation(client.IdClient, idReservation);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Response.Redirect("MesResas.aspx");
            }

        }

        protected void btnEnvoyer_Click(object sender, EventArgs e)
        {
            try
            {
                int idDestinataire = Convert.ToInt32(this.sendContact.Value);
                int idHebergement = Convert.ToInt32(this.sendHebergement.Value);
                int idExpediteur = client.IdClient;
                string message = this.txtMessage.Text;
                bool statut = false;
                DateTime date = DateTime.Now;


                DaoMessage daoMessage = new DaoMessage();
                daoMessage.AddMessage(idDestinataire, idExpediteur, message, statut, date, idHebergement);
                Session["notify"] = "message";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Response.Redirect("MesResas.aspx");
            }
        }

        protected void lvwReservation_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListViewItemType.DataItem)
                {
                    if (client != null)
                    {
                        if (clientFavoris != null)
                        {
                            LinkButton lbtFavoris = (LinkButton)e.Item.FindControl("lbtFavorisResa");

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

        protected void btnAvis_Click(object sender, EventArgs e)
        {
            try
            {
                int idHebergement = Convert.ToInt32(this.sendIdHeb.Value);
                string commentaire = this.txtAvis.Text;
                bool statut = true;
                DateTime date = DateTime.Now;
                int note = 4;

                DaoAvis daoAvis = new DaoAvis();
                daoAvis.AddAvis(client.IdClient, idHebergement, note, commentaire, statut, date);
                Session["notify"] = "avis";

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Response.Redirect("MesResas.aspx");
            }
        }
    }
}