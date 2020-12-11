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
    /// Logique d'interaction pour frmControllerAdmin.xaml
    /// </summary>
    public partial class frmControllerAdmin : Window
    {
        edfEntities gst;
        public frmControllerAdmin()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gst = new edfEntities();
            lstController.ItemsSource = gst.controleur.ToList();


        }

        private void LstController_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstController.SelectedItem != null)
            {
                int numController = (lstController.SelectedItem as controleur).id;
                var query = from cli in gst.client
                            where cli.idcontroleur == numController
                            select new ClientPerso
                            {
                                idClient = cli.identifiant,
                                nomClient = cli.nom,
                                prenomClient = cli.prenom,
                                ancienReleveClient = cli.ancienReleve,
                                dernierReleveClient = cli.dernierReleve,
                                totalClient = cli.dernierReleve - cli.ancienReleve
                            };
                lstClient.ItemsSource = query.ToList();
            }
        }

        private void LstClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnInsererController_Click(object sender, RoutedEventArgs e)
        {
            if (txtNomClient.SelectedText == null)
            {
                MessageBox.Show("Veuillez sélectionner entree un nom controlleur", "Choix du controlleur ", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                if (txtPrenomClient.SelectedText == null)
                {
                    MessageBox.Show("Veuillez sélectionner entree un prenom controlleur ", "Choix du prenom ", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    controleur ctrl = new controleur()
                    {
                        id = gst.controleur.ToList().Max(c => c.id),
                        nom = txtNomController.Text,
                        prenom = txtPrenomClient.Text,
                        login = txtNomController.Text.Substring(0, 1).ToLower(), /*&& txtPrenomClient.Text.Substring(0,1).ToLower(),*/
                        mdp = txtNomController.Text.Substring(0, 1).ToLower()


                    };
                    gst.controleur.Add(ctrl);
                    gst.SaveChanges();
                    MessageBox.Show("L'inscription de votre controlleur \na bien été effectuée", "Insertion", MessageBoxButton.OK, MessageBoxImage.Information);

                }
            }
        }

        private void BtnInsererClient_Click(object sender, RoutedEventArgs e)
        {
            if (txtNomClient.SelectedText == null)
            {
                MessageBox.Show("Veuillez sélectionner entree un nom", "Choix du nom ", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                if (txtPrenomClient.SelectedText == null)
                {
                    MessageBox.Show("Veuillez sélectionner entree un prenom", "Choix du prenom ", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    client cli = new client()
                    {
                        identifiant = (gst.client.ToList().Max(c => c.identifiant))+1,
                        nom = txtNomClient.Text,
                        prenom = txtPrenomClient.Text,
                        ancienReleve = 0,
                        dernierReleve = 0,
                        idcontroleur = (lstController.SelectedItem as controleur).id,
                    };
                    gst.client.Add(cli);
                    gst.SaveChanges();
                    MessageBox.Show("L'inscription de votre client \na bien été effectuée", "Insertion", MessageBoxButton.OK, MessageBoxImage.Information);

                }
            }
        }
    }
}
