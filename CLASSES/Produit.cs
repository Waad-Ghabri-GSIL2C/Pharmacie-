using System;

namespace Gestion_Pharmacie.Classes
{
    public enum StatutP
    {
        Medicaments,
        Para
    }

    public class Produit
    {
        // Propriétés publiques pour le DataGridView
        public string Reference { get; set; }
        public StatutP TypeProduit { get; set; }
        public string NomProduit { get; set; }
        public int Quantite { get; set; }
        public decimal Prix { get; set; }
        public string Statut { get; set; }
        public int Seuil { get; set; }

        // Constructeur
        public Produit(string reference, StatutP typeProduit, string nomProduit,
                       int quantite, decimal prix, string statut)
        {
            Reference = reference;
            TypeProduit = typeProduit;
            NomProduit = nomProduit;
            Quantite = quantite;
            Prix = prix;
            Statut = statut;



            Seuil = 5; // Valeur par défaut
        }
    }
}