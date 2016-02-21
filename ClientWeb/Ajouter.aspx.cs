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
                    try
                    {
                        bien.MontantCharges = Convert.ToDouble(MontantCharges.Text);
                    }
                    catch (FormatException)
                    {
                        bien.MontantCharges = 0;
                    }
                    try
                    {
                        bien.NbEtages = Convert.ToInt32(NombreEtage.Text);
                    }
                    catch (FormatException)
                    {
                        bien.NbEtages = 0;
                    }
                    try
                    {
                        bien.NbPieces = Convert.ToInt32(NombrePiece.Text);
                    }
                    catch (FormatException)
                    {
                        bien.NbPieces = 0;
                    }
                    try
                    {
                        bien.NumEtage = Convert.ToInt32(NumeroEtage.Text);
                    }
                    catch (FormatException)
                    {
                        bien.NumEtage = 0;
                    }

                    if (Image.HasFile)
                    {
                        Stream fs = Image.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        bien.PhotoPrincipaleBase64 = Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                    else
                    {
                        bien.PhotoPrincipaleBase64 = "";
                    }

                    bien.PhotosBase64 = null; // A completer

                    try
                    {
                        bien.Prix = Convert.ToDouble(Prix.Text);
                    }
                    catch (FormatException)
                    {
                        bien.Prix = 0;
                    }

                    try
                    {
                        bien.Surface = Convert.ToDouble(Surface.Text);
                    }
                    catch (FormatException)
                    {
                        bien.Surface = 0;
                    }

                    
                    bien.Titre = Titre.Text;
                    bien.TransactionEffectuee = false;
                    bien.TypeBien = (ServiceAgence.BienImmobilierBase.eTypeBien)obj.AffectSelectedValue(DropDownListTypeBien);
                    bien.TypeChauffage = (ServiceAgence.BienImmobilierBase.eTypeChauffage)obj.AffectSelectedValue(DropDownListTypeChauffage);
                    bien.TypeTransaction = (ServiceAgence.BienImmobilierBase.eTypeTransaction)obj.AffectSelectedValue(DropDownListTypeTransaction);
                    bien.Ville = Ville.Text;

                    client.AjouterBienImmobilier(bien);
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

    }
}