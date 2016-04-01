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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace ClientWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ServiceAgence.BienImmobilier CurrentBien=null;

        public ObservableCollection<ServiceAgence.BienImmobilierBase> ListBienBase
        {
            get { return (ObservableCollection<ServiceAgence.BienImmobilierBase>)GetProperty(); }
            set { SetProperty(value); }
        }


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

        public string ItemSelect
        {
            get { return (string)GetProperty(); }
            set { SetProperty(value); }
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


        public MainWindow()
        {
            
            this.DataContext = this;
            ListBienBase = new ObservableCollection<ServiceAgence.BienImmobilierBase>();

            BindBienList();
            //InitializeComponent();
        }


        #region BindingData
        private void BindBienList()
        {
            using (ServiceAgence.AgenceClient client = new ServiceAgence.AgenceClient())
            {

                client.Open();

                ServiceAgence.CriteresRechercheBiensImmobiliers c = new ServiceAgence.CriteresRechercheBiensImmobiliers();

                Initcriteres(c);

                ServiceAgence.ResultatListeBiensImmobiliers res = client.LireListeBiensImmobiliers(c, null, null);

                this.ListBienBase = res.Liste.List;

                for (int i = 0; i < ListBienBase.Count; i++)
                    Console.WriteLine("id :" + ListBienBase.ElementAt(i).Id);

                client.Close();
            }
            this.DataContext = this;
           
            InitializeComponent();
            listBox.Items.Refresh();
        }

        /// <summary>
        /// A faire
        /// </summary>
        private void BindCurrentBien()
        {

        }

        #endregion

        #region Gestion Events

        private void button_Add(object sender, RoutedEventArgs e)
        {
            Windowadd winadd = new Windowadd();
            winadd.Show();

			winadd.Owner = this;

			if (winadd.ShowDialog() == true)
			{

				//recharger
			}
            

        }

        /// <summary>
        /// Non opérationnelle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Modify(object sender, RoutedEventArgs e)
        {
            ServiceAgence.BienImmobilierBase SelectedBien = (ServiceAgence.BienImmobilierBase)listBox.SelectedItem;
            if (SelectedBien != null)
            {
                Windowadd winadd = new Windowadd(SelectedBien.Id);
                winadd.Show();
            }
            else
            {
                Windowadd winadd = new Windowadd();
                winadd.Show();
            }
            
            
        }


        /// <summary>
        /// Supprime dans la base, mais actualisation ne marche pas (il faut relancer le programme)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Delete(object sender, RoutedEventArgs e)
        {
            ServiceAgence.BienImmobilierBase SelectedBien = (ServiceAgence.BienImmobilierBase)listBox.SelectedItem;
            if (SelectedBien != null)
            {
                Console.WriteLine("Item select :" + SelectedBien.Id);
                using (ServiceAgence.AgenceClient client = new ServiceAgence.AgenceClient())
                {

                    client.Open();

                    client.SupprimerBienImmobilier(SelectedBien.Id.ToString());

                    client.Close();
                }
                BindBienList();
            }
            
        }

        private void button_Filtre(object sender, RoutedEventArgs e)
        {
            // Faire une autre windows de filtre
            Windowadd winadd = new Windowadd();
			winadd.Owner = this;
			winadd.Show();

			if (winadd.ShowDialog() == true)
			{
				//recharger
			}
        }

        /// <summary>
        /// Capture l'id de l'item selectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("DoubleClick");
            
            ServiceAgence.BienImmobilierBase SelectedBien = (ServiceAgence.BienImmobilierBase)listBox.SelectedItem;
            if (SelectedBien != null) { // Le select n'est pas null
                var item = ItemsControl.ContainerFromElement(listBox, e.OriginalSource as DependencyObject) as ListBoxItem;
                if (item != null)
                {
                    Console.WriteLine("Item select :" + SelectedBien.Id);
                    label_ID.Content = SelectedBien.Id.ToString();

                    using (ServiceAgence.AgenceClient client = new ServiceAgence.AgenceClient()) // Recupere détails bien
                    {
                        ServiceAgence.ResultatBienImmobilier res = client.LireDetailsBienImmobilier(SelectedBien.Id.ToString());
                        CurrentBien = res.Bien;
                    }

                    BindCurrentBien();
                    
                }
            }
        }
        #endregion
    }
}
