using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Projet_Pharmacie.DAL
{
    /// <summary>
    /// Classe d'accès aux données pour la gestion des Fournisseurs
    /// </summary>
    public class FournisseurDAL
    {
        /// <summary>
        /// Récupère tous les fournisseurs
        /// </summary>
        public static DataTable GetAllFournisseurs()
        {
            string query = @"SELECT 
                                FournisseurID, 
                                NomFournisseur, 
                                Telephone, 
                                Email, 
                                Adresse,
                                ProduitsFournis
                             FROM Fournisseurs
                             ORDER BY NomFournisseur";

            return DatabaseConnection.ExecuteQuery(query);
        }

        /// <summary>
        /// Ajoute un nouveau fournisseur
        /// </summary>
        public static bool AjouterFournisseur(string nomFournisseur, string telephone,
            string email, string adresse)
        {
            // Vérifier si le fournisseur existe déjà
            if (FournisseurExiste(nomFournisseur))
            {
                MessageBox.Show("Ce fournisseur existe déjà dans la base de données.",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string query = @"INSERT INTO Fournisseurs (NomFournisseur, Telephone, Email, Adresse, DateCreation)
                            VALUES (@NomFournisseur, @Telephone, @Email, @Adresse, GETDATE())";

            SqlParameter[] parameters = {
                new SqlParameter("@NomFournisseur", nomFournisseur),
                new SqlParameter("@Telephone", telephone ?? (object)DBNull.Value),
                new SqlParameter("@Email", email ?? (object)DBNull.Value),
                new SqlParameter("@Adresse", adresse ?? (object)DBNull.Value)
            };

            return DatabaseConnection.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Supprime un fournisseur
        /// </summary>
        public static bool SupprimerFournisseur(int fournisseurID)
        {
            string query = "DELETE FROM Fournisseurs WHERE FournisseurID = @FournisseurID";

            SqlParameter[] parameters = {
                new SqlParameter("@FournisseurID", fournisseurID)
            };

            return DatabaseConnection.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Modifie les informations d'un fournisseur
        /// </summary>
        public static bool ModifierFournisseur(int fournisseurID, string nomFournisseur,
            string telephone, string email, string adresse)
        {
            string query = @"UPDATE Fournisseurs 
                            SET NomFournisseur = @NomFournisseur, 
                                Telephone = @Telephone, 
                                Email = @Email, 
                                Adresse = @Adresse
                            WHERE FournisseurID = @FournisseurID";

            SqlParameter[] parameters = {
                new SqlParameter("@FournisseurID", fournisseurID),
                new SqlParameter("@NomFournisseur", nomFournisseur),
                new SqlParameter("@Telephone", telephone ?? (object)DBNull.Value),
                new SqlParameter("@Email", email ?? (object)DBNull.Value),
                new SqlParameter("@Adresse", adresse ?? (object)DBNull.Value)
            };

            return DatabaseConnection.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Vérifie si un fournisseur existe déjà
        /// </summary>
        public static bool FournisseurExiste(string nomFournisseur)
        {
            string query = "SELECT COUNT(*) FROM Fournisseurs WHERE NomFournisseur = @NomFournisseur";

            SqlParameter[] parameters = {
                new SqlParameter("@NomFournisseur", nomFournisseur)
            };

            object result = DatabaseConnection.ExecuteScalar(query, parameters);
            return result != null && Convert.ToInt32(result) > 0;
        }

        /// <summary>
        /// Récupère un fournisseur par son ID
        /// </summary>
        public static DataRow GetFournisseurByID(int fournisseurID)
        {
            string query = @"SELECT 
                                FournisseurID, 
                                NomFournisseur, 
                                Telephone, 
                                Email, 
                                Adresse
                             FROM Fournisseurs 
                             WHERE FournisseurID = @FournisseurID";

            SqlParameter[] parameters = {
                new SqlParameter("@FournisseurID", fournisseurID)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        /// <summary>
        /// Recherche des fournisseurs par nom
        /// </summary>
        public static DataTable RechercherFournisseurs(string recherche)
        {
            string query = @"SELECT 
                                FournisseurID, 
                                NomFournisseur, 
                                Telephone, 
                                Email, 
                                Adresse
                             FROM Fournisseurs 
                             WHERE NomFournisseur LIKE @Recherche 
                                OR Email LIKE @Recherche
                             ORDER BY NomFournisseur";

            SqlParameter[] parameters = {
                new SqlParameter("@Recherche", "%" + recherche + "%")
            };

            return DatabaseConnection.ExecuteQuery(query, parameters);
        }

        /// <summary>
        /// Récupère le nombre total de fournisseurs
        /// </summary>
        public static int GetNombreFournisseurs()
        {
            string query = "SELECT COUNT(*) FROM Fournisseurs";
            object result = DatabaseConnection.ExecuteScalar(query);
            return result != null ? Convert.ToInt32(result) : 0;
        }
    }
}