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

        private void prijaviButton_Click(object sender, RoutedEventArgs e)
        {
            // provjera da li je prazan
            // insert??
            string problemText = problemTextBox.Text;
            using (ESGLokalnaBazaContext db = new ESGLokalnaBazaContext(ESGLokalnaBazaContext.ConnectionString))
            {
                db.CreateIfNotExists();
                try
                {
                    Table<Problemi> problemi = db.GetTable<Problemi>();
                    
                }
                catch (Exception omaska)
                { 
                }
            
            }
        }
    }
}