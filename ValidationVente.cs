using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Gestion_Pharmacie.Classes;
using Projet_Pharmacie.DAL;


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

                // Enregistrer dans la base de données
                bool venteReussie = EnregistrerVentesDansBaseDeDonnees();

                if (venteReussie)
                {
                    MessageBox.Show("✅ Vente validée avec succès!",
                        "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Vider la liste de vente
                    ListeVente.ProduitsVente.Clear();
                    ListeVente.ProduitsVendus.Clear();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("❌ Erreur lors de l'enregistrement de la vente.\n\nVeuillez réessayer.",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la validation : {ex.Message}\n\nStackTrace:\n{ex.StackTrace}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Enregistre toutes les ventes dans la base de données
        /// 
        /// PROCESSUS DE MISE À JOUR DES DONNÉES :
        /// 1. Pour chaque produit dans la liste de vente :
        ///    - Récupère le ProduitID depuis la base de données (via la référence)
        ///    - Vérifie que le stock est suffisant
        ///    - Enregistre la vente dans la table Ventes
        /// 2. Le trigger de la base de données met automatiquement à jour le stock
        /// 3. Utilise des paramètres SQL pour éviter les injections SQL
        /// 4. Gère les erreurs individuellement pour chaque produit
        /// </summary>
        private bool EnregistrerVentesDansBaseDeDonnees()
        {
            try
            {
                bool toutReussi = true;
                List<string> erreursDetails = new List<string>();

                foreach (var produitVente in ListeVente.ProduitsVente)
                {
                    // Récupérer le ProduitID depuis la base de données
                    DataRow produitBD = ProduitDAL.GetProduitByReference(produitVente.Reference);

                    if (produitBD == null)
                    {
                        toutReussi = false;
                        erreursDetails.Add($"Produit introuvable : {produitVente.NomProduit}");
                        continue;
                    }

                    int produitID = Convert.ToInt32(produitBD["ProduitID"]);
                    int stockDisponible = Convert.ToInt32(produitBD["Quantite"]);

                    // Vérifier le stock
                    if (stockDisponible < produitVente.Quantite)
                    {
                        toutReussi = false;
                        erreursDetails.Add($"{produitVente.NomProduit} : Stock insuffisant (Disponible: {stockDisponible}, Demandé: {produitVente.Quantite})");
                        continue;
                    }

                    // Enregistrer la vente dans la base de données
                    bool venteEnregistree = VenteDAL.AjouterVente(
                        produitID,
                        produitVente.Reference,
                        produitVente.NomProduit,
                        produitVente.TypeProduit.ToString(),
                        produitVente.Quantite,
                        produitVente.Prix
                    );

                    if (!venteEnregistree)
                    {
                        toutReussi = false;
                        erreursDetails.Add($"Échec de l'enregistrement : {produitVente.NomProduit}");
                    }
                    else
                    {
                        // Ajouter à la liste des produits vendus
                        ListeVente.ProduitsVendus.Add(new Produit(
                            produitVente.Reference,
                            produitVente.TypeProduit,
                            produitVente.NomProduit,
                            produitVente.Quantite,
                            produitVente.Prix,
                            "Vendu"
                        ));
                    }
                }

                // Afficher les erreurs si nécessaire
                if (!toutReussi && erreursDetails.Count > 0)
                {
                    string messageErreur = "⚠️ Certaines ventes n'ont pas pu être enregistrées :\n\n" +
                                          string.Join("\n", erreursDetails);
                    MessageBox.Show(messageErreur, "Attention",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                return toutReussi;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur critique lors de l'enregistrement des ventes :\n{ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}