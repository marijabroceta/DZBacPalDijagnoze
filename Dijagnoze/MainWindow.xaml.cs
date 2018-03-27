using Dijagnoze.UI;
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

namespace Dijagnoze
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPacijenti_Click(object sender, RoutedEventArgs e)
        {
            var pacijentPrikaz = new PacijentiPrikaz();
            pacijentPrikaz.Show();
        }

        private void btnDijagnoze_Click(object sender, RoutedEventArgs e)
        {
            var dijagnozePrikaz = new DijagnozaPrikaz(DijagnozaPrikaz.Stanje.PRIKAZ);
            dijagnozePrikaz.Show();
        }

        
    }
}
