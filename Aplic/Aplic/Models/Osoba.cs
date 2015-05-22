using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Aplic.Models
{
    public abstract class Osoba : INotifyPropertyChanged, IDataErrorInfo
    {

        private int id;
        private string ime; 
        private string prezime;
        private string email;
        private string broj_telefona;


        public Osoba(string firstName, string lastName, string email, string brTel)
        {
            try
            {
                this.Ime = firstName;
                this.Prezime = lastName;
                this.Email = email;
                this.broj_telefona = brTel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Osoba()
        {

        }



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
                    case "FirstName":
                        if (String.IsNullOrEmpty(Ime))
                        {
                            errorMessage = "Morate unijeti ime";
                        }
                        break;
                    case "LastName":
                        if (String.IsNullOrEmpty(Prezime))
                        {
                            errorMessage = "Morate unijeti prezime";
                        }
                        break;
                    case "Email":
                        if (String.IsNullOrEmpty(Email))
                        {
                            errorMessage = "Morate unijeti email";
                        }
                        else
                        {
                            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                            Match match = regex.Match(Email);
                            if (!match.Success)
                                errorMessage = "Neispravna email adresa";
                        }
                        break;
                    case "Broj_telefona":
                        if (String.IsNullOrEmpty(Broj_telefona))
                        {
                            errorMessage = "Morate unijeti broj telefona";
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
            "Ime","Prezime", "Email", "Broj_telefona"
        };
        #endregion


        



    }
}
