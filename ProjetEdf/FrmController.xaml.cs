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

namespace ProjetEdf
{
    /// <summary>
    /// Logique d'interaction pour FrmController.xaml
    /// </summary>
    public partial class FrmController : Window
    {
        edfEntities gst;

        public FrmController()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gst = new edfEntities();
            lstClient.ItemsSource = gst.client.ToList();
        }

       

        private void BtnInsere_Click(object sender, RoutedEventArgs e)
        { 

        }
    }
}
