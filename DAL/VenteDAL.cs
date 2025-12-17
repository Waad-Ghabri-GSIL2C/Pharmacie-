using System;
using System.Data;
using System.Data.SQLite;

namespace Projet_Pharmacie.DAL
{
    /// <summary>
    /// Classe d'accès aux données pour les Ventes (Version SQLite)
    /// Table Ventes : VenteID, DateVente, ProduitID, Reference, NomProduit, TypeProduit, Quantite, PrixUnitaire, Montant
    /// </summary>
    public class VenteDAL
    {
        /// <summary>
        /// Ajoute une vente dans la base de données
        /// Le trigger SQLite met automatiquement à jour le stock
        /// </summary>
        public static bool AjouterVente(int produitID, string reference, string nomProduit,
                                       string typeProduit, int quantite, decimal prixUnitaire)
        {
            try
            {
                // Vérifier le stock disponible
                string queryStock = "SELECT Quantite FROM Produits WHERE ProduitID = @ProduitID";
                SQLiteParameter[] paramsStock = { new SQLiteParameter("@ProduitID", produitID) };

                object result = DatabaseConnection.ExecuteScalar(queryStock, paramsStock);
                int stockActuel = result != null ? Convert.ToInt32(result) : 0;

                if (stockActuel < quantite)
                {
                    System.Windows.Forms.MessageBox.Show(
                        $"Stock insuffisant pour {nomProduit}.\nStock disponible : {stockActuel}\nQuantité demandée : {quantite}",
                        "Stock insuffisant",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Warning);
                    return false;
                }

                // Calculer le montant
                decimal montant = quantite * prixUnitaire;

                // Insérer la vente
                string query = @"INSERT INTO Ventes 
                                (ProduitID, Reference, NomProduit, TypeProduit, Quantite, PrixUnitaire, Montant)
                                VALUES 
                                (@ProduitID, @Reference, @NomProduit, @TypeProduit, @Quantite, @PrixUnitaire, @Montant)";

                SQLiteParameter[] parameters = {
                    new SQLiteParameter("@ProduitID", produitID),
                    new SQLiteParameter("@Reference", reference),
                    new SQLiteParameter("@NomProduit", nomProduit),
                    new SQLiteParameter("@TypeProduit", typeProduit),
                    new SQLiteParameter("@Quantite", quantite),
                    new SQLiteParameter("@PrixUnitaire", prixUnitaire),
                    new SQLiteParameter("@Montant", montant)
                };

                bool success = DatabaseConnection.ExecuteNonQuery(query, parameters);

                if (success)
                {
                    System.Windows.Forms.MessageBox.Show(
                        "Vente enregistrée avec succès !\nLe stock a été mis à jour automatiquement.",
                        "Succès",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Information);
                }

                return success;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Erreur lors de l'ajout de la vente : " + ex.Message,
                    "Erreur",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Récupère toutes les ventes
        /// </summary>
        public static DataTable GetAllVentes()
        {
            string query = @"SELECT 
                                VenteID,
                                DateVente,
                                Reference,
                                NomProduit,
                                TypeProduit,
                                Quantite,
                                PrixUnitaire,
                                Montant
                            FROM Ventes
                            ORDER BY DateVente DESC";

            return DatabaseConnection.ExecuteQuery(query);
        }

        /// <summary>
        /// Récupère les ventes d'aujourd'hui
        /// </summary>
        public static DataTable GetVentesAujourdhui()
        {
            string query = @"SELECT 
                                VenteID,
                                DateVente,
                                Reference,
                                NomProduit,
                                Quantite,
                                PrixUnitaire,
                                Montant
                            FROM Ventes
                            WHERE DATE(DateVente) = DATE('now')
                            ORDER BY DateVente DESC";

            return DatabaseConnection.ExecuteQuery(query);
        }

        /// <summary>
        /// Calcule le total des ventes d'aujourd'hui
        /// </summary>
        public static decimal GetTotalVentesAujourdhui()
        {
            string query = @"SELECT IFNULL(SUM(Montant), 0)
                            FROM Ventes
                            WHERE DATE(DateVente) = DATE('now')";

            object result = DatabaseConnection.ExecuteScalar(query);
            return result != null ? Convert.ToDecimal(result) : 0;
        }

        /// <summary>
        /// Récupère les ventes par période
        /// </summary>
        public static DataTable GetVentesParPeriode(DateTime dateDebut, DateTime dateFin)
        {
            string query = @"SELECT 
                                VenteID,
                                DateVente,
                                Reference,
                                NomProduit,
                                Quantite,
                                Montant
                            FROM Ventes
                            WHERE DateVente >= @DateDebut AND DateVente <= @DateFin
                            ORDER BY DateVente DESC";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@DateDebut", dateDebut.ToString("yyyy-MM-dd HH:mm:ss")),
                new SQLiteParameter("@DateFin", dateFin.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss"))
            };

            return DatabaseConnection.ExecuteQuery(query, parameters);
        }

        /// <summary>
        /// Récupère les produits les plus vendus
        /// </summary>
        public static DataTable GetProduitsLesPlusVendus(int top = 10)
        {
            string query = $@"SELECT 
                                NomProduit,
                                TypeProduit,
                                SUM(Quantite) AS 'Quantité Vendue',
                                SUM(Montant) AS 'Chiffre d''Affaires'
                            FROM Ventes
                            GROUP BY NomProduit, TypeProduit
                            ORDER BY SUM(Quantite) DESC
                            LIMIT {top}";

            return DatabaseConnection.ExecuteQuery(query);
        }

        /// <summary>
        /// Supprime une vente (remet le stock)
        /// </summary>
        public static bool SupprimerVente(int venteID)
        {
            SQLiteConnection conn = null;
            SQLiteTransaction transaction = null;

            try
            {
                conn = DatabaseConnection.GetConnection();
                conn.Open();
                transaction = conn.BeginTransaction();

                // Récupérer les infos de la vente
                string queryVente = "SELECT ProduitID, Quantite FROM Ventes WHERE VenteID = @VenteID";
                using (SQLiteCommand cmd = new SQLiteCommand(queryVente, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@VenteID", venteID);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int produitID = reader.GetInt32(0);
                            int quantite = reader.GetInt32(1);
                            reader.Close();

                            // Remettre le stock
                            string queryStock = @"UPDATE Produits 
                                                 SET Quantite = Quantite + @Quantite,
                                                     Statut = CASE 
                                                         WHEN Quantite + @Quantite > Seuil THEN 'En stock'
                                                         WHEN Quantite + @Quantite > 0 THEN 'Stock limité'
                                                         ELSE 'Rupture'
                                                     END
                                                 WHERE ProduitID = @ProduitID";

                            using (SQLiteCommand cmdStock = new SQLiteCommand(queryStock, conn, transaction))
                            {
                                cmdStock.Parameters.AddWithValue("@Quantite", quantite);
                                cmdStock.Parameters.AddWithValue("@ProduitID", produitID);
                                cmdStock.ExecuteNonQuery();
                            }
                        }
                    }
                }

                // Supprimer la vente
                string queryDelete = "DELETE FROM Ventes WHERE VenteID = @VenteID";
                using (SQLiteCommand cmdDelete = new SQLiteCommand(queryDelete, conn, transaction))
                {
                    cmdDelete.Parameters.AddWithValue("@VenteID", venteID);
                    cmdDelete.ExecuteNonQuery();
                }

                transaction.Commit();
                return true;
            }
            catch (Exception)
            {
                transaction?.Rollback();
                return false;
            }
            finally
            {
                conn?.Close();
            }
        }
    }
}