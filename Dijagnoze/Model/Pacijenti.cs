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
    public enum Pol
    {
        Muski,
        Zenski
    }

    public class Pacijenti:INotifyPropertyChanged,ICloneable
    {

        

        private int id;
        private string ime;
        private string prezime;
        private string jmbg;
        private string adresa;
        private Pol pol;
        private DateTime? datumSmrti;
        private Mesto mesto;
        private int mestoId;
        private Dijagnoza dijagnoza;
        private int dijagnozaId;
        private int aktivan;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        

        public string Ime
        {
            get { return ime; }
            set
            {
                ime = value;
                OnPropertyChanged("Ime");
            }
        }

        

        public string Prezime
        {
            get { return prezime; }
            set
            {
                prezime = value;
                OnPropertyChanged("Prezime");
            }
        }

        

        public string Jmbg
        {
            get { return jmbg; }
            set
            {
                jmbg = value;
                OnPropertyChanged("Jmbg");
            }
        }

        public string Adresa
        {
            get { return adresa; }
            set
            {
                adresa = value;
                OnPropertyChanged("Adresa");
            }
        }


        public Pol Pol
        {
            get { return pol; }
            set
            {
                pol = value;
                OnPropertyChanged("Pol");
            }
        }

        

        public DateTime? DatumSmrti
        {
            get { return datumSmrti; }
            set { datumSmrti = value; }
        }




        public Mesto Mesto
        {
            get
            {
                if(mesto == null)
                {
                    mesto = Mesto.GetById(MestoId);
                }
                return mesto;
            }
            set
            {
                mesto = value;
                MestoId = mesto.Id;
            }
        }

        

        public Dijagnoza Dijagnoza
        {
            get
            {
                if(dijagnoza == null)
                {
                    dijagnoza = Dijagnoza.GetById(DijagnozaId);
                }
                return dijagnoza;
            }
            set
            {
                dijagnoza = value;
                DijagnozaId = dijagnoza.Id;
                OnPropertyChanged("Dijagnoza");
            }
        }

        

        public int MestoId
        {
            get { return mestoId; }
            set
            {
                mestoId = value;
                OnPropertyChanged("MestoId");
            }
        }

        

        public int DijagnozaId
        {
            get { return dijagnozaId; }
            set
            {
                dijagnozaId = value;
                OnPropertyChanged("DijagnozaId");
            }
        }


        public int Aktivan
        {
            get { return aktivan; }
            set
            {
                aktivan = value;
                OnPropertyChanged("Aktivan");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return new Pacijenti()
            {
                Id = id,
                Ime = ime,
                Prezime = prezime,
                Jmbg = jmbg,
                Adresa = adresa,
                Pol = pol,
                DatumSmrti = datumSmrti,
                Mesto = mesto,
                Dijagnoza = dijagnoza,
                MestoId = mestoId,
                DijagnozaId = DijagnozaId
            };
        }

        #region db

        public static ObservableCollection<Pacijenti> GetAll()
        {
            var pacijent = new ObservableCollection<Pacijenti>();
            using (var conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["Dijagnoze"].ConnectionString))
            {
                SQLiteCommand cmd = conn.CreateCommand();
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                cmd.CommandText = "SELECT * FROM pacijent WHERE Aktivan = 0;";
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "pacijent");

                foreach (DataRow row in ds.Tables["pacijent"].Rows)
                {
                    var p = new Pacijenti();
                    p.Id = int.Parse(row["Id"].ToString());
                    p.Ime = row["Ime"].ToString();
                    p.Prezime = row["Prezime"].ToString();
                    p.Jmbg = row["Jmbg"].ToString();
                    if (!DBNull.Value.Equals(row["Adresa"].ToString()))
                    {
                        p.Adresa = row["Adresa"].ToString();
                    }
                    else
                    {
                        p.Adresa = "";
                    }
                                                                             
                    p.Pol = (Pol)Enum.Parse(typeof(Pol), (row["Pol"].ToString()));
                    if (DBNull.Value.Equals(row["DatumSmrti"].ToString()))
                    {                      
                        p.DatumSmrti = DateTime.Parse(row["DatumSmrti"].ToString());
                    }
                    else
                    {
                        p.DatumSmrti = new DateTime();
                    }                
                    p.MestoId = int.Parse(row["MestoId"].ToString());
                    p.DijagnozaId = int.Parse(row["DijagnozaId"].ToString());
                    p.Aktivan = int.Parse(row["Aktivan"].ToString());

                    pacijent.Add(p);
                }
            }
            return pacijent;
        }

        public static Pacijenti Create(Pacijenti p)
        {
            using (var conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["Dijagnoze"].ConnectionString))
            {
                conn.Open();

                SQLiteCommand cmd = conn.CreateCommand();

                cmd.CommandText = "INSERT INTO pacijent (ime,prezime,jmbg,adresa,pol,datumSmrti,mestoId,dijagnozaId,aktivan) VALUES (@ime,@prezime,@jmbg,@adresa,@pol,@datumSmrti,@mestoId,@dijagnozaId,@aktivan)";
               
                cmd.Parameters.AddWithValue("ime", p.Ime);
                cmd.Parameters.AddWithValue("prezime", p.Prezime);
                cmd.Parameters.AddWithValue("jmbg", p.Jmbg);
                cmd.Parameters.AddWithValue("adresa", p.Adresa);
                cmd.Parameters.AddWithValue("pol", p.Pol);
                cmd.Parameters.AddWithValue("datumSmrti", p.DatumSmrti);
                cmd.Parameters.AddWithValue("mestoId", p.MestoId);
                cmd.Parameters.AddWithValue("dijagnozaId", p.DijagnozaId);
                cmd.Parameters.AddWithValue("aktivan", p.Aktivan);
                cmd.ExecuteNonQuery();

            }

            Aplikacija.Instance.Pacijenti.Add(p);
            return p;
        }

        public static void Update(Pacijenti p)
        {
            using (var conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["Dijagnoze"].ConnectionString))
            {
                conn.Open();

                SQLiteCommand cmd = conn.CreateCommand();


                cmd.CommandText = "UPDATE pacijent SET ime = @ime,prezime = @prezime, jmbg = @jmbg,adresa = @adresa,datumSmrti = @datumSmrti,pol = @pol,mestoId = @mestoId,dijagnozaId = @dijagnozaId, aktivan= @aktivan WHERE id = @id";
                
                cmd.Parameters.AddWithValue("Id", p.Id);
                cmd.Parameters.AddWithValue("Ime",p.Ime);
                cmd.Parameters.AddWithValue("Prezime", p.Prezime);
                cmd.Parameters.AddWithValue("Jmbg", p.Jmbg);
                cmd.Parameters.AddWithValue("Adresa", p.Adresa);
                cmd.Parameters.AddWithValue("DatumSmrti", p.DatumSmrti);
                cmd.Parameters.AddWithValue("Pol", p.Pol);
                cmd.Parameters.AddWithValue("MestoId", p.MestoId);
                cmd.Parameters.AddWithValue("DijagnozaId", p.DijagnozaId);
                cmd.Parameters.AddWithValue("Aktivan", p.Aktivan);
                

                cmd.ExecuteNonQuery();
            }
            //azuriranje modela
            foreach (var pacijent in Aplikacija.Instance.Pacijenti)
            {
                if (p.Id == pacijent.Id)
                {
                    pacijent.Ime = p.Ime;
                    pacijent.Prezime = p.Prezime;
                    pacijent.Jmbg = p.Jmbg;
                    pacijent.Pol = p.Pol;
                    pacijent.DatumSmrti = p.DatumSmrti;
                    pacijent.MestoId = p.MestoId;
                    pacijent.DijagnozaId = p.DijagnozaId;
                    pacijent.Aktivan = p.Aktivan;
                }
            }
        }

        public static void Delete(Pacijenti p)
        {
            p.Aktivan = 1;
            Update(p);
        }

        public static ObservableCollection<Pacijenti> PretragaPacijenata(string unos)
        {
            var pacijent = new ObservableCollection<Pacijenti>();

            using (var conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["Dijagnoze"].ConnectionString))
            {
                SQLiteCommand cmd = conn.CreateCommand();
                SQLiteDataAdapter da = new SQLiteDataAdapter();

                cmd.CommandText = "SELECT * FROM pacijent p INNER JOIN dijagnozad d ON p.dijagnozaId = d.id INNER JOIN mesto m ON p.mestoId = m.id"+
                    " WHERE (ime LIKE @unos OR prezime LIKE @unos OR jmbg LIKE @unos OR adresa LIKE @unos OR d.sifra LIKE @unos OR m.mesto LIKE @unos) AND aktivan = 0;";
                cmd.Parameters.AddWithValue("unos", "%" + unos.Trim() + "%");
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "pacijent");

                foreach (DataRow row in ds.Tables["pacijent"].Rows)
                {
                    var p = new Pacijenti();
                    p.Id = int.Parse(row["id"].ToString());
                    p.Ime = row["ime"].ToString();
                    p.Prezime = row["prezime"].ToString();
                    p.Jmbg = row["jmbg"].ToString();
                    if (!DBNull.Value.Equals(row["Adresa"].ToString()))
                    {
                        p.Adresa = row["Adresa"].ToString();
                    }
                    else
                    {
                        p.Adresa = "";
                    }
                    p.Pol = (Pol)Enum.Parse(typeof(Pol), (row["Pol"].ToString()));
                    if (DBNull.Value.Equals(row["DatumSmrti"].ToString()))
                    {
                        p.DatumSmrti = DateTime.Parse(row["DatumSmrti"].ToString());
                    }
                    else
                    {
                        p.DatumSmrti = new DateTime();
                    }
                    p.MestoId = int.Parse(row["MestoId"].ToString());
                    p.DijagnozaId = int.Parse(row["DijagnozaId"].ToString());
                    p.Aktivan = int.Parse(row["Aktivan"].ToString());

                    pacijent.Add(p);
                }

            }
            return pacijent;
        }

        #endregion
    }
}
