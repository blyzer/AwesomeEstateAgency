using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientWeb
{
    public partial class Deconnexion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Admin"] = "false";
            Response.Redirect("~/Default.aspx");
        }
    }
}