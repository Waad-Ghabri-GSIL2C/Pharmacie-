-- On a utilisé SQL Server Management Studio comme SGBD 

USE master;
GO


-- SUPPRIMER L'ANCIENNE BASE SI ELLE EXISTE

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'Projet_Pharmacie')
BEGIN
    ALTER DATABASE Projet_Pharmacie SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE Projet_Pharmacie;
    PRINT '✓ Ancienne base supprimée.';
END
GO


-- CRÉER LA NOUVELLE BASE DE DONNÉES

CREATE DATABASE Projet_Pharmacie;
GO
PRINT '✓ Base de données Projet_Pharmacie créée.';
GO

USE Projet_Pharmacie;
GO

 
-- CRÉATION DES TABLES


-- Table Administrateurs
CREATE TABLE Administrateurs (
    AdministrateurID INT PRIMARY KEY IDENTITY(1,1),
    NomUtilisateur NVARCHAR(50) UNIQUE NOT NULL,
    MotDePasse NVARCHAR(255) NOT NULL,
    Email NVARCHAR(100),
    DateCreation DATETIME DEFAULT GETDATE()
);
PRINT '✓ Table Administrateurs créée.';
GO

-- Table Pharmaciens 
CREATE TABLE Pharmaciens (
    PharmacienID INT PRIMARY KEY IDENTITY(1,1),
    CIN NVARCHAR(20) UNIQUE NOT NULL,
    Nom NVARCHAR(50) NOT NULL,
    Prenom NVARCHAR(50) NOT NULL,
    Login NVARCHAR(50) UNIQUE NOT NULL,
    MotDePasse NVARCHAR(255) NOT NULL,
    Telephone NVARCHAR(15),
    Email NVARCHAR(100),
    DateEmbauche DATE,
    DateCreation DATETIME DEFAULT GETDATE(),
    Actif BIT DEFAULT 1,
    Statut NVARCHAR(20) DEFAULT 'Actif'
);
PRINT '✓ Table Pharmaciens créée.';
GO

-- Table Fournisseurs
CREATE TABLE Fournisseurs (
    FournisseurID INT PRIMARY KEY IDENTITY(1,1),
    NomFournisseur NVARCHAR(100) NOT NULL,
    Adresse NVARCHAR(200),
    Telephone NVARCHAR(15),
    Email NVARCHAR(100),
    ProduitsFournis NVARCHAR(MAX),
    DateCreation DATETIME DEFAULT GETDATE(),
    Statut NVARCHAR(20) DEFAULT 'Actif'
);
PRINT '✓ Table Fournisseurs créée.';
GO

-- Table Produits 
CREATE TABLE Produits (
    ProduitID INT PRIMARY KEY IDENTITY(1,1),
    Reference NVARCHAR(20) UNIQUE NOT NULL,
    TypeProduit NVARCHAR(50) NOT NULL,
    NomProduit NVARCHAR(100) NOT NULL,
    Quantite INT DEFAULT 0,
    Prix DECIMAL(10,2) NOT NULL,
    Seuil INT DEFAULT 10,
    Statut NVARCHAR(20) DEFAULT 'En stock',
    DateExpiration DATE,
    FournisseurID INT,
    DerniereModification DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (FournisseurID) REFERENCES Fournisseurs(FournisseurID) ON DELETE SET NULL
);
PRINT '✓ Table Produits créée.';
GO

-- Table CommandesFournisseurs 
CREATE TABLE CommandesFournisseurs (
    CommandeID INT PRIMARY KEY IDENTITY(1,1),
    FournisseurID INT NOT NULL,
    ProduitID INT NOT NULL,
    NomProduit NVARCHAR(100) NOT NULL,
    Quantite INT NOT NULL,
    Delai INT NOT NULL,  -- Délai en jours
    DateCommande DATETIME DEFAULT GETDATE(),
    DateReception DATETIME NULL,
    Statut NVARCHAR(20) DEFAULT 'En attente',
    FOREIGN KEY (FournisseurID) REFERENCES Fournisseurs(FournisseurID) ON DELETE CASCADE,
    FOREIGN KEY (ProduitID) REFERENCES Produits(ProduitID) ON DELETE CASCADE
);
PRINT '✓ Table CommandesFournisseurs créée (adaptée au code C#).';
GO

-- Table Ventes 
CREATE TABLE Ventes (
    VenteID INT PRIMARY KEY IDENTITY(1,1),
    DateVente DATETIME DEFAULT GETDATE(),
    ProduitID INT NOT NULL,
    Reference NVARCHAR(20) NOT NULL,
    NomProduit NVARCHAR(100) NOT NULL,
    TypeProduit NVARCHAR(50) NOT NULL,
    Quantite INT NOT NULL,
    PrixUnitaire DECIMAL(10,2) NOT NULL,
    Montant DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (ProduitID) REFERENCES Produits(ProduitID) ON DELETE CASCADE
);
PRINT '✓ Table Ventes créée (adaptée au code C#).';
GO


-- CRÉATION DES TRIGGERS 


-- Trigger pour mettre à jour le stock après une vente
CREATE TRIGGER trg_UpdateStockAfterSale
ON Ventes
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Mettre à jour la quantité
    UPDATE Produits
    SET Quantite = Produits.Quantite - inserted.Quantite,
        DerniereModification = GETDATE()
    FROM Produits
    INNER JOIN inserted ON Produits.ProduitID = inserted.ProduitID;
    
    -- Mettre à jour le statut selon le seuil
    UPDATE Produits
    SET Statut = CASE 
        WHEN Quantite > Seuil THEN 'En stock'
        WHEN Quantite > 0 AND Quantite <= Seuil THEN 'Stock limité'
        ELSE 'Rupture'
    END
    WHERE ProduitID IN (SELECT ProduitID FROM inserted);
    
    PRINT '✓ Stock mis à jour après vente.';
END;
GO
PRINT '✓ Trigger trg_UpdateStockAfterSale créé.';
GO

-- Trigger pour mettre à jour le stock après réception d'une commande
CREATE TRIGGER trg_UpdateStockAfterCommandeRecue
ON CommandesFournisseurs
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Vérifier si le statut est passé à 'Reçue'
    IF UPDATE(Statut)
    BEGIN
        -- Mettre à jour le stock uniquement pour les commandes marquées comme 'Reçue'
        UPDATE Produits
        SET Quantite = Produits.Quantite + inserted.Quantite,
            DerniereModification = GETDATE()
        FROM Produits
        INNER JOIN inserted ON Produits.ProduitID = inserted.ProduitID
        WHERE inserted.Statut = 'Reçue' 
          AND inserted.CommandeID IN (
              SELECT inserted.CommandeID 
              FROM inserted 
              INNER JOIN deleted ON inserted.CommandeID = deleted.CommandeID 
              WHERE deleted.Statut <> 'Reçue'
          );
        
        -- Mettre à jour le statut selon le seuil
        UPDATE Produits
        SET Statut = CASE 
            WHEN Quantite > Seuil THEN 'En stock'
            WHEN Quantite > 0 AND Quantite <= Seuil THEN 'Stock limité'
            ELSE 'Rupture'
        END
        WHERE ProduitID IN (SELECT ProduitID FROM inserted WHERE Statut = 'Reçue');
        
        PRINT '✓ Stock mis à jour après réception de commande.';
    END
END;
GO
PRINT '✓ Trigger trg_UpdateStockAfterCommandeRecue créé.';
GO


-- CRÉATION DES VUES 


-- Vue pour afficher les produits en stock faible
CREATE VIEW Vue_ProduitStockFaible AS
SELECT 
    ProduitID,
    Reference,
    TypeProduit,
    NomProduit,
    Quantite,
    Seuil,
    Prix,
    Statut,
    DateExpiration
FROM Produits
WHERE Quantite <= Seuil AND Quantite >= 0;
GO
PRINT '✓ Vue Vue_ProduitStockFaible créée.';
GO

-- Vue pour afficher les produits en rupture de stock
CREATE VIEW Vue_ProduitsEnRupture AS
SELECT 
    ProduitID,
    Reference,
    NomProduit,
    TypeProduit,
    Quantite,
    Prix,
    DateExpiration
FROM Produits
WHERE Quantite = 0 OR Statut = 'Rupture';
GO
PRINT '✓ Vue Vue_ProduitsEnRupture créée.';
GO

-- Vue pour afficher les statistiques des ventes
CREATE VIEW Vue_StatistiquesVentes AS
SELECT 
    P.ProduitID,
    P.NomProduit,
    P.TypeProduit,
    SUM(V.Quantite) AS TotalVendu,
    SUM(V.Montant) AS ChiffreAffaires,
    COUNT(V.VenteID) AS NombreVentes
FROM Ventes V
INNER JOIN Produits P ON V.ProduitID = P.ProduitID
GROUP BY P.ProduitID, P.NomProduit, P.TypeProduit;
GO
PRINT '✓ Vue Vue_StatistiquesVentes créée.';
GO

-- Vue pour afficher les commandes en attente
CREATE VIEW Vue_CommandesEnAttente AS
SELECT 
    CF.CommandeID,
    F.NomFournisseur,
    CF.NomProduit,
    CF.Quantite,
    CF.Delai,
    CF.DateCommande,
    CF.Statut,
    DATEDIFF(day, CF.DateCommande, GETDATE()) AS JoursDepuisCommande
FROM CommandesFournisseurs CF
INNER JOIN Fournisseurs F ON CF.FournisseurID = F.FournisseurID
WHERE CF.Statut = 'En attente';
GO
PRINT '✓ Vue Vue_CommandesEnAttente créée.';
GO

-- ========================================
-- INSERTION DES DONNÉES DE TEST
-- ========================================

-- Insérer un administrateur par défaut
INSERT INTO Administrateurs (NomUtilisateur, MotDePasse, Email)
VALUES ('admin', 'admin123', 'admin@pharmacie.tn');
PRINT '✓ 1 administrateur inséré (Login: admin / MDP: admin123).';
GO

-- Insérer des pharmaciens de test
INSERT INTO Pharmaciens (CIN, Nom, Prenom, Login, MotDePasse, Email, DateEmbauche)
VALUES 
('12345678', 'Ben Salem', 'Amira', 'amira.salem', 'amira123', 'amira.salem@pharmacie.tn', '2023-01-15'),
('87654321', 'Jebali', 'Mohamed', 'mohamed.jebali', 'mohamed123', 'mohamed.jebali@pharmacie.tn', '2023-03-20');
PRINT '✓ 2 pharmaciens insérés.';
GO

-- Insérer des fournisseurs
INSERT INTO Fournisseurs (NomFournisseur, Adresse, Telephone, Email, ProduitsFournis)
VALUES 
('Pharma Plus', '123 Rue de la Santé, Tunis', '71234567', 'contact@pharmaplus.tn', 'Médicaments, Vitamines'),
('MediSupply', '456 Avenue Médicale, Sfax', '74987654', 'info@medisupply.tn', 'Parapharmacie'),
('HealthCorp', '789 Boulevard Santé, Sousse', '73147258', 'sales@healthcorp.tn', 'Médicaments, Matériel médical');
PRINT '✓ 3 fournisseurs insérés.';
GO

-- Insérer des produits de test
INSERT INTO Produits (Reference, TypeProduit, NomProduit, Quantite, Prix, Seuil, DateExpiration, FournisseurID)
VALUES 
('MED001', 'Medicaments', 'Paracétamol 500mg', 150, 5.50, 20, '2026-12-31', 1),
('MED002', 'Medicaments', 'Ibuprofène 400mg', 100, 7.20, 20, '2026-06-30', 1),
('MED003', 'Medicaments', 'Amoxicilline 1g', 80, 12.00, 15, '2025-12-31', 3),
('MED004', 'Medicaments', 'Aspirine 100mg', 5, 4.00, 20, '2026-09-30', 1),
('PARA001', 'Para', 'Vitamine C 1000mg', 84, 8.50, 15, '2027-03-15', 2),
('PARA002', 'Para', 'Crème hydratante', 45, 15.00, 10, '2026-08-20', 2),
('PARA003', 'Para', 'Shampooing anti-pelliculaire', 30, 12.50, 10, '2026-11-10', 2);
PRINT '✓ 7 produits insérés.';
GO

-- Insérer des commandes fournisseurs de test
INSERT INTO CommandesFournisseurs (FournisseurID, ProduitID, NomProduit, Quantite, Delai, Statut)
VALUES 
(1, 4, 'Aspirine 100mg', 100, 7, 'En attente'),
(2, 5, 'Vitamine C 1000mg', 50, 10, 'En attente'),
(3, 3, 'Amoxicilline 1g', 75, 5, 'En attente');
PRINT '✓ 3 commandes fournisseurs insérées.';
GO

-- Insérer des ventes de test
INSERT INTO Ventes (ProduitID, Reference, NomProduit, TypeProduit, Quantite, PrixUnitaire, Montant)
VALUES 
(1, 'MED001', 'Paracétamol 500mg', 'Medicaments', 10, 5.50, 55.00),
(2, 'MED002', 'Ibuprofène 400mg', 'Medicaments', 5, 7.20, 36.00),
(5, 'PARA001', 'Vitamine C 1000mg', 'Para', 3, 8.50, 25.50);
PRINT '✓ 3 ventes de test insérées (le stock a été automatiquement mis à jour par le trigger).';
GO

-- ========================================
-- VÉRIFICATIONS FINALES
-- ========================================

PRINT '';
PRINT '========================================';
PRINT 'RÉCAPITULATIF DE LA BASE DE DONNÉES';
PRINT '========================================';

DECLARE @NbTables INT;
DECLARE @NbTriggers INT;
DECLARE @NbVues INT;
DECLARE @NbAdministrateurs INT;
DECLARE @NbPharmaciens INT;
DECLARE @NbFournisseurs INT;
DECLARE @NbProduits INT;
DECLARE @NbCommandes INT;
DECLARE @NbVentes INT;

SELECT @NbTables = COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE';
SELECT @NbTriggers = COUNT(*) FROM sys.triggers WHERE parent_class = 1;
SELECT @NbVues = COUNT(*) FROM INFORMATION_SCHEMA.VIEWS;
SELECT @NbAdministrateurs = COUNT(*) FROM Administrateurs;
SELECT @NbPharmaciens = COUNT(*) FROM Pharmaciens;
SELECT @NbFournisseurs = COUNT(*) FROM Fournisseurs;
SELECT @NbProduits = COUNT(*) FROM Produits;
SELECT @NbCommandes = COUNT(*) FROM CommandesFournisseurs;
SELECT @NbVentes = COUNT(*) FROM Ventes;

PRINT '✓ ' + CAST(@NbTables AS VARCHAR) + ' tables créées';
PRINT '✓ ' + CAST(@NbTriggers AS VARCHAR) + ' triggers créés';
PRINT '✓ ' + CAST(@NbVues AS VARCHAR) + ' vues créées';
PRINT '✓ ' + CAST(@NbAdministrateurs AS VARCHAR) + ' administrateur inséré';
PRINT '✓ ' + CAST(@NbPharmaciens AS VARCHAR) + ' pharmaciens insérés';
PRINT '✓ ' + CAST(@NbFournisseurs AS VARCHAR) + ' fournisseurs insérés';
PRINT '✓ ' + CAST(@NbProduits AS VARCHAR) + ' produits insérés';
PRINT '✓ ' + CAST(@NbCommandes AS VARCHAR) + ' commandes en attente';
PRINT '✓ ' + CAST(@NbVentes AS VARCHAR) + ' ventes enregistrées';
PRINT '';
PRINT '========================================';
PRINT '✅ BASE DE DONNÉES CRÉÉE AVEC SUCCÈS !';
PRINT '========================================';
PRINT '';
PRINT '📝 Identifiants de connexion :';
PRINT '   Admin    : admin / admin123';
PRINT '   Pharmacien 1 : amira.salem / amira123';
PRINT '   Pharmacien 2 : mohamed.jebali / mohamed123';
PRINT '';
GO