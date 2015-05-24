using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using Aplic.Models;






namespace Aplic.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        string Username, Pasword;


        Klijent klijent;

        //deklaracija formi
        PrijavaZaPosao pZaPosao;
        PrijavaKorisnika pKorisnika;
        ManagerView managerView;
        DirektorView direktorView;


        //deklaracija viewModela
        PrijavaZaPosaoViewModel pZaPosaoViewModel;
        PrijavaKorisnikaViewModel pKorisnikaViewModel;
        ManagerViewModel managerViewModel;
        DirektorViewModel direktorViewModel;


        //commande
        public ICommand Oglas { get; set; }
        public ICommand Prijava { get; set; }
        public ICommand Izbor { get; set; }
        public ICommand UserLogin { get; set; }

        //konstruktor
        public MainWindowViewModel()
        {

            Oglas = new RelayCommand(_prikaziOglasFormu);
            Prijava = new RelayCommand(_prikaziFormuZaPrijavu);
            Izbor = new RelayCommand(_prikaziFormuMiliD);


            pZaPosaoViewModel = new PrijavaZaPosaoViewModel(this);
            pKorisnikaViewModel = new PrijavaKorisnikaViewModel(this);
            managerViewModel = new ManagerViewModel(this);
            direktorViewModel = new DirektorViewModel(this);

            // ubacivanje klijenta
            klijent = new Klijent();

        }




        private void _prikaziOglasFormu(object parametar)
        {
            pZaPosao = new PrijavaZaPosao();
            pZaPosao.DataContext = pZaPosaoViewModel;
            pZaPosao.Show();
        }

        private void _prikaziFormuZaPrijavu(object parametar)
        {
            pKorisnika = new PrijavaKorisnika();
            pKorisnika.DataContext = pKorisnikaViewModel;
            pKorisnika.Show();
        }


        private void _prikaziFormuMiliD(object parametar)
        {
            if (Username == "Manager" && Pasword == "Managerpasword")
            {
                managerView = new ManagerView();
                managerView.DataContext = managerViewModel;
                managerView.Show();
            }
            else if(Username=="Direktor" && Pasword=="Direktorpasword")
            {
                direktorView = new DirektorView();
                direktorView.DataContext = direktorViewModel;
                direktorView.Show();
            }
            else
            {
                //klijent iz baze ili MessageBox....nije pravilna sifra
            }
        }



        private void _userLogin(object parametar)
        {
            /*
              Baza.BazaPodataka bp = new Baza.BazaPodataka();
             if (bp.ProvjeriLoginPodatke(Username, Password))
             {
                 //da se doda dugme kupi  na formi 
             }
             else
             {
                 Str = "Username ili password nisu tačni.";//ovo na Message Box
             }
             */
        }






        //geteri i seteri
        public string Pasword1
        {
            get { return Pasword; }
            set { Pasword = value; }
        }

        public string Username1
        {
            get { return Username; }
            set { Username = value; }
        }

        //interface

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
