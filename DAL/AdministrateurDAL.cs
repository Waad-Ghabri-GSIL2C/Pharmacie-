using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Projet_Pharmacie.DAL
{
    /// <summary>
    /// Classe d'accès aux données pour la gestion des Administrateurs
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

                SqlParameter[] parameters = {
                    new SqlParameter("@NomUtilisateur", nomUtilisateur),
                    new SqlParameter("@MotDePasse", motDePasse)
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
                SqlParameter[] paramsVerif = { new SqlParameter("@NomUtilisateur", nomUtilisateur) };

                object resultVerif = DatabaseConnection.ExecuteScalar(queryVerif, paramsVerif);
                if (Convert.ToInt32(resultVerif) > 0)
                {
                    MessageBox.Show("Ce nom d'utilisateur existe déjà.",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Insérer le nouvel administrateur
                string query = @"INSERT INTO Administrateurs (NomUtilisateur, MotDePasse, Email, DateCreation)
                                VALUES (@NomUtilisateur, @MotDePasse, @Email, GETDATE())";

                SqlParameter[] parameters = {
                    new SqlParameter("@NomUtilisateur", nomUtilisateur),
                    new SqlParameter("@MotDePasse", motDePasse),
                    new SqlParameter("@Email", email ?? (object)DBNull.Value)
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
    }
}
