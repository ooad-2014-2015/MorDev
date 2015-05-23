using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using Aplic.Models;
using Aplic;





namespace Aplic.ViewModels
{
   public class MainWindowViewModel : INotifyPropertyChanged
    {
       string Username, Pasword;
       //deklaracija formi
        PrijavaZaPosao pZaPosao;
        PrijavaKorisnika pKorisnika;
        ManagerView managerView;
        //deklaracija viewModela
        PrijavaZaPosaoViewModel pZaPosaoViewModel;
        PrijavaKorisnikaViewModel pKorisnikaViewModel;
        ManagerViewModel managerViewModel;

        Klijent klijent;



        public ICommand Oglas { get; set; }
        public ICommand UserLogin { get; set; }
        public MainWindowViewModel()
        {
            pZaPosaoViewModel = new PrijavaZaPosaoViewModel(this);
            Oglas = new RelayCommand(prikaziOglasFormu);

            pKorisnikaViewModel = new PrijavaKorisnikaViewModel(this);
            managerViewModel= new ManagerViewModel(this);
            //vezat za dogadaj ubacivanja klijenta
            klijent = new Klijent();

        }




        private void prikaziOglasFormu(object parametar)
        {            
              pZaPosao = new PrijavaZaPosao();
              pZaPosao.DataContext = pZaPosaoViewModel;
              pZaPosao.Show();
        }

        private void prikaziManagerFormu(object parametar)
        {
            if (Username == "Manager" && Pasword == "Managerpasword")
            {
                managerView = new ManagerView();
                managerView.DataContext = managerViewModel;
                managerView.Show();  
            }        
            else
            {
                //MessageBox....nije pravilna sifra
            }
        }



        private void userLogin(object parametar)
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
