using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Projet_Pharmacie.DAL
{
    /// <summary>
    /// Classe pour gérer la connexion à la base de données SQLite
    /// Supporte une base de données par administrateur
    /// </summary>
    public class DatabaseConnection
    {
        // Login de l'administrateur actuellement connecté
        private static string currentAdminLogin = null;

        // Base de données principale pour les administrateurs
        private static readonly string mainDbPath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "Pharmacie_Main.db"
        );

        // Chemin de la base de données de l'admin connecté
        private static string currentDbPath = null;

        /// <summary>
        /// Définit l'administrateur connecté et charge sa base de données
        /// </summary>
        public static void SetCurrentAdmin(string login)
        {
            currentAdminLogin = login;
            currentDbPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                $"Pharmacie_{login}.db"
            );

            // Créer la base de données de l'admin si elle n'existe pas
            if (!File.Exists(currentDbPath))
            {
                SQLiteConnection.CreateFile(currentDbPath);
                InitialiserBaseDeDonneesAdmin(currentDbPath);
            }
        }

        /// <summary>
        /// Réinitialise la connexion (déconnexion)
        /// </summary>
        public static void ResetConnection()
        {
            currentAdminLogin = null;
            currentDbPath = null;
        }

        /// <summary>
        /// Retourne le chemin de la base de données appropriée
        /// </summary>
        private static string GetDatabasePath()
        {
            // Si un admin est connecté, utiliser sa base
            if (!string.IsNullOrEmpty(currentDbPath))
            {
                return currentDbPath;
            }

            // Sinon, utiliser la base principale (pour l'authentification)
            return mainDbPath;
        }

        /// <summary>
        /// Retourne une nouvelle connexion SQLite
        /// </summary>
        public static SQLiteConnection GetConnection()
        {
            try
            {
                string dbPath = GetDatabasePath();

                // Créer la base principale si elle n'existe pas
                if (dbPath == mainDbPath && !File.Exists(mainDbPath))
                {
                    SQLiteConnection.CreateFile(mainDbPath);
                    InitialiserBaseDeDonneesPrincipale();
                }

                string connectionString = $"Data Source={dbPath};Version=3;";
                SQLiteConnection conn = new SQLiteConnection(connectionString);
                return conn;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de connexion à la base de données : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Teste la connexion à la base de données
        /// </summary>
        public static bool TestConnection()
        {
            try
            {
                using (SQLiteConnection conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données : " + ex.Message,
                    "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Exécute une requête SELECT et retourne un DataTable
        /// </summary>
        public static DataTable ExecuteQuery(string query, SQLiteParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SQLiteConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'exécution de la requête : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        /// <summary>
        /// Exécute une commande INSERT, UPDATE ou DELETE
        /// </summary>
        public static bool ExecuteNonQuery(string query, SQLiteParameter[] parameters = null)
        {
            try
            {
                using (SQLiteConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'exécution de la commande : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Exécute une requête et retourne une seule valeur (COUNT, SUM, etc.)
        /// </summary>
        public static object ExecuteScalar(string query, SQLiteParameter[] parameters = null)
        {
            try
            {
                using (SQLiteConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'exécution de la requête : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Initialise la base de données principale (table Administrateurs uniquement)
        /// </summary>
        private static void InitialiserBaseDeDonneesPrincipale()
        {
            try
            {
                string connectionString = $"Data Source={mainDbPath};Version=3;";
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    string createTable = @"
                        -- Table Administrateurs (base principale)
                        CREATE TABLE IF NOT EXISTS Administrateurs (
                            AdministrateurID INTEGER PRIMARY KEY AUTOINCREMENT,
                            NomUtilisateur TEXT NOT NULL UNIQUE,
                            MotDePasse TEXT NOT NULL,
                            Email TEXT,
                            DateCreation DATETIME DEFAULT CURRENT_TIMESTAMP
                        );

                        -- Insertion d'un administrateur par défaut
                        INSERT OR IGNORE INTO Administrateurs (NomUtilisateur, MotDePasse, Email)
                        VALUES ('admin', 'admin123', 'admin@pharmacie.tn');
                    ";

                    using (SQLiteCommand cmd = new SQLiteCommand(createTable, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "✅ Base de données principale créée avec succès!\n\n" +
                    "📁 Emplacement: " + mainDbPath + "\n\n" +
                    "👤 Compte admin par défaut:\n" +
                    "   Login: admin\n" +
                    "   Mot de passe: admin123\n\n" +
                    "ℹ️ Chaque administrateur aura sa propre base de données.",
                    "Base de données initialisée",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de l'initialisation de la base de données principale : " + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        /// <summary>
        /// Initialise la base de données d'un administrateur spécifique
        /// </summary>
        private static void InitialiserBaseDeDonneesAdmin(string dbPath)
        {
            try
            {
                string connectionString = $"Data Source={dbPath};Version=3;";
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    string createTables = @"
                        -- Table Produits
                        CREATE TABLE IF NOT EXISTS Produits (
                            ProduitID INTEGER PRIMARY KEY AUTOINCREMENT,
                            Reference TEXT NOT NULL UNIQUE,
                            TypeProduit TEXT NOT NULL,
                            NomProduit TEXT NOT NULL,
                            Quantite INTEGER NOT NULL DEFAULT 0,
                            Prix REAL NOT NULL DEFAULT 0,
                            Seuil INTEGER NOT NULL DEFAULT 10,
                            Statut TEXT NOT NULL DEFAULT 'Rupture',
                            DerniereModification DATETIME DEFAULT CURRENT_TIMESTAMP
                        );

                        -- Table Pharmaciens
                        CREATE TABLE IF NOT EXISTS Pharmaciens (
                            PharmacienID INTEGER PRIMARY KEY AUTOINCREMENT,
                            CIN TEXT NOT NULL UNIQUE,
                            Nom TEXT NOT NULL,
                            Prenom TEXT NOT NULL,
                            Login TEXT NOT NULL UNIQUE,
                            MotDePasse TEXT NOT NULL,
                            Email TEXT,
                            DateCreation DATETIME DEFAULT CURRENT_TIMESTAMP,
                            Actif INTEGER DEFAULT 1
                        );

                        -- Table Fournisseurs
                        CREATE TABLE IF NOT EXISTS Fournisseurs (
                            FournisseurID INTEGER PRIMARY KEY AUTOINCREMENT,
                            NomFournisseur TEXT NOT NULL UNIQUE,
                            Telephone TEXT,
                            Email TEXT,
                            Adresse TEXT,
                            ProduitsFournis TEXT,
                            DateCreation DATETIME DEFAULT CURRENT_TIMESTAMP
                        );

                        -- Table CommandesFournisseurs
                        CREATE TABLE IF NOT EXISTS CommandesFournisseurs (
                            CommandeID INTEGER PRIMARY KEY AUTOINCREMENT,
                            FournisseurID INTEGER NOT NULL,
                            ProduitID INTEGER NOT NULL,
                            NomProduit TEXT NOT NULL,
                            Quantite INTEGER NOT NULL,
                            Delai INTEGER NOT NULL,
                            DateCommande DATETIME DEFAULT CURRENT_TIMESTAMP,
                            Statut TEXT DEFAULT 'En attente',
                            DateReception DATETIME,
                            FOREIGN KEY (FournisseurID) REFERENCES Fournisseurs(FournisseurID),
                            FOREIGN KEY (ProduitID) REFERENCES Produits(ProduitID)
                        );

                        -- Table Ventes
                        CREATE TABLE IF NOT EXISTS Ventes (
                            VenteID INTEGER PRIMARY KEY AUTOINCREMENT,
                            ProduitID INTEGER NOT NULL,
                            Reference TEXT NOT NULL,
                            NomProduit TEXT NOT NULL,
                            TypeProduit TEXT NOT NULL,
                            Quantite INTEGER NOT NULL,
                            PrixUnitaire REAL NOT NULL,
                            Montant REAL NOT NULL,
                            DateVente DATETIME DEFAULT CURRENT_TIMESTAMP,
                            FOREIGN KEY (ProduitID) REFERENCES Produits(ProduitID)
                        );

                        -- Trigger après insertion d'une vente
                        CREATE TRIGGER IF NOT EXISTS trg_AfterVenteInsert
                        AFTER INSERT ON Ventes
                        BEGIN
                            UPDATE Produits
                            SET Quantite = Quantite - NEW.Quantite,
                                Statut = CASE 
                                    WHEN (Quantite - NEW.Quantite) > Seuil THEN 'En stock'
                                    WHEN (Quantite - NEW.Quantite) > 0 THEN 'Stock limité'
                                    ELSE 'Rupture'
                                END,
                                DerniereModification = CURRENT_TIMESTAMP
                            WHERE ProduitID = NEW.ProduitID;
                        END;

                        -- Trigger après réception d'une commande
                        CREATE TRIGGER IF NOT EXISTS trg_AfterCommandeRecue
                        AFTER UPDATE OF Statut ON CommandesFournisseurs
                        WHEN NEW.Statut = 'Reçue' AND OLD.Statut = 'En attente'
                        BEGIN
                            UPDATE Produits
                            SET Quantite = Quantite + NEW.Quantite,
                                Statut = CASE 
                                    WHEN (Quantite + NEW.Quantite) > Seuil THEN 'En stock'
                                    WHEN (Quantite + NEW.Quantite) > 0 THEN 'Stock limité'
                                    ELSE 'Rupture'
                                END,
                                DerniereModification = CURRENT_TIMESTAMP
                            WHERE ProduitID = NEW.ProduitID;
                        END;

                        -- Insertion de fournisseurs par défaut
                        INSERT OR IGNORE INTO Fournisseurs (NomFournisseur, Telephone, Email, Adresse, ProduitsFournis)
                        VALUES 
                            ('Laboratoires Galenika', '71 123 456', 'contact@galenika.tn', 'Tunis, Tunisie', 'Médicaments génériques, antibiotiques'),
                            ('Pharma Distribution', '71 234 567', 'info@pharmadist.tn', 'Ariana, Tunisie', 'Matériel médical, équipements'),
                            ('MediSupply Tunisia', '71 345 678', 'sales@medisupply.tn', 'Sousse, Tunisie', 'Produits parapharmaceutiques, cosmétiques'),
                            ('Import Santé Plus', '71 456 789', 'contact@sante-plus.tn', 'Sfax, Tunisie', 'Médicaments importés, vaccins');

                        -- Insertion de produits de test
                        INSERT OR IGNORE INTO Produits (Reference, TypeProduit, NomProduit, Quantite, Prix, Seuil, Statut)
                        VALUES 
                            ('MED001', 'Médicament', 'Paracétamol 500mg', 150, 5.500, 20, 'En stock'),
                            ('MED002', 'Médicament', 'Ibuprofène 400mg', 8, 8.750, 15, 'Stock limité'),
                            ('MED003', 'Médicament', 'Amoxicilline 1g', 0, 12.500, 10, 'Rupture'),
                            ('PARA001', 'Parapharmacie', 'Crème hydratante', 45, 15.000, 10, 'En stock'),
                            ('MAT001', 'Matériel', 'Thermomètre digital', 25, 35.000, 5, 'En stock');

                        -- Insertion d'un pharmacien de test
                        INSERT OR IGNORE INTO Pharmaciens (CIN, Nom, Prenom, Login, MotDePasse, Email, Actif)
                        VALUES 
                            ('12345678', 'Ben Ali', 'Fatma', 'fatma.benali', 'pharma123', 'fatma.benali@pharmacie.tn', 1);
                    ";

                    using (SQLiteCommand cmd = new SQLiteCommand(createTables, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de l'initialisation de la base de données admin : " + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        /// <summary>
        /// Retourne le login de l'admin actuellement connecté
        /// </summary>
        public static string GetCurrentAdminLogin()
        {
            return currentAdminLogin;
        }

        /// <summary>
        /// Retourne le chemin complet de la base de données actuelle
        /// </summary>
        public static string GetCurrentDatabasePath()
        {
            return GetDatabasePath();
        }

        /// <summary>
        /// Ajoute des données de test pour un administrateur existant
        /// Utile si vous avez déjà une base et voulez ajouter les fournisseurs
        /// </summary>
        public static bool AjouterDonneesDeTest()
        {
            try
            {
                string insertData = @"
                    INSERT OR IGNORE INTO Fournisseurs (NomFournisseur, Telephone, Email, Adresse, ProduitsFournis)
                    VALUES 
                        ('Laboratoires Galenika', '71 123 456', 'contact@galenika.tn', 'Tunis, Tunisie', 'Médicaments génériques, antibiotiques'),
                        ('Pharma Distribution', '71 234 567', 'info@pharmadist.tn', 'Ariana, Tunisie', 'Matériel médical, équipements'),
                        ('MediSupply Tunisia', '71 345 678', 'sales@medisupply.tn', 'Sousse, Tunisie', 'Produits parapharmaceutiques, cosmétiques'),
                        ('Import Santé Plus', '71 456 789', 'contact@sante-plus.tn', 'Sfax, Tunisie', 'Médicaments importés, vaccins');

                    INSERT OR IGNORE INTO Produits (Reference, TypeProduit, NomProduit, Quantite, Prix, Seuil, Statut)
                    VALUES 
                        ('MED001', 'Médicament', 'Paracétamol 500mg', 150, 5.500, 20, 'En stock'),
                        ('MED002', 'Médicament', 'Ibuprofène 400mg', 8, 8.750, 15, 'Stock limité'),
                        ('MED003', 'Médicament', 'Amoxicilline 1g', 0, 12.500, 10, 'Rupture'),
                        ('PARA001', 'Parapharmacie', 'Crème hydratante', 45, 15.000, 10, 'En stock'),
                        ('MAT001', 'Matériel', 'Thermomètre digital', 25, 35.000, 5, 'En stock');

                    INSERT OR IGNORE INTO Pharmaciens (CIN, Nom, Prenom, Login, MotDePasse, Email, Actif)
                    VALUES 
                        ('12345678', 'Ben Ali', 'Fatma', 'fatma', 'pfatma123', 'fatma.benali@pharmacie.tn', 1);
                        ('10101010', 'Ben mohamed', 'samir', 'samir', 'samir123', 'samir@pharmacie.tn', 1);
                ";

                bool success = ExecuteNonQuery(insertData);

                if (success)
                {
                    MessageBox.Show(
                        "✅ Données de test ajoutées avec succès!\n\n" +
                        "📦 4 Fournisseurs\n" +
                        "💊 5 Produits\n" +
                        "👤 1 Pharmacien\n\n" +
                        "Pharmacien de test:\n" +
                        "   Login: fatma.benali\n" +
                        "   Mot de passe: pharma123",
                        "Données de test",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }

                return success;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de l'ajout des données de test : " + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }
        }
    }
}
