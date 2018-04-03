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
        ICollectionView viewPretraga;

        public Pacijenti IzabraniPacijent { get; set; }

        public PacijentiPrikaz()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Aplikacija.Instance.Pacijenti);
            view.Filter = PrikazFilter;

            dgPacijenti.IsSynchronizedWithCurrentItem = true;
            dgPacijenti.DataContext = this;
            dgPacijenti.ItemsSource = view;
        }

        private bool PrikazFilter(object obj)
        {
            return ((Pacijenti)obj).Aktivan == 0;
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var noviPacijent = new Pacijenti();
            

            var pacijentEdit = new PacijentEdit(noviPacijent,PacijentEdit.Operacija.DODAVANJE);
            pacijentEdit.ShowDialog();
        }

        private void PretragaPacijenta_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = tbPretraga.Text;
            viewPretraga = CollectionViewSource.GetDefaultView(Pacijenti.PretragaPacijenata(text));
            dgPacijenti.ItemsSource = viewPretraga;
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var kopija = (Pacijenti)IzabraniPacijent.Clone();
                var pacijentProzor = new PacijentEdit(kopija, PacijentEdit.Operacija.IZMENA);

                pacijentProzor.Show();
            }
            catch
            {
                MessageBox.Show("Morate obeleziti red koji zelite da menjate!");
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            var listaPacijenata = Aplikacija.Instance.Pacijenti;
            try
            {
                if (MessageBox.Show($"Da li zetite da obrisete {IzabraniPacijent.Ime} {IzabraniPacijent.Prezime} ?", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    foreach (var pacijent in listaPacijenata)
                    {
                        if (pacijent.Id == IzabraniPacijent.Id)
                        {
                            Pacijenti.Delete(pacijent);
                            view.Refresh();
                            break;
                        }
                    }
                }
            }
            
            catch
            {
                MessageBox.Show("Morate obeleziti red koji zelite da brisete!");
            }
        }

        private void btnZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
