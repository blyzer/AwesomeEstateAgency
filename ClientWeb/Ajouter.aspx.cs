using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientWeb
{
    public partial class Ajouter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Catalogue obj = new Catalogue();
            if (!this.IsPostBack)
            {

                obj.Load_DropDownListItem<ServiceAgence.BienImmobilierBase.eTypeBien>(DropDownListTypeBien, false);
                obj.Load_DropDownListItem<ServiceAgence.BienImmobilierBase.eTypeChauffage>(DropDownListTypeChauffage, false);
                obj.Load_DropDownListItem<ServiceAgence.BienImmobilierBase.eEnergieChauffage>(DropDownListEnergieChauffage, false);
                obj.Load_DropDownListItem<ServiceAgence.BienImmobilierBase.eTypeTransaction>(DropDownListTypeTransaction, false);

                DropDownListTypeBien.SelectedValue = "0";
                DropDownListEnergieChauffage.SelectedValue = "0";
                DropDownListTypeChauffage.SelectedValue = "0";
                DropDownListTypeTransaction.SelectedValue = "0";

            }

            if (this.IsPostBack)
            {
                using (ServiceAgence.AgenceClient client = new ServiceAgence.AgenceClient())
                {
                    ServiceAgence.BienImmobilier bien = new ServiceAgence.BienImmobilier();

                    Initbien(bien);

                    bien.Adresse = Adresse.Text;
                    bien.CodePostal = CP.Text;
                    bien.DateMiseEnTransaction = DateTime.Now;
                    bien.DateTransaction = null; // ?? A completer ??
                    bien.Description = Description.Text;
                    bien.EnergieChauffage = (ServiceAgence.BienImmobilierBase.eEnergieChauffage)obj.AffectSelectedValue(DropDownListEnergieChauffage);
                    bien.MontantCharges = ConvertStringToDouble(MontantCharges.Text, 0);
                    bien.NbEtages = ConvertStringToInt(NombreEtage.Text, 0);
                    bien.NbPieces = ConvertStringToInt(NombrePiece.Text, 0);
                    bien.NumEtage = ConvertStringToInt(NumeroEtage.Text, 0);

                    if (Image.HasFile)
                    {
                        //bien.Description = ImageToBase64(Image);
                        bien.PhotoPrincipaleBase64 = ImageToBase64(Image);
                        string img = ImageToBase64(Image);
                        bien.PhotosBase64 = new List<string>();
                        bien.PhotosBase64.Add(img);
                    }
                    else
                    {
                        bien.PhotoPrincipaleBase64 = "";
                    }


                    bien.Prix = ConvertStringToDouble(Prix.Text, 0);
                    bien.Surface = ConvertStringToDouble(Surface.Text, 0);

                    bien.Titre = Titre.Text;
                    bien.TransactionEffectuee = false;
                    bien.TypeBien = (ServiceAgence.BienImmobilierBase.eTypeBien)obj.AffectSelectedValue(DropDownListTypeBien);
                    bien.TypeChauffage = (ServiceAgence.BienImmobilierBase.eTypeChauffage)obj.AffectSelectedValue(DropDownListTypeChauffage);
                    bien.TypeTransaction = (ServiceAgence.BienImmobilierBase.eTypeTransaction)obj.AffectSelectedValue(DropDownListTypeTransaction);
                    bien.Ville = Ville.Text;

                    client.AjouterBienImmobilier(bien);
                }

                Response.Redirect("~/Catalogue.aspx");
            }
        }

        private void Initbien(ServiceAgence.BienImmobilier b)
        {
            b.Adresse = "";
            b.CodePostal = "";
            b.Description = "";
            b.MontantCharges = 0;
            b.NbEtages = 0;
            b.NbPieces = 0;
            b.NumEtage = 0;
            b.PhotoPrincipaleBase64 = "";
            b.Prix = 0;
            b.Surface = 0;
            b.Titre = "";
            b.TransactionEffectuee = false;
            b.Ville = "";
        }

        public int ConvertStringToInt(string s, int j)
        {
            int i;
            if (int.TryParse(s, out i)) return i;
            return j;
        }
        public double ConvertStringToDouble(string s, double j)
        {
            double i;
            if (double.TryParse(s, out i)) return i;
            return j;
        }

        public string ImageToBase64(FileUpload img)
        {
            string base64String = "";
            MemoryStream m = new MemoryStream(img.FileBytes);
            byte[] imageBytes = m.ToArray();
            base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }

    }
}