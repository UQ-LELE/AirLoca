using AirLoca.DAO;
using AirLoca.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirLoca
{
    public partial class TestRandomItem : System.Web.UI.Page
    {
        static Random rnd = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Hebergement> hebergements = LoadHebergements();
            List<Hebergement> LotAleatoire = new List<Hebergement>();

            do
            {
                LotAleatoire.Add(hebergements[rnd.Next(hebergements.Count)]);
            } while (LotAleatoire.Count < 3);
          


            ListView1.DataSource = LotAleatoire;
            ListView1.DataBind();
        }

        private List<Hebergement> LoadHebergements()
        {
            DaoHebergement daoHebergement = new DaoHebergement();
            return daoHebergement.GetHebergement();
        } 



    }

}