using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Aplic.Models
{
    public class Ponuda : INotifyPropertyChanged
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
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }

        private Planeta planeta;

        public Planeta Planeta
        {
            get { return planeta; }
            set { planeta = value; }
        }

        

        private string opis;

        public string Opis
        {
            get { return opis; }
            set { opis = value; }
        }

        private string smjestaj;

        public string Smjestaj
        {
            get { return smjestaj; }
            set { smjestaj = value; }
        }

        private int trajanjeDana;

        public int TrajanjeDana
        {
            get { return trajanjeDana; }
            set { trajanjeDana = value; }
        }

        private decimal cijena;

        public decimal Cijena
        {
            get { return cijena; }
            set { cijena = value; }
        }

        private int kapacitet;

        public int Kapacitet
        {
            get { return kapacitet; }
            set { kapacitet = value; }
        }


        private ObservableCollection<DateTime> polasci;

        public ObservableCollection<DateTime> Polasci
        {
            get { return polasci; }
            set { polasci = value; }
        }

        private ObservableCollection<Atrakcija> atrakcije;

        public ObservableCollection<Atrakcija> Atrakcije
        {
            get { return atrakcije; }
            set { atrakcije = value; }
        }

        private ObservableCollection<Recenzija> recenzije;

        public ObservableCollection<Recenzija> Recenzije
        {
            get { return recenzije; }
            set { recenzije = value; }
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
