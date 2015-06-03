using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace EnterSpaceGuide
{
    public partial class LogInPage : PhoneApplicationPage
    {
        public LogInPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            ocistiLogIn();
        }
        private void logInButton_Click(object sender, RoutedEventArgs e)
        {
            if (!validirajLogIn())
                return;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            while (NavigationService.CanGoBack)
            {
                NavigationService.RemoveBackEntry();
            }
        }
        private bool validirajLogIn()
        {
            string user = userTextBox.Text;
            string pass = passTextBox.Password;
            if (user.Length == 0 || pass.Length == 0)
            {
                MessageBox.Show("Niste unijeli obavezna polja. ", "Omaška!", MessageBoxButton.OK);
                ocistiLogIn();
                return false;
            }
            using (ESGLokalnaBazaContext db = new ESGLokalnaBazaContext(ESGLokalnaBazaContext.ConnectionString))
            {
                db.CreateIfNotExists();
                try
                {
                    var korisnik = (from f in db.Korisnici
                                    where (f.KorisnickoIme == user && f.Sifra == pass)
                                    select f).FirstOrDefault();

                    if (korisnik == null)
                    {
                        MessageBox.Show("Korisnik ne postoji. ", "Omaška!", MessageBoxButton.OK);
                        ocistiLogIn();
                        return false;
                    }
                    if (korisnik.Tip == 1)
                    {
                        var putovanje = (from f in db.Putovanja
                                         where (f.Korisnik_id == korisnik.Id)
                                         select f).FirstOrDefault();
                        if (putovanje == null)
                        {
                            MessageBox.Show("Korisnik trenutno nema rezervisano putovanje. ", "Omaška!", MessageBoxButton.OK);
                            ocistiLogIn();
                            return false;
                        }
                        NavigationService.Navigate(new Uri("/PutovanjePage.xaml?korID=" + korisnik.Id + "&putID=" + putovanje.Id.ToString(), UriKind.Relative));
                    }
                    else
                    {
                        NavigationService.Navigate(new Uri("/OsiguranjePage.xaml?korID=" + korisnik.Id, UriKind.Relative));
                    }

                }
                catch (Exception omsaka)
                {
                }
                return true;
            }
        }

        private void ocistiLogIn()
        {
            userTextBox.Text = string.Empty;
            passTextBox.Password = string.Empty;
        }
    }
}