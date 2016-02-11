using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace ClientWeb
{

    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (this.IsPostBack)
            {
                using (ServiceAgence.AgenceClient client = new ServiceAgence.AgenceClient())
                {

                    client.Open();
                    
                    ServiceAgence.CriteresRechercheBiensImmobiliers a = new ServiceAgence.CriteresRechercheBiensImmobiliers();
                    a.TitreContient = Label1.Text;
                    a.AdresseContient = "";
                    a.CodePostal = "";
                    a.DateMiseEnTransaction1 = null;
                    a.DateMiseEnTransaction2 = null;
                    a.DateTransaction1 = null;
                    a.DateTransaction2 = null;
                    a.DescriptionContient = "";
                    a.EnergieChauffage = null;
                    a.MontantCharges1 = -1;
                    a.MontantCharges2 = -1;
                    a.NbEtages1 = -1;
                    a.NbEtages2 = -1;
                    a.NbPieces1 = -1;
                    a.NbPieces2 = -1;
                    a.NumEtage1 = -1;
                    a.NumEtage2 = -1;
                    a.Prix1 = -1;
                    a.Prix2 = -1;
                    a.Surface1 = -1;
                    a.Surface2 = -1;
                    a.TransactionEffectuee = null;
                    a.Tris = null;
                    a.TypeBien = null;
                    a.TypeChauffage = null;
                    a.TypeTransaction = null;
                    a.Ville = "";

                    ServiceAgence.ResultatListeBiensImmobiliers res = client.LireListeBiensImmobiliers(a, 0, 2);

                    //List<ServiceAgence.BienImmobilier> liste = new List<ServiceAgence.BienImmobilier>();
                    this.rpResultats.DataSource = res.Liste.List;
                    this.rpResultats.DataBind();
                    //this.rpResultats.Items[0].FindControl("");
                    client.Close();
                }
            }
        }
    }


}