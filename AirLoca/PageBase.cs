using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace AirLoca
{
    public class PageBase : Page
    {
        private string notify;
        private string message;
        private string type;
        protected void Page_PreRender(object sender, EventArgs e)
        {
            notify = Convert.ToString(Session["notify"]);

            if (!String.IsNullOrEmpty(notify))
            {
                switch (notify)
                {
                    case "connexion":
                        message = "Vous êtes connecté !";
                        type = "success";
                        break;
                    case "deconnexion":
                        message = "Vous êtes déconnecté !";
                        type = "warning";
                        break;
                    case "creation":
                        message = "Votre compte a été créé avec succès, bienvenue !";
                        type = "success";
                        break;
                    case "avis":
                        message = "Votre avis a bien été ajouté !";
                        type = "success";
                        break;
                    case "message":
                        message = "Votre message a bien été envoyé !";
                        type = "success";
                        break;
                    case "favoris":
                        message = "L'hébergement a été ajouté à vos favoris !";
                        type = "success";
                        break;
                    case "log":
                        message = "Vous devez vous connecter pour continuer !";
                        type = "warning";
                        break;
                    case "reservation":
                        message = "Votre réservation a été enregistrée avec succès !";
                        type = "success";
                        break;
                    case "coordModify":
                        message = "Vos coordonnées ont été modifiée avec succès !";
                        type = "success";
                        break;
                    case "pwModify":
                        message = "Votre mot de passe a été modifié avec succès !";
                        type = "success";
                        break;
                    case "hebAdd":
                        message = "Votre location a été ajoutée avec succès !";
                        type = "success";
                        break;
                    case "hebModify":
                        message = "Votre location a été modifiée avec succès !";
                        type = "success";
                        break;
                    case "hebDelete":
                        message = "Votre location a été supprimée avec succès !";
                        type = "success";
                        break;
                }

                notify = null;
                Session.Remove("notify");

                StringBuilder sb = new StringBuilder();
                sb.Append("<script type='text/javascript'>");
                sb.Append(" $.notify({");
                sb.Append(" message: '"+message+"'");
                sb.Append("},{");
                sb.Append(" type: '"+type+"',");
                sb.Append(" placement: {from: 'top', align: 'center'}");
                sb.Append("});");
                sb.Append("</script>");


                //Render the function invocation. 

                if (!ClientScript.IsStartupScriptRegistered("JSScript"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "JSScript", sb.ToString());
                }
            }
        }
    }
}
