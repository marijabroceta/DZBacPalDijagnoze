using Dijagnoze.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Dijagnoze.UI
{
    /// <summary>
    /// Interaction logic for DijagnozaPrikaz.xaml
    /// </summary>
    public partial class DijagnozaPrikaz : Window
    {
        private ICollectionView view;

        public enum Stanje { PRIKAZ, ODABIR }
        private Stanje stanje;

        public Dijagnoza SelektovanaDijagnoza = null;

        public DijagnozaPrikaz(Stanje stanje)
        {
            InitializeComponent();

            this.stanje = stanje;

            if(stanje == Stanje.PRIKAZ)
            {
                btnIzaberi.Visibility = Visibility.Hidden;
            }

            view = CollectionViewSource.GetDefaultView(Aplikacija.Instance.Dijagnoze);

            dgDijagnoze.IsSynchronizedWithCurrentItem = true;
            dgDijagnoze.DataContext = this;
            dgDijagnoze.ItemsSource = view;
        }

        private void btnIzaberi_Click(object sender, RoutedEventArgs e)
        {
            SelektovanaDijagnoza = dgDijagnoze.SelectedItem as Dijagnoza;
            this.DialogResult = true;
            this.Close();
        }
    }
}
