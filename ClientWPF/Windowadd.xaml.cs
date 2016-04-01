using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ClientWPF
{
    /// <summary>
    /// Logique d'interaction pour Windowadd.xaml
    /// </summary>
    public partial class Windowadd : Window
    {

        private ServiceAgence.BienImmobilier bien;
        private int id_bien;
        public Windowadd(int id=-1)
        {
            id_bien = id;
            InitializeComponent();
            cb_Chauffage.SelectedItem = 1;

            if (id != -1) // Modifier : Recup data du bien
            {
                using (ServiceAgence.AgenceClient client = new ServiceAgence.AgenceClient())
                {
                    client.Open();
                    bien = client.LireDetailsBienImmobilier(id_bien.ToString()).Bien;

                    txt_Adresse.Text = bien.Adresse;
                    txt_CodePostal.Text = bien.CodePostal;
                    txt_Description.Text = bien.Description;
                    cb_EChauffage.SelectedItem = bien.EnergieChauffage;
                    txt_MontantCharges.Text = bien.MontantCharges.ToString();
                    txt_NbEtages.Text = bien.NbEtages.ToString();
                    txt_NbPiece.Text = bien.NbPieces.ToString();
                    txt_NumEtage.Text = bien.NumEtage.ToString();
                    //bien.PhotoPrincipaleBase64 = null; // A completer
                    //bien.PhotosBase64 = null; // A completer
                    txt_Prix.Text = bien.Prix.ToString();
                    txt_Surface.Text = bien.Surface.ToString();
                    txt_Titre.Text = bien.Titre;
                    cb_TypeBien.SelectedItem = bien.TypeBien;
                    cb_Chauffage.SelectedItem = bien.TypeChauffage;
                    cb_Transaction.SelectedItem = bien.TypeTransaction;
                    txt_Ville.Text = bien.Ville;
                    bien.Id = Convert.ToInt32(id_bien);
                    client.Close();
                }
                
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (ServiceAgence.AgenceClient client = new ServiceAgence.AgenceClient())
            {

                client.Open();

                if (id_bien == -1) // Ajouter : création d'un bien
                {
                    bien = new ServiceAgence.BienImmobilier();
                }

                bien.Adresse = txt_Adresse.Text;
                bien.CodePostal = txt_CodePostal.Text;
                bien.Description = txt_Description.Text;
                bien.EnergieChauffage = (ServiceAgence.BienImmobilierBase.eEnergieChauffage)cb_EChauffage.SelectedItem;
                bien.MontantCharges = ConvertStringToDouble(txt_MontantCharges.Text, 0);
                bien.NbEtages = ConvertStringToInt(txt_NbEtages.Text, 0);
                bien.NbPieces = ConvertStringToInt(txt_NbPiece.Text, 0);
                bien.NumEtage = ConvertStringToInt(txt_NumEtage.Text, 0);
                bien.PhotoPrincipaleBase64 = null; // A completer
                bien.PhotosBase64 = null; // A completer
                bien.Prix = ConvertStringToDouble(txt_Prix.Text, 0);
                bien.Surface = ConvertStringToDouble(txt_Surface.Text, 0);
                bien.Titre = txt_Titre.Text;
                bien.TypeBien = (ServiceAgence.BienImmobilierBase.eTypeBien)cb_TypeBien.SelectedItem;
                bien.TypeChauffage = (ServiceAgence.BienImmobilierBase.eTypeChauffage)cb_Chauffage.SelectedItem;
                bien.TypeTransaction = (ServiceAgence.BienImmobilierBase.eTypeTransaction)cb_Transaction.SelectedItem;
                bien.Ville = txt_Ville.Text;

                if (id_bien == -1) // Ajouter
                {
                    bien.DateMiseEnTransaction = DateTime.Now;
                    bien.DateTransaction = null;
                    bien.TransactionEffectuee = false;

                    client.AjouterBienImmobilier(bien);
                }
                

                if(id_bien!=-1) // Modifier
                {
                    client.ModifierBienImmobilier(bien);
                }
                

                client.Close();
            }

            this.Close();
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
    }
}
