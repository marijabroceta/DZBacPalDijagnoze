using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijagnoze.Model
{
    public class Aplikacija
    {
        public static Aplikacija Instance { get; private set; } = new Aplikacija();

        public ObservableCollection<Pacijenti> Pacijenti { get; set; }
        public ObservableCollection<Mesto> Mesto { get; set; }
        public ObservableCollection<Dijagnoza> Dijagnoze { get; set; }
        public ObservableCollection<User> Users { get; set; }

        private Aplikacija()
        {
            Pacijenti = Model.Pacijenti.GetAll();
            Mesto = Model.Mesto.GetAll();
            Dijagnoze = Dijagnoza.GetAll();
            Users = User.GetAll();
        }
    }
}
