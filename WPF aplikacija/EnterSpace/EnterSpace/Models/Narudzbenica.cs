using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterSpace.Models
{
    public class Narudzbenica
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime datum;

        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }

        private string destinacija;

        public string Destinacija
        {
            get { return destinacija; }
            set { destinacija = value; }
        }
        

        private int brojPutnika;

        public int BrojPutnika
        {
            get { return brojPutnika; }
            set { brojPutnika = value; }
        }

        private Poslovnisaradnik poslovniSaradnik;

        public Poslovnisaradnik PoslovniSaradnik
        {
            get { return poslovniSaradnik; }
            set { poslovniSaradnik = value; }
        }

        private decimal dogovorenaCijena;

        public decimal DogovorenaCijena
        {
            get { return dogovorenaCijena; }
            set { dogovorenaCijena = value; }
        }

        private string tipOpreme;

        public string TipOpreme
        {
            get { return tipOpreme; }
            set { tipOpreme = value; }
        }
        
        
        
        
        
        
        
    }
}
