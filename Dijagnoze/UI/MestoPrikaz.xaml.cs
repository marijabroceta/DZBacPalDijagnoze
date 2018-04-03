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
    /// Interaction logic for MestoPrikaz.xaml
    /// </summary>
    public partial class MestoPrikaz : Window
    {
        ICollectionView view;

        public Mesto IzabranoMesto { get; set; }

        public MestoPrikaz()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Aplikacija.Instance.Mesto);

            dgMesto.IsSynchronizedWithCurrentItem = true;
            dgMesto.DataContext = this;
            dgMesto.ItemsSource = view;
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var novoMesto = new Mesto();


            var mestoEdit = new MestoEdit(novoMesto, MestoEdit.Operacija.DODAVANJE);
            mestoEdit.ShowDialog();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var kopija = (Mesto)IzabranoMesto.Clone();
                var mestoProzor = new MestoEdit(kopija, MestoEdit.Operacija.IZMENA);

                mestoProzor.Show();
            }
            catch
            {
                MessageBox.Show("Morate obeleziti red koji zelite da menjate!");
            }
        }

        private void btnZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
