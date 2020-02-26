using AirLoca.DAO;
using AirLoca.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.UI;

namespace AirLoca
{
    public partial class _Default :PageBase
    {

        static Random rnd = new Random();
        private int i;
        private Client client;
        public string departement { get { return this.ddlDepartements.SelectedValue; } }
        public string typeHergement { get { return this.ddlTypeHebergement.SelectedValue; } }


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
                i = 0;
                List<Departement> departements = LoadDepartements();
                List<Hebergement> LotAleatoire = new List<Hebergement>();

                if (!IsPostBack)
                {
                    List<Hebergement> hebergements = LoadHebergements();
                    Application["listHebergement"] = hebergements;

                    //LoadDropDownList Departements
                    DataTable table = new DataTable();
                    table.Columns.Add("CodeDepartement", typeof(string));
                    table.Columns.Add("NomCodeDepartement", typeof(string));

                    foreach (Departement item in departements)
                    {
                        table.Rows.Add(item.CodeDepartement, item.CodeDepartement + " - " + item.NomDepartement);
                    }

                    ddlDepartements.DataSource = table;
                    ddlDepartements.DataTextField = "NomCodeDepartement";
                    ddlDepartements.DataValueField = "CodeDepartement";
                    ddlDepartements.DataBind();

                    //LoadRandom Carousel
                    int NombreHebergement = 3;
                    do
                    {
                        LotAleatoire.Add(hebergements[rnd.Next(hebergements.Count)]);
                    } while (LotAleatoire.Count < NombreHebergement);

                    //Variante au AppendLine : ici on peut transmettre un valeur à id, cette valeur est indiquée après la virgule. Si plusieurs valeurs, indiquer le nb de valeur attendue dans {} et mettre autant de valeur après la virgule;
                    //String.Format("<a href='DetailHebergement.aspx?id={0}", 1);

                    StringBuilder stringBuilder = new StringBuilder();

                    foreach (Hebergement item in LotAleatoire)
                    {

                        if (i == 0)
                        {
                            stringBuilder.AppendLine("<div class='carousel-item active'>");
                            i++;
                        }
                        else
                        {
                            stringBuilder.AppendLine("<div class='carousel-item'>");
                            i++;
                        }
                        stringBuilder.AppendLine("<a href='DetailHebergement.aspx?id=" + item.IdHebergement + "'>");
                        stringBuilder.AppendLine("<img class='d-block w-100' src='" + Convert.ToString(item.Photo) + "' alt='Other slide'></a>");
                        stringBuilder.AppendLine("<div class='carousel-caption d-none d-md-block'>");
                        stringBuilder.AppendLine("<h5>" + Convert.ToString(item.Nom) + "</h5></div></div>");

                        this.ltrCarousel.Visible = true;
                        this.ltrCarousel.Text = stringBuilder.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Departement> LoadDepartements()
        {
            try
            {
                DaoDepartement daodepartement = new DaoDepartement();
                return daodepartement.GetDepartement();
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

        protected void btnRechercher_Click(object sender, EventArgs e)
        {
            try
            {              
                Dictionary<string, string> dictionnaireRecherche = new Dictionary<string, string>();
                dictionnaireRecherche.Add("departement", this.ddlDepartements.SelectedValue);
                dictionnaireRecherche.Add("type", this.ddlTypeHebergement.SelectedValue);
                Session["Recherche"] = dictionnaireRecherche;
                Response.Redirect("ListHebergement.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }


}


