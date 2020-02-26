using AirLoca.DAO;
using AirLoca.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace AirLoca
{
    public partial class Paiement : PageBase
    {
        private List<Hebergement> hebergements;
        private Hebergement reservation;
        private Client client;
        private List<Hebergement> DateReserved;

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

                hebergements = new List<Hebergement>();

                reservation = (Hebergement)Session["reservation"];
                hebergements.Add(reservation);


                if (!IsPostBack)
                {
                    this.lvwHebergement.DataSource = hebergements;
                    this.lvwHebergement.DataBind();
                    this.lblPrixBase.Text = Convert.ToString(reservation.PrixDeBase) + " €/nuit.";

                    //DateReserved = GetDateReserved();

                    //if (DateReserved != null)
                    //{
                    //    StringBuilder sb = new StringBuilder();
                    //    sb.Append("<script type='text/javascript'>");
                    //    sb.Append("var disabledArr = [");
                    //    foreach (Hebergement item in DateReserved)
                    //    {
                    //        sb.Append("\"" + item.Reservation.DateDebut.ToString("dd/MM/yyyy") + "\",");
                    //    }
                    //    sb.Append("];");
                    //    sb.Append("</script>");

                    //    if (!ClientScript.IsClientScriptBlockRegistered("ScriptDateDisable"))
                    //    {
                    //        ClientScript.RegisterClientScriptBlock(this.GetType(), "ScriptDateDisable", sb.ToString());
                    //    }
                    //}

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public List<Hebergement> GetDateReserved()
        {
            try
            {
                reservation = (Hebergement)Session["reservation"];

                DaoReservation daoReservation = new DaoReservation();
                return daoReservation.GetReservationLoc(reservation.IdHebergement);
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
                int idHebergement = reservation.IdHebergement;
                int idClient = client.IdClient;
                double prix = reservation.PrixDeBase;
                DateTime dateReservation = DateTime.Now;

                string[] dateRange = (Request.Form["datefilter"]).Split('-');
                DateTime dateDebut = DateTime.Parse(dateRange[0]);
                DateTime dateFin = DateTime.Parse(dateRange[1]);
                TimeSpan duree = dateFin.Subtract(dateDebut);
                int days = Convert.ToInt32(duree.TotalDays);

                double prixTotal = prix * days;

                DaoReservation daoReservation = new DaoReservation();
                daoReservation.AddReservation(idHebergement, idClient, dateReservation, dateDebut, dateFin, prixTotal);

                Session["notify"] = "reservation";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Session.Remove("reservation");

                Response.Redirect("MesResas.aspx");
            }

        }
    }
}
