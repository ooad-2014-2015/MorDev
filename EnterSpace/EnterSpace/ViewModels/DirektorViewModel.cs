using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterSpace.Models;
using EnterSpace.ViewModels;

namespace EnterSpace.Models
{
    class DirektorViewModel
    {
        DAL.Baza db = new DAL.Baza();
        public MainWindowViewModel parent { get; set; }

        public DirektorViewModel(MainWindowViewModel P)
        {
            parent = P;
            var uposlenici = db.Uposlenici.ToList();
            uposlenik = new DAL.Uposlenik();
            ponuda = new DAL.Ponuda();
            _ispisiUposlenike();
            _ispisiPonude();
        }

        private DAL.Uposlenik uposlenik;
        public DAL.Uposlenik Uposlenik
        {
            get { return uposlenik; }
            set { uposlenik = value; }
        }

        private DAL.Ponuda ponuda;
        public DAL.Ponuda Ponuda
        {
            get { return ponuda; }
            set { ponuda = value; }
        }

        public void _ispisiUposlenike()
        {
            foreach (var u in db.Uposlenici)
            {
                //uposlenik.Ime = u.Ime;      
                //ispisi u listbox/combobox
            }
        }

        public void _ispisiPonude()
        {
            foreach (var u in db.Ponude)
            {     
                //ispisi u listbox/combobox
            }
        }


    }
}
