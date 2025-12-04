using Projet_Pharmacie;
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

            // Tous les champs sont remplis
            // Ici vous pouvez ajouter le code pour sauvegarder le compte dans votre base de données

            MessageBox.Show("Votre compte a été créé avec succès!",
                           "Création réussie",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);


            CompteAdministrateur compteAdministrateur = new CompteAdministrateur();
            compteAdministrateur.Show();


            this.Close();




        }

        private void NouveauCompteAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}

