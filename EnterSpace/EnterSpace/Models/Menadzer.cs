using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterSpace.Models
{
    public class Menadzer
    {
        private int id;
        private string ime;
        private string prezime;


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Ime
        {
            get { return ime; }
            set
            {
                ime = value;
 
            }
        }

        public string Prezime
        {
            get { return prezime; }
            set
            {
                prezime = value;

            }
        }
        private string userM;

        public string UserM
        {
            get { return userM; }
            set { userM = value; }
        }
        private string passM;

        public string PassM
        {
            get { return passM; }
            set { passM = value; }
        }
        
        
    }
}
