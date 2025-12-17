using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Projet_Pharmacie.DAL
{
    /// <summary>
    /// Classe d'accès aux données pour la gestion des Administrateurs (Version SQLite)
    /// </summary>
    public class AdministrateurDAL
    {
        /// <summary>
        /// Vérifie les identifiants de connexion d'un administrateur
        /// </summary>
        public static bool VerifierConnexion(string nomUtilisateur, string motDePasse)
        {
            try
            {
                string query = @"SELECT COUNT(*) 
                                FROM Administrateurs 
                                WHERE NomUtilisateur = @NomUtilisateur 
                                  AND MotDePasse = @MotDePasse";

                SQLiteParameter[] parameters = {
                    new SQLiteParameter("@NomUtilisateur", nomUtilisateur),
                    new SQLiteParameter("@MotDePasse", motDePasse)
                };

                object result = DatabaseConnection.ExecuteScalar(query, parameters);
                return result != null && Convert.ToInt32(result) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la vérification : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Ajoute un nouvel administrateur
        /// </summary>
        public static bool AjouterAdministrateur(string nomUtilisateur, string motDePasse, string email)
        {
            try
            {
                // Vérifier si l'utilisateur existe déjà
                string queryVerif = "SELECT COUNT(*) FROM Administrateurs WHERE NomUtilisateur = @NomUtilisateur";
                SQLiteParameter[] paramsVerif = { new SQLiteParameter("@NomUtilisateur", nomUtilisateur) };
                object resultVerif = DatabaseConnection.ExecuteScalar(queryVerif, paramsVerif);

                if (Convert.ToInt32(resultVerif) > 0)
                {
                    MessageBox.Show("Ce nom d'utilisateur existe déjà.",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Insérer le nouvel administrateur
                string query = @"INSERT INTO Administrateurs (NomUtilisateur, MotDePasse, Email, DateCreation)
                                VALUES (@NomUtilisateur, @MotDePasse, @Email, CURRENT_TIMESTAMP)";

                SQLiteParameter[] parameters = {
                    new SQLiteParameter("@NomUtilisateur", nomUtilisateur),
                    new SQLiteParameter("@MotDePasse", motDePasse),
                    new SQLiteParameter("@Email", string.IsNullOrEmpty(email) ? DBNull.Value : (object)email)
                };

                return DatabaseConnection.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Récupère tous les administrateurs
        /// </summary>
        public static DataTable GetAllAdministrateurs()
        {
            string query = "SELECT AdministrateurID, NomUtilisateur, Email, DateCreation FROM Administrateurs";
            return DatabaseConnection.ExecuteQuery(query);
        }

        /// <summary>
        /// Supprime un administrateur
        /// </summary>
        public static bool SupprimerAdministrateur(int administrateurID)
        {
            try
            {
                string query = "DELETE FROM Administrateurs WHERE AdministrateurID = @AdministrateurID";

                SQLiteParameter[] parameters = {
                    new SQLiteParameter("@AdministrateurID", administrateurID)
                };

                return DatabaseConnection.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Modifie le mot de passe d'un administrateur
        /// </summary>
        public static bool ModifierMotDePasse(string nomUtilisateur, string nouveauMotDePasse)
        {
            try
            {
                string query = @"UPDATE Administrateurs 
                                SET MotDePasse = @NouveauMotDePasse
                                WHERE NomUtilisateur = @NomUtilisateur";

                SQLiteParameter[] parameters = {
                    new SQLiteParameter("@NomUtilisateur", nomUtilisateur),
                    new SQLiteParameter("@NouveauMotDePasse", nouveauMotDePasse)
                };

                return DatabaseConnection.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la modification : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Récupère le nombre total d'administrateurs
        /// </summary>
        public static int GetNombreAdministrateurs()
        {
            string query = "SELECT COUNT(*) FROM Administrateurs";
            object result = DatabaseConnection.ExecuteScalar(query);
            return result != null ? Convert.ToInt32(result) : 0;
        }
    }
}