using Gestion_Pharmacie.Classes;
using Projet_Pharmacie.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Projet_Pharmacie
{
    public partial class ComptePharmacien : Form
    {
        // ⚠️ IMPORTANT : On garde cette liste UNIQUEMENT pour compatibilité avec ListeVente
        // Les données réelles viennent maintenant de la base de données
        public static List<Produit> produitsStock = new List<Produit>();
        public static List<CommandeFournisseur> commandesEnAttente = new List<CommandeFournisseur>();
        private DataRow produitSelectionne = null; // ✅ CHANGÉ : maintenant c'est un DataRow

        public ComptePharmacien()
        {
            try
            {
                InitializeComponent();

                // Configuration du DataGridView
                ConfigurerDataGridView();

                // ✅ NOUVEAU : Tester la connexion à la base de données
                if (!DatabaseConnection.TestConnection())
                {
                    MessageBox.Show("❌ Impossible de se connecter à la base de données.\n\nVérifiez votre configuration SQL Server.",
                        "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Charger les produits depuis la base de données
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
            dgvStock.ReadOnly = true;
            dgvStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStock.MultiSelect = false;
            dgvStock.AutoGenerateColumns = true;
        }

 

        // ========== CHARGEMENT DES DONNÉES ==========

        private void ChargerTousLesProduits()
        {
            try
            {
                // Charger depuis la base de données
                DataTable dtProduits = ProduitDAL.GetAllProduits();

                if (dtProduits != null && dtProduits.Rows.Count > 0)
                {
                    // Lier les données au DataGridView
                    dgvStock.DataSource = dtProduits;

                    // Personnaliser les colonnes
                    PersonnaliserColonnes();

                    //Synchroniser avec la liste statique (pour compatibilité)
                    SynchroniserListeStatique(dtProduits);
                }
                else
                {
                    MessageBox.Show("Aucun produit trouvé dans la base de données.\n\nAjoutez des produits pour commencer.",
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvStock.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des produits : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Synchroniser la liste statique avec la base de données
        private void SynchroniserListeStatique(DataTable dtProduits)
        {
            try
            {
                ComptePharmacien.produitsStock.Clear();

                foreach (DataRow row in dtProduits.Rows)
                {
                    // Convertir le type string en StatutP enum
                    string typeStr = row["TypeProduit"].ToString();
                    StatutP typeEnum;

                    if (typeStr == "Medicaments")
                        typeEnum = StatutP.Medicaments;
                    else if (typeStr == "Para")
                        typeEnum = StatutP.Para;
                    else
                        typeEnum = StatutP.Medicaments; //par défaut 

                    Produit p = new Produit(
                        row["Reference"].ToString(),
                        typeEnum,
                        row["NomProduit"].ToString(),
                        Convert.ToInt32(row["Quantite"]),
                        Convert.ToDecimal(row["Prix"]),
                        row["Statut"].ToString()
                    );

                    ComptePharmacien.produitsStock.Add(p);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la synchronisation : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PersonnaliserColonnes()
        {
            try
            {
                if (dgvStock.Columns.Count > 0)
                {
                    // Masquer ProduitID
                    if (dgvStock.Columns["ProduitID"] != null)
                        dgvStock.Columns["ProduitID"].Visible = false;

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

                // Rechercher dans la base de données
                DataTable dtRecherche = ProduitDAL.RechercherProduits(nomRecherche);

                if (dtRecherche != null && dtRecherche.Rows.Count > 0)
                {
                    // Afficher les résultats
                    dgvStock.DataSource = dtRecherche;
                    PersonnaliserColonnes();

                    // Sélectionner le premier résultat
                    produitSelectionne = dtRecherche.Rows[0];

                    MessageBox.Show($"✅ {dtRecherche.Rows.Count} produit(s) trouvé(s) !\n\n" +
                        $"Produit : {produitSelectionne["NomProduit"]}\n" +
                        $"Stock disponible : {produitSelectionne["Quantite"]}",
                        "Recherche", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("❌ Aucun produit trouvé avec ce nom.", "Recherche",
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

                // Récupérer la quantité depuis DataRow
                int quantiteDisponible = Convert.ToInt32(produitSelectionne["Quantite"]);

                // Vérifier si la quantité demandée est disponible
                if (quantiteDemandee > quantiteDisponible)
                {
                    MessageBox.Show($"❌ Quantité insuffisante en stock.\n\n" +
                        $"Stock disponible : {quantiteDisponible}\n" +
                        $"Quantité demandée : {quantiteDemandee}",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Récupérer les données depuis DataRow
                string reference = produitSelectionne["Reference"].ToString();
                string typeStr = produitSelectionne["TypeProduit"].ToString();
                string nomProduit = produitSelectionne["NomProduit"].ToString();
                decimal prix = Convert.ToDecimal(produitSelectionne["Prix"]);

                // Convertir le type
                StatutP typeEnum = (typeStr == "Medicaments") ? StatutP.Medicaments : StatutP.Para;

                // Vérifier si le produit existe déjà dans la liste de vente
                var produitExistant = ListeVente.ProduitsVente.FirstOrDefault(p => p.Reference == reference);

                if (produitExistant != null)
                {
                    // Si le produit existe déjà, augmenter la quantité
                    produitExistant.Quantite += quantiteDemandee;

                    MessageBox.Show($"✅ Quantité mise à jour :\n\n{nomProduit}\nNouvelle quantité : {produitExistant.Quantite}",
                        "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Ajouter le nouveau produit à la liste de vente
                    ListeVente.ProduitsVente.Add(new Produit(
                        reference,
                        typeEnum,
                        nomProduit,
                        quantiteDemandee,
                        prix,
                        "Ajouté à la vente"
                    ));

                    MessageBox.Show($"✅ Produit ajouté à la liste de vente :\n\n" +
                        $"{quantiteDemandee} x {nomProduit}\n" +
                        $"Prix unitaire : {prix:N2} DT",
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
                    // La vente a été validée, mettre à jour le stock dans la BD
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

        // Mettre à jour le stock dans la base de données
        private void MettreAJourStockApresVente()
        {
            try
            {
                bool toutOk = true;
                List<string> erreurs = new List<string>();

                // Parcourir les produits vendus
                foreach (var produitVendu in ListeVente.ProduitsVendus)
                {
                    // Récupérer d'abord la quantité actuelle depuis la BD
                    DataRow produitActuel = ProduitDAL.GetProduitByReference(produitVendu.Reference);

                    if (produitActuel != null)
                    {
                        int quantiteActuelle = Convert.ToInt32(produitActuel["Quantite"]);
                        int nouvelleQuantite = quantiteActuelle - produitVendu.Quantite;

                        // Mettre à jour dans la base de données
                        if (!ProduitDAL.ModifierQuantiteProduit(produitVendu.Reference, nouvelleQuantite))
                        {
                            toutOk = false;
                            erreurs.Add($"- {produitVendu.NomProduit}");
                        }
                    }
                    else
                    {
                        toutOk = false;
                        erreurs.Add($"- {produitVendu.NomProduit} (produit introuvable)");
                    }
                }

                // Afficher le résultat
                if (toutOk)
                {
                    MessageBox.Show("✅ Stock mis à jour avec succès dans la base de données !",
                        "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"⚠️ Erreurs lors de la mise à jour du stock :\n\n{string.Join("\n", erreurs)}",
                        "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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