using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterSpace.Models
{
    public class Poslovnisaradnik
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string jib;

        public string Jib
        {
            get { return jib; }
            set { jib = value; }
        }

        private string naziv;

        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }

        private DateTime datumPocetkaSaradnje;

        public DateTime DatumPocetkaSaradnje
        {
            get { return datumPocetkaSaradnje; }
            set { datumPocetkaSaradnje = value; }
        }

        private string tipOpreme;

        public string TipOpreme
        {
            get { return tipOpreme; }
            set { tipOpreme = value; }
        }
        
        
        
    }
}
