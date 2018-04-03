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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            var username = this.tbUsername.Text;
            var password = this.tbPassword.Text;
            bool pronasao = false;

            foreach (var user in Aplikacija.Instance.Users)
            {
                if (user.Username == username && user.Password == password)
                {
                    this.Hide();
                    MestoPrikaz mp = new MestoPrikaz();
                    mp.Show();
                    pronasao = true;

                    break;
                }
                else if (user.Username == "" && user.Password == "")
                {
                    MessageBox.Show("Morate uneti korisnicko ime i lozinku");
                }
            }
            if (!pronasao)
            {
                MessageBox.Show("Neuspesno logovanje!");
            }
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
