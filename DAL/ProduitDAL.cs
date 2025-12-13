using Projet_Pharmacie.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Projet_Pharmacie.DAL
{
    /// <summary>
    /// Classe d'accès aux données pour les Produits
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

            SqlParameter[] parameters = {
                new SqlParameter("@Reference", reference)
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

            SqlParameter[] parameters = {
                new SqlParameter("@Reference", reference),
                new SqlParameter("@TypeProduit", typeProduit),
                new SqlParameter("@NomProduit", nomProduit),
                new SqlParameter("@Quantite", quantite),
                new SqlParameter("@Prix", prix),
                new SqlParameter("@Seuil", seuil)
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
                                DerniereModification = GETDATE()
                            WHERE Reference = @Reference";

            SqlParameter[] parameters = {
                new SqlParameter("@Reference", reference),
                new SqlParameter("@NouveauPrix", nouveauPrix)
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
                                DerniereModification = GETDATE()
                            WHERE Reference = @Reference";

            SqlParameter[] parameters = {
                new SqlParameter("@Reference", reference),
                new SqlParameter("@NouvelleQuantite", nouvelleQuantite)
            };

            return DatabaseConnection.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Supprime un produit
        /// </summary>
        public static bool SupprimerProduit(string reference)
        {
            string query = "DELETE FROM Produits WHERE Reference = @Reference";

            SqlParameter[] parameters = {
                new SqlParameter("@Reference", reference)
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

            SqlParameter[] parameters = {
                new SqlParameter("@NomProduit", "%" + nomProduit + "%")
            };

            return DatabaseConnection.ExecuteQuery(query, parameters);
        }

        /// <summary>
        /// Récupère les produits en stock faible
        /// </summary>
        public static DataTable GetProduitsStockFaible()
        {
            string query = "SELECT * FROM Vue_ProduitStockFaible ORDER BY Quantite";
            return DatabaseConnection.ExecuteQuery(query);
        }

        /// <summary>
        /// Vérifie si une référence existe déjà
        /// </summary>
        public static bool ReferenceExiste(string reference)
        {
            string query = "SELECT COUNT(*) FROM Produits WHERE Reference = @Reference";

            SqlParameter[] parameters = {
                new SqlParameter("@Reference", reference)
            };

            object result = DatabaseConnection.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result) > 0;
        }
    }
}
