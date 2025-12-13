using System;
using System.Data;
using System.Windows.Forms;
using Projet_Pharmacie.DAL;

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

        // Événement du chargement du formulaire
        private void GestionComptes_Load(object sender, EventArgs e)
        {
            // Charger tous les pharmaciens depuis la base de données
            ChargerPharmaciens();
            txtIDPhar.Focus();
        }

        /// <summary>
        /// Charge tous les pharmaciens depuis la base de données dans le DataGridView
        /// </summary>
        private void ChargerPharmaciens()
        {
            try
            {
                // Récupérer les données depuis la base
                DataTable dt = PharmacienDAL.GetAllPharmaciens();

                // Vider le DataGridView
                dgv_ComptePhar.Rows.Clear();

                // Remplir le DataGridView avec les données
                foreach (DataRow row in dt.Rows)
                {
                    int index = dgv_ComptePhar.Rows.Add();
                    dgv_ComptePhar.Rows[index].Cells["ID"].Value = row["ID"].ToString();
                    dgv_ComptePhar.Rows[index].Cells["Nom"].Value = row["Nom"].ToString();
                    dgv_ComptePhar.Rows[index].Cells["Prenom"].Value = row["Prenom"].ToString();
                    dgv_ComptePhar.Rows[index].Cells["Login"].Value = row["Login"].ToString();
                    dgv_ComptePhar.Rows[index].Cells["MotDePasse"].Value = row["MotDePasse"].ToString();
                    dgv_ComptePhar.Rows[index].Cells["Email"].Value = row["Email"].ToString();
                }

                // Afficher le nombre de pharmaciens
                this.Text = $"Gestion des Comptes - {dt.Rows.Count} pharmacien(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des pharmaciens : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                // Ajouter le pharmacien dans la base de données
                bool resultat = PharmacienDAL.AjouterPharmacien(
                    txtIDPhar.Text.Trim(),
                    txtNomPhar.Text.Trim(),
                    txtPrePhar.Text.Trim(),
                    txtLogPhar.Text.Trim(),
                    txtMDPPhar.Text.Trim(),
                    txtEmailPhar.Text.Trim()
                );

                if (resultat)
                {
                    MessageBox.Show("Pharmacien ajouté avec succès dans la base de données!", "Succès",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recharger la liste des pharmaciens
                    ChargerPharmaciens();

                    // Vider les champs
                    ViderChamps();
                }
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

                // Récupérer les informations du pharmacien sélectionné
                string cin = dgv_ComptePhar.SelectedRows[0].Cells["ID"].Value?.ToString();
                string nomPhar = dgv_ComptePhar.SelectedRows[0].Cells["Nom"].Value?.ToString();
                string prenomPhar = dgv_ComptePhar.SelectedRows[0].Cells["Prenom"].Value?.ToString();

                // Confirmer la suppression
                DialogResult result = MessageBox.Show(
                    $"Voulez-vous vraiment supprimer le pharmacien {nomPhar} {prenomPhar}?\n\n" +
                    $"CIN: {cin}\n\n" +
                    "Cette action est irréversible!",
                    "Confirmation de suppression",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Supprimer de la base de données
                    bool supprime = PharmacienDAL.SupprimerPharmacienDefinitif(cin);

                    if (supprime)
                    {
                        MessageBox.Show("Pharmacien supprimé avec succès de la base de données!", "Succès",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Recharger la liste des pharmaciens
                        ChargerPharmaciens();

                        // Vider les champs
                        ViderChamps();
                    }
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

                    // Message pour indiquer qu'on peut modifier
                    MessageBox.Show("Vous pouvez maintenant modifier les informations et cliquer sur 'Ajouter' pour mettre à jour.\n\n" +
                        "Note: La modification n'est pas encore implémentée. Pour l'instant, vous pouvez supprimer et re-créer.",
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // BONUS: Méthode de recherche (optionnelle)
        private void RechercherPharmacien(string recherche)
        {
            try
            {
                DataTable dt = PharmacienDAL.RechercherParNom(recherche);

                dgv_ComptePhar.Rows.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    int index = dgv_ComptePhar.Rows.Add();
                    dgv_ComptePhar.Rows[index].Cells["ID"].Value = row["ID"].ToString();
                    dgv_ComptePhar.Rows[index].Cells["Nom"].Value = row["Nom"].ToString();
                    dgv_ComptePhar.Rows[index].Cells["Prenom"].Value = row["Prenom"].ToString();
                    dgv_ComptePhar.Rows[index].Cells["Login"].Value = row["Login"].ToString();
                    dgv_ComptePhar.Rows[index].Cells["MotDePasse"].Value = row["MotDePasse"].ToString();
                    dgv_ComptePhar.Rows[index].Cells["Email"].Value = row["Email"].ToString();
                }

                this.Text = $"Gestion des Comptes - {dt.Rows.Count} résultat(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la recherche : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}