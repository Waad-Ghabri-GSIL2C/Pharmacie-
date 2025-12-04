using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Pharmacie.Classes
{
    internal class Stock
    {
        public List<Produit> ListeProduits { get; set; }

        public Stock()
        {
            ListeProduits = new List<Produit>();
        }

    }
}