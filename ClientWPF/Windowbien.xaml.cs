using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Logique d'interaction pour Windowbien.xaml
    /// </summary>
    public partial class Windowbien : Window
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



        public Windowbien(int id_bien=-1)
        {

            using (ServiceAgence.AgenceClient client = new ServiceAgence.AgenceClient())
            {
                client.Open();
                bien = client.LireDetailsBienImmobilier(id_bien.ToString()).Bien;
            }
            InitializeComponent();

            this.DataContext = this;
        }
    }
}
