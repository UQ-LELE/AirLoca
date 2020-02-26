using AirLoca.DAO;
using AirLoca.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;

namespace AirLoca
{
    public partial class MesHebergements : PageBase
    {
        private Client client;

        private int idHebergement;

        private string nom;
        private string num;
        private string voie;
        private string ville;
        private string codePostal;
        private string type;
        private int prix;
        private string description;

        public string TabHebergement { get; set; }

        public string TabLocation { get; set; }

        public string TabHistoLoca { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                client = (Client)Session["client"];

                this.lbtCharge.Attributes.Add("onclick", "document.getElementById('" + fupImage.ClientID + "').click(); return false;");

                if (!IsPostBack)
                {
                    TabHebergement = "active";

                    if (client != null)
                    {
                        if (client.Type == false)
                        {
                            this.NotOwner.Visible = true;
                        }
                        else
                        {
                            this.Owner.Visible = true;
                            if (LoadLocation() != null)
                            {
                                lvwOwnerLoc.DataSource = LoadLocation();
                                lvwOwnerLoc.DataBind();
                            }
                            else
                            {
                                this.NoLoc.Visible = true;
                            }
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

        public List<Hebergement> LoadLocation()
        {
            try
            {
                DaoLocation daoLocation = new DaoLocation();
                return daoLocation.GetLocation(client.IdClient);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void BtnDeleteLoc_Click1(object sender, EventArgs e)
        {
            try
            {
                string arg = ((Button)sender).CommandArgument;
                int idHebergement = Convert.ToInt32(arg);

                DaoLocation daoLocation = new DaoLocation();
                daoLocation.DeleteLocation(idHebergement);
                Session["notify"] = "hebDelete";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Response.Redirect("MesHebergements.aspx");
            }
        }

        //protected void BtnValidateLoc_Click1(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int idHebergement = Convert.ToInt32(((Button)sender).CommandArgument);
        //        int idClient = client.IdClient;
        //        string nomHebergement = this.txtNomLoca.Text;
        //        string type = this.ddlTypeLoca.Text;
        //        string description = this.txtDescriptionLoca.Text;
        //        string prix = this.txtPrixLoca.Text;
        //        bool statut = true;
        //        string nomAdresse = "Location";
        //        string numero = this.txtNumLoca.Text;
        //        string voie = this.txtVoieLoca.Text;
        //        string ville = this.txtVilleLoca.Text;
        //        string codePostal = this.txtCPLoca.Text;

        //        double prixDeBase = Convert.ToDouble(prix);


        //        DaoLocation daoLocation = new DaoLocation();
        //        daoLocation.UpLocation(idClient, nomHebergement, type, description, statut, nomAdresse, numero, voie, ville, codePostal, prixDeBase);


        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        Response.Redirect("MesHebergements.aspx");
        //    }
        //}

        protected bool ValidationEx(string ex)
        {
            List<string> extension = new List<string>();
            extension.Add("image/jpg");
            extension.Add("image/png");
            extension.Add("image/jpeg");
            extension.Add("image/gif");

            return extension.Contains(ex);

        }

        protected void BtnAddLoc_Click1(object sender, EventArgs e)
        {
            try
            {
                int idClient = client.IdClient;
                string nomHebergement = this.txtNomLoc.Text;
                string type = this.ddlTypeLoc.Text;
                string description = this.txtDescriptionLoc.Text;
                bool statut = true;
                int prixDeBase = Convert.ToInt32(this.txtPrixLoc.Text);
                string nomAdresse = "Location";
                string numero = this.txtNumLoc.Text;
                string voie = this.txtVoieLoc.Text;
                string ville = this.txtVilleLoc.Text;
                string codePostal = this.txtCPLoc.Text;

                string folderPath = Server.MapPath("~/Images/");
                string imageFileName = Path.GetFileName(fupImage.FileName);
                string ex = fupImage.PostedFile.ContentType;

                if (ValidationEx(ex) && fupImage.PostedFile.ContentLength < 1000000)
                {
                    string fullPath = folderPath + imageFileName;
                    fupImage.SaveAs(fullPath);

                    string photo = "Images/" + imageFileName;

                    DaoLocation daoLocation = new DaoLocation();
                    daoLocation.AddLocation(client.IdClient, nomHebergement, type, description, photo, statut, nomAdresse, numero, voie, ville, codePostal, prixDeBase);
                }
                else
                {
                    string photo = "~/Images/default.jpg";
                    DaoLocation daoLocation = new DaoLocation();
                    daoLocation.AddLocation(client.IdClient, nomHebergement, type, description, photo, statut, nomAdresse, numero, voie, ville, codePostal, prixDeBase);
                }

                this.NotOwner.Visible = false;
                this.Owner.Visible = true;

                if (LoadLocation() != null)
                {
                    lvwOwnerLoc.DataSource = LoadLocation();
                    lvwOwnerLoc.DataBind();
                }
                else
                {
                    this.NoLoc.Visible = true;
                }

                TabHebergement = "active";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        protected void BtnValidateLoc_Click(object sender, EventArgs e)
        {
            idHebergement = Convert.ToInt32(((Button)sender).CommandArgument);

            try {

                foreach (ListViewItem item in lvwOwnerLoc.Items)
                {
                    TextBox txtNomLoca = (TextBox)item.FindControl("txtNomLoca");
                    TextBox txtNumLoca = (TextBox)item.FindControl("txtNumLoca");
                    TextBox txtVoieLoca = (TextBox)item.FindControl("txtVoieLoca");
                    TextBox txtVilleLoca = (TextBox)item.FindControl("txtVilleLoca");
                    TextBox txtCPLoca = (TextBox)item.FindControl("txtCPLoca");
                    DropDownList ddlTypeLoca = (DropDownList)item.FindControl("ddlTypeLoca");
                    TextBox txtDescriptionLoca = (TextBox)item.FindControl("txtDescriptionLoca");
                    TextBox txtPrixLoca = (TextBox)item.FindControl("txtPrixLoca");

                    if (Convert.ToInt32(txtNomLoca.ToolTip) == idHebergement)
                    {
                        nom = txtNomLoca.Text;
                    }

                    if (Convert.ToInt32(txtNumLoca.ToolTip) == idHebergement)
                    {
                        num = txtNumLoca.Text;
                    }

                    if (Convert.ToInt32(txtVoieLoca.ToolTip) == idHebergement)
                    {
                        voie = txtVoieLoca.Text;
                    }

                    if (Convert.ToInt32(txtVilleLoca.ToolTip) == idHebergement)
                    {
                        ville = txtVilleLoca.Text;
                    }

                    if (Convert.ToInt32(txtCPLoca.ToolTip) == idHebergement)
                    {
                        codePostal = txtCPLoca.Text;
                    }

                    if (Convert.ToInt32(ddlTypeLoca.ToolTip) == idHebergement)
                    {
                        type = ddlTypeLoca.SelectedValue;
                    }

                    if (Convert.ToInt32(txtPrixLoca.ToolTip) == idHebergement)
                    {
                        prix = Convert.ToInt32(txtPrixLoca.Text);
                    }

                    if (Convert.ToInt32(txtDescriptionLoca.ToolTip) == idHebergement)
                    {
                        description = txtDescriptionLoca.Text;
                    }
                }
                bool statut = true;
                string nomAdresse = "Location";
                DaoLocation daoLocation = new DaoLocation();
                daoLocation.UpLocation(client.IdClient, nom, type, description, statut, nomAdresse, num, voie, ville, codePostal, prix, idHebergement);

                if (LoadLocation() != null)
                {
                    lvwOwnerLoc.DataSource = LoadLocation();
                    lvwOwnerLoc.DataBind();
                }
                else
                {
                    this.NoLoc.Visible = true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Response.Redirect("MesHebergements.aspx");
            }

        }


    }
}