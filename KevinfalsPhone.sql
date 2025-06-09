-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Hôte : localhost
-- Généré le : lun. 09 juin 2025 à 20:56
-- Version du serveur : 10.4.32-MariaDB
-- Version de PHP : 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `KevinfalsPhone`
--

-- --------------------------------------------------------

--
-- Structure de la table `Categories`
--

CREATE TABLE `Categories` (
  `Id` int(11) NOT NULL,
  `Nom` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `Categories`
--

INSERT INTO `Categories` (`Id`, `Nom`) VALUES
(1, 'Huawei'),
(2, 'Samsung'),
(3, 'Apple'),
(4, 'GooglePixel');

-- --------------------------------------------------------

--
-- Structure de la table `OrderItems`
--

CREATE TABLE `OrderItems` (
  `Id` int(11) NOT NULL,
  `OrderId` int(11) NOT NULL,
  `ProductId` int(11) NOT NULL,
  `Quantite` int(11) NOT NULL,
  `PrixUnitaire` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `OrderItems`
--

INSERT INTO `OrderItems` (`Id`, `OrderId`, `ProductId`, `Quantite`, `PrixUnitaire`) VALUES
(1, 1, 1, 1, 899.99),
(2, 2, 1, 9, 899.99),
(3, 3, 19, 1, 1299.99);

-- --------------------------------------------------------

--
-- Structure de la table `Orders`
--

CREATE TABLE `Orders` (
  `Id` int(11) NOT NULL,
  `UserId` int(11) NOT NULL,
  `DateCommande` datetime(6) NOT NULL,
  `AdresseLivraison` varchar(500) NOT NULL,
  `PrixTotal` decimal(10,2) NOT NULL,
  `NombreProduits` int(11) NOT NULL,
  `NumeroFacture` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `Orders`
--

INSERT INTO `Orders` (`Id`, `UserId`, `DateCommande`, `AdresseLivraison`, `PrixTotal`, `NombreProduits`, `NumeroFacture`) VALUES
(1, 2, '2025-06-07 21:38:21.611390', 'Antananarivo', 899.99, 1, 'FAC-20250607-16128672'),
(2, 2, '2025-06-07 21:38:51.042931', 'Antsirabe', 8099.91, 9, 'FAC-20250607-10429620'),
(3, 2, '2025-06-07 22:20:01.265952', 'Analakely', 1299.99, 1, 'FAC-20250607-12674433');

-- --------------------------------------------------------

--
-- Structure de la table `Products`
--

CREATE TABLE `Products` (
  `Id` int(11) NOT NULL,
  `Nom` varchar(200) NOT NULL,
  `Description` varchar(1000) NOT NULL,
  `Prix` decimal(10,2) NOT NULL,
  `Stock` int(11) NOT NULL,
  `Image` varchar(500) DEFAULT NULL,
  `CategoryId` int(11) NOT NULL,
  `DateCreation` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `Products`
--

INSERT INTO `Products` (`Id`, `Nom`, `Description`, `Prix`, `Stock`, `Image`, `CategoryId`, `DateCreation`) VALUES
(1, 'Huawei P50 Pro', 'Smartphone haut de gamme', 899.99, 0, 'h1.jpg', 1, '2025-06-07 22:17:33.000000'),
(2, 'Huawei Mate 40 Pro', 'Smartphone puissant et élégant', 799.99, 8, 'h2.jpg', 1, '2025-06-07 22:17:33.000000'),
(3, 'Huawei Nova 11', 'Excellent rapport qualité-prix', 499.99, 12, 'h3.jpg', 1, '2025-06-07 22:17:33.000000'),
(4, 'Huawei P40 Lite', 'Smartphone milieu de gamme', 299.99, 20, 'h4.jpg', 1, '2025-06-07 22:17:33.000000'),
(5, 'Huawei Y9a', 'Écran FullView et bonne autonomie', 259.99, 15, 'h5.jpg', 1, '2025-06-07 22:17:33.000000'),
(6, 'Huawei P60 Pro', 'Nouveauté avec caméra avancée', 999.99, 6, 'h6.jpg', 1, '2025-06-07 22:17:33.000000'),
(7, 'Huawei Nova 10 SE', 'Design moderne et performant', 379.99, 9, 'h7.jpg', 1, '2025-06-07 22:17:33.000000'),
(8, 'Huawei Mate 50', 'Flagship innovant', 1099.99, 5, 'h8.jpg', 1, '2025-06-07 22:17:33.000000'),
(9, 'Samsung Galaxy S24 Ultra', 'Smartphone haut de gamme', 1399.99, 10, 's1.jpg', 2, '2025-06-07 22:17:33.000000'),
(10, 'Samsung Galaxy Z Fold5', 'Écran pliable', 1799.99, 3, 's2.webp', 2, '2025-06-07 22:17:33.000000'),
(11, 'Samsung Galaxy S23', 'Excellent en photo', 999.99, 7, 's3.webp', 2, '2025-06-07 22:17:33.000000'),
(12, 'Samsung Galaxy A54', 'Milieu de gamme puissant', 449.99, 14, 's4.jpg', 2, '2025-06-07 22:17:33.000000'),
(13, 'Samsung Galaxy M14', 'Bonne autonomie', 199.99, 18, 's5.jpg', 2, '2025-06-07 22:17:33.000000'),
(14, 'Samsung Galaxy Z Flip5', 'Design pliable compact', 1199.99, 6, 's6.jpg', 2, '2025-06-07 22:17:33.000000'),
(15, 'Samsung Galaxy S22 Ultra', 'Stylet intégré', 1249.99, 4, 's7.jpg', 2, '2025-06-07 22:17:33.000000'),
(16, 'Samsung Galaxy Note 20', 'Productivité et performance', 949.99, 5, 's8.webp', 2, '2025-06-07 22:17:33.000000'),
(17, 'iPhone 15 Pro Max', 'Dernier modèle haut de gamme', 1599.99, 10, 'a1.webp', 3, '2025-06-07 22:17:33.000000'),
(18, 'iPhone 15', 'Modèle standard 2023', 1099.99, 8, 'a2.jpeg', 3, '2025-06-07 22:17:33.000000'),
(19, 'iPhone 14 Pro', 'Technologie avancée', 1299.99, 5, 'a3.jpg', 3, '2025-06-07 22:17:33.000000'),
(20, 'iPhone 13', 'Performance et autonomie', 899.99, 10, 'a4.jpeg', 3, '2025-06-07 22:17:33.000000'),
(21, 'iPhone SE (2022)', 'Compact et rapide', 479.99, 12, 'a5.webp', 3, '2025-06-07 22:17:33.000000'),
(22, 'iPhone 12', 'Bon rapport qualité/prix', 749.99, 9, 'a6.webp', 3, '2025-06-07 22:17:33.000000'),
(23, 'iPhone 11', 'Encore performant', 599.99, 11, 'a7.jpg', 3, '2025-06-07 22:17:33.000000'),
(24, 'iPhone XR', 'Coloré et accessible', 399.99, 7, 'a8.webp', 3, '2025-06-07 22:17:33.000000'),
(25, 'Google Pixel 8 Pro', 'IA intégrée et caméra top', 1099.99, 7, 'g1.png', 4, '2025-06-07 22:17:33.000000'),
(27, 'Google Pixel 7 Pro', 'Caméra exceptionnelle', 899.99, 6, 'g3.webp', 4, '2025-06-07 22:17:33.000000'),
(28, 'Google Pixel 7a', 'Bon prix et performances', 499.99, 12, 'g4.webp', 4, '2025-06-07 22:17:33.000000'),
(29, 'Google Pixel 6 Pro', 'Excellent appareil photo', 799.99, 8, 'g5.webp', 4, '2025-06-07 22:17:33.000000'),
(30, 'Google Pixel 6a', 'Petit prix, grande valeur', 399.99, 13, 'g6.png', 4, '2025-06-07 22:17:33.000000'),
(31, 'Google Pixel 5', 'Bonne autonomie', 349.99, 10, 'g7.jpg', 4, '2025-06-07 22:17:33.000000'),
(32, 'Google Pixel 4a', 'Compact et fluide', 299.99, 14, 'g8.jpg', 4, '2025-06-07 22:17:33.000000');

-- --------------------------------------------------------

--
-- Structure de la table `Users`
--

CREATE TABLE `Users` (
  `Id` int(11) NOT NULL,
  `Nom` varchar(50) NOT NULL,
  `Prenom` varchar(50) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `DateNaissance` datetime(6) NOT NULL,
  `Ville` varchar(100) NOT NULL,
  `Pays` varchar(100) NOT NULL,
  `MotDePasse` varchar(255) NOT NULL,
  `Role` varchar(10) NOT NULL,
  `DateCreation` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `Users`
--

INSERT INTO `Users` (`Id`, `Nom`, `Prenom`, `Email`, `DateNaissance`, `Ville`, `Pays`, `MotDePasse`, `Role`, `DateCreation`) VALUES
(1, 'Admin', 'Admin', 'admin@gmail.com', '1990-01-01 00:00:00.000000', 'Antananarivo', 'Madagasikara', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'Admin', '2025-06-07 22:17:33.000000'),
(2, 'FALISOA', 'Kevin', 'kevinfal383@gmail.com', '2006-05-23 00:00:00.000000', 'Antananarivo', 'Madagasikara', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'User', '2025-06-07 21:37:45.680552'),
(3, 'Son', 'Goku', 'songoku@gmail.com', '0309-03-04 00:00:00.000000', 'Pluton', 'Zeparse', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'User', '2025-06-07 22:43:02.960414');

-- --------------------------------------------------------

--
-- Structure de la table `__EFMigrationsHistory`
--

CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `__EFMigrationsHistory`
--

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`) VALUES
('20250607142727_premiere migration', '8.0.11'),
('20250607192231_deuxieme migration', '8.0.11'),
('20250607193543_troisieme migration', '8.0.11'),
('20250607201734_mettre les images', '8.0.11');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `Categories`
--
ALTER TABLE `Categories`
  ADD PRIMARY KEY (`Id`);

--
-- Index pour la table `OrderItems`
--
ALTER TABLE `OrderItems`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_OrderItems_OrderId` (`OrderId`),
  ADD KEY `IX_OrderItems_ProductId` (`ProductId`);

--
-- Index pour la table `Orders`
--
ALTER TABLE `Orders`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Orders_UserId` (`UserId`);

--
-- Index pour la table `Products`
--
ALTER TABLE `Products`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Products_CategoryId` (`CategoryId`);

--
-- Index pour la table `Users`
--
ALTER TABLE `Users`
  ADD PRIMARY KEY (`Id`);

--
-- Index pour la table `__EFMigrationsHistory`
--
ALTER TABLE `__EFMigrationsHistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `Categories`
--
ALTER TABLE `Categories`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT pour la table `OrderItems`
--
ALTER TABLE `OrderItems`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT pour la table `Orders`
--
ALTER TABLE `Orders`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT pour la table `Products`
--
ALTER TABLE `Products`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;

--
-- AUTO_INCREMENT pour la table `Users`
--
ALTER TABLE `Users`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `OrderItems`
--
ALTER TABLE `OrderItems`
  ADD CONSTRAINT `FK_OrderItems_Orders_OrderId` FOREIGN KEY (`OrderId`) REFERENCES `Orders` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_OrderItems_Products_ProductId` FOREIGN KEY (`ProductId`) REFERENCES `Products` (`Id`) ON DELETE CASCADE;

--
-- Contraintes pour la table `Orders`
--
ALTER TABLE `Orders`
  ADD CONSTRAINT `FK_Orders_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE;

--
-- Contraintes pour la table `Products`
--
ALTER TABLE `Products`
  ADD CONSTRAINT `FK_Products_Categories_CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `Categories` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
