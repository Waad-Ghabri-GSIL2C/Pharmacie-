using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Pharmacie.Classes
{
    internal class Pharmacien : Utilisateur
    {
        protected int ID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        protected string Login { get; set; }
        protected string MotDePasse { get; set; }
        public string Email { get; set; }

        public Statut Statut { get; set; }

        public Pharmacien(int id, string nom, string prenom, string login, string password, string email, Statut statut) : base(id, nom, prenom, login, password, email, statut)
        { }
    }
}