using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using EnterSpace.Models;
using EnterSpace.ViewModels;
using System.Windows;
namespace EnterSpace.Models
{
    public class ManagerViewModel
    {
        DAL.Baza db = new DAL.Baza();
        public MainWindowViewModel parent { get; set; }
        public ICommand DodajNovuPonudu { get; set; }
        public ICommand DodajNovogUposlenika { get; set; }

        public ManagerViewModel(MainWindowViewModel P)
        {
            parent = P;
            var uposlenici = db.Uposlenici.ToList();
            var ponude = db.Ponude.ToList();
            uposlenik = new DAL.Uposlenik();
            ponuda = new DAL.Ponuda();
            DodajNovuPonudu = new RelayCommand(_unesiPonudu);
            DodajNovogUposlenika = new RelayCommand(_unesiUposlenika);
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

        public void _unesiPonudu(object parameter)
        {
            ponuda.Id = db.Ponude.ToList().Count + 1;
            ponuda.Naziv = Ponuda.Naziv;
            ponuda.Opis = Ponuda.Opis;
            ponuda.Smjestaj = Ponuda.Smjestaj;
            ponuda.Kapacitet = Ponuda.Kapacitet;
            ponuda.Cijena = Ponuda.Cijena;

            db.Ponude.Add(ponuda);
            db.SaveChanges();
            System.Windows.MessageBox.Show("Vasi podaci su uspjesno uneseni u bazu!");

        }

        public void _unesiUposlenika(object parameter)
        {
            uposlenik.Id = db.Uposlenici.ToList().Count + 1;
            uposlenik.Ime = Uposlenik.Ime;
            uposlenik.Prezime = Uposlenik.Prezime;
            uposlenik.Email = Uposlenik.Email;
            uposlenik.Broj_telefona = Uposlenik.Broj_telefona;
            uposlenik.DatumRegistracije = DateTime.Now;
            uposlenik.Username = Uposlenik.Ime + Uposlenik.Prezime;
            uposlenik.Password = Uposlenik.Ime + Uposlenik.Prezime + uposlenik.Id;

            db.Uposlenici.Add(uposlenik);
            db.SaveChanges();
            System.Windows.MessageBox.Show("Uspjesno ste dodali novog uposlenika!");

        }
    }
}
