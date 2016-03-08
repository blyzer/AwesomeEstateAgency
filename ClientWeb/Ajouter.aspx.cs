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

            if (Session["Admin"] == null || Session["Admin"].ToString() == "false")
            {
                Response.Redirect("~/Connexion.aspx");
            }
            else
            {
                Catalogue obj = new Catalogue();

                string id = Request.QueryString["id"];

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



                    if (id != null)
                    {

                        using (ServiceAgence.AgenceClient client = new ServiceAgence.AgenceClient())
                        {
                            client.Open();

                            ServiceAgence.BienImmobilier bien = client.LireDetailsBienImmobilier(id).Bien;

                            Titre.Text = bien.Titre;
                            Prix.Text = bien.Prix.ToString();
                            MontantCharges.Text = bien.MontantCharges.ToString();
                            Adresse.Text = bien.Adresse;
                            CP.Text = bien.CodePostal;
                            Ville.Text = bien.Ville;
                            Surface.Text = bien.Surface.ToString();
                            NombreEtage.Text = bien.NbEtages.ToString();
                            NumeroEtage.Text = bien.NumEtage.ToString();
                            Description.Text = bien.Description;
                            NombrePiece.Text = bien.NbPieces.ToString();
                            Description.Text = bien.Description;
                            DropDownListTypeBien.SelectedIndex = (int)bien.TypeBien;
                            DropDownListTypeTransaction.SelectedIndex = (int)bien.TypeTransaction;
                            DropDownListTypeChauffage.SelectedIndex = (int)bien.TypeChauffage;
                            DropDownListEnergieChauffage.SelectedIndex = (int)bien.EnergieChauffage;

                        }

                    }

                }

                if (this.IsPostBack)
                {
                    using (ServiceAgence.AgenceClient client = new ServiceAgence.AgenceClient())
                    {
                        client.Open();

                        ServiceAgence.BienImmobilier bien;

                        if (id == null)
                        {
                            bien = new ServiceAgence.BienImmobilier();
                            Initbien(bien);
                        }
                        else
                        {
                            bien = client.LireDetailsBienImmobilier(id).Bien;

                        }



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
                        bien.PhotoPrincipaleBase64 = "";
                        bien.PhotosBase64 = new List<string>();

                        PutImage(ImageP, bien);
                        PutImage(Image1, bien);
                        PutImage(Image2, bien);


                        bien.Prix = ConvertStringToDouble(Prix.Text, 0);
                        bien.Surface = ConvertStringToDouble(Surface.Text, 0);

                        bien.Titre = Titre.Text;
                        bien.TransactionEffectuee = false;
                        bien.TypeBien = (ServiceAgence.BienImmobilierBase.eTypeBien)obj.AffectSelectedValue(DropDownListTypeBien);
                        bien.TypeChauffage = (ServiceAgence.BienImmobilierBase.eTypeChauffage)obj.AffectSelectedValue(DropDownListTypeChauffage);
                        bien.TypeTransaction = (ServiceAgence.BienImmobilierBase.eTypeTransaction)obj.AffectSelectedValue(DropDownListTypeTransaction);
                        bien.Ville = Ville.Text;

                        if (id != null)
                        {
                            bien.Id = Convert.ToInt32(id);
                            client.ModifierBienImmobilier(bien);
                        }
                        else
                        {
                            client.AjouterBienImmobilier(bien);
                        }


                        client.Close();
                    }

                    Response.Redirect("~/Administration.aspx");
                }
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

        private bool PutImage(FileUpload f, ServiceAgence.BienImmobilier b)
        {
            
            if (f.HasFile)
            {
                string img = ImageToBase64(f);
                b.PhotosBase64.Add(img);
                return true;
            }
            else
            {
                return false;
            }
            
        }

    }
}