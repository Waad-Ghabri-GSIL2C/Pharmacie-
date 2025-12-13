using System;
using System.Data;
using System.Data.SqlClient;

namespace Projet_Pharmacie.DAL
{
    /// <summary>
    /// Classe d'accès aux données pour les Ventes
    /// Table Ventes : VenteID, DateVente, ProduitID, Reference, NomProduit, TypeProduit, Quantite, PrixUnitaire, Montant
    /// </summary>
    public class VenteDAL
    {
        /// <summary>
        /// Ajoute une vente dans la base de données
        /// Le trigger SQL met automatiquement à jour le stock
        /// </summary>
        public static bool AjouterVente(int produitID, string reference, string nomProduit,
                                       string typeProduit, int quantite, decimal prixUnitaire)
        {
            try
            {
                // Vérifier le stock disponible
                string queryStock = "SELECT Quantite FROM Produits WHERE ProduitID = @ProduitID";
                SqlParameter[] paramsStock = { new SqlParameter("@ProduitID", produitID) };

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

                SqlParameter[] parameters = {
                    new SqlParameter("@ProduitID", produitID),
                    new SqlParameter("@Reference", reference),
                    new SqlParameter("@NomProduit", nomProduit),
                    new SqlParameter("@TypeProduit", typeProduit),
                    new SqlParameter("@Quantite", quantite),
                    new SqlParameter("@PrixUnitaire", prixUnitaire),
                    new SqlParameter("@Montant", montant)
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
                            WHERE CAST(DateVente AS DATE) = CAST(GETDATE() AS DATE)
                            ORDER BY DateVente DESC";

            return DatabaseConnection.ExecuteQuery(query);
        }

        /// <summary>
        /// Calcule le total des ventes d'aujourd'hui
        /// </summary>
        public static decimal GetTotalVentesAujourdhui()
        {
            string query = @"SELECT ISNULL(SUM(Montant), 0)
                            FROM Ventes
                            WHERE CAST(DateVente AS DATE) = CAST(GETDATE() AS DATE)";

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

            SqlParameter[] parameters = {
                new SqlParameter("@DateDebut", dateDebut),
                new SqlParameter("@DateFin", dateFin.AddDays(1).AddSeconds(-1))
            };

            return DatabaseConnection.ExecuteQuery(query, parameters);
        }

        /// <summary>
        /// Récupère les produits les plus vendus
        /// </summary>
        public static DataTable GetProduitsLesPlusVendus(int top = 10)
        {
            string query = $@"SELECT TOP {top}
                                NomProduit,
                                TypeProduit,
                                SUM(Quantite) AS [Quantité Vendue],
                                SUM(Montant) AS [Chiffre d'Affaires]
                            FROM Ventes
                            GROUP BY NomProduit, TypeProduit
                            ORDER BY SUM(Quantite) DESC";

            return DatabaseConnection.ExecuteQuery(query);
        }

        /// <summary>
        /// Supprime une vente (remet le stock)
        /// </summary>
        public static bool SupprimerVente(int venteID)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;

            try
            {
                conn = DatabaseConnection.GetConnection();
                conn.Open();
                transaction = conn.BeginTransaction();

                // Récupérer les infos de la vente
                string queryVente = "SELECT ProduitID, Quantite FROM Ventes WHERE VenteID = @VenteID";
                using (SqlCommand cmd = new SqlCommand(queryVente, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@VenteID", venteID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
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

                            using (SqlCommand cmdStock = new SqlCommand(queryStock, conn, transaction))
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
                using (SqlCommand cmdDelete = new SqlCommand(queryDelete, conn, transaction))
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