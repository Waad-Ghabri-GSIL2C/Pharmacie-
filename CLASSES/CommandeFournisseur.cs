using System;

namespace Gestion_Pharmacie.Classes
{
    public class CommandeFournisseur
    {
        public string NomProduit { get; set; }
        public int Quantite { get; set; }
        public string NomFournisseur { get; set; }
        public DateTime DateCommande { get; set; }
        public int DelaiJours { get; set; }
        public string Etat { get; set; } 

        public CommandeFournisseur(string nomProduit, int quantite, string nomFournisseur, int delaiJours,string etat)
        {
            NomProduit = nomProduit;
            Quantite = quantite;
            NomFournisseur = nomFournisseur;
            DateCommande = DateTime.Now;
            DelaiJours = delaiJours;
            Etat = etat;
        }
    }
}
