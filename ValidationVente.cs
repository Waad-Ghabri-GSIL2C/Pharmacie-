using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Gestion_Pharmacie.Classes;

namespace Projet_Pharmacie
{
    public partial class ValidationVente : Form
    {
        private List<Produit> produitsStock;

        public ValidationVente()
        {
            InitializeComponent();

            // Récupérer la liste des produits en stock depuis ComptePharmacien
            // (vous devrez passer cette liste en paramètre ou la rendre statique)
        }

        private void ValidationVente_Load(object sender, EventArgs e)
        {
            try
            {
                // Vérifier si la liste de vente contient des produits
                if (ListeVente.ProduitsVente.Count == 0)
                {
                    MessageBox.Show("La liste de vente est vide!", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }

                // Charger les produits dans le DataGridView
                ChargerListeVente();

                // Calculer et afficher le prix total
                CalculerPrixTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChargerListeVente()
        {
            try
            {
                // Configuration du DataGridView
                dgvListeVente.AutoGenerateColumns = true;
                dgvListeVente.AllowUserToAddRows = false;
                dgvListeVente.AllowUserToDeleteRows = false;
                dgvListeVente.ReadOnly = true;
                dgvListeVente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvListeVente.MultiSelect = false;
                dgvListeVente.BackgroundColor = System.Drawing.Color.White;

                // Style des en-têtes
                dgvListeVente.EnableHeadersVisualStyles = false;
                dgvListeVente.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
                dgvListeVente.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
                dgvListeVente.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
                dgvListeVente.ColumnHeadersHeight = 35;

                // Style des lignes
                dgvListeVente.RowsDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
                dgvListeVente.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
                dgvListeVente.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(52, 152, 219);
                dgvListeVente.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
                dgvListeVente.RowTemplate.Height = 30;

                // Lier les données
                dgvListeVente.DataSource = null;
                dgvListeVente.DataSource = new System.ComponentModel.BindingList<Produit>(ListeVente.ProduitsVente);

                // Personnaliser les colonnes
                PersonnaliserColonnes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement de la liste : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PersonnaliserColonnes()
        {
            try
            {
                if (dgvListeVente.Columns.Count > 0)
                {
                    // Référence
                    if (dgvListeVente.Columns["Reference"] != null)
                    {
                        dgvListeVente.Columns["Reference"].HeaderText = "Référence";
                        dgvListeVente.Columns["Reference"].Width = 100;
                    }

                    // Type
                    if (dgvListeVente.Columns["TypeProduit"] != null)
                    {
                        dgvListeVente.Columns["TypeProduit"].HeaderText = "Type";
                        dgvListeVente.Columns["TypeProduit"].Width = 120;
                    }

                    // Nom
                    if (dgvListeVente.Columns["NomProduit"] != null)
                    {
                        dgvListeVente.Columns["NomProduit"].HeaderText = "Nom du produit";
                        dgvListeVente.Columns["NomProduit"].Width = 250;
                    }

                    // Quantité
                    if (dgvListeVente.Columns["Quantite"] != null)
                    {
                        dgvListeVente.Columns["Quantite"].HeaderText = "Quantité";
                        dgvListeVente.Columns["Quantite"].Width = 100;
                        dgvListeVente.Columns["Quantite"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    // Prix unitaire
                    if (dgvListeVente.Columns["Prix"] != null)
                    {
                        dgvListeVente.Columns["Prix"].HeaderText = "Prix unitaire (DT)";
                        dgvListeVente.Columns["Prix"].Width = 130;
                        dgvListeVente.Columns["Prix"].DefaultCellStyle.Format = "N2";
                        dgvListeVente.Columns["Prix"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }

                    // Masquer les colonnes inutiles
                    if (dgvListeVente.Columns["Statut"] != null)
                        dgvListeVente.Columns["Statut"].Visible = false;
                    if (dgvListeVente.Columns["Genre"] != null)
                        dgvListeVente.Columns["Genre"].Visible = false;
                    if (dgvListeVente.Columns["Seuil"] != null)
                        dgvListeVente.Columns["Seuil"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la personnalisation des colonnes : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculerPrixTotal()
        {
            try
            {
                decimal total = 0;

                foreach (var produit in ListeVente.ProduitsVente)
                {
                    total += produit.Prix * produit.Quantite;
                }

                lblPrixTotal.Text = $"Prix Total: {total:N2} DT";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du calcul du total : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnValiderVente_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListeVente.ProduitsVente.Count == 0)
                {
                    MessageBox.Show("La liste de vente est vide!", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirmation de la vente
                DialogResult confirmation = MessageBox.Show(
                    "Êtes-vous sûr de vouloir valider cette vente?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmation != DialogResult.Yes)
                    return;

                // Mettre à jour le stock dans ComptePharmacien
                // Note: Vous devrez passer la liste produitsStock depuis ComptePharmacien
                // ou la rendre statique pour pouvoir la modifier ici

                // Pour l'instant, on simule la mise à jour
                bool stockMisAJour = MettreAJourStock();

                if (stockMisAJour)
                {
                    MessageBox.Show("Vente validée et stock mis à jour!",
                        "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Vider la liste de vente
                    ListeVente.ProduitsVente.Clear();

                    // Fermer le formulaire
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erreur lors de la mise à jour du stock!",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la validation : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool MettreAJourStock()
        {
            try
            {
                // Accéder au stock depuis ComptePharmacien
                // Cette méthode nécessite que produitsStock soit accessible

                // Solution temporaire: marquer les produits comme vendus
                foreach (var produitVente in ListeVente.ProduitsVente)
                {
                    // Le stock sera mis à jour dans ComptePharmacien
                    // via ListeVente.ProduitsVendus
                    ListeVente.ProduitsVendus.Add(produitVente);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la mise à jour du stock : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Voulez-vous vraiment annuler cette vente?\n\nLa liste de vente sera vidée.",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Vider la liste de vente
                    ListeVente.ProduitsVente.Clear();

                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            try
            {
                // Retourner sans valider ni annuler
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimerProduit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvListeVente.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Veuillez sélectionner un produit à supprimer.",
                        "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var produitASupprimer = (Produit)dgvListeVente.SelectedRows[0].DataBoundItem;

                DialogResult result = MessageBox.Show(
                    $"Voulez-vous supprimer ce produit de la liste?\n\n{produitASupprimer.NomProduit}",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ListeVente.ProduitsVente.Remove(produitASupprimer);
                    ChargerListeVente();
                    CalculerPrixTotal();

                    MessageBox.Show("Produit supprimé de la liste.",
                        "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
