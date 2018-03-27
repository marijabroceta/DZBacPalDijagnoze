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
    /// Interaction logic for PacijentEdit.xaml
    /// </summary>
    public partial class PacijentEdit : Window
    {
        ICollectionView viewMesto;

        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private Operacija operacija;
        
        Pacijenti pacijenti;

        public PacijentEdit(Pacijenti pacijenti,Operacija operacija)
        {
            InitializeComponent();

            this.pacijenti = pacijenti;
            this.operacija = operacija;

            viewMesto = CollectionViewSource.GetDefaultView(Aplikacija.Instance.Mesto);

            cbMesto.ItemsSource = viewMesto;
            cbPol.ItemsSource = Enum.GetValues(typeof(Pol)).Cast<Pol>();

            cbMesto.SelectedIndex = 0;

            tbIme.DataContext = pacijenti;
            tbPrezime.DataContext = pacijenti;
            tbJmbg.DataContext = pacijenti;
            tbAdresa.DataContext = pacijenti;
            cbMesto.DataContext = pacijenti;
            cbPol.DataContext = pacijenti;
            tbDijagnoza.DataContext = pacijenti;
        }

        private void btnPickDijagnoza_Click(object sender, RoutedEventArgs e)
        {
            DijagnozaPrikaz dijagnozaPrikaz = new DijagnozaPrikaz(DijagnozaPrikaz.Stanje.ODABIR);
            if (dijagnozaPrikaz.ShowDialog() == true)
            {
                pacijenti.Dijagnoza = dijagnozaPrikaz.SelektovanaDijagnoza;
            }
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            switch (operacija)
            {
                case Operacija.DODAVANJE:

                    Pacijenti.Create(pacijenti);
                    break;

                case Operacija.IZMENA:

                    Pacijenti.Update(pacijenti);
                    break;
            }
            Close();
        }
    }
}
