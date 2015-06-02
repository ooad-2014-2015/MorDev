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
        }
        private void logInButton_Click(object sender, RoutedEventArgs e)
        {
            string user = userTextBox.Text;
            string pass = passTextBox.Password;
            if (user.Length == 0 || pass.Length == 0) {
                MessageBox.Show("Niste unijeli obavezna polja. ", "Omaška!", MessageBoxButton.OK);
                userTextBox.Text = string.Empty;
                passTextBox.Password = string.Empty;
                return;
            }
            using (ESGLokalnaBazaContext db = new ESGLokalnaBazaContext(ESGLokalnaBazaContext.ConnectionString))
            {
                db.CreateIfNotExists();
                try
                {
                    Table<Korisnici> korisnici = db.GetTable<Korisnici>();
                    var korisniciUpit = from k in korisnici.ToList() select k;
                    var korisnik = korisniciUpit.FirstOrDefault(kor => kor.KorisnickoIme == user && kor.Sifra == pass);
                    if (korisnik == null)
                    {
                        MessageBox.Show("Korisnik ne postoji. ", "Omaška!", MessageBoxButton.OK);
                        userTextBox.Text = string.Empty;
                        passTextBox.Password = string.Empty;
                        return;
                    }
                    
                    if (korisnik.Tip == 1)
                    {
                        Table<Putovanja> putovanja = db.GetTable<Putovanja>();
                        var putovanjaUpit = from p in putovanja.ToList() select p;
                        var putovanje = putovanja.FirstOrDefault(pt => pt.Korisnik_id == korisnik.Id);
                        if (putovanje == null)
                        {
                            MessageBox.Show("Korisnik trenutno nema rezervisano putovanje. ", "Omaška!", MessageBoxButton.OK);
                            userTextBox.Text = string.Empty;
                            passTextBox.Password = string.Empty;
                            return;
                        }
                        NavigationService.Navigate(new Uri("/PutovanjePage.xaml?korID=" + korisnik.Id.ToString() + "&putID=" + putovanje.Id.ToString(), UriKind.Relative));
                    }

                }
                catch (Exception omsaka)
                { 
                }
            }
        }
    }
}