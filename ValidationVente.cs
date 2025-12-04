using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Gestion_Pharmacie.Classes;

namespace Projet_Pharmacie
{
    public partial class ValidationVente : Form
    {
        public ValidationVente()
        {
            InitializeComponent();
        }

        private void ValidationVente_Load(object sender, EventArgs e)
        {
            try
            {
                if (ListeVente.ProduitsVente.Count == 0)
                {
                    MessageBox.Show("La liste de vente est vide!", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }

                ChargerListeVente();
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
                dgvListeVente.AutoGenerateColumns = true;
                dgvListeVente.DataSource = null;
                dgvListeVente.DataSource = new System.ComponentModel.BindingList<Produit>(ListeVente.ProduitsVente);
                dgvListeVente.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement de la liste : {ex.Message}",
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

                DialogResult confirmation = MessageBox.Show(
                    "Êtes-vous sûr de vouloir valider cette vente?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmation != DialogResult.Yes)
                    return;

                bool stockMisAJour = MettreAJourStock();

                if (stockMisAJour)
                {
                    MessageBox.Show("Vente validée et stock mis à jour!",
                        "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ListeVente.ProduitsVente.Clear();
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
                foreach (var produitVente in ListeVente.ProduitsVente)
                {
                    ListeVente.ProduitsVendus.Add(new Produit(
                        produitVente.Reference,
                        produitVente.TypeProduit,
                        produitVente.NomProduit,
                        produitVente.Quantite,
                        produitVente.Prix,
                        "Vendu"
                    ));
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