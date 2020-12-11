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

namespace ProjetEdf
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        edfEntities gst;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gst = new edfEntities();
        }

        private void BtnConnexion_Click(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text == null)
            {
                MessageBox.Show("Veuillez sélectionner un login", "Rentree un login", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                if (txtPassword.Text == null)
                {
                    MessageBox.Show("Veuillez sélectionner un mot de passe", "Rentree un mdp", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    controleur connect = gst.controleur.ToList().Find(cont => cont.login == (txtLogin.Text) && cont.mdp == (txtPassword.Text));

                    if (connect.statut == "admin")
                    {
                        frmControllerAdmin frmAdmin = new frmControllerAdmin();
                        frmAdmin.Show();
                    }
                    else if(connect.statut == "ctrl")
                    {
                        FrmController frm = new FrmController();
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Login ou password incorrect", "Merci de réessayer", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                }
                
            }
        }
    }
}
