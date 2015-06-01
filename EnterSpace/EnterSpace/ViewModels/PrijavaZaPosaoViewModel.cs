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
    public class PrijavaZaPosaoViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel Parent { get; set; }
        DAL.Baza db = new DAL.Baza();

        Prijavnica prijavnica;
        public ICommand Posalji { get; set; }


        private DAL.Uposlenik uposlenik ;
        public DAL.Uposlenik Uposlenik
	    {
            get { return uposlenik; }
            set { uposlenik = value; }
	    }

        public PrijavaZaPosaoViewModel(MainWindowViewModel P)
        {
            Parent = P;
            uposlenik = new DAL.Uposlenik();
            Posalji = new RelayCommand(_posalji);
            var uposlenici = db.Uposlenici.ToList();
        }
 

        public void _posalji(object parameter)
        {
            uposlenik.Id = db.Uposlenici.ToList().Count + 1;
            uposlenik.Ime = Uposlenik.Ime;
            uposlenik.Prezime = Uposlenik.Prezime;
            uposlenik.Email = Uposlenik.Email;
            uposlenik.Broj_telefona = Uposlenik.Broj_telefona;
            uposlenik.DatumRegistracije  = DateTime.Now;
            uposlenik.Username = Uposlenik.Ime + Uposlenik.Prezime;
            uposlenik.Password = Uposlenik.Ime + Uposlenik.Prezime + uposlenik.Id;

            db.Uposlenici.Add(uposlenik);
            db.SaveChanges();
            System.Windows.MessageBox.Show("Prijava poslana! Sve potrebne informacije dobit cete na Vas email!");
            
        }


        public Prijavnica Prijavnica
        {
            get { return prijavnica; }
            set { prijavnica = value; }
        }

        //impl interfacea

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
