using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Projet_Pharmacie.DAL
{
    /// <summary>
    /// Classe d'accès aux données pour la gestion des pharmaciens (Version SQLite)
    /// Correspond à la table Pharmaciens de votre base de données
    /// </summary>
    public class PharmacienDAL
    {
        /// <summary>
        /// Récupère tous les pharmaciens depuis la base de données
        /// </summary>
        public static DataTable GetAllPharmaciens()
        {
            string query = @"SELECT 
                                PharmacienID, 
                                CIN AS ID, 
                                Nom, 
                                Prenom, 
                                Login, 
                                MotDePasse, 
                                Email,
                                DateCreation,
                                Actif
                             FROM Pharmaciens
                             WHERE Actif = 1
                             ORDER BY Nom, Prenom";

            return DatabaseConnection.ExecuteQuery(query);
        }

        /// <summary>
        /// Ajoute un nouveau pharmacien dans la base de données
        /// </summary>
        public static bool AjouterPharmacien(string cin, string nom, string prenom,
            string login, string motDePasse, string email)
        {
            // Vérifier si le CIN existe déjà
            if (CINExiste(cin))
            {
                MessageBox.Show("Ce CIN existe déjà dans la base de données.",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Vérifier si le login existe déjà
            if (LoginExiste(login))
            {
                MessageBox.Show("Ce login existe déjà dans la base de données.",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string query = @"INSERT INTO Pharmaciens (CIN, Nom, Prenom, Login, MotDePasse, Email, DateCreation, Actif)
                            VALUES (@CIN, @Nom, @Prenom, @Login, @MotDePasse, @Email, CURRENT_TIMESTAMP, 1)";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@CIN", cin),
                new SQLiteParameter("@Nom", nom),
                new SQLiteParameter("@Prenom", prenom),
                new SQLiteParameter("@Login", login),
                new SQLiteParameter("@MotDePasse", motDePasse),
                new SQLiteParameter("@Email", email)
            };

            return DatabaseConnection.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Supprime un pharmacien de la base de données (soft delete)
        /// </summary>
        public static bool SupprimerPharmacien(string cin)
        {
            // On ne supprime pas vraiment, on désactive le pharmacien
            string query = "UPDATE Pharmaciens SET Actif = 0 WHERE CIN = @CIN";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@CIN", cin)
            };

            return DatabaseConnection.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Supprime définitivement un pharmacien (hard delete)
        /// </summary>
        public static bool SupprimerPharmacienDefinitif(string cin)
        {
            string query = "DELETE FROM Pharmaciens WHERE CIN = @CIN";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@CIN", cin)
            };

            return DatabaseConnection.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Modifie les informations d'un pharmacien
        /// </summary>
        public static bool ModifierPharmacien(string cin, string nom, string prenom,
            string login, string motDePasse, string email)
        {
            string query = @"UPDATE Pharmaciens 
                            SET Nom = @Nom, 
                                Prenom = @Prenom, 
                                Login = @Login, 
                                MotDePasse = @MotDePasse, 
                                Email = @Email
                            WHERE CIN = @CIN";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@CIN", cin),
                new SQLiteParameter("@Nom", nom),
                new SQLiteParameter("@Prenom", prenom),
                new SQLiteParameter("@Login", login),
                new SQLiteParameter("@MotDePasse", motDePasse),
                new SQLiteParameter("@Email", email)
            };

            return DatabaseConnection.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Vérifie si un CIN existe déjà dans la base de données
        /// </summary>
        public static bool CINExiste(string cin)
        {
            string query = "SELECT COUNT(*) FROM Pharmaciens WHERE CIN = @CIN AND Actif = 1";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@CIN", cin)
            };

            object result = DatabaseConnection.ExecuteScalar(query, parameters);
            return result != null && Convert.ToInt32(result) > 0;
        }

        /// <summary>
        /// Vérifie si un login existe déjà dans la base de données
        /// </summary>
        public static bool LoginExiste(string login)
        {
            string query = "SELECT COUNT(*) FROM Pharmaciens WHERE Login = @Login AND Actif = 1";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@Login", login)
            };

            object result = DatabaseConnection.ExecuteScalar(query, parameters);
            return result != null && Convert.ToInt32(result) > 0;
        }

        /// <summary>
        /// Recherche un pharmacien par son CIN
        /// </summary>
        public static DataTable RechercherParCIN(string cin)
        {
            string query = @"SELECT 
                                PharmacienID,
                                CIN AS ID, 
                                Nom, 
                                Prenom, 
                                Login, 
                                MotDePasse, 
                                Email,
                                DateCreation
                             FROM Pharmaciens 
                             WHERE CIN = @CIN AND Actif = 1";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@CIN", cin)
            };

            return DatabaseConnection.ExecuteQuery(query, parameters);
        }

        /// <summary>
        /// Recherche des pharmaciens par nom ou prénom
        /// </summary>
        public static DataTable RechercherParNom(string recherche)
        {
            string query = @"SELECT 
                                PharmacienID,
                                CIN AS ID, 
                                Nom, 
                                Prenom, 
                                Login, 
                                MotDePasse, 
                                Email,
                                DateCreation
                             FROM Pharmaciens 
                             WHERE (Nom LIKE @Recherche OR Prenom LIKE @Recherche) AND Actif = 1
                             ORDER BY Nom, Prenom";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@Recherche", "%" + recherche + "%")
            };

            return DatabaseConnection.ExecuteQuery(query, parameters);
        }

        /// <summary>
        /// Vérifie les identifiants de connexion (Login + Mot de passe)
        /// </summary>
        public static bool VerifierConnexion(string login, string motDePasse)
        {
            string query = @"SELECT COUNT(*) 
                            FROM Pharmaciens 
                            WHERE Login = @Login AND MotDePasse = @MotDePasse AND Actif = 1";

            SQLiteParameter[] parameters = {
                new SQLiteParameter("@Login", login),
                new SQLiteParameter("@MotDePasse", motDePasse)
            };

            object result = DatabaseConnection.ExecuteScalar(query, parameters);
            return result != null && Convert.ToInt32(result) > 0;
        }

        /// <summary>
        /// Récupère le nombre total de pharmaciens actifs
        /// </summary>
        public static int GetNombrePharmaciens()
        {
            string query = "SELECT COUNT(*) FROM Pharmaciens WHERE Actif = 1";
            object result = DatabaseConnection.ExecuteScalar(query);
            return result != null ? Convert.ToInt32(result) : 0;
        }
    }
}