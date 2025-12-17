using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Projet_Pharmacie.DAL
{
    /// <summary>
    /// Classe d'accès aux données pour la gestion des Commandes Fournisseurs (Version SQLite)
    /// </summary>
    public class CommandeDAL
    {
        /// <summary>
        /// Récupère toutes les commandes
        /// </summary>
        public static DataTable GetAllCommandes()
        {
            string query = @"SELECT 
                                CF.CommandeID,
                                CF.FournisseurID,
                                F.NomFournisseur,
                                CF.ProduitID,
                                CF.NomProduit,
                                CF.Quantite,
                                CF.Delai,
                                CF.DateCommande,
                                CF.Statut,
                                CF.DateReception
                             FROM CommandesFournisseurs CF
                             INNER JOIN Fournisseurs F ON CF.FournisseurID = F.FournisseurID
                             ORDER BY CF.DateCommande DESC";

            return DatabaseConnection.ExecuteQuery(query);
        }

        /// <summary>
        /// Récupère uniquement les commandes en attente
        /// </summary>
        public static DataTable GetCommandesEnAttente()
        {
            string query = @"SELECT 
                                CF.CommandeID,
                                CF.FournisseurID,
                                F.NomFournisseur,
                                CF.ProduitID,
                                CF.NomProduit,
                                CF.Quantite,
                                CF.Delai,
                                CF.DateCommande,
                                CF.Statut
                             FROM CommandesFournisseurs CF
                             INNER JOIN Fournisseurs F ON CF.FournisseurID = F.FournisseurID
                             WHERE CF.Statut = 'En attente'
                             ORDER BY CF.DateCommande DESC";

            return DatabaseConnection.ExecuteQuery(query);
        }

        /// <summary>
        /// Ajoute une nouvelle commande fournisseur
        /// </summary>
        public static bool AjouterCommande(int fournisseurID, int produitID, string nomProduit,
            int quantite, int delai)
        {
            string query = @"INSERT INTO CommandesFournisseurs 
                            (FournisseurID, ProduitID, NomProduit, Quantite, Delai, DateCommande, Statut)
                            VALUES 
                            (@FournisseurID, @ProduitID, @NomProduit, @Quantite, @Delai, CURRENT_TIMESTAMP, 'En attente')";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@FournisseurID", fournisseurID),
                new SQLiteParameter("@ProduitID", produitID),
                new SQLiteParameter("@NomProduit", nomProduit),
                new SQLiteParameter("@Quantite", quantite),
                new SQLiteParameter("@Delai", delai)
            };

            return DatabaseConnection.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Marque une commande comme "Reçue" - DÉCLENCHE AUTOMATIQUEMENT LE TRIGGER
        /// qui met à jour le stock dans la table Produits
        /// </summary>
        public static bool MarquerCommandeRecue(int commandeID)
        {
            try
            {
                string query = @"UPDATE CommandesFournisseurs 
                                SET Statut = 'Reçue', 
                                    DateReception = CURRENT_TIMESTAMP
                                WHERE CommandeID = @CommandeID";

                SQLiteParameter[] parameters = {
                    new SQLiteParameter("@CommandeID", commandeID)
                };

                bool resultat = DatabaseConnection.ExecuteNonQuery(query, parameters);

                if (resultat)
                {
                    MessageBox.Show(
                        "✅ Commande marquée comme reçue!\n" +
                        "✅ Le stock a été automatiquement mis à jour grâce au trigger SQLite!",
                        "Succès",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                return resultat;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la réception de la commande: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Supprime une commande
        /// </summary>
        public static bool SupprimerCommande(int commandeID)
        {
            string query = "DELETE FROM CommandesFournisseurs WHERE CommandeID = @CommandeID";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@CommandeID", commandeID)
            };

            return DatabaseConnection.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Récupère les détails d'une commande spécifique
        /// </summary>
        public static DataRow GetCommandeByID(int commandeID)
        {
            string query = @"SELECT 
                                CF.CommandeID,
                                CF.FournisseurID,
                                F.NomFournisseur,
                                CF.ProduitID,
                                CF.NomProduit,
                                CF.Quantite,
                                CF.Delai,
                                CF.DateCommande,
                                CF.Statut,
                                CF.DateReception
                             FROM CommandesFournisseurs CF
                             INNER JOIN Fournisseurs F ON CF.FournisseurID = F.FournisseurID
                             WHERE CF.CommandeID = @CommandeID";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@CommandeID", commandeID)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        /// <summary>
        /// Récupère toutes les commandes d'un fournisseur spécifique
        /// </summary>
        public static DataTable GetCommandesParFournisseur(int fournisseurID)
        {
            string query = @"SELECT 
                                CF.CommandeID,
                                F.NomFournisseur,
                                CF.NomProduit,
                                CF.Quantite,
                                CF.Delai,
                                CF.DateCommande,
                                CF.Statut,
                                CF.DateReception
                             FROM CommandesFournisseurs CF
                             INNER JOIN Fournisseurs F ON CF.FournisseurID = F.FournisseurID
                             WHERE CF.FournisseurID = @FournisseurID
                             ORDER BY CF.DateCommande DESC";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@FournisseurID", fournisseurID)
            };

            return DatabaseConnection.ExecuteQuery(query, parameters);
        }

        /// <summary>
        /// Récupère le nombre de commandes en attente
        /// </summary>
        public static int GetNombreCommandesEnAttente()
        {
            string query = "SELECT COUNT(*) FROM CommandesFournisseurs WHERE Statut = 'En attente'";
            object result = DatabaseConnection.ExecuteScalar(query);
            return result != null ? Convert.ToInt32(result) : 0;
        }

        /// <summary>
        /// Récupère les commandes dont le délai est dépassé
        /// </summary>
        public static DataTable GetCommandesEnRetard()
        {
            string query = @"SELECT 
                                CF.CommandeID,
                                F.NomFournisseur,
                                CF.NomProduit,
                                CF.Quantite,
                                CF.Delai,
                                CF.DateCommande,
                                CAST((julianday('now') - julianday(CF.DateCommande)) AS INTEGER) AS JoursEcoules,
                                CAST((julianday('now') - julianday(CF.DateCommande)) AS INTEGER) - CF.Delai AS JoursRetard
                             FROM CommandesFournisseurs CF
                             INNER JOIN Fournisseurs F ON CF.FournisseurID = F.FournisseurID
                             WHERE CF.Statut = 'En attente' 
                               AND CAST((julianday('now') - julianday(CF.DateCommande)) AS INTEGER) > CF.Delai
                             ORDER BY JoursRetard DESC";

            return DatabaseConnection.ExecuteQuery(query);
        }
    }
}