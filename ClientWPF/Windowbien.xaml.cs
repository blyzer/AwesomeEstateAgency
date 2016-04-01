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
    /// Logique d'interaction pour Windowbien.xaml
    /// </summary>
    public partial class Windowbien : Window
    {
        public ServiceAgence.BienImmobilier bien;
        public Windowbien(int id_bien=-1)
        {

            using (ServiceAgence.AgenceClient client = new ServiceAgence.AgenceClient())
            {
                client.Open();
                bien = client.LireDetailsBienImmobilier(id_bien.ToString()).Bien;
                Titre.Content = bien.Titre;
            }
            InitializeComponent();
        }
    }
}
