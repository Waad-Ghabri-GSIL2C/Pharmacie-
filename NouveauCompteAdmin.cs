using Projet_Pharmacie;
using Projet_Pharmacie.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_Pharmacie
{
    public partial class NouveauCompteAdmin : Form
    {
        public NouveauCompteAdmin()
        {
            InitializeComponent();
            InitialiserMotDePasse();
        }

        private void InitialiserMotDePasse()
        {
            // Masquer le mot de passe
            if (BoxMDPN != null)
            {
                BoxMDPN.PasswordChar = '*';
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void BtnConfirmer_Click(object sender, EventArgs e)
        {
            // Vérifier si tous les champs sont remplis
            if (string.IsNullOrWhiteSpace(BoxNom.Text) ||
                string.IsNullOrWhiteSpace(BoxPrenom.Text) ||
                string.IsNullOrWhiteSpace(BoxID.Text) ||
                string.IsNullOrWhiteSpace(BoxTel.Text) ||
                string.IsNullOrWhiteSpace(BoxMail.Text) ||
                string.IsNullOrWhiteSpace(BoxPharmacie.Text) ||
                string.IsNullOrWhiteSpace(BoxLoginN.Text) ||
                string.IsNullOrWhiteSpace(BoxMDPN.Text))
            {
                MessageBox.Show("Il faut remplir tous les champs!",
                               "Champs manquants",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                return;
            }

            // Récupérer les informations
            string login = BoxLoginN.Text.Trim();
            string motDePasse = BoxMDPN.Text.Trim();
            string email = BoxMail.Text.Trim();

            // Validation du login (pas d'espaces, caractères spéciaux)
            if (login.Contains(" ") || login.Length < 3)
            {
                MessageBox.Show("Le login doit contenir au moins 3 caractères et ne pas contenir d'espaces.",
                    "Login invalide",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                BoxLoginN.Focus();
                return;
            }

            // Validation du mot de passe
            if (motDePasse.Length < 4)
            {
                MessageBox.Show("Le mot de passe doit contenir au moins 4 caractères.",
                    "Mot de passe invalide",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                BoxMDPN.Focus();
                return;
            }

            // ✅ NOUVEAU : Enregistrer le compte dans la base de données principale
            bool resultat = AdministrateurDAL.AjouterAdministrateur(login, motDePasse, email);

            if (resultat)
            {
                MessageBox.Show(
                    $"✅ Compte administrateur créé avec succès!\n\n" +
                    $"👤 Nom: {BoxNom.Text} {BoxPrenom.Text}\n" +
                    $"🏥 Pharmacie: {BoxPharmacie.Text}\n" +
                    $"📧 Email: {email}\n" +
                    $"🔑 Login: {login}\n" +
                    $"🔐 Mot de passe: {motDePasse}\n\n" +
                    $"📁 Une base de données personnelle sera créée automatiquement\n" +
                    $"   lors de votre première connexion.\n\n" +
                    $"💾 Fichier: Pharmacie_{login}.db",
                    "Création réussie",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Retourner à l'écran de connexion
                EspaceAdministrateur espaceAdministrateur = new EspaceAdministrateur();
                espaceAdministrateur.Show();
                this.Close();
            }
            else
            {
                // L'erreur est déjà affichée dans AdministrateurDAL
                // (par exemple : login déjà existant)
            }
        }

        private void NouveauCompteAdmin_Load(object sender, EventArgs e)
        {
        }
    }
}