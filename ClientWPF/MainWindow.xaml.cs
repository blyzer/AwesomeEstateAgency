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

        public ObservableCollection<ServiceAgence.BienImmobilierBase> ListeBienImmo { get { return (ObservableCollection<ServiceAgence.BienImmobilierBase>)GetProperty(); } set { SetProperty(value); } }

        public ServiceAgence.BienImmobilierBase selectedItem { get { return (ServiceAgence.BienImmobilierBase)GetProperty(); } set { SetProperty(value); } }


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

        public ServiceAgence.CriteresRechercheBiensImmobiliers filtre
        {
            get { return (ServiceAgence.CriteresRechercheBiensImmobiliers)GetProperty(); }
            set { SetProperty(value); }
        }

        private void InitFiltre()
        {

            filtre.TitreContient = "";
            filtre.AdresseContient = "";
            filtre.CodePostal = "";
            filtre.DateMiseEnTransaction1 = null;
            filtre.DateMiseEnTransaction2 = null;
            filtre.DateTransaction1 = null;
            filtre.DateTransaction2 = null;
            filtre.DescriptionContient = "";
            filtre.EnergieChauffage = null;
            filtre.MontantCharges1 = -1;
            filtre.MontantCharges2 = -1;
            filtre.NbEtages1 = -1;
            filtre.NbEtages2 = -1;
            filtre.NbPieces1 = -1;
            filtre.NbPieces2 = -1;
            filtre.NumEtage1 = -1;
            filtre.NumEtage2 = -1;
            filtre.Prix1 = -1;
            filtre.Prix2 = -1;
            filtre.Surface1 = -1;
            filtre.Surface2 = -1;
            filtre.TransactionEffectuee = null;
            filtre.Tris = null;
            filtre.TypeBien = null;
            filtre.TypeChauffage = null;
            filtre.TypeTransaction = null;
            filtre.Ville = "";
        }

		
        public MainWindow()
        {

            InitializeComponent();

            this.ListeBienImmo = new ObservableCollection<ServiceAgence.BienImmobilierBase>();

            this.filtre = new ServiceAgence.CriteresRechercheBiensImmobiliers();

            InitFiltre();

            

            new Action(async () =>
			{
				await InitBiensAsync();
			}).Invoke();

			

            this.DataContext = this;
        }


        #region BindingData

		private async Task InitBiensAsync()
		{

            loader.Position = TimeSpan.Zero;
            loader.Play();
			loader.Visibility = System.Windows.Visibility.Visible;

            //Console.WriteLine("load..");
            await InitBiens();

		}

		private async Task<Boolean> InitBiens()
        {

            using (ServiceAgence.AgenceClient client = new ServiceAgence.AgenceClient())
            {

                client.Open();

                ServiceAgence.ResultatListeBiensImmobiliers res = await client.LireListeBiensImmobiliersAsync(filtre, null, null);
				
				this.ListeBienImmo.Clear();
				for (int i = 0; i < res.Liste.List.Count; i++)
				{
					this.ListeBienImmo.Add(res.Liste.List.ElementAt(i));
				}
                //this.ListeBienImmo = res.Liste.List;
				

                for (int i = 0; i < ListeBienImmo.Count; i++)
                    Console.WriteLine("id :" + ListeBienImmo.ElementAt(i).Id);

                client.Close();

                loader.Visibility = System.Windows.Visibility.Hidden;
                loader.Stop();
                //Console.WriteLine("load !");

            }

			return true;
	
        }

        /// <summary>
        /// Nouvelle fenetre sur le bien bindé
        /// </summary>
        /// <param name="id">ID du bien</param>
        private void BindCurrentBien(int id)
        {

        }

        #endregion

        #region Gestion Events

		private async void button_Add(object sender, RoutedEventArgs e)
        {
            Windowadd winadd = new Windowadd();
            //winadd.Show();

            winadd.Owner = this;

            if (winadd.ShowDialog() == true)
            {
				await InitBiensAsync();
            }

        }

        /// <summary>
        /// Fenetre de modification d'un bien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private async void button_Modify(object sender, RoutedEventArgs e)
        {
            if (selectedItem != null)
            {
                Windowadd winadd = new Windowadd(selectedItem.Id);

                if (winadd.ShowDialog() == true)
                {
					await InitBiensAsync();
                }
            }

        }


        /// <summary>
        /// Supprime dans la base
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
                ListeBienImmo.Remove(selectedItem);
            }


        }

		private async void button_Filtre(object sender, RoutedEventArgs e)
        {
			await InitBiensAsync();

            Console.WriteLine("Filtre");
        }

        private async void button_UnFiltre(object sender, RoutedEventArgs e)
        {
			InitFiltre();
			await InitBiensAsync();
            Console.WriteLine("Defiltrer");
        }

        /// <summary>
        /// Capture l'id de l'item selectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            
            Console.WriteLine("DoubleClick");

            //ServiceAgence.BienImmobilierBase SelectedBien = (ServiceAgence.BienImmobilierBase)listBox.SelectedItem;
            if (selectedItem != null)
            { // Le select n'est pas null
                var item = ItemsControl.ContainerFromElement(listBox, e.OriginalSource as DependencyObject) as ListBoxItem;
                if (item != null)
                {
                    Console.WriteLine("Item select :" + selectedItem.Id);

                    Windowbien winbien = new Windowbien(selectedItem.Id);
                    winbien.Owner = this;
                    winbien.Show();

                }
            }
        }
        #endregion



    }
}