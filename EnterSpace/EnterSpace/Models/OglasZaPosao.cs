using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterSpace.Models
{
    public class OglasZaPosao
    {

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string naziv;

        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }

        private string opis;

        public string Opis
        {
            get { return opis; }
            set { opis = value; }
        }

        private int trajanje;

        public int Trajanje
        {
            get { return trajanje; }
            set { trajanje = value; }
        }
        
        
        
    }
}
