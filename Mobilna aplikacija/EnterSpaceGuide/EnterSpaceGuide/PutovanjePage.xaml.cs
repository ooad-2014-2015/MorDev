using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using EnterSpaceGuide.Resources;
using System.Data.Linq;
using System.IO;
using System.Windows.Media.Imaging;

namespace EnterSpaceGuide
{
    public partial class MainPage : PhoneApplicationPage
    {
        public int KorisnikID { get; set; }
        public int PutovanjeID { get; set; }

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string korID = string.Empty;
            string putID = string.Empty;
            NavigationContext.QueryString.TryGetValue("korID", out korID);
            KorisnikID = Int32.Parse(korID);
            NavigationContext.QueryString.TryGetValue("putID", out putID);
            PutovanjeID = Int32.Parse(putID);
            popuniPivot();
            popuniIme();
        }

        private void popuniIme()
        {
            if (korisnik.Text == string.Empty)
            {
                using (ESGLokalnaBazaContext db = new ESGLokalnaBazaContext(ESGLokalnaBazaContext.ConnectionString))
                {
                    db.CreateIfNotExists();
                    try
                    {
                        Table<Korisnici> korisnici = db.GetTable<Korisnici>();
                        var korisniciUpit = from k in korisnici.ToList() select k;
                        var korisnikDB = korisniciUpit.FirstOrDefault(kor => kor.Id == KorisnikID);
                        korisnik.Text = korisnikDB.KorisnickoIme.ToString() + "[" + korisnikDB.Ime.ToString() + " " + korisnikDB.Prezime.ToString() + "]";
                    }
                    catch (Exception omaska)
                    { 
                     
                    }
                }
            }
            if (nazivPutovanja.Text == string.Empty)
            {
                using (ESGLokalnaBazaContext db = new ESGLokalnaBazaContext(ESGLokalnaBazaContext.ConnectionString))
                {
                    db.CreateIfNotExists();
                    try
                    {
                        Table<Putovanja> putovanja = db.GetTable<Putovanja>();
                        var putovanjaUpit = from p in putovanja.ToList() select p;
                        var putovanjeDB = putovanjaUpit.FirstOrDefault(put => put.Id == PutovanjeID);
                        nazivPutovanja.Text = putovanjeDB.Naziv.ToString();
                        planeta.Text = putovanjeDB.Planeta.ToString();
                    }
                    catch (Exception omaska)
                    { 
                    
                    }
                }
            
            }
        }

        private void popuniPivot()
        {
            if (atrakcijePivot.Items.Count == 0)
            {
                using (ESGLokalnaBazaContext db = new ESGLokalnaBazaContext(ESGLokalnaBazaContext.ConnectionString))
                {
                    db.CreateIfNotExists();
                    try
                    {
                        // Poboljsati sa boljim upitom
                        Table<Atrakcije> atrakcije = db.GetTable<Atrakcije>();
                        var atrakcijeUpit = from a in atrakcije.ToList() select a;
                        foreach (var atrakcija in atrakcijeUpit)
                        {
                            if (atrakcija.Id_putovanja == PutovanjeID)
                            {
                                PivotItem pivot = new PivotItem();
                                AtrakcijaKontrola atrakcijaKontrola = new AtrakcijaKontrola();
                                atrakcijaKontrola.vrijemeAtrakcije.Text = atrakcija.Vrijeme.ToShortTimeString();
                                atrakcijaKontrola.danAtrakcije.Text = atrakcija.Dan.ToString();
                                atrakcijaKontrola.opisAtrakcije.Text = atrakcija.Opis.ToString();
                                if (atrakcija.Slika != null && atrakcija.Slika.ToArray() is Byte[])
                                {
                                    MemoryStream stream = new MemoryStream(atrakcija.Slika.ToArray());
                                    BitmapImage image = new BitmapImage();
                                    image.SetSource(stream);
                                    atrakcijaKontrola.slikaAtrakcije.Source = image;
                                }
                                pivot.Header = atrakcija.Naziv;
                                pivot.Content = atrakcijaKontrola;
                                atrakcijePivot.Items.Add(pivot);
                            }

                        }

                    }
                    catch (Exception omaska)
                    {

                    }
                }
            }
        }
    }
}