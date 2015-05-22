using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplic.Models
{
    public class Atrakcija
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

        private decimal cijena;

        public decimal Cijena
        {
            get { return cijena; }
            set { cijena = value; }
        }

        private DateTime vrijemeDesavanja;

        public DateTime VrijemeDesavanja
        {
            get { return vrijemeDesavanja; }
            set { vrijemeDesavanja = value; }
        }

        private int dan;

        public int Dan
        {
            get { return dan; }
            set { dan = value; }
        }
        
        
        
        
        
        
    }
}
