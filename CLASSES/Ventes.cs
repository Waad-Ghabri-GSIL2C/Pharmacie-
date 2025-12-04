using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Pharmacie.Classes
{
    internal class Ventes
    {
        protected int IDVente { get; set; }
        public DateTime DateVente { get; set; }
        public float Montant { get; set; }
        public int IDPharmacien { get; set; }
        public List<Produit> ProduitsVendues { get; set; }

        public Ventes(int idVente, DateTime dateVente, float montant, int idPharmacien)
        {
            IDVente = idVente;
            DateVente = dateVente;
            Montant = montant;
            IDPharmacien = idPharmacien;
            ProduitsVendues = new List<Produit>();
        }
    }
}