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
    public partial class Catalogue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Load_DropDownListItem<ServiceAgence.BienImmobilierBase.eTypeBien>(DropDownListTypeBien);
                Load_DropDownListItem<ServiceAgence.BienImmobilierBase.eTypeChauffage>(DropDownListTypeChauffage);
            }

            if (this.IsPostBack)
            {

                using (ServiceAgence.AgenceClient client = new ServiceAgence.AgenceClient())
                {

                    client.Open();
                    ServiceAgence.CriteresRechercheBiensImmobiliers a = new ServiceAgence.CriteresRechercheBiensImmobiliers();
                    Initcriteres(a);
                    a.TitreContient = Recherche.Text;

                    // Recherche avancée
                    double Number = 0;
                    if (Double.TryParse(RecherchePrixMin.Text, out Number)) a.Prix1 = Number;
                    if (Double.TryParse(RecherchePrixMax.Text, out Number)) a.Prix2 = Number;
                    if (Double.TryParse(RechercheASurfaceMin.Text, out Number)) a.Surface1 = Number;
                    if (Double.TryParse(RechercheASurfaceMax.Text, out Number)) a.Surface2 = Number;
                    if (Double.TryParse(RechercheASurfaceMax.Text, out Number)) a.Surface2 = Number;
                    if (Double.TryParse(RechercheASurfaceMax.Text, out Number)) a.Surface2 = Number;

                    a.TypeBien = (ServiceAgence.BienImmobilierBase.eTypeBien)AffectSelectedValue(DropDownListTypeBien);
                    a.TypeChauffage = (ServiceAgence.BienImmobilierBase.eTypeChauffage)AffectSelectedValue(DropDownListTypeChauffage);

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

        public void Load_DropDownListItem<T>(DropDownList ddli)
        {
            ddli.Items.Clear();
            string[] names = Enum.GetNames(typeof(T));
            foreach (int value in Enum.GetValues(typeof(T)))
            {
                ddli.Items.Add(new ListItem(Enum.GetName(typeof(T), value), value.ToString()));
            }

        }

        /// <summary>
        /// Retourne l'integer de la valeur associée
        /// </summary>
        /// <param name="ddli"></param>
        /// <returns>Int de la "clé"</returns>
        public object AffectSelectedValue(DropDownList ddli)
        {

            int val;
            if (int.TryParse(ddli.SelectedValue, out val))
            {
                return val;
            }
            else
            {
                return null;
            }

        }
    }


}