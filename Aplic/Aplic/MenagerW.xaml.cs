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
using System.Windows.Shapes;

namespace Aplic
{
    /// <summary>
    /// Interaction logic for MenagerW.xaml
    /// </summary>
    public partial class MenagerW : Window
    {
        UnosKlijentaW unosKlijenta2;
        UnosPonudeW unosPonude1, unosPonude2;
        public MenagerW()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            unosKlijenta2 = new UnosKlijentaW();
            unosKlijenta2.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            unosPonude1 = new UnosPonudeW();
            unosPonude1.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            //dio gdje povuce iz baze ponudu sa id-om kojeg procita iz textBoxa
            unosPonude2 = new UnosPonudeW();
            unosPonude2.ShowDialog();
        }
    }
}
