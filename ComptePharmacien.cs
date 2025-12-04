using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Gestion_Pharmacie.Classes;

namespace Projet_Pharmacie
{
    public partial class ComptePharmacien : Form
    {
        // Liste des produits en stock
        private List<Produit> produitsStock = new List<Produit>();
        private Produit produitSelectionne = null;

        public ComptePharmacien()
        {
            try
            {
                InitializeComponent();

                // Configuration du DataGridView
                ConfigurerDataGridView();

                // Initialiser les données de test
                InitialiserDonnees();

                // Charger les produits directement
                ChargerTousLesProduits();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'initialisation du formulaire :\n{ex.Message}\n\nStackTrace:\n{ex.StackTrace}",
                    "Erreur Critique", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComptePharmacien_Load(object sender, EventArgs e)
        {
            try
            {
                // Charger tous les produits au démarrage
                ChargerTousLesProduits();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des produits :\n{ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== CONFIGURATION ==========

        private void ConfigurerDataGridView()
        {
            try
            {
                // Configuration de base
                dgvStock.AutoGenerateColumns = true;
                dgvStock.AllowUserToAddRows = false;
                dgvStock.AllowUserToDeleteRows = false;
                dgvStock.ReadOnly = true;
                dgvStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvStock.MultiSelect = false;
                dgvStock.BackgroundColor = System.Drawing.Color.White;
                dgvStock.BorderStyle = BorderStyle.Fixed3D;

                // Style des en-têtes
                dgvStock.EnableHeadersVisualStyles = false;
                dgvStock.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Navy;
                dgvStock.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
                dgvStock.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
                dgvStock.ColumnHeadersHeight = 30;

                // Style des lignes
                dgvStock.RowsDefaultCellStyle.Font = new System.Drawing.Font("Arial", 9F);
                dgvStock.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                dgvStock.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DarkBlue;
                dgvStock.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur de configuration du DataGridView : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitialiserDonnees()
        {
            try
            {
                if (produitsStock.Count == 0)
                {
                    produitsStock.Add(new Produit("P001", StatutP.Medicaments, "Paracétamol", 100, 5.50m, "En stock"));
                    produitsStock.Add(new Produit("P002", StatutP.Medicaments, "Aspirine", 50, 7.00m, "En stock"));
                    produitsStock.Add(new Produit("P003", StatutP.Para, "Vitamine C", 75, 12.00m, "En stock"));
                    produitsStock.Add(new Produit("P004", StatutP.Para, "Crème hydratante", 30, 15.50m, "Stock limité"));
                    produitsStock.Add(new Produit("P005", StatutP.Medicaments, "Ibuprofène", 80, 6.50m, "En stock"));
                    produitsStock.Add(new Produit("P006", StatutP.Medicaments, "Sirop contre la toux", 40, 9.00m, "En stock"));
                    produitsStock.Add(new Produit("P007", StatutP.Para, "Pommade anti-inflammatoire", 25, 11.50m, "Stock limité"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'initialisation des données : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== CHARGEMENT DES DONNÉES ==========

        private void ChargerTousLesProduits()
        {
            try
            {
                // S'assurer que les données existent
                if (produitsStock.Count == 0)
                {
                    InitialiserDonnees();
                }

                // Lier les données au DataGridView
                dgvStock.DataSource = null;
                dgvStock.DataSource = new System.ComponentModel.BindingList<Produit>(produitsStock);

                // Personnaliser les colonnes
                PersonnaliserColonnes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des produits : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PersonnaliserColonnes()
        {
            try
            {
                if (dgvStock.Columns.Count > 0)
                {
                    // Personnaliser Référence
                    if (dgvStock.Columns["Reference"] != null)
                    {
                        dgvStock.Columns["Reference"].HeaderText = "Référence";
                        dgvStock.Columns["Reference"].Width = 100;
                    }

                    // Personnaliser Type
                    if (dgvStock.Columns["TypeProduit"] != null)
                    {
                        dgvStock.Columns["TypeProduit"].HeaderText = "Type";
                        dgvStock.Columns["TypeProduit"].Width = 120;
                    }

                    // Personnaliser Nom
                    if (dgvStock.Columns["NomProduit"] != null)
                    {
                        dgvStock.Columns["NomProduit"].HeaderText = "Nom du produit";
                        dgvStock.Columns["NomProduit"].Width = 200;
                    }

                    // Personnaliser Quantité
                    if (dgvStock.Columns["Quantite"] != null)
                    {
                        dgvStock.Columns["Quantite"].HeaderText = "Quantité";
                        dgvStock.Columns["Quantite"].Width = 80;
                        dgvStock.Columns["Quantite"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    // Personnaliser Prix
                    if (dgvStock.Columns["Prix"] != null)
                    {
                        dgvStock.Columns["Prix"].HeaderText = "Prix (DT)";
                        dgvStock.Columns["Prix"].Width = 100;
                        dgvStock.Columns["Prix"].DefaultCellStyle.Format = "N2";
                        dgvStock.Columns["Prix"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }

                    // Personnaliser Statut
                    if (dgvStock.Columns["Statut"] != null)
                    {
                        dgvStock.Columns["Statut"].HeaderText = "Statut";
                        dgvStock.Columns["Statut"].Width = 120;
                    }

                    // Masquer les colonnes inutiles
                    if (dgvStock.Columns["Seuil"] != null)
                        dgvStock.Columns["Seuil"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la personnalisation des colonnes : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== ÉVÉNEMENTS BOUTONS ==========

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            try
            {
                string nomRecherche = txtNP.Text.Trim();

                if (string.IsNullOrEmpty(nomRecherche))
                {
                    MessageBox.Show("Veuillez entrer un nom de produit à rechercher.",
                        "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Rechercher le produit par nom
                produitSelectionne = produitsStock.FirstOrDefault(p =>
                    p.NomProduit.ToLower().Contains(nomRecherche.ToLower()));

                if (produitSelectionne != null)
                {
                    // Afficher uniquement le produit trouvé
                    dgvStock.DataSource = null;
                    dgvStock.DataSource = new List<Produit> { produitSelectionne };
                    PersonnaliserColonnes();

                    MessageBox.Show($"Produit trouvé : {produitSelectionne.NomProduit}\nStock disponible : {produitSelectionne.Quantite}",
                        "Recherche", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Produit non trouvé.", "Recherche",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    produitSelectionne = null;
                    ChargerTousLesProduits();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la recherche : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                // Vérifier si un produit est sélectionné
                if (produitSelectionne == null)
                {
                    MessageBox.Show("Veuillez d'abord rechercher un produit.",
                        "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Vérifier si la quantité est renseignée
                if (string.IsNullOrEmpty(txtQte.Text))
                {
                    MessageBox.Show("Veuillez entrer une quantité.",
                        "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Valider la quantité
                if (!int.TryParse(txtQte.Text, out int quantiteDemandee) || quantiteDemandee <= 0)
                {
                    MessageBox.Show("Veuillez entrer une quantité valide (nombre entier positif).",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Vérifier si la quantité demandée est disponible
                if (quantiteDemandee > produitSelectionne.Quantite)
                {
                    MessageBox.Show($"Quantité insuffisante en stock.\n\nStock disponible : {produitSelectionne.Quantite}\nQuantité demandée : {quantiteDemandee}",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Vérifier si le produit existe déjà dans la liste de vente
                var produitExistant = ListeVente.ProduitsVente.FirstOrDefault(p =>
                    p.Reference == produitSelectionne.Reference);

                if (produitExistant != null)
                {
                    // Si le produit existe déjà, augmenter la quantité
                    produitExistant.Quantite += quantiteDemandee;

                    MessageBox.Show($"Quantité mise à jour :\n\n{produitSelectionne.NomProduit}\nNouvelle quantité : {produitExistant.Quantite}",
                        "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Ajouter le nouveau produit à la liste de vente
                    ListeVente.ProduitsVente.Add(new Produit(
                        produitSelectionne.Reference,
                        produitSelectionne.TypeProduit,
                        produitSelectionne.NomProduit,
                        quantiteDemandee,
                        produitSelectionne.Prix,
                        "Ajouté à la vente"
                    ));

                    MessageBox.Show($"Produit ajouté à la liste de vente :\n\n{quantiteDemandee} x {produitSelectionne.NomProduit}\nPrix unitaire : {produitSelectionne.Prix:N2} DT",
                        "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Réinitialiser les champs
                txtNP.Clear();
                txtQte.Clear();
                produitSelectionne = null;
                ChargerTousLesProduits();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout du produit : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            try
            {
                // Vérifier s'il y a des produits dans la liste de vente
                if (ListeVente.ProduitsVente.Count == 0)
                {
                    MessageBox.Show("La liste de vente est vide.\n\nVeuillez d'abord ajouter des produits.",
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Ouvrir le formulaire ValidationVente
                ValidationVente formValidation = new ValidationVente();

                // Gérer le retour du formulaire de validation
                DialogResult result = formValidation.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // La vente a été validée, mettre à jour le stock
                    MettreAJourStockApresVente();

                    // Recharger l'affichage
                    ChargerTousLesProduits();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ouverture de la validation de vente : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MettreAJourStockApresVente()
        {
            try
            {
                // Parcourir les produits vendus
                foreach (var produitVendu in ListeVente.ProduitsVendus)
                {
                    // Trouver le produit correspondant dans le stock
                    var produitStock = produitsStock.FirstOrDefault(p =>
                        p.Reference == produitVendu.Reference);

                    if (produitStock != null)
                    {
                        // Déduire la quantité vendue du stock
                        produitStock.Quantite -= produitVendu.Quantite;

                        // Mettre à jour le statut si nécessaire
                        if (produitStock.Quantite <= 0)
                        {
                            produitStock.Statut = "Rupture de stock";
                        }
                        else if (produitStock.Quantite < 20)
                        {
                            produitStock.Statut = "Stock limité";
                        }
                        else
                        {
                            produitStock.Statut = "En stock";
                        }
                    }
                }

                // Vider la liste des produits vendus après mise à jour
                ListeVente.ProduitsVendus.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la mise à jour du stock : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== ÉVÉNEMENTS TEXTBOX ==========

        private void txtNP_TextChanged(object sender, EventArgs e)
        {
            // Optionnel : validation en temps réel
        }

        private void txtQte_TextChanged(object sender, EventArgs e)
        {
            // Optionnel : validation en temps réel
        }

        // ========== GESTION DE LA FERMETURE ==========

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Demander confirmation si la liste de vente contient des produits
            if (ListeVente.ProduitsVente.Count > 0)
            {
                DialogResult result = MessageBox.Show(
                    "Vous avez des produits dans la liste de vente.\n\nVoulez-vous vraiment quitter ?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}