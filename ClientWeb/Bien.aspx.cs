using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientWeb
{
	public partial class Bien : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            ServiceAgence.BienImmobilier bien;
            using (ServiceAgence.AgenceClient client = new ServiceAgence.AgenceClient())
            {

                client.Open();

                ServiceAgence.ResultatBienImmobilier res = client.LireDetailsBienImmobilier(Request.QueryString["id"]);
                bien = res.Bien;

                BienTitre.Text = bien.Titre.ToString();
                BienAdresse.Text= bien.Adresse.ToString();
                BienCP.Text=bien.CodePostal.ToString();
                BienDesc.Text = bien.Description.ToString();

                client.Close();
            }
        }
	}
}