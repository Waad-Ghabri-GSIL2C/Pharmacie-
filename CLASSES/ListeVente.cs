using System;
using System.Collections.Generic;
using System.Linq;

namespace Gestion_Pharmacie.Classes
{
    public static class ListeVente
    {
        // Liste statique partagée entre tous les formulaires (produits en cours de vente)
        public static List<Produit> ProduitsVente { get; set; }
            = new List<Produit>();

        // Liste des produits vendus (pour mettre à jour le stock après validation)
        public static List<Produit> ProduitsVendus { get; set; }
            = new List<Produit>();

        // Méthode pour calculer le total de la vente
        public static decimal CalculerTotal()
        {
            return ProduitsVente.Sum(p => p.Prix * p.Quantite);
        }

        // Méthode pour vider la liste après validation
        public static void ViderListe()
        {
            ProduitsVente.Clear();
        }

        // Méthode pour obtenir le nombre de produits
        public static int NombreProduits()
        {
            return ProduitsVente.Count;
        }

        // Méthode pour obtenir le nombre total d'articles
        public static int NombreTotalArticles()
        {
            return ProduitsVente.Sum(p => p.Quantite);
        }

        // Méthode pour vérifier si un produit existe déjà dans la liste
        public static bool ProduitExiste(string reference)
        {
            return ProduitsVente.Any(p => p.Reference == reference);
        }

        // Méthode pour obtenir un produit par référence
        public static Produit ObtenirProduit(string reference)
        {
            return ProduitsVente.FirstOrDefault(p => p.Reference == reference);
        }

        // Méthode pour supprimer un produit de la liste
        public static bool SupprimerProduit(string reference)
        {
            var produit = ProduitsVente.FirstOrDefault(p => p.Reference == reference);
            if (produit != null)
            {
                ProduitsVente.Remove(produit);
                return true;
            }
            return false;
        }

        // Méthode pour vider la liste des produits vendus
        public static void ViderProduitsVendus()
        {
            ProduitsVendus.Clear();
        }
    }
}
