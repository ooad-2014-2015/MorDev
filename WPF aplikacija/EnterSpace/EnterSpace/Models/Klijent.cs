﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace EnterSpace.Models
{
    public class Klijent:Osoba, INotifyPropertyChanged, IDataErrorInfo
    {

        private int id;
        private string ime; 
        private string prezime;
        private string email;
        private string broj_telefona;

        
        public int Id
        {
            get { return id; }
            set { id = value;  }
        }

        public string Ime
        {
            get { return ime; }
            set 
            { 
                ime = value; 
                OnPropertyChanged("Ime"); 
            }
        }

        public string Prezime
        {
            get { return prezime; }
            set 
            { 
                prezime = value; 
                OnPropertyChanged("Prezime"); 
            }
        }

        public string Email
        {
            get { return email; }
            set 
            { 
                email = value; 
                OnPropertyChanged("Email"); 
            }
        }

        public string Broj_telefona
        {
            get { return broj_telefona; }
            set
            { 
                broj_telefona = value; 
                OnPropertyChanged("Broj_telefona"); 
            }
        }

        private string username,password;
        private DateTime datumRegistracije;
        
        

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

        public Klijent() { }
        public Klijent(int id, string fn, string ln, string email, string brTel, string u, string pass)
        {
            this.id = id;
            this.ime = fn;
            this.prezime = ln;
            this.email = email;
            this.broj_telefona = brTel;
            this.username = u;
            this.password = pass;

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
