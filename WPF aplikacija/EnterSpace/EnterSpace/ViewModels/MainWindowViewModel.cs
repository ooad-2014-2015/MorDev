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


        private ObservableCollection<DAL.Ponuda> listaPonuda;
        public ObservableCollection<DAL.Ponuda> Ponude
        {
            get { return listaPonuda; }
            set
            {
                listaPonuda = value;
            }
        }

        private string hidprop;

	    public string Hidprop
	    {
		    get { return hidprop;}
		    set { hidprop = value;}
	    }

        bool _dgVisibility;
        public bool DataGridVisibility
        {
            get { return _dgVisibility; }
            set
            {
                _dgVisibility = value;
                OnPropertyChanged("DataGridVisibility");
            }
        }


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
        public ICommand MerkurKlik { get; set; }
        public ICommand VeneraKlik { get; set; }
        public ICommand MjesecKlik { get; set; }
        public ICommand MarsKlik { get; set; }
        public ICommand JupiterKlik { get; set; }
        public ICommand SaturnKlik { get; set; }
        public ICommand UranKlik { get; set; }
        public ICommand NeptunKlik { get; set; }
        public ICommand HelpMe { get; set; }


#endregion
#region konstruktor
        public MainWindowViewModel()
        {

            #region relayCommands
            Oglas = new RelayCommand(_prikaziOglasFormu);
            Prijava = new RelayCommand(_prikaziFormuZaPrijavu);
            Izbor = new RelayCommand(_prikaziFormuMiliD);
            MjesecKlik = new RelayCommand(_metodaMjesec);
            MerkurKlik = new RelayCommand(_metodaMerkur);
            VeneraKlik = new RelayCommand(_metodaVenera);
            MarsKlik = new RelayCommand(_metodaMars);
            JupiterKlik = new RelayCommand(_metodaJupiter);
            SaturnKlik = new RelayCommand(_metodaSaturn);
            NeptunKlik = new RelayCommand(_metodaNeptun);
            UranKlik = new RelayCommand(_metodaUran);
            HelpMe = new RelayCommand(_metodaHelp);
            #endregion

            pZaPosaoViewModel = new PrijavaZaPosaoViewModel(this);
            pKorisnikaViewModel = new PrijavaKorisnikaViewModel(this);
            managerViewModel = new ManagerViewModel(this);
            direktorViewModel = new DirektorViewModel(this);

            var ponude = db.Ponude.ToList();
            listaPonuda = new ObservableCollection<DAL.Ponuda>(ponude);
            hidprop = "Hidden";

            // ubacivanje klijenta
            klijent = new Klijent();
            var klijenti = db.Klijenti.ToList();


            //za nit - ovaj dio ubaciti u metodu koja se bude bindala za dugme rezervisi
            nit = new Thread(() => generisiNarudzbu());
            nit.IsBackground = true;
            nit.Start(); 

        }

        private void _metodaHelp(object obj)
        {
            MessageBox.Show("- Ukoliko nemate korisnicki racun, pritisnite SignUp te popunite svoje podatke i pritisnite dugme posalji. \n"+
                "- Da biste rezervisali putovanje morate se logovati. Unesite korisnicko ime i password te pritisnite dugme LogIn \n" +
                "- Pritisnite mišem planetu na koju zelite putovati i potvrdite rezervaciju. \n" +
                "- Ukoliko zelite prijaviti se za posao pritisnite dugme Oglas za posao ");
        }


        #region metodeZaPlanete
        private string _kreirajRezervaciju(string imePlanete)
        {
            var _rezervacije = db.Rezervacije.ToList();
            var _ponude = db.Ponude.ToList();
            var _klijenti = db.Klijenti.ToList();
            var _planete = db.Planete.ToList();

            int idPlanete=1;
            foreach (var pl in _planete)
            {
                if (pl.Naziv == imePlanete) {idPlanete = pl.Id; }
            }


            foreach (var p in _ponude)
            {
                
                if (p.Planeta.Id == idPlanete) 
                {
     
                    var novaRezervacija = new DAL.Rezervacija();
                    novaRezervacija.Ponuda = p;
                    novaRezervacija.DatumPolaska = p.datumPolaska;
                    novaRezervacija.DatumRezervacije = DateTime.Now;

                    foreach (var kl in _klijenti)
                    {
                        if (Username1 == kl.Username) 
                        { 
                            novaRezervacija.Klijent = kl; 
                        }
                    }
                    int brrez = 0;
                    foreach (var rez in _rezervacije)
                    {
                        if (rez.Ponuda == p) brrez++;
                    }

                    if (brrez< p.Kapacitet)
                    {
                        db.Rezervacije.Add(novaRezervacija);
                        db.SaveChanges();
                        return ("Uspjesno ste rezervisali putovanje!");
                    }
                }
                 
            }
            return ("Nazalost kapacitet je popunjen! "); 
        }
        private void _metodaMjesec(object obj)
        {

            if (prijavljen == false)
            {
                MessageBox.Show("Morate se logovati da bi ste mogli izvrsiti rezervaciju");
            }
            else
            {
                if (MessageBox.Show("Da li zelite rezervisati putovanje na Mjesec?", "Question", 
                    MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    MessageBox.Show("Odustali ste od rezervacije!");
                }
                else
                {

                    MessageBox.Show(_kreirajRezervaciju("Mjesec"));
                }
                
            }
        }
        private void _metodaMerkur(object obj)
        {
            if (prijavljen == false)
            {
                MessageBox.Show("Morate se logovati da bi ste mogli izvrsiti rezervaciju");
            }
            else
            {
                if (MessageBox.Show("Da li zelite rezervisati putovanje na Merkur?", "Question",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    MessageBox.Show("Odustali ste od rezervacije!");
                }
                else
                {
                    MessageBox.Show(_kreirajRezervaciju("Merkur"));
                }

            }
        }
        private void _metodaVenera(object obj)
        {
            if (prijavljen == false)
            {
                MessageBox.Show("Morate se logovati da bi ste mogli izvrsiti rezervaciju");
            }
            else
            {
                if (MessageBox.Show("Da li zelite rezervisati putovanje na Veneru?", "Question",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    MessageBox.Show("Odustali ste od rezervacije!");
                }
                else
                {
                    MessageBox.Show(_kreirajRezervaciju("Venera"));
                }

            }
        }
        private void _metodaMars(object obj)
        {
            if (prijavljen == false)
            {
                MessageBox.Show("Morate se logovati da bi ste mogli izvrsiti rezervaciju");
            }
            else
            {
                if (MessageBox.Show("Da li zelite rezervisati putovanje na Mars?", "Question",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    MessageBox.Show("Odustali ste od rezervacije!");
                }
                else
                {
                    MessageBox.Show(_kreirajRezervaciju("Mars"));
                }

            }
        }
        private void _metodaJupiter(object obj)
        {
            if (prijavljen == false)
            {
                MessageBox.Show("Morate se logovati da bi ste mogli izvrsiti rezervaciju");
            }
            else
            {
                if (MessageBox.Show("Da li zelite rezervisati putovanje na Jupiter?", "Question",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    MessageBox.Show("Odustali ste od rezervacije!");
                }
                else
                {
                    MessageBox.Show(_kreirajRezervaciju("Jupiter"));
                }

            }
        }
        private void _metodaSaturn(object obj)
        {
            if (prijavljen == false)
            {
                MessageBox.Show("Morate se logovati da bi ste mogli izvrsiti rezervaciju");
            }
            else
            {
                if (MessageBox.Show("Da li zelite rezervisati putovanje na Saturn?", "Question",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    MessageBox.Show("Odustali ste od rezervacije!");
                }
                else
                {
                    MessageBox.Show(_kreirajRezervaciju("Saturn"));
                }

            }
        }
        private void _metodaNeptun(object obj)
        {
            if (prijavljen == false)
            {
                MessageBox.Show("Morate se logovati da bi ste mogli izvrsiti rezervaciju");
            }
            else
            {
                if (MessageBox.Show("Da li zelite rezervisati putovanje na Neptun?", "Question",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    MessageBox.Show("Odustali ste od rezervacije!");
                }
                else
                {
                    MessageBox.Show(_kreirajRezervaciju("Neptun"));
                }

            }
        }
        private void _metodaUran(object obj)
        {
            if (prijavljen == false)
            {
                MessageBox.Show("Morate se logovati da bi ste mogli izvrsiti rezervaciju");
            }
            else
            {
                if (MessageBox.Show("Da li zelite rezervisati putovanje na Uran?", "Question",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    MessageBox.Show("Odustali ste od rezervacije!");
                }
                else
                {
                    MessageBox.Show(_kreirajRezervaciju("Uran"));
                }

            }
        }
  



        #endregion




#endregion


#region metode
        

       private void generisiNarudzbu()
        {
            var ponude = db.Ponude.ToList();
            var rezervacije = db.Rezervacije.ToList();
            var narudzbenice = db.Narudzbenice.ToList();
            var saradnici= db.Poslovnisaradnici.ToList();
            
            int brojRezervacija = 0;
            foreach (var p in ponude) 
            {
                if (Convert.ToInt32( (p.datumPolaska - DateTime.Now).TotalDays )== 2)
                {
                    foreach (var r in rezervacije)
                    {
                        if (r.Ponuda == p) brojRezervacija++;
                    }
                    foreach (var ps in saradnici)
                    {
                        var n = new DAL.Narudzbenica();
                        n.BrojPutnika = brojRezervacija;
                        n.Datum = DateTime.Now;
                        n.Destinacija = p.Naziv;
                        n.PoslovniSaradnik = ps;
                        n.TipOpreme = ps.TipOpreme;
                        //provjera da li je narudzbenica vec kreirana:
                        bool postoji=false;
                        foreach (var i in narudzbenice)
                        {
                            if (i.Destinacija == p.Naziv && i.Datum == n.Datum) postoji = true;
                        }
                        if (!postoji)
                        {
                            db.Narudzbenice.Add(n);
                            db.SaveChanges();
                        }
                        
                    }

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

        bool prijavljen = false;
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
                            prijavljen = true;
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
