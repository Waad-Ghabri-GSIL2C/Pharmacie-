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
    public partial class EspaceUtilisateur : Form
    {
        public EspaceUtilisateur()
        {
            InitializeComponent();
        }

        private void BtnAdministrateur_Click(object sender, EventArgs e)
        {
            // Créer et afficher l'interface EspaceAdministrateur
            EspaceAdministrateur espaceAdmin = new EspaceAdministrateur();
            espaceAdmin.Show();

            // Optionnel : Cacher la fenêtre actuelle
            this.Hide();
        }



        private void BtnPharmacien_Click(object sender, EventArgs e)
        {
            // Créer et afficher l'interface EspacePharmacien
            EspacePharmacien espacePharmacien = new EspacePharmacien();
            espacePharmacien.Show();

            // Optionnel : Cacher la fenêtre actuelle
            this.Hide();
        }

        private void EspaceUtilisateur_Load(object sender, EventArgs e)
        {

        }


    }
}