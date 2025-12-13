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
using Projet_Pharmacie.DAL;

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
            string login = BoxLogin.Text.Trim();
            string motDePasse = BoxMDP.Text;

            // Vérifications basiques
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(motDePasse))
            {
                MessageBox.Show("Veuillez saisir votre login et votre mot de passe.",
                    "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // VÉRIFICATION DANS LA BASE DE DONNÉES
            bool connexionReussie = Projet_Pharmacie.DAL.AdministrateurDAL.VerifierConnexion(login, motDePasse);

            if (connexionReussie)
            {
                MessageBox.Show("✅ Connexion réussie ! Bienvenue Administrateur.",
                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ouvrir l'interface admin
                CompteAdministrateur compteAdministrateur = new CompteAdministrateur();
                compteAdministrateur.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("❌ Login ou mot de passe incorrect.\n\nVeuillez vérifier vos coordonnées.",
                    "Échec de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Effacer le mot de passe
                BoxMDP.Clear();
                BoxMDP.Focus();
            }
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

            
            this.Hide();
            return;
        }

        private void EspaceAdministrateur_Load(object sender, EventArgs e)
        {

        }
    }
}
