using System;
using System.Collections.Generic;
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

    public class Pacijenti
    {

        

        private int id;
        private string ime;
        private string prezime;
        private string jmbg;
        private Pol pol;
        private Mesto mesto;
        private Dijagnoza dijagnoza;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        

        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }

        

        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; }
        }

        

        public string Jmbg
        {
            get { return jmbg; }
            set { jmbg = value; }
        }

        

        public Pol Pol
        {
            get { return pol; }
            set { pol = value; }
        }

        

        public Mesto Mesto
        {
            get { return mesto; }
            set { mesto = value; }
        }

        

        public Dijagnoza Dijagnoza
        {
            get { return dijagnoza; }
            set { dijagnoza = value; }
        }


    }
}
