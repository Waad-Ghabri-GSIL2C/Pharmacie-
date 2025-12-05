using System;
using System.Linq;
using System.Windows.Forms;
using Gestion_Pharmacie.Classes;

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
            // Initialiser les données si la liste est vide
            if (ComptePharmacien.produitsStock.Count == 0)
            {
                ComptePharmacien.produitsStock.Add(new Produit("P001", StatutP.Medicaments, "Paracétamol", 100, 5.50m, "En stock"));
                ComptePharmacien.produitsStock.Add(new Produit("P002", StatutP.Medicaments, "Aspirine", 50, 7.00m, "En stock"));
                ComptePharmacien.produitsStock.Add(new Produit("P003", StatutP.Para, "Vitamine C", 75, 12.00m, "En stock"));
                ComptePharmacien.produitsStock.Add(new Produit("P004", StatutP.Para, "Crème hydratante", 30, 15.50m, "Stock limité"));
                ComptePharmacien.produitsStock.Add(new Produit("P005", StatutP.Medicaments, "Ibuprofène", 80, 6.50m, "En stock"));
            }

            ChargerStock();
        }

        // ========== CHARGER LE STOCK ==========
        private void ChargerStock()
        {
            dgv_GS.AutoGenerateColumns = true;
            dgv_GS.DataSource = null;
            dgv_GS.DataSource = new System.ComponentModel.BindingList<Produit>(ComptePharmacien.produitsStock);
        }

        // ========== MODIFIER PRIX ==========
        private void Btn_Modifier_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_ref.Text) || string.IsNullOrWhiteSpace(txt_Nouveau.Text))
            {
                MessageBox.Show("Veuillez remplir la référence et le nouveau prix.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txt_Nouveau.Text, out decimal nouveauPrix) || nouveauPrix <= 0)
            {
                MessageBox.Show("Veuillez entrer un prix valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var produit = ComptePharmacien.produitsStock.FirstOrDefault(p => p.Reference == txt_ref.Text.Trim());

            if (produit != null)
            {
                produit.Prix = nouveauPrix;
                MessageBox.Show("Prix modifié avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_ref.Clear();
                txt_Nouveau.Clear();
                ChargerStock();
            }
            else
            {
                MessageBox.Show("Produit non trouvé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== AJOUTER NOUVEAU PRODUIT ==========
        private void Btn_AjouterN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_nouveauRef.Text) || string.IsNullOrWhiteSpace(txt_nouveauNom.Text) ||
                string.IsNullOrWhiteSpace(txt_nouveauType.Text) || string.IsNullOrWhiteSpace(txt_nouveauPrix.Text) ||
                string.IsNullOrWhiteSpace(txt_nouveauQte.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txt_nouveauPrix.Text, out decimal prix) || prix <= 0)
            {
                MessageBox.Show("Prix invalide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txt_nouveauQte.Text, out int qte) || qte < 0)
            {
                MessageBox.Show("Quantité invalide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ComptePharmacien.produitsStock.Any(p => p.Reference == txt_nouveauRef.Text.Trim()))
            {
                MessageBox.Show("Cette référence existe déjà.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StatutP type;
            if (txt_nouveauType.Text.ToLower() == "medicaments" || txt_nouveauType.Text.ToLower() == "médicaments")
                type = StatutP.Medicaments;
            else if (txt_nouveauType.Text.ToLower() == "para")
                type = StatutP.Para;
            else
            {
                MessageBox.Show("Type invalide. Utilisez 'Medicaments' ou 'Para'.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string statut = qte >= 50 ? "En stock" : qte >= 20 ? "Stock limité" : qte > 0 ? "Stock bas" : "Rupture de stock";

            var nouveauProduit = new Produit(txt_nouveauRef.Text.Trim(), type, txt_nouveauNom.Text.Trim(), qte, prix, statut);
            ComptePharmacien.produitsStock.Add(nouveauProduit);

            MessageBox.Show("Produit ajouté avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txt_nouveauRef.Clear();
            txt_nouveauNom.Clear();
            txt_nouveauType.Clear();
            txt_nouveauPrix.Clear();
            txt_nouveauQte.Clear();

            ChargerStock();
        }

        // ========== SUPPRIMER PRODUIT ==========
        private void Btn_Supprimer_Click(object sender, EventArgs e)
        {
            if (dgv_GS.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un produit à supprimer.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var produit = (Produit)dgv_GS.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"Voulez-vous vraiment supprimer ce produit ?\n\n{produit.NomProduit}", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ComptePharmacien.produitsStock.Remove(produit);
                MessageBox.Show("Produit supprimé.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ChargerStock();
            }
        }

        // ========== ANNULER ==========
        private void Btn_Annuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
    }
}