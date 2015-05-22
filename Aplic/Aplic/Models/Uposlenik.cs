using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Text.RegularExpressions;
//using MySql.Data.MySqlClient;

namespace Aplic.Models
{
    public class Uposlenik : Osoba, INotifyPropertyChanged, IDataErrorInfo
    {
        private string vrstaPosla;
        

        public Uposlenik(string firstName, string lastName, string email, string brTel, string vrstaP, DateTime datZap)
            : base(firstName, lastName, email, brTel)
        {
            this.vrstaPosla = vrstaP;
            this.datumZaposlenja = datZap;
        }


        public string VrstaPosla
        {
            get { return vrstaPosla; }
            set 
            { 
                vrstaPosla = value; 
                OnPropertyChanged("VrstaPosla"); 
            }
        }

        private DateTime datumZaposlenja;
        public DateTime DatumZaposlenja 
        {
            get { return DatumZaposlenja; }
            set 
            { 
                datumZaposlenja = value; 
                OnPropertyChanged("DatumZaposlenja"); 
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion


        #region Greske

        string IDataErrorInfo.Error
        {
            get { return String.Empty; }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get { return getValidationError(columnName); }
        }

        string getValidationError(string columnName)
        {
            String errorMessage = String.Empty;
            switch (columnName)
            {
                case "VrstaPosla":
                    if (String.IsNullOrEmpty(VrstaPosla))
                    {
                        errorMessage = "Morate unijeti trazene podatke";
                    }
                    break;
                case "DatumZaposlenja":
                    if (String.IsNullOrEmpty(DatumZaposlenja.ToString()))
                    {
                        errorMessage = "Morate unijeti trazene podatke";
                    }
                    break;
                
            }
            return errorMessage;
        }


        public bool IsValid
        {
            get
            {
                foreach (string p in AllProperties)
                {
                    if (getValidationError(p) != null)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        static readonly string[] AllProperties =
        {
            "VrstaPosla","DatumZaposlenja"
        };
        #endregion

        
    }
}
