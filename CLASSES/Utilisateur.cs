using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Pharmacie.Classes
{
    public enum Statut
    {
        Admin,
        Pharmacien
    }
    internal class Utilisateur
    {
        protected int ID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        protected string Login { get; set; }
        protected string MotDePasse { get; set; }
        public string Email { get; set; }

        public Statut Statut { get; set; }

        public Utilisateur(int id, string nom, string prenom, string login, string password, string email, Statut statut)
        {
            ID = id;
            Nom = nom;
            Prenom = prenom;
            Login = login;
            MotDePasse = password;
            Email = email;
            Statut = statut;

        }

    }
}
