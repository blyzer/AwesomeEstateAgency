using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientWeb
{
    public partial class Connexion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (Email.Text.CompareTo("Admin") == 0 && Password.Text.CompareTo("Pass") == 0)
                {
                    Session["Admin"] = "true";
                    Response.Redirect("~/Administration.aspx");
                }
                else
                {
                    Session["Error"] = "Echec de connexion";
                    Session["Admin"] = "false";
                }
            }

        }
    }
}