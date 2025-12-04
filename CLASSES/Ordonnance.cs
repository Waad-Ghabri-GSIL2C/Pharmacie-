using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Pharmacie.Classes
{
    internal class Ordonnance
    {
        protected int IDOrd { get; set; }
        public DateTime DateOrd { get; set; }
        public List<Produit> ListeProd { get; set; }
        public string Medecin { get; set; }
        public string Client { get; set; }

        public Ordonnance(int idOrd, DateTime dateOrd, string medecin, string client)
        {
            IDOrd = idOrd;
            DateOrd = dateOrd;
            ListeProd = new List<Produit>();
            Medecin = medecin;
            Client = client;
        }
    }
}