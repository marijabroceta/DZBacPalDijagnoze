using Dijagnoze.Model;
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

namespace Dijagnoze.UI
{
    /// <summary>
    /// Interaction logic for MestoEdit.xaml
    /// </summary>
    public partial class MestoEdit : Window
    {
        public enum Operacija { DODAVANJE, IZMENA}

        

        Mesto mesto;
        Operacija operacija;

        public MestoEdit(Mesto mesto, Operacija operacija)
        {
            InitializeComponent();

            this.mesto = mesto;
            this.operacija = operacija;

            tbMesto.DataContext = mesto;
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    
                    Mesto.Create(mesto);
                    break;

                case Operacija.IZMENA:

                    Mesto.Update(mesto);
                    break;
            }
            Close();
        }

        private void btnIzadji_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
