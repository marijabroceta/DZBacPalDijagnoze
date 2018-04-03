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
    public class Mesto : INotifyPropertyChanged, ICloneable
    {

        private int id;
        
        private string mestoStanovanja;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }



        



        public string MestoStanovanja
        {
            get { return mestoStanovanja; }
            set
            {
                mestoStanovanja = value;
                OnPropertyChanged("MestoStanovanja");
            }
        }

        public static Mesto GetById(int Id)
        {
            foreach (var mesto in Aplikacija.Instance.Mesto)
            {
                if (mesto.Id == Id)
                {
                    return mesto;
                }
            }
            return null;
        }

        public override string ToString()
        {

            return $"{MestoStanovanja}";

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
            return new Mesto()
            {
                Id = id,
                MestoStanovanja = mestoStanovanja
            };
        }

        #region db

        public static ObservableCollection<Mesto> GetAll()
        {
            var mesto = new ObservableCollection<Mesto>();
            using (var conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["Dijagnoze"].ConnectionString))
            {
                SQLiteCommand cmd = conn.CreateCommand();
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                cmd.CommandText = "SELECT * FROM Mesto";
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "mesto");

                foreach (DataRow row in ds.Tables["mesto"].Rows)
                {
                    var m = new Mesto();
                    m.Id = int.Parse(row["Id"].ToString());
                    
                    m.MestoStanovanja = row["Mesto"].ToString();

                    mesto.Add(m);
                }
            }
            return mesto;
        }

        public static Mesto Create(Mesto m)
        {
            using (var conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["Dijagnoze"].ConnectionString))
            {
                conn.Open();

                SQLiteCommand cmd = conn.CreateCommand();

                cmd.CommandText = "INSERT INTO mesto (mesto) VALUES(@mesto)";
               
                
                cmd.Parameters.AddWithValue("mesto", m.MestoStanovanja);

                cmd.ExecuteNonQuery();

            }

            Aplikacija.Instance.Mesto.Add(m);
            return m;
        }

        public static void Update(Mesto m)
        {
            using (var conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["Dijagnoze"].ConnectionString))
            {
                conn.Open();

                SQLiteCommand cmd = conn.CreateCommand();


                cmd.CommandText = "UPDATE mesto SET mesto = @mesto WHERE id = @id";

                cmd.Parameters.AddWithValue("Id", m.Id);
                cmd.Parameters.AddWithValue("mesto", m.MestoStanovanja);


                cmd.ExecuteNonQuery();
            }
            //azuriranje modela
            foreach (var mesto in Aplikacija.Instance.Mesto)
            {
                if (m.Id == mesto.Id)
                {
                    mesto.MestoStanovanja = m.MestoStanovanja;
                }
            }
        }
        #endregion
    }
}
