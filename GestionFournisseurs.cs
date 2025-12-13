using System;
using System.Data;
using System.Windows.Forms;
using Projet_Pharmacie.DAL;

namespace Projet_Pharmacie
{
    public partial class GestionFournisseurs : Form
    {
        public GestionFournisseurs()
        {
            InitializeComponent();
        }

        private void GestionFournisseurs_Load(object sender, EventArgs e)
        {
            ChargerFournisseurs();
            ChargerCommandes();
        }

        /// <summary>
        /// Charge tous les fournisseurs depuis la base de données
        /// </summary>
        private void ChargerFournisseurs()
        {
            try
            {
                // Récupérer les fournisseurs depuis la BD
                DataTable dt = FournisseurDAL.GetAllFournisseurs();

                // Configurer le DataGridView
                dgvFournisseurs.AutoGenerateColumns = false;
                dgvFournisseurs.Columns.Clear();

                // Colonnes
                dgvFournisseurs.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "FournisseurID",
                    HeaderText = "ID",
                    Name = "FournisseurID",
                    Visible = false // Caché mais utile pour récupérer l'ID
                });

                dgvFournisseurs.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "NomFournisseur",
                    HeaderText = "Fournisseur",
                    Name = "NomFournisseur",
                    Width = 200
                });

                dgvFournisseurs.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Email",
                    HeaderText = "Email",
                    Name = "Email",
                    Width = 200
                });

                dgvFournisseurs.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Telephone",
                    HeaderText = "Téléphone",
                    Name = "Telephone",
                    Width = 120
                });

                dgvFournisseurs.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Adresse",
                    HeaderText = "Adresse",
                    Name = "Adresse",
                    Width = 200
                });

                dgvFournisseurs.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "ProduitsFournis",
                    HeaderText = "ProduitsFournis",
                    Name = "ProduitsFournis",
                    Width = 200
                });

                // Lier les données
                dgvFournisseurs.DataSource = dt;

                // Message dans le titre
                this.Text = $"Gestion Fournisseurs - {dt.Rows.Count} fournisseur(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des fournisseurs : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Charge toutes les commandes en attente depuis la base de données
        /// </summary>
        private void ChargerCommandes()
        {
            try
            {
                // Récupérer les commandes en attente depuis la BD
                DataTable dt = CommandeDAL.GetCommandesEnAttente();

                // Configurer le DataGridView
                dgvCommandes.AutoGenerateColumns = false;
                dgvCommandes.Columns.Clear();

                // Colonnes
                dgvCommandes.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "CommandeID",
                    HeaderText = "ID",
                    Name = "CommandeID",
                    Visible = false // Caché mais nécessaire
                });

                dgvCommandes.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "NomProduit",
                    HeaderText = "Nom produit",
                    Name = "NomProduit",
                    Width = 200
                });

                dgvCommandes.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Quantite",
                    HeaderText = "Quantité",
                    Name = "Quantite",
                    Width = 80
                });

                dgvCommandes.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "NomFournisseur",
                    HeaderText = "Fournisseur",
                    Name = "NomFournisseur",
                    Width = 150
                });

                dgvCommandes.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Delai",
                    HeaderText = "Délai (jours)",
                    Name = "Delai",
                    Width = 100
                });

                dgvCommandes.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "DateCommande",
                    HeaderText = "Date",
                    Name = "DateCommande",
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
                });

                // Bouton "Reçue"
                var btnRecue = new DataGridViewButtonColumn
                {
                    HeaderText = "Action",
                    Text = "Reçue",
                    Name = "BtnRecue",
                    UseColumnTextForButtonValue = true,
                    Width = 100
                };
                dgvCommandes.Columns.Add(btnRecue);

                // Lier les données
                dgvCommandes.DataSource = dt;

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des commandes : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Événement : Clic sur le bouton Valider Commande
        /// </summary>
        private void btnValiderCommande_Click(object sender, EventArgs e)
        {
            try
            {
                // Vérifier qu'un fournisseur est sélectionné
                if (dgvFournisseurs.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Veuillez sélectionner un fournisseur.", "Attention",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validation des champs
                if (string.IsNullOrWhiteSpace(txtNomProduit.Text))
                {
                    MessageBox.Show("Veuillez entrer le nom du produit.", "Attention",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNomProduit.Focus();
                    return;
                }

                if (!int.TryParse(txtQuantite.Text, out int quantite) || quantite <= 0)
                {
                    MessageBox.Show("Veuillez entrer une quantité valide (nombre entier positif).", "Attention",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQuantite.Focus();
                    return;
                }

                if (!int.TryParse(txtDelai.Text, out int delai) || delai <= 0)
                {
                    MessageBox.Show("Veuillez entrer un délai valide (nombre de jours).", "Attention",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDelai.Focus();
                    return;
                }

                // Récupérer le fournisseur sélectionné
                DataRowView rowView = (DataRowView)dgvFournisseurs.SelectedRows[0].DataBoundItem;
                int fournisseurID = Convert.ToInt32(rowView["FournisseurID"]);
                string nomFournisseur = rowView["NomFournisseur"].ToString();

                // Chercher le produit dans la base de données
                string nomProduit = txtNomProduit.Text.Trim();
                DataTable dtProduits = ProduitDAL.RechercherProduits(nomProduit);

                int produitID;

                if (dtProduits.Rows.Count > 0)
                {
                    // Produit existe
                    produitID = Convert.ToInt32(dtProduits.Rows[0]["ProduitID"]);
                }
                else
                {
                    // Produit n'existe pas, demander si on veut le créer
                    DialogResult result = MessageBox.Show(
                        $"Le produit '{nomProduit}' n'existe pas dans la base de données.\n\n" +
                        "Voulez-vous le créer maintenant ?",
                        "Produit inexistant",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                    {
                        return;
                    }

                    // Créer le produit avec quantité 0 (sera mis à jour à la réception)
                    string reference = "P" + (new Random().Next(1000, 9999)).ToString();
                    bool produitCree = ProduitDAL.AjouterProduit(reference, "Para", nomProduit, 0, 0, 10);

                    if (!produitCree)
                    {
                        MessageBox.Show("Impossible de créer le produit.", "Erreur",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Récupérer l'ID du produit créé
                    dtProduits = ProduitDAL.RechercherProduits(nomProduit);
                    produitID = Convert.ToInt32(dtProduits.Rows[0]["ProduitID"]);
                }

                // Ajouter la commande dans la base de données
                bool resultat = CommandeDAL.AjouterCommande(fournisseurID, produitID, nomProduit, quantite, delai);

                if (resultat)
                {
                    MessageBox.Show(
                        $"✅ Commande créée avec succès!\n\n" +
                        $"Fournisseur: {nomFournisseur}\n" +
                        $"Produit: {nomProduit}\n" +
                        $"Quantité: {quantite}\n" +
                        $"Délai: {delai} jours",
                        "Succès",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Vider les champs
                    txtNomProduit.Clear();
                    txtQuantite.Clear();
                    txtDelai.Clear();

                    // Recharger les commandes
                    ChargerCommandes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la création de la commande : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Événement : Clic sur le bouton "Reçue" dans le DataGridView des commandes
        /// </summary>
        private void dgvCommandes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Vérifier que ce n'est pas l'en-tête
                if (e.RowIndex < 0) return;

                // Vérifier que c'est bien la colonne du bouton "Reçue"
                if (e.ColumnIndex == dgvCommandes.Columns["BtnRecue"].Index)
                {
                    // Récupérer la commande
                    DataRowView rowView = (DataRowView)dgvCommandes.Rows[e.RowIndex].DataBoundItem;
                    int commandeID = Convert.ToInt32(rowView["CommandeID"]);
                    string nomProduit = rowView["NomProduit"].ToString();
                    int quantite = Convert.ToInt32(rowView["Quantite"]);
                    string nomFournisseur = rowView["NomFournisseur"].ToString();

                    // Confirmer la réception
                    DialogResult result = MessageBox.Show(
                        $"Confirmer la réception de cette commande ?\n\n" +
                        $"📦 Produit : {nomProduit}\n" +
                        $"📊 Quantité : {quantite}\n" +
                        $"🏢 Fournisseur : {nomFournisseur}\n\n" +
                        $"⚠️ Le stock sera automatiquement mis à jour !",
                        "Confirmation de réception",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Marquer la commande comme reçue (DÉCLENCHE LE TRIGGER SQL)
                        bool receptionOk = CommandeDAL.MarquerCommandeRecue(commandeID);

                        if (receptionOk)
                        {
                            // Recharger les commandes
                            ChargerCommandes();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la réception de la commande : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Événement : Bouton Annuler
        /// </summary>
        private void btn_Annuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}