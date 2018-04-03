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
    public class User:INotifyPropertyChanged,ICloneable
    {
        private int id;
        private string username;
        private string password;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

       

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        

        public string Password
        {
            get { return password; }
            set { password = value; }
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
            return new User()
            {
                Id = id,
                Username = username,
                Password = password
            };
        }

        #region db

        public static ObservableCollection<User> GetAll()
        {
            var user = new ObservableCollection<User>();
            using (var conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["Dijagnoze"].ConnectionString))
            {
                SQLiteCommand cmd = conn.CreateCommand();
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                cmd.CommandText = "SELECT * FROM user";
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "user");

                foreach (DataRow row in ds.Tables["user"].Rows)
                {
                    var u = new User();
                    u.Id = int.Parse(row["Id"].ToString());
                    u.Username = row["Username"].ToString();
                    u.Password = row["Password"].ToString();

                    user.Add(u);
                }
            }
            return user;
        }
        #endregion
    }
}
