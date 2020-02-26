using AirLoca.DAO;
using AirLoca.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirLoca
{
    public partial class MesMessages : PageBase
    {
        private Client client;
        int i = 0;
        Messagerie mesMes;
        List<Messagerie> messages;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                client = (Client)Session["client"];

                messages = GetSujet();

                if (!IsPostBack)
                {
                    lvwSujet.DataSource = messages;
                    lvwSujet.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private List<Messagerie> GetSujet()
        {
            DaoMessage daoMessage = new DaoMessage();
            return daoMessage.GetAllMessage(client.IdClient);
        }

        protected void lbtSujet_Click(object sender, EventArgs e)
        {
            try
            {
                string arg = ((LinkButton)sender).CommandArgument;
                string[] args = arg.Split('-');
                int idContact = Convert.ToInt32(args[0]);
                int idHebergement = Convert.ToInt32(args[1]);

                DaoMessage daoMessage = new DaoMessage();
                List<Messagerie> mesMessages = daoMessage.GetMyMessage(client.IdClient, idContact, idHebergement);

                lvwTitre.DataSource = mesMessages;
                lvwTitre.DataBind();

                lvwMessage.DataSource = mesMessages;
                lvwMessage.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void lvwSujet_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListViewItemType.DataItem)
                {

                    LinkButton lbtSujet = (LinkButton)e.Item.FindControl("lbtSujet");

                    Messagerie mesMes = (Messagerie)e.Item.DataItem;

                    lbtSujet.CommandArgument = mesMes.IdContact + "-" + mesMes.IdHebergement;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lvwMessage_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListViewItemType.DataItem)
                {

                    Literal ltrMessage = (Literal)e.Item.FindControl("ltrMessage");

                    mesMes = (Messagerie)e.Item.DataItem;

                    //this.Label1.Text = mesMes.NomHebergement;

                    StringBuilder stbMessage = new StringBuilder();

                    if (mesMes.IdExpediteur == client.IdClient)
                    {
                        stbMessage.AppendLine("<div class='d-flex justify-content-end ml-5 mr-1'>");
                        stbMessage.AppendLine("<div class='msgBox bg-primary d-inline-block text-light p-2 ml-auto mb-3'>");
                        stbMessage.AppendLine("<p class='mb-1'>" + mesMes.Message + "</p>");
                        stbMessage.AppendLine("<p><small class='text-light font-weight-light pull-right'>" + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR"), "{0:d MMM yyyy}", mesMes.Date) + "</small></p>");
                        ltrMessage.Text = stbMessage.ToString();
                    }
                    else
                    {
                        stbMessage.AppendLine("<div class='d-flex justify-content-start mr-5'>");
                        stbMessage.AppendLine("<div class='msgBox bg-light p-2 d-inline-block mr-auto mb-3'>");
                        stbMessage.AppendLine("<p class='mb-1'><small class='text-muted font-weight-light'>" + mesMes.PrenomContact + " " + mesMes.NomContact[0] + "." + "</small></p>");
                        stbMessage.AppendLine("<p class='mb-1 ml-1'>" + mesMes.Message + "</p>");
                        stbMessage.AppendLine("<p class='mb-1'><small class='text-muted font-weight-light'> " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR"), "{0:d MMM yyyy}", mesMes.Date) + "</small></p>");
                        ltrMessage.Text = stbMessage.ToString();
                    }
                    stbMessage.AppendLine("</div>");
                    stbMessage.AppendLine("</div>");
                    ltrMessage.Text = stbMessage.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                int idContact = Convert.ToInt32(this.sendContact.Value);
                int idHebergement = Convert.ToInt32(this.sendHebergement.Value);
                int idExpediteur = client.IdClient;
                string message = this.txtMessage.Text;
                bool statut = false;
                DateTime date = DateTime.Now;

                DaoMessage daoMessage = new DaoMessage();
                daoMessage.AddMessage(idContact, idExpediteur, message, statut, date, idHebergement);

                List<Messagerie> mesMessages = daoMessage.GetMyMessage(client.IdClient, idContact, idHebergement);

                string script = "$.notify({ message: 'Votre message a été envoyé avec succès '},{type: 'success'}); ";

                Page.ClientScript.RegisterStartupScript(this.GetType(), "FunctionNotify", script, true);

                lvwMessage.DataSource = mesMessages;
                lvwMessage.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        protected void lvwTitre_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                Literal ltrTitre = (Literal)e.Item.FindControl("ltrTitre");

                Messagerie mesMes = (Messagerie)e.Item.DataItem;

                StringBuilder stbTitre = new StringBuilder();

                if (i == 0)
                {
                    stbTitre.AppendLine("<h4><label>" + mesMes.NomHebergement + "<small class='text-muted font-weight-light'>" + " - " + mesMes.PrenomContact + " " + mesMes.NomContact[0] + "." + "</small></label></h4><button type='button' class='btn btn-primary' data-toggle='modal' data-target='#Message' onclick='sendModal(" + mesMes.IdContact + "," + mesMes.IdHebergement + ")'><span class='fas fa-pen-square'></span>&nbsp;&nbsp;Répondre</button><hr/>");
                    ltrTitre.Text = stbTitre.ToString();
                    i++;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}