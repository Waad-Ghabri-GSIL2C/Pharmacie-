using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Gestion_Pharmacie.Classes;

namespace Projet_Pharmacie
{
    public partial class GestionFournisseurs : Form
    {
        private List<Fournisseur> fournisseurs = new List<Fournisseur>();

        public GestionFournisseurs()
        {
            InitializeComponent();
            InitialiserFournisseurs();

            ChargerFournisseurs();
            ChargerCommandes();
        }



        private void InitialiserFournisseurs()
        {
            var f1 = new Fournisseur(1, "PharmaPlus", "Tunis", "contact@pharmaplus.tn", "71123456");
            f1.ListeProduitsFournis.Add(new Produit("P003", StatutP.Para, "Vitamine C", 0, 12.00m, ""));
            f1.ListeProduitsFournis.Add(new Produit("P004", StatutP.Para, "Crème hydratante", 0, 15.50m, ""));

            var f2 = new Fournisseur(2, "MediCare", "Sfax", "info@medicare.tn", "74987654");
            f2.ListeProduitsFournis.Add(new Produit("P007", StatutP.Para, "Pommade anti-inflammatoire", 0, 11.50m, ""));

            var f3 = new Fournisseur(3, "HealthSupply", "Sousse", "sales@healthsupply.tn", "73456789");

            fournisseurs.Add(f1);
            fournisseurs.Add(f2);
            fournisseurs.Add(f3);
        }

        private void ChargerFournisseurs()
        {
            dgvFournisseurs.AutoGenerateColumns = false;
            dgvFournisseurs.Columns.Clear();

            dgvFournisseurs.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NomF",
                HeaderText = "Fournisseur",
                Width = 150
            });

            dgvFournisseurs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ColProduits",
                HeaderText = "Produit",
                Width = 200
            });

            dgvFournisseurs.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "EmailF",
                HeaderText = "Email",
                Width = 200
            });

            dgvFournisseurs.DataSource = new System.ComponentModel.BindingList<Fournisseur>(fournisseurs);

            // ⬇️ Utilisez DataBindingComplete au lieu de foreach
            dgvFournisseurs.DataBindingComplete += (s, e) =>
            {
                foreach (DataGridViewRow row in dgvFournisseurs.Rows)
                {
                    var fournisseur = (Fournisseur)row.DataBoundItem;
                    var produits = string.Join(", ", fournisseur.ListeProduitsFournis.Select(p => p.NomProduit));
                    row.Cells["ColProduits"].Value = string.IsNullOrEmpty(produits) ? "Aucun" : produits;
                }
            };
        }

        private void ChargerCommandes()
        {
            dgvCommandes.AutoGenerateColumns = false;
            dgvCommandes.Columns.Clear();

            dgvCommandes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NomProduit", HeaderText = "Nom produit", Width = 150 });
            dgvCommandes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantite", HeaderText = "Quantité", Width = 80 });
            dgvCommandes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NomFournisseur", HeaderText = "Fournisseur", Width = 150 });
            dgvCommandes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DelaiJours", HeaderText = "Délai (jours)", Width = 100 });

            var btnRecue = new DataGridViewButtonColumn { HeaderText = "Reçue / Attente", Text = "Reçue", UseColumnTextForButtonValue = true, Width = 120 };
            dgvCommandes.Columns.Add(btnRecue);

            dgvCommandes.DataSource = new System.ComponentModel.BindingList<CommandeFournisseur>(ComptePharmacien.commandesEnAttente);
        }

        private void btnValiderCommande_Click(object sender, EventArgs e)
        {
            if (dgvFournisseurs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Sélectionnez un fournisseur.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNomProduit.Text) || !int.TryParse(txtQuantite.Text, out int qte) || qte <= 0 || !int.TryParse(txtDelai.Text, out int delai) || delai <= 0)
            {
                MessageBox.Show("Vérifiez les champs (nom, quantité et délai doivent être valides).", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var fournisseur = (Fournisseur)dgvFournisseurs.SelectedRows[0].DataBoundItem;
            var commande = new CommandeFournisseur(txtNomProduit.Text.Trim(), qte, fournisseur.NomF, delai, "En attente");

            ComptePharmacien.commandesEnAttente.Add(commande);
            MessageBox.Show("Commande créée avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtNomProduit.Clear();
            txtQuantite.Clear();
            txtDelai.Clear();
            ChargerCommandes();
        }

        private void dgvCommandes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Vérifier que ce n'est pas l'en-tête
            if (e.RowIndex < 0) return;

            // Vérifier que c'est bien la colonne du bouton (dernière colonne)
            if (e.ColumnIndex == dgvCommandes.Columns.Count - 1)
            {
                var commande = (CommandeFournisseur)dgvCommandes.Rows[e.RowIndex].DataBoundItem;

                if (MessageBox.Show($"Confirmer la réception ?\n\n{commande.NomProduit}\nQuantité : {commande.Quantite}",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MettreAJourStock(commande);
                    ComptePharmacien.commandesEnAttente.Remove(commande);

                    // ⬇️ Recharger DIFFÉREMMENT
                    dgvCommandes.DataSource = null;
                    dgvCommandes.DataSource = new System.ComponentModel.BindingList<CommandeFournisseur>(ComptePharmacien.commandesEnAttente);

                    MessageBox.Show("Réception validée et stock mis à jour !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void MettreAJourStock(CommandeFournisseur commande)
        {
            var produit = ComptePharmacien.produitsStock.FirstOrDefault(p => p.NomProduit.ToLower() == commande.NomProduit.ToLower());

            if (produit != null)
            {
                produit.Quantite += commande.Quantite;
                produit.Statut = produit.Quantite >= 50 ? "En stock" : produit.Quantite >= 20 ? "Stock limité" : "Stock bas";
            }
            else
            {
                string refProduit = "P" + (ComptePharmacien.produitsStock.Count + 1).ToString("000");
                ComptePharmacien.produitsStock.Add(new Produit(refProduit, StatutP.Para, commande.NomProduit, commande.Quantite, 0m, "En stock"));
            }
        }


        private void btn_Annuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
