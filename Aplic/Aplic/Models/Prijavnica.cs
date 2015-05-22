using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplic.Models
{
    public class Prijavnica
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private OglasZaPosao oglas;

        public OglasZaPosao Oglas
        {
            get { return oglas; }
            set { oglas = value; }
        }
        

        private DateTime datumPrijave;

        public DateTime DatumPrijave
        {
            get { return datumPrijave; }
            set { datumPrijave = value; }
        }

        private Osoba kandidat;

        public Osoba Kandidat
        {
            get { return kandidat; }
            set { kandidat = value; }
        }


        private string cv;

        public string Cv
        {
            get { return cv; }
            set { cv = value; }
        }
        
        
        
        
    }
}
