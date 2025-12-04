using Projet_Pharmacie;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_Pharmacie
{
    public partial class EspaceAdministrateur : Form
    {
        public EspaceAdministrateur()
        {
            InitializeComponent();
            InitialiserMotDePasse();
        }


        private void InitialiserMotDePasse()
        {
            // Configurer le TextBox du mot de passe pour masquer les caractères
            BoxMDP.PasswordChar = '*';
            BoxMDP.MaxLength = 10; // Limiter la longueur
        }

        private void BtnConnexion_Click(object sender, EventArgs e)
        {
            // Vérifier les identifiants (à implémenter)
            string login = BoxLogin.Text;
            string motDePasse = BoxMDP.Text;



            // Vérifications basiques côté client
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(motDePasse))
            {
                MessageBox.Show("Veuillez saisir votre login et votre mot de passe.",
                                "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;


            }


            // Optionnel : vider le mot de passe 
            BoxMDP.Clear();

            CompteAdministrateur compteAdministrateur = new CompteAdministrateur();
            compteAdministrateur.Show();

            // Optionnel : Cacher la fenêtre actuelle
            this.Hide();
            return;

        }
        private void BoxLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void BoxMDP_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnCompte_Click(object sender, EventArgs e)
        {
            NouveauCompteAdmin nouveauCompte = new NouveauCompteAdmin();
            nouveauCompte.Show();

            // Optionnel : Cacher la fenêtre actuelle
            this.Hide();
            return;
        }

        private void EspaceAdministrateur_Load(object sender, EventArgs e)
        {

        }
    }
}
