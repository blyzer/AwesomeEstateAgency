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
                    //LRecherche.Text = Recherche.Text;
                    Initcriteres(a);
                    a.TitreContient = Recherche.Text;
                    if (RechercheAPrixMin.Text != null)
                    {
                        a.Prix1 = (double)Double.Parse(RechercheAPrixMin.Text);
                    }
                    ServiceAgence.ResultatListeBiensImmobiliers res = client.LireListeBiensImmobiliers(a, 0, 2);
                    
                    this.rpResultats.DataSource = res.Liste.List;
                    this.rpResultats.DataBind();
                    //this.rpResultats.Items[0].FindControl("");
                    client.Close();
                }
            }
        }

        private void Initcriteres(ServiceAgence.CriteresRechercheBiensImmobiliers c)
        {
            c.TitreContient = "";
            c.AdresseContient = "";
            c.CodePostal = "";
            c.DateMiseEnTransaction1 = null;
            c.DateMiseEnTransaction2 = null;
            c.DateTransaction1 = null;
            c.DateTransaction2 = null;
            c.DescriptionContient = "";
            c.EnergieChauffage = null;
            c.MontantCharges1 = -1;
            c.MontantCharges2 = -1;
            c.NbEtages1 = -1;
            c.NbEtages2 = -1;
            c.NbPieces1 = -1;
            c.NbPieces2 = -1;
            c.NumEtage1 = -1;
            c.NumEtage2 = -1;
            c.Prix1 = -1;
            c.Prix2 = -1;
            c.Surface1 = -1;
            c.Surface2 = -1;
            c.TransactionEffectuee = null;
            c.Tris = null;
            c.TypeBien = null;
            c.TypeChauffage = null;
            c.TypeTransaction = null;
            c.Ville = "";
        }
    }


}