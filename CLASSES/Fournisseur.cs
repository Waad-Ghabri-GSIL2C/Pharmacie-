using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Pharmacie.Classes
{
    internal class Fournisseur
    {
        protected int IDF { get; set; }
        public string NomF { get; set; }
        public string Adresse { get; set; }
        public string EmailF { get; set; }
        public string Tel { get; set; }
        public List<Produit> ListeProduitsFournis { get; set; }

        public Fournisseur(int idF, string nomF, string adresse, string emailF, string tel)
        {
            IDF = idF;
            NomF = nomF;
            Adresse = adresse;
            EmailF = emailF;
            Tel = tel;
            ListeProduitsFournis = new List<Produit>();
        }
    }
}