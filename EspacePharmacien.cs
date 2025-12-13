using System;
using System.Windows.Forms;
using Projet_Pharmacie.DAL;

namespace Projet_Pharmacie
{
    public partial class EspacePharmacien : Form
    {
        public EspacePharmacien()
        {
            InitializeComponent();
            InitialiserMotDePasse();
        }

        private void InitialiserMotDePasse()
        {
            // Configurer le TextBox du mot de passe pour masquer les caractères
            BoxMDP1.PasswordChar = '*';
            BoxMDP1.MaxLength = 10;
        }

        private void BtnConnexion1_Click(object sender, EventArgs e)
        {
            string login = BoxLogin1.Text.Trim();
            string motDePasse = BoxMDP1.Text;

            // Vérifier si les champs sont vides
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(motDePasse))
            {
                MessageBox.Show("Veuillez saisir votre login et votre mot de passe.",
                    "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ VÉRIFICATION DANS LA BASE DE DONNÉES
            bool connexionReussie = Projet_Pharmacie.DAL.PharmacienDAL.VerifierConnexion(login, motDePasse);

            if (connexionReussie)
            {
                MessageBox.Show("✅ Connexion réussie ! Bienvenue Pharmacien.",
                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                try
                {
                    ComptePharmacien comptePharmacien = new ComptePharmacien();
                    this.Hide();
                    comptePharmacien.ShowDialog();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de l'ouverture : {ex.Message}",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("❌ Login ou mot de passe incorrect.\n\nVeuillez vérifier vos coordonnées.",
                    "Échec de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Effacer le mot de passe
                BoxMDP1.Clear();
                BoxMDP1.Focus();
            }
        }

        private void BoxLogin1_TextChanged(object sender, EventArgs e)
        {
            // Optionnel
        }

        private void BoxMDP1_TextChanged(object sender, EventArgs e)
        {
            // Optionnel : permettre la connexion avec Entrée
        }

        private void EspacePharmacien_Load(object sender, EventArgs e)
        {
            // Mettre le focus sur le champ login au démarrage
            BoxLogin1.Focus();
        }

        // ✅ BONUS : Permettre la connexion avec la touche Entrée
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                BtnConnexion1_Click(this, EventArgs.Empty);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}