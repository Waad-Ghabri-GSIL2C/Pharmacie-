using System;
using System.Windows.Forms;

namespace Projet_Pharmacie
{
    public partial class CompteAdministrateur : Form
    {
        public CompteAdministrateur()
        {
            InitializeComponent();
        }

        private void btn_Gestioncomptes_Click(object sender, EventArgs e)
        {
            GestionComptes formGestionComptes = new GestionComptes();
            formGestionComptes.ShowDialog();
        }

        private void btn_Gestionstock_Click(object sender, EventArgs e)
        {
            GestionStock formGestionStock = new GestionStock();
            formGestionStock.ShowDialog();
        }

        private void btn_Gestionfournisseurs_Click(object sender, EventArgs e)
        {
            GestionFournisseurs formGestionFournisseurs = new GestionFournisseurs();
            formGestionFournisseurs.ShowDialog();
        }
        private void CompteAdministrateur_Load(object sender, EventArgs e)
        {

        }


        private void btn_retour_Click(object sender, EventArgs e)
        {

            EspaceUtilisateur espace = new EspaceUtilisateur();
            this.Close();
            espace.ShowDialog();
        }
    }
}