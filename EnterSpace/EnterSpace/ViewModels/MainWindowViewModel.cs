using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using EnterSpace.ViewModels;
using EnterSpace.Models;
using System.Windows;

using System.Collections.ObjectModel;

using System.Threading;





namespace EnterSpace
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
       

#region deklaracija atributa
        string username, pasword;
        Klijent klijent;
        DAL.Baza db = new DAL.Baza();


#endregion
#region deklaracija formi
        PrijavaZaPosao pZaPosao;
        PrijavaKorisnika pKorisnika;
        ManagerView managerView;
        DirektorView direktorView;


#endregion
#region deklaracija viewModela
        PrijavaZaPosaoViewModel pZaPosaoViewModel;
        PrijavaKorisnikaViewModel pKorisnikaViewModel;
        ManagerViewModel managerViewModel;
        DirektorViewModel direktorViewModel;

        Thread nit;
        //liste
        

#endregion
 #region commande
        public ICommand Oglas { get; set; }
        public ICommand Prijava { get; set; }
        public ICommand Izbor { get; set; }
        public ICommand UserLogin { get; set; }
#endregion
#region konstruktor
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
            var klijenti = db.Klijenti.ToList();


            //za nit - ovaj dio ubaciti u metodu koja se bude bindala za dugme rezervisi
            nit = new Thread(() => generisiNarudzbu());
            nit.IsBackground = true;
            nit.Start(); 

        }
#endregion


#region metode
       private void generisiNarudzbu()
        {
            var ponude = db.Ponude.ToList();
            var rezervacije = db.Rezervacije.ToList();

           foreach(var r in rezervacije)
           {
               int brojRezervacija=0;
               DateTime pamtiDatum=DateTime.Now;
               foreach(var p in ponude)
               {                  
                    if(r.Ponuda.Id==p.Id) //broji samo rezervacije od te ponude koju posmatra
                    {
                        brojRezervacija++;
                        pamtiDatum = r.DatumPolaska;
                    }
                    if(brojRezervacija > p.Kapacitet)
                    {
                        MessageBox.Show("Kapacitet ponude popunjen!");
                    }
               }
               if ((pamtiDatum - DateTime.Now).TotalDays==3  ) 
               {
               //kreiranje NArudzebnice i ubacivanje narudzbenice u bazu
               }
           }
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
            if (Username1 == "manager" && Password1 == "1")
            {
                managerView = new ManagerView();
                managerView.DataContext = managerViewModel;
                managerView.Show();
            }
            else if (Username1 == "direktor" && Password1 == "1")
            {
                direktorView = new DirektorView();
                direktorView.DataContext = direktorViewModel;
                direktorView.Show();
            }
            else
            {

                using(DAL.Baza db = new DAL.Baza())
                {
                    bool p = false;
                    foreach(var k in db.Klijenti)
                    {
                        if (k.Username == Username1 && k.Password == Password1)
                        {
                            MessageBox.Show("Uspjesno ste prijavljeni na sistem!", "Uspjesna prijava");
                            p=true;
                        }
                    }
                     
                            
                 if (p==false)  
                 MessageBox.Show("Pogrešan username ili password", "Greška");
                        
                   
                   
            }

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
#endregion




 #region geteri i seteri
        public Klijent Klijent
        {
            get { return klijent; }
            set { klijent = value; }
        }
        public string Password1
        {
            get { return pasword; }
            set { pasword = value; }
        }

        public string Username1
        {
            get { return username; }
            set { username = value; }
        }
 #endregion


#region implemetacija interfejsa

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
#endregion
    }
}
