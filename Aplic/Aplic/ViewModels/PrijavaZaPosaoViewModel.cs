using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Aplic.Models;

namespace Aplic.ViewModels
{
   public class PrijavaZaPosaoViewModel:INotifyPropertyChanged
    {
       public MainWindowViewModel Parent { get; set; }

       public PrijavaZaPosaoViewModel(MainWindowViewModel P)
        {
            Parent =P;
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
