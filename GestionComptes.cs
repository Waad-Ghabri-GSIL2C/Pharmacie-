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
    public partial class GestionComptes : Form
    {
      
        public GestionComptes()
        {
            InitializeComponent();
            ConfigurerDataGridView();
        }

        // Configuration initiale du DataGridView
        private void ConfigurerDataGridView()
        {
            // Les colonnes sont déjà créées dans le designer
            dgv_ComptePhar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_ComptePhar.MultiSelect = false;
            dgv_ComptePhar.AllowUserToAddRows = false;
            dgv_ComptePhar.ReadOnly = true;
        }

        // Événement du bouton Ajouter
        private void btnAjouterPhar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation des champs
                if (string.IsNullOrWhiteSpace(txtIDPhar.Text))
                {
                    MessageBox.Show("Veuillez entrer un ID (CIN).", "Champ requis",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIDPhar.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNomPhar.Text))
                {
                    MessageBox.Show("Veuillez entrer un nom.", "Champ requis",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNomPhar.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPrePhar.Text))
                {
                    MessageBox.Show("Veuillez entrer un prénom.", "Champ requis",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPrePhar.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtLogPhar.Text))
                {
                    MessageBox.Show("Veuillez entrer un login.", "Champ requis",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLogPhar.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMDPPhar.Text))
                {
                    MessageBox.Show("Veuillez entrer un mot de passe.", "Champ requis",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMDPPhar.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtEmailPhar.Text))
                {
                    MessageBox.Show("Veuillez entrer un email.", "Champ requis",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmailPhar.Focus();
                    return;
                }

                // Vérifier si l'ID existe déjà
                foreach (DataGridViewRow row in dgv_ComptePhar.Rows)
                {
                    if (row.Cells["ID"].Value?.ToString() == txtIDPhar.Text)
                    {
                        MessageBox.Show("Cet ID (CIN) existe déjà.", "Erreur",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Vérifier si le login existe déjà
                foreach (DataGridViewRow row in dgv_ComptePhar.Rows)
                {
                    if (row.Cells["Login"].Value?.ToString() == txtLogPhar.Text)
                    {
                        MessageBox.Show("Ce login existe déjà.", "Erreur",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Ajouter le pharmacien au DataGridView
                int index = dgv_ComptePhar.Rows.Add();
                dgv_ComptePhar.Rows[index].Cells["ID"].Value = txtIDPhar.Text;
                dgv_ComptePhar.Rows[index].Cells["Nom"].Value = txtNomPhar.Text;
                dgv_ComptePhar.Rows[index].Cells["Prenom"].Value = txtPrePhar.Text;
                dgv_ComptePhar.Rows[index].Cells["Login"].Value = txtLogPhar.Text;
                dgv_ComptePhar.Rows[index].Cells["MotDePasse"].Value = txtMDPPhar.Text;
                dgv_ComptePhar.Rows[index].Cells["Email"].Value = txtEmailPhar.Text;

                MessageBox.Show("Pharmacien ajouté avec succès!", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Vider les champs après l'ajout
                ViderChamps();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Événement du bouton Supprimer
        private void btnSuppPhar_Click(object sender, EventArgs e)
        {
            try
            {
                // Vérifier si une ligne est sélectionnée
                if (dgv_ComptePhar.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Veuillez sélectionner un pharmacien à supprimer.",
                        "Aucune sélection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirmer la suppression
                string nomPhar = dgv_ComptePhar.SelectedRows[0].Cells["Nom"].Value?.ToString();
                string prenomPhar = dgv_ComptePhar.SelectedRows[0].Cells["Prenom"].Value?.ToString();

                DialogResult result = MessageBox.Show(
                    $"Voulez-vous vraiment supprimer le pharmacien {nomPhar} {prenomPhar}?",
                    "Confirmation de suppression",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Supprimer la ligne sélectionnée
                    dgv_ComptePhar.Rows.RemoveAt(dgv_ComptePhar.SelectedRows[0].Index);

                    MessageBox.Show("Pharmacien supprimé avec succès!", "Succès",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ViderChamps();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Événement du bouton Annuler
        private void btnAnnulerPhar_Click(object sender, EventArgs e)
        {

                this.Close();
 
        }

        // Méthode pour vider tous les champs
        private void ViderChamps()
        {
            txtIDPhar.Clear();
            txtNomPhar.Clear();
            txtPrePhar.Clear();
            txtLogPhar.Clear();
            txtMDPPhar.Clear();
            txtEmailPhar.Clear();
            txtIDPhar.Focus();
        }

        // Événement optionnel: double-clic sur une ligne pour charger les données
        private void dgv_ComptePhar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgv_ComptePhar.Rows[e.RowIndex];
                    txtIDPhar.Text = row.Cells["ID"].Value?.ToString();
                    txtNomPhar.Text = row.Cells["Nom"].Value?.ToString();
                    txtPrePhar.Text = row.Cells["Prenom"].Value?.ToString();
                    txtLogPhar.Text = row.Cells["Login"].Value?.ToString();
                    txtMDPPhar.Text = row.Cells["MotDePasse"].Value?.ToString();
                    txtEmailPhar.Text = row.Cells["Email"].Value?.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Événement du chargement du formulaire
        private void GestionComptes_Load(object sender, EventArgs e)
        {
            txtIDPhar.Focus();
        }
    }
}