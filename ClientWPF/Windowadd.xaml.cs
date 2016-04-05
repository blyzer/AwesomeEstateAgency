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
                    bien.PhotoPrincipaleBase64 = null; // A completer
                    bien.PhotosBase64 = null; // A completer

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


    }
}
