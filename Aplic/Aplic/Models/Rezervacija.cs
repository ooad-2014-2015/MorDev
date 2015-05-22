using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplic.Models
{
    public class Rezervacija
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private Klijent klijent;

        public Klijent Klijent
        {
            get { return klijent; }
            set { klijent = value; }
        }

        private Ponuda ponuda;

        public Ponuda Ponuda
        {
            get { return ponuda; }
            set { ponuda = value; }
        }

        private DateTime datumRezervacije;

        public DateTime DatumRezervacije
        {
            get { return datumRezervacije; }
            set { datumRezervacije = value; }
        }

        private DateTime datumPolaska;

        public DateTime DatumPolaska
        {
            get { return datumPolaska; }
            set { datumPolaska = value; }
        }

        private DateTime datumDolaska;

        public DateTime DatumDolaska
        {
            get { return datumDolaska; }
            set { datumDolaska = value; }
        }
        
        
        
        
        
    }
}
