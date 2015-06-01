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
    public class PrijavaKorisnikaViewModel : INotifyPropertyChanged
    {
        public Action CloseAction { get; set; }
        public MainWindowViewModel Parent { get; set; }

        DAL.Baza db = new DAL.Baza();
        public ICommand UnosKlijenta { get; set; }
        

        private DAL.Klijent klijent;
	    public DAL.Klijent Klijent
	    {
		    get { return klijent;}
		    set { klijent = value;}
	    }

        public PrijavaKorisnikaViewModel(MainWindowViewModel P)
        {
            Parent = P;
            klijent = new DAL.Klijent();
            UnosKlijenta = new RelayCommand(_unesiKlijenta);
            var klijenti = db.Klijenti.ToList();
        }
 

        public void _unesiKlijenta(object parameter)
        {
            klijent.Id = db.Klijenti.ToList().Count+1;
            klijent.Ime = Klijent.Ime;
            klijent.Prezime = Klijent.Prezime;
            klijent.Email = Klijent.Email;
            klijent.DatumRegistracije = DateTime.Now;
            klijent.Username = Klijent.Ime+Klijent.Prezime;
            klijent.Password = Klijent.Ime + Klijent.Prezime+klijent.Id;

            EnterSpace.Models.Klijent k = new EnterSpace.Models.Klijent(
            klijent.Id,
            klijent.Ime,
            klijent.Prezime,
            klijent.Email,
            klijent.DatumRegistracije.ToString(),
            klijent.Username ,
            klijent.Password );

            

            db.Klijenti.Add(klijent);
            db.SaveChanges();
            System.Windows.MessageBox.Show("Vasi podaci su uspjesno uneseni u bazu!");
            
        }
       

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
