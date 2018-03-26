using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijagnoze.Model
{
    public class Mesto
    {

        private int id;
        private string adresa;
        private string mestoStanovanja;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        

        public string Adresa
        {
            get { return adresa; }
            set { adresa = value; }
        }

       

        public string MestoStanovanja
        {
            get { return mestoStanovanja; }
            set { mestoStanovanja = value; }
        }



    }
}
