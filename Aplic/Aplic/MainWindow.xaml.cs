
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Aplic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PrijavaZaPosaoW prijavaZaPosao1;
        LoginW logIn;
        UnosKlijentaW unosKlijenta1;

        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            prijavaZaPosao1 = new PrijavaZaPosaoW();
            prijavaZaPosao1.ShowDialog();
           

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            logIn = new LoginW();
            logIn.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            unosKlijenta1 = new UnosKlijentaW();
            unosKlijenta1.ShowDialog();
        }

     

        private void Button_Click_4(object sender, RoutedEventArgs e)
        { //ovaj dogadaj je kreiran samo da testira menager formu
            MenagerW m = new MenagerW();
            m.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            

        }
    }
}
