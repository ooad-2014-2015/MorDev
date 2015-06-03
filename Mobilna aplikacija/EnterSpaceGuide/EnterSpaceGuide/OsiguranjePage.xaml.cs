using System;
using System.Net;
using System.Text;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using Microsoft.Phone.Reactive;
using Microsoft.Phone.Shell;
using Microsoft.Xna.Framework;
using Windows.Devices.Sensors;
using Windows.Networking.Proximity;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using Windows.Phone.Speech.Recognition;
using Windows.Phone.Speech.Synthesis;
using System.Windows.Navigation;

namespace EnterSpaceGuide
{
    public partial class OsiguranjePage : PhoneApplicationPage
    {
        public int KorisnikID { get; set; }
        StreamSocket BTSocket;
        string BT_Received = string.Empty;

        public OsiguranjePage()
        {
            InitializeComponent();
            Loaded += OsiguranjePage_Loaded;
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
   
        private async void OsiguranjePage_Loaded(object sender, RoutedEventArgs e)
        {
            PeerFinder.Start();
            PeerFinder.AlternateIdentities["Bluetooth:Paired"] = "";
            var peers = await PeerFinder.FindAllPeersAsync();
            debugTextBox.Text = "Traženje uparenih uređaja...";

            for (int i = 0; i < peers.Count; i++)
            {
                upareniUredjaji.Items.Add(peers[i].DisplayName);
            }

            debugTextBox.Text = "Pronađeno " + peers.Count.ToString() + " uparenih uređaja.";
        }

        private async void upareniUredjaji_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (upareniUredjaji.SelectedItem == null)
            {
                debugTextBox.Text = "Niste odabrali upareni uređaj...";
                return;
            }
            else
            {
                PeerFinder.AlternateIdentities["Bluetooth:Paired"] = "";
                var PF = await PeerFinder.FindAllPeersAsync();
                BTSocket = new StreamSocket();
                await BTSocket.ConnectAsync(PF[upareniUredjaji.SelectedIndex].HostName, "1");
            }
        }
    }
}