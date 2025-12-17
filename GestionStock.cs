using System;
using System.Data;
using System.Windows.Forms;
using Projet_Pharmacie.DAL;

namespace Projet_Pharmacie
{
    public partial class GestionStock : Form
    {
        public GestionStock()
        {
            InitializeComponent();
        }

        private void GestionStock_Load(object sender, EventArgs e)
        {
            ChargerStock();
        }

        // ========== CHARGER LE STOCK DEPUIS LA BASE DE DONNÉES ==========
        private void ChargerStock()
        {
            try
            {
                DataTable dt = ProduitDAL.GetAllProduits();
                dgv_GS.DataSource = dt;

                // Personnaliser les en-têtes des colonnes
                if (dgv_GS.Columns.Count > 0)
                {
                    dgv_GS.Columns["ProduitID"].HeaderText = "ID";
                    dgv_GS.Columns["Reference"].HeaderText = "Référence";
                    dgv_GS.Columns["TypeProduit"].HeaderText = "Type";
                    dgv_GS.Columns["NomProduit"].HeaderText = "Nom du Produit";
                    dgv_GS.Columns["Quantite"].HeaderText = "Quantité";
                    dgv_GS.Columns["Prix"].HeaderText = "Prix (DT)";
                    dgv_GS.Columns["Statut"].HeaderText = "Statut";
                    dgv_GS.Columns["Seuil"].HeaderText = "Seuil";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement du stock : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Modifier Prix 
        private void Btn_Modifier_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_ref.Text) || string.IsNullOrWhiteSpace(txt_Nouveau.Text))
            {
                MessageBox.Show("Veuillez remplir la référence et le nouveau prix.",
                    "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txt_Nouveau.Text, out decimal nouveauPrix) || nouveauPrix <= 0)
            {
                MessageBox.Show("Veuillez entrer un prix valide.",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Vérifier si le produit existe
                if (!ProduitDAL.ReferenceExiste(txt_ref.Text.Trim()))
                {
                    MessageBox.Show("Produit non trouvé.",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Modifier le prix
                bool succes = ProduitDAL.ModifierPrixProduit(txt_ref.Text.Trim(), nouveauPrix);

                if (succes)
                {
                    MessageBox.Show("Prix modifié avec succès !",
                        "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_ref.Clear();
                    txt_Nouveau.Clear();
                    ChargerStock();
                }
                else
                {
                    MessageBox.Show("Erreur lors de la modification du prix.",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Ajouter un nouveau produit 
        private void Btn_AjouterN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_nouveauRef.Text) ||
                string.IsNullOrWhiteSpace(txt_nouveauNom.Text) ||
                string.IsNullOrWhiteSpace(txt_nouveauType.Text) ||
                string.IsNullOrWhiteSpace(txt_nouveauPrix.Text) ||
                string.IsNullOrWhiteSpace(txt_nouveauQte.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.",
                    "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txt_nouveauPrix.Text, out decimal prix) || prix <= 0)
            {
                MessageBox.Show("Prix invalide.",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txt_nouveauQte.Text, out int qte) || qte < 0)
            {
                MessageBox.Show("Quantité invalide.",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Vérifier si la référence existe déjà
                if (ProduitDAL.ReferenceExiste(txt_nouveauRef.Text.Trim()))
                {
                    MessageBox.Show("Cette référence existe déjà.",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Ajouter le produit
                bool succes = ProduitDAL.AjouterProduit(
                    txt_nouveauRef.Text.Trim(),
                    txt_nouveauType.Text.Trim(),
                    txt_nouveauNom.Text.Trim(),
                    qte,
                    prix
                );

                if (succes)
                {
                    MessageBox.Show("Produit ajouté avec succès !",
                        "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txt_nouveauRef.Clear();
                    txt_nouveauNom.Clear();
                    txt_nouveauType.Clear();
                    txt_nouveauPrix.Clear();
                    txt_nouveauQte.Clear();

                    ChargerStock();
                }
                else
                {
                    MessageBox.Show("Erreur lors de l'ajout du produit.",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Supprimer Produit 
        private void Btn_Supprimer_Click(object sender, EventArgs e)
        {
            if (dgv_GS.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un produit à supprimer.",
                    "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Récupérer la référence du produit sélectionné
            string reference = dgv_GS.SelectedRows[0].Cells["Reference"].Value.ToString();
            string nomProduit = dgv_GS.SelectedRows[0].Cells["NomProduit"].Value.ToString();

            if (MessageBox.Show($"Voulez-vous vraiment supprimer ce produit ?\n\n{nomProduit} ({reference})",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    bool succes = ProduitDAL.SupprimerProduit(reference);

                    if (succes)
                    {
                        MessageBox.Show("Produit supprimé.",
                            "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ChargerStock();
                    }
                    else
                    {
                        MessageBox.Show("Impossible de supprimer ce produit.",
                            "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur : {ex.Message}",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Annuler
        private void Btn_Annuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Gestionnaires d'événements vides 
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
    }
}