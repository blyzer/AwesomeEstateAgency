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
        public string BienTitre;
        public string BienAdresse;
        public string BienCP;
        public string BienDesc;
        public string BienPrix;
        public string BienVille;
        public string BienDateMiseEnTransaction;
        public string BienEnergieChauffage;
        public string BienMontantCharges;
        public string BienNbEtages;
        public string BienNbPieces;
        public string BienNumEtage;
        public string BienSurface;
        public string BienTypeChauffage;
        public string BienTypeBien;
        public string BienImage;

        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceAgence.BienImmobilier bien;
            using (ServiceAgence.AgenceClient client = new ServiceAgence.AgenceClient())
            {

                client.Open();

                ServiceAgence.ResultatBienImmobilier res = client.LireDetailsBienImmobilier(Request.QueryString["id"]);
                bien = res.Bien;

                //Titre :
                BienTitre = bien.Titre.ToString();

                //Info generale :
                BienTypeBien = bien.TypeBien.ToString();
                BienNbEtages = bien.NbEtages.ToString();
                BienNbPieces = bien.NbPieces.ToString();
                BienSurface = bien.Surface.ToString() + " m²";

                //Prix :
                BienMontantCharges = bien.MontantCharges.ToString() + " €";
                BienPrix = bien.Prix.ToString() + " €";

                //Coordonnées :
                BienAdresse = bien.Adresse.ToString();
                BienCP = bien.CodePostal.ToString();
                BienVille = bien.Ville.ToString();

                //Description :
                BienDesc = bien.Description.ToString();

                //Chauffage :
                BienEnergieChauffage = bien.EnergieChauffage.ToString();
                BienTypeChauffage = bien.TypeChauffage.ToString();

                //Info complémentaires :
                BienDateMiseEnTransaction = bien.DateMiseEnTransaction.ToString();
                BienNumEtage = bien.NumEtage.ToString();

                //Image :
                BienImage = bien.PhotoPrincipaleBase64;

                client.Close();
            }
        }
    }
}