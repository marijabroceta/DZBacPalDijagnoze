using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijagnoze.Model
{
    public class Dijagnoza:INotifyPropertyChanged
    {
        private int id;
        private string sifra;
        private string idDijagnoze;
        private string nazivD;
        private string nazivLatinski;
        private DateTime vaziOd;
        private string metastaze;
        private string histoloskaDijagnoza;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        

        public string Sifra
        {
            get { return sifra; }
            set
            {
                sifra = value;
                OnPropertyChanged("Sifra");
            }
        }

       

        public string IdDijagnoze
        {
            get { return idDijagnoze; }
            set
            {
                idDijagnoze = value;
                OnPropertyChanged("IdDijagnoze");
            }
        }

        

        public string NazivD
        {
            get { return nazivD; }
            set
            {
                nazivD = value;
                OnPropertyChanged("NazivD");
            }
        }

       

        public string NazivLatinski
        {
            get { return nazivLatinski; }
            set
            {
                nazivLatinski = value;
                OnPropertyChanged("NazivLatinski");
            }
        }

       

        public DateTime VaziOd
        {
            get { return vaziOd; }
            set
            {
                vaziOd = value;
                OnPropertyChanged("VaziOd");
            }
        }

        

        public string Metastaze
        {
            get { return metastaze; }
            set
            {
                metastaze = value;
                OnPropertyChanged("Metastaze");
            }
        }

       

        public string HistoloskaDijagnoza
        {
            get { return histoloskaDijagnoza; }
            set
            {
                histoloskaDijagnoza = value;
                OnPropertyChanged("HistoloskaDijagnoza");
            }
        }


        public static Dijagnoza GetById(int Id)
        {
            foreach (var dijagnoza in Aplikacija.Instance.Dijagnoze)
            {
                if (dijagnoza.Id == Id)
                {
                    return dijagnoza;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return $"{Sifra}";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region db

        public static ObservableCollection<Dijagnoza> GetAll()
        {
            var dijagnoza = new ObservableCollection<Dijagnoza>();
            using (var conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["Dijagnoze"].ConnectionString))
            {
                SQLiteCommand cmd = conn.CreateCommand();
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                cmd.CommandText = "SELECT * FROM dijagnozad";
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "dijagnozad");

                foreach (DataRow row in ds.Tables["dijagnozad"].Rows)
                {
                    var d = new Dijagnoza();
                    d.Id = int.Parse(row["Id"].ToString());
                    d.IdDijagnoze = row["Id_Dijagnoza"].ToString();
                    d.Sifra = row["Sifra"].ToString();
                    d.NazivD = row["NazivD"].ToString();
                    d.NazivLatinski = row["NazivLatinski"].ToString();
                    d.VaziOd = DateTime.Parse(row["Vazi_Od"].ToString());
                    d.Metastaze = row["Metastaze"].ToString();
                    d.HistoloskaDijagnoza = row["Histoloska_Dijagnoza"].ToString();

                    dijagnoza.Add(d);
                }
            }
            return dijagnoza;
        }

        public static ObservableCollection<Dijagnoza> PretragaDijagnoze(string unos)
        {
            var dijagnoza = new ObservableCollection<Dijagnoza>();

            using (var conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["Dijagnoze"].ConnectionString))
            {
                SQLiteCommand cmd = conn.CreateCommand();
                SQLiteDataAdapter da = new SQLiteDataAdapter();

                cmd.CommandText = "SELECT * FROM dijagnozad WHERE sifra LIKE @unos OR id_dijagnoza LIKE @unos OR nazivd LIKE @unos OR nazivlatinski LIKE @unos OR metastaze LIKE @unos OR histoloska_dijagnoza LIKE @unos";
                cmd.Parameters.AddWithValue("unos", "%" + unos.Trim() + "%");
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "dijagnozad");

                foreach (DataRow row in ds.Tables["dijagnozad"].Rows)
                {
                    var d = new Dijagnoza();
                    d.Id = int.Parse(row["Id"].ToString());
                    d.IdDijagnoze = row["Id_Dijagnoza"].ToString();
                    d.Sifra = row["Sifra"].ToString();
                    d.NazivD = row["NazivD"].ToString();
                    d.NazivLatinski = row["NazivLatinski"].ToString();
                    d.VaziOd = DateTime.Parse(row["Vazi_Od"].ToString());
                    d.Metastaze = row["Metastaze"].ToString();
                    d.HistoloskaDijagnoza = row["Histoloska_Dijagnoza"].ToString();

                    dijagnoza.Add(d);
                }

            }
            return dijagnoza;
        }


        #endregion
    }
}
