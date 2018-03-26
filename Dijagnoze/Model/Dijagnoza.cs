using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijagnoze.Model
{
    public class Dijagnoza
    {
        private int id;
        private string sifra;
        private string idDijagnoze;
        private string nazivD;
        private string nazivLatinski;
        private DateTime vaziOd;
        private string metastaze;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        

        public string Sifra
        {
            get { return sifra; }
            set { sifra = value; }
        }

       

        public string IdDijagnoze
        {
            get { return idDijagnoze; }
            set { idDijagnoze = value; }
        }

        

        public string NazivD
        {
            get { return nazivD; }
            set { nazivD = value; }
        }

       

        public string NazivLatinski
        {
            get { return nazivLatinski; }
            set { nazivLatinski = value; }
        }

       

        public DateTime VaziOd
        {
            get { return vaziOd; }
            set { vaziOd = value; }
        }

        

        public string Metastaze
        {
            get { return metastaze; }
            set { metastaze = value; }
        }






    }
}
