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

            using (ServiceAgence.AgenceClient client = new ServiceAgence.AgenceClient())
            {
                client.Open();
                ServiceAgence.CriteresRechercheBiensImmobiliers a = new ServiceAgence.CriteresRechercheBiensImmobiliers();
                Initcriteres(a);
                
                if (false==true)
                { // Le visiteur vient de la page d'accueil
                    a.TitreContient = "";
                }


                if (!this.IsPostBack)
                {

                    Load_DropDownListItem<ServiceAgence.BienImmobilierBase.eTypeBien>(DropDownListTypeBien, true);
                    Load_DropDownListItem<ServiceAgence.BienImmobilierBase.eTypeChauffage>(DropDownListTypeChauffage, true);
                    Load_DropDownListItem<ServiceAgence.BienImmobilierBase.eEnergieChauffage>(DropDownListEnergieChauffage, true);

                    DropDownListTypeBien.SelectedValue = "-1";
                    DropDownListEnergieChauffage.SelectedValue = "-1";
                    DropDownListTypeChauffage.SelectedValue = "-1";
                    
                }

                if (this.IsPostBack)
                {
                    if (Request.Form["searchtype"] != null)
                    { // Recherche simple
                        dbg.Text = Request.Form["searchtype"].ToString();
                        a.TitreContient = RechercheTitre_simple.Text;
                    }

                    else
                    {// Recherche avancée

                        dbg.Text = "adv";

                        a.TitreContient = RechercheTitre_adv.Text;
                        a.DescriptionContient = RechercheDescription.Text;
                        a.AdresseContient = RechercheAdresse.Text;
                        a.CodePostal = RechercheCodePostal.Text;
                        a.Ville = RechercheVille.Text;

                        if (DropDownListTypeBien.SelectedValue != "-1")
                        {
                            a.TypeBien = (ServiceAgence.BienImmobilierBase.eTypeBien)AffectSelectedValue(DropDownListTypeBien);
                        }
                        if (DropDownListEnergieChauffage.SelectedValue != "-1")
                        {
                            a.EnergieChauffage = (ServiceAgence.BienImmobilierBase.eEnergieChauffage)AffectSelectedValue(DropDownListEnergieChauffage);
                        }
                        if (DropDownListTypeChauffage.SelectedValue != "-1")
                        {
                            a.TypeChauffage = (ServiceAgence.BienImmobilierBase.eTypeChauffage)AffectSelectedValue(DropDownListTypeChauffage);
                        }



                        double Number = 0;
                        if (Double.TryParse(RecherchePrixMin.Text, out Number)) a.Prix1 = Number;
                        if (Double.TryParse(RecherchePrixMax.Text, out Number)) a.Prix2 = Number;
                        if (Double.TryParse(RechercheSurfaceMin.Text, out Number)) a.Surface1 = Number;
                        if (Double.TryParse(RechercheSurfaceMax.Text, out Number)) a.Surface2 = Number;
                        if (Double.TryParse(RechercheEtageMin.Text, out Number)) a.NbEtages1 = (int)Number;
                        if (Double.TryParse(RechercheEtageMax.Text, out Number)) a.NbEtages2 = (int)Number;
                        if (Double.TryParse(RecherchePieceMin.Text, out Number)) a.NbPieces1 = (int)Number;
                        if (Double.TryParse(RecherchePieceMax.Text, out Number)) a.NbPieces2 = (int)Number;
                    }

                    
                }

                ServiceAgence.ResultatListeBiensImmobiliers res = client.LireListeBiensImmobiliers(a, 0, 2);

                this.rpResultats.DataSource = res.Liste.List;
                this.rpResultats.DataBind();
                client.Close();
               
            }
        }

        private void Initcriteres(ServiceAgence.CriteresRechercheBiensImmobiliers c)
        {

            c.TitreContient = "";
            c.AdresseContient = "";
            c.CodePostal = "";
            c.DateMiseEnTransaction1 = null; // Pas dans recherche
            c.DateMiseEnTransaction2 = null; // Pas dans recherche
            c.DateTransaction1 = null; // Pas dans recherche
            c.DateTransaction2 = null; // Pas dans recherche
            c.DescriptionContient = "";
            c.EnergieChauffage = null;
            c.MontantCharges1 = -1; // Pas dans recherche
            c.MontantCharges2 = -1; // Pas dans recherche
            c.NbEtages1 = -1;
            c.NbEtages2 = -1;
            c.NbPieces1 = -1;
            c.NbPieces2 = -1;
            c.NumEtage1 = -1; // Pas dans recherche
            c.NumEtage2 = -1; // Pas dans recherche
            c.Prix1 = -1;
            c.Prix2 = -1;
            c.Surface1 = -1;
            c.Surface2 = -1;
            c.TransactionEffectuee = null; // Pas dans recherche
            c.Tris = null; // Pas dans recherche
            c.TypeBien = null;
            c.TypeChauffage = null;
            c.TypeTransaction = null; // Pas dans recherche
            c.Ville = "";

        }

        public void Load_DropDownListItem<T>(DropDownList ddli, bool Tous)
        {
            ddli.Items.Clear();

            string[] names = Enum.GetNames(typeof(T));
            foreach (int value in Enum.GetValues(typeof(T)))
            {
                ddli.Items.Add(new ListItem(Enum.GetName(typeof(T), value), value.ToString()));
            }
            if (Tous)
            {
                ddli.Items.Add(new ListItem("Tous", "-1"));
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