using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplic.Models
{
    public class Recenzija
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private Ponuda ponuda;

        public Ponuda Ponuda
        {
            get { return ponuda; }
            set { ponuda = value; }
        }

        private decimal brojcanaOcjena;

        public decimal BrojcanaOcjena
        {
            get { return brojcanaOcjena; }
            set { brojcanaOcjena = value; }
        }

        private string tekst;

        public string Tekst
        {
            get { return tekst; }
            set { tekst = value; }
        }
        

        private DateTime datumRecenziranja;

        public DateTime Datumrecenziranja
        {
            get { return datumRecenziranja; }
            set { datumRecenziranja = value; }
        }
        
    }
}
