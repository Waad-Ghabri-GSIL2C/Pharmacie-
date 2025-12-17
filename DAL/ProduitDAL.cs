using System;
using System.Data;
using System.Data.SQLite;

namespace Projet_Pharmacie.DAL
{
    /// <summary>
    /// Classe d'accès aux données pour les Produits (Version SQLite)
    /// </summary>
    public class ProduitDAL
    {
        /// <summary>
        /// Récupère tous les produits
        /// </summary>
        public static DataTable GetAllProduits()
        {
            string query = @"SELECT ProduitID, Reference, TypeProduit, NomProduit, 
                            Quantite, Prix, Seuil, Statut 
                            FROM Produits 
                            ORDER BY NomProduit";
            return DatabaseConnection.ExecuteQuery(query);
        }

        /// <summary>
        /// Récupère un produit par sa référence
        /// </summary>
        public static DataRow GetProduitByReference(string reference)
        {
            string query = @"SELECT ProduitID, Reference, TypeProduit, NomProduit, 
                            Quantite, Prix, Seuil, Statut 
                            FROM Produits 
                            WHERE Reference = @Reference";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@Reference", reference)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        /// <summary>
        /// Ajoute un nouveau produit
        /// </summary>
        public static bool AjouterProduit(string reference, string typeProduit, string nomProduit,
                                         int quantite, decimal prix, int seuil = 10)
        {
            string query = @"INSERT INTO Produits (Reference, TypeProduit, NomProduit, Quantite, Prix, Seuil, Statut)
                            VALUES (@Reference, @TypeProduit, @NomProduit, @Quantite, @Prix, @Seuil, 
                                    CASE WHEN @Quantite > @Seuil THEN 'En stock' 
                                         WHEN @Quantite > 0 THEN 'Stock limité' 
                                         ELSE 'Rupture' END)";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@Reference", reference),
                new SQLiteParameter("@TypeProduit", typeProduit),
                new SQLiteParameter("@NomProduit", nomProduit),
                new SQLiteParameter("@Quantite", quantite),
                new SQLiteParameter("@Prix", prix),
                new SQLiteParameter("@Seuil", seuil)
            };

            return DatabaseConnection.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Modifie le prix d'un produit
        /// </summary>
        public static bool ModifierPrixProduit(string reference, decimal nouveauPrix)
        {
            string query = @"UPDATE Produits 
                            SET Prix = @NouveauPrix, 
                                DerniereModification = CURRENT_TIMESTAMP
                            WHERE Reference = @Reference";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@Reference", reference),
                new SQLiteParameter("@NouveauPrix", nouveauPrix)
            };

            return DatabaseConnection.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Modifie la quantité d'un produit (pour ajout manuel)
        /// </summary>
        public static bool ModifierQuantiteProduit(string reference, int nouvelleQuantite)
        {
            string query = @"UPDATE Produits 
                            SET Quantite = @NouvelleQuantite,
                                Statut = CASE 
                                    WHEN @NouvelleQuantite > Seuil THEN 'En stock'
                                    WHEN @NouvelleQuantite <= Seuil AND @NouvelleQuantite > 0 THEN 'Stock limité'
                                    ELSE 'Rupture'
                                END,
                                DerniereModification = CURRENT_TIMESTAMP
                            WHERE Reference = @Reference";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@Reference", reference),
                new SQLiteParameter("@NouvelleQuantite", nouvelleQuantite)
            };

            return DatabaseConnection.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Supprime un produit
        /// </summary>
        public static bool SupprimerProduit(string reference)
        {
            string query = "DELETE FROM Produits WHERE Reference = @Reference";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@Reference", reference)
            };

            return DatabaseConnection.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Recherche des produits par nom
        /// </summary>
        public static DataTable RechercherProduits(string nomProduit)
        {
            string query = @"SELECT ProduitID, Reference, TypeProduit, NomProduit, 
                            Quantite, Prix, Seuil, Statut 
                            FROM Produits 
                            WHERE NomProduit LIKE @NomProduit
                            ORDER BY NomProduit";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@NomProduit", "%" + nomProduit + "%")
            };

            return DatabaseConnection.ExecuteQuery(query, parameters);
        }

        /// <summary>
        /// Récupère les produits en stock faible
        /// </summary>
        public static DataTable GetProduitsStockFaible()
        {
            string query = @"SELECT ProduitID, Reference, TypeProduit, NomProduit, 
                            Quantite, Prix, Seuil, Statut 
                            FROM Produits 
                            WHERE Quantite <= Seuil 
                            ORDER BY Quantite";
            return DatabaseConnection.ExecuteQuery(query);
        }

        /// <summary>
        /// Vérifie si une référence existe déjà
        /// </summary>
        public static bool ReferenceExiste(string reference)
        {
            string query = "SELECT COUNT(*) FROM Produits WHERE Reference = @Reference";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@Reference", reference)
            };

            object result = DatabaseConnection.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result) > 0;
        }
    }
}