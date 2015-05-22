using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplic.Models
{
    class Karta
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime datumPlacanja;

        public DateTime DatumPlacanja
        {
            get { return datumPlacanja; }
            set { datumPlacanja = value; }
        }

        private Rezervacija rezervacija;

        public Rezervacija Rezervacija
        {
            get { return rezervacija; }
            set { rezervacija = value; }
        }

        
        
        
    }
}
