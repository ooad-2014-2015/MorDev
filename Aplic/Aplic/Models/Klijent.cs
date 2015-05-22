using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Aplic.Models
{
    public class Klijent:Osoba, INotifyPropertyChanged, IDataErrorInfo
    {
        private string username,password;
        private DateTime datumRegistracije;
        /*
        public Klijent(string firstName, string lastName, string email, string brTel, string vrstaP, DateTime datZap)
            : base(firstName, lastName, email, brTel)
        {
            this.vrstaPosla = vrstaP;
            this.datumZaposlenja = datZap;
        }*/

        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged("Username"); }
        }

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged("Password"); }
        }
        
        public DateTime DatumRegistracije 
        {
            get { return DatumRegistracije; }
            set { datumRegistracije = value; OnPropertyChanged("DatumRegistracije"); }
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
                case "Username":
                    if (String.IsNullOrEmpty(Username))
                    {
                        errorMessage = "Morate unijeti trazene podatke";
                    }
                    break;
                case "Password":
                    if (String.IsNullOrEmpty(Password))
                    {
                        errorMessage = "Morate unijeti trazene podatke";
                    }
                    break;
                case "DatumRegistracije":
                    if (String.IsNullOrEmpty(DatumRegistracije.ToString()))
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
            "Username","Password","DatumRegistracije"
        };
        #endregion
    }
}
