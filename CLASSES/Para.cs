using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Pharmacie.Classes
{
    internal class Para : Produit
    {
        public string Reference { get; set; }
        public StatutP TypeProduit { get; set; }
        public string NomProduit { get; set; }
        public int Quantite { get; set; }
        public decimal Prix { get; set; }
        public string Statut { get; set; }
        public int Seuil { get; set; }
        public string Fournisseur { get; set; }

        public Para (string reference, StatutP typeProduit, string nomProduit,
                       int quantite, decimal prix, string statut, string fournisseur) : base(reference, typeProduit, nomProduit, quantite, prix, statut)
        {
            Fournisseur = fournisseur;
            Seuil = 10;
        }

    }
}