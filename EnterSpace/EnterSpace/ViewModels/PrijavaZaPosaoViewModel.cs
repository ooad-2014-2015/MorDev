using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using EnterSpace.Models;

namespace EnterSpace.Models
{
    public class PrijavaZaPosaoViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel parent { get; set; }

        Prijavnica prijavnica;


        public PrijavaZaPosaoViewModel(MainWindowViewModel P)
        {
            parent = P;
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
