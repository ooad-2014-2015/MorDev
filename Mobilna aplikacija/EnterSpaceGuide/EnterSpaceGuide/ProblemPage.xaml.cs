using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Data.Linq;

namespace EnterSpaceGuide
{
    public partial class ProblemPage : PhoneApplicationPage
    {
        public int KorisnikID { get; set; }
        public ProblemPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            ocistiProblem();
        }

        private void ocistiProblem()
        {
            problemTextBox.Text = string.Empty;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string korID = string.Empty;
            NavigationContext.QueryString.TryGetValue("korID", out korID);
            KorisnikID = Int32.Parse(korID);
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
                        var korisnikDB = (from f in db.Korisnici
                                          where (f.Id == KorisnikID)
                                          select f).FirstOrDefault();                                          
                        korisnik.Text = korisnikDB.KorisnickoIme.ToString() + "[" + korisnikDB.Ime.ToString() + " " + korisnikDB.Prezime.ToString() + "]";
                    }
                    catch (Exception omaska)
                    { 
                     
                    }
                }
            }
        }

        private void prijaviButton_Click(object sender, RoutedEventArgs e)
        {
            string problemText = problemTextBox.Text;
            if (problemText == string.Empty)
            {
                MessageBox.Show("Niste unijeli problem. ", "Omaška!", MessageBoxButton.OK);
                return;
            }
            using (ESGLokalnaBazaContext db = new ESGLokalnaBazaContext(ESGLokalnaBazaContext.ConnectionString))
            {
                db.CreateIfNotExists();
                try
                {
                    Problemi problem = new Problemi();
                    problem.Datum = DateTime.Now;
                    problem.Korisnik_id = KorisnikID;
                    problem.Opis = problemText;
                    problem.Id = db.Problemi.ToList().Count + 1;
                    db.Problemi.InsertOnSubmit(problem);
                    db.SubmitChanges();
                    ocistiProblem();
                    MessageBox.Show("Problem uspješno prijavljen. Ne brinite. Osiguranje radi na rješavanju problema. ", "Bez panike", MessageBoxButton.OK);
                    NavigationService.GoBack();
                }
                catch (Exception omaska)
                { 
                }
            
            }
        }

        private void odustaniButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}