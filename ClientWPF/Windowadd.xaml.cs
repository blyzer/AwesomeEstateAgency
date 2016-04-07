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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.IO;
using System.Drawing.Imaging;

namespace ClientWPF
{
    /// <summary>
    /// Logique d'interaction pour Windowadd.xaml
    /// </summary>
	public partial class Windowadd : Window, INotifyPropertyChanged
    {



        private Dictionary<string, object> _propretyValues = new Dictionary<string, object>(); // Dictionary équivaut a HashMap
        private object GetProperty([CallerMemberName] string propertyName = null)
        {
            if (_propretyValues.ContainsKey(propertyName)) return _propretyValues[propertyName];
            return null;
        }

        private bool SetProperty<T>(T newValue, [CallerMemberName] string propertyName = null) // <T> : méthode générique
        {                                                                                      // propretyName=null : params optionnel
                                                                                               // [CallerMemberName] : remplace propertyName par nom element qui l'a appelé
            T current = (T)GetProperty(propertyName);
            if (!EqualityComparer<T>.Default.Equals(current, newValue)) // Si TextAffiche est changer
            {
                _propretyValues[propertyName] = newValue;
                if (PropertyChanged != null) // Si y'a eu des changements
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); // Actualise la valeur
                    return true;
                }
            }
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ServiceAgence.BienImmobilier bien
        {
            get { return (ServiceAgence.BienImmobilier)GetProperty(); }
            set { SetProperty(value); }
        }

        private int id_bien;
        private Uri u=null;


        public Windowadd(int id = -1)
        {
            InitializeComponent();

            id_bien = id;

            if (id != -1) // Modifier : Recup data du bien
            {
                using (ServiceAgence.AgenceClient client = new ServiceAgence.AgenceClient())
                {

                    client.Open();
                    bien = client.LireDetailsBienImmobilier(id_bien.ToString()).Bien;
                    client.Close();
                }

            }
            else
            {
                bien = new ServiceAgence.BienImmobilier();
            }


            this.DataContext = this;

        }



        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (ServiceAgence.AgenceClient client = new ServiceAgence.AgenceClient())
            {

                client.Open();


                if (id_bien == -1) // Ajouter
                {
                    bien.DateMiseEnTransaction = DateTime.Now;
                    bien.DateTransaction = null;
                    bien.TransactionEffectuee = false;
                    if(u==null)
                    {
                        //u = new Uri("file:///C:/Users/Anthony/Desktop/IUT/CSharp/TAE/AwesomeEstateAgency/ClientWPF/images/nothumbnail.png");
                        u = new Uri(@".\images\nothumbnail.png");
                    }
                        
                    BitmapImage bi = new BitmapImage(u);
                    bien.PhotoPrincipaleBase64 = BitmapImagetoBase64(bi);
                    bien.PhotosBase64 = new ObservableCollection<string>();
                    bien.PhotosBase64.Add(bien.PhotoPrincipaleBase64);
                    

                    client.AjouterBienImmobilier(bien);
                }

                else // Modifier
                {
                    ServiceAgence.ResultatBool res = client.ModifierBienImmobilier(bien);

                }


                client.Close();
            }

            this.DialogResult = true;

            this.Close();
        }

        private void bOpenFileDialog_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = true;


            // Call the ShowDialog method to show the dialog box.
            bool? userClickedOK = openFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
            if (userClickedOK == true)
            {
                u = new Uri(openFileDialog1.FileName);
            }
        }

        public static string BitmapImagetoBase64(BitmapImage image)
        {
            if (image == null) return "";
            using(MemoryStream stream=new MemoryStream())
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(stream);
                byte[] byteArray = stream.ToArray();
                return System.Convert.ToBase64String(byteArray);
            }
        }

    }
}
