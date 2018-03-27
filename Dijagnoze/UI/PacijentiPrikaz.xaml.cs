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
    /// Interaction logic for PacijentiPrikaz.xaml
    /// </summary>
    public partial class PacijentiPrikaz : Window
    {
        private ICollectionView view;

        public PacijentiPrikaz()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Aplikacija.Instance.Pacijenti);

            dgPacijenti.IsSynchronizedWithCurrentItem = true;
            dgPacijenti.DataContext = this;
            dgPacijenti.ItemsSource = view;
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var noviPacijent = new Pacijenti();
            

            var pacijentEdit = new PacijentEdit(noviPacijent,PacijentEdit.Operacija.DODAVANJE);
            pacijentEdit.ShowDialog();
        }
    }
}
