using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplic.Models
{
    public class Izvjestaj
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime datumKreiranja;

        public DateTime DatumKreiranja
        {
            get { return datumKreiranja; }
            set { datumKreiranja = value; }
        }

        private Uposlenik kreator;

        public Uposlenik Kreator
        {
            get { return kreator; }
            set { kreator = value; }
        }
        
        
        
    }
}
