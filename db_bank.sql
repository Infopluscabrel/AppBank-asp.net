-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : sam. 19 fév. 2022 à 08:37
-- Version du serveur :  5.7.31
-- Version de PHP : 7.3.21

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `db_bank`
--
CREATE DATABASE IF NOT EXISTS `db_bank` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `db_bank`;

-- --------------------------------------------------------

--
-- Structure de la table `accounts`
--

DROP TABLE IF EXISTS `accounts`;
CREATE TABLE IF NOT EXISTS `accounts` (
  `AccountID` int(11) NOT NULL AUTO_INCREMENT,
  `AccountNumber` longtext CHARACTER SET utf8mb4,
  `AccountBalance` double NOT NULL,
  `AccountCreationDate` datetime(6) NOT NULL,
  `AccountUpdatedDate` datetime(6) NOT NULL,
  `AccountDeletedDate` datetime(6) NOT NULL,
  `AccountState` tinyint(1) NOT NULL,
  `CustomerID` int(11) NOT NULL,
  PRIMARY KEY (`AccountID`),
  KEY `IX_Accounts_CustomerID` (`CustomerID`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `accounts`
--

INSERT INTO `accounts` (`AccountID`, `AccountNumber`, `AccountBalance`, `AccountCreationDate`, `AccountUpdatedDate`, `AccountDeletedDate`, `AccountState`, `CustomerID`) VALUES
(1, '79143636', 10000, '2021-11-19 11:22:54.679705', '2021-11-19 11:22:54.679705', '0001-01-01 00:00:00.000000', 1, 1);

-- --------------------------------------------------------

--
-- Structure de la table `customers`
--

DROP TABLE IF EXISTS `customers`;
CREATE TABLE IF NOT EXISTS `customers` (
  `CustomerID` int(11) NOT NULL AUTO_INCREMENT,
  `CustomerFirstName` longtext CHARACTER SET utf8mb4,
  `CustomerLastName` longtext CHARACTER SET utf8mb4,
  `CustomerEmail` longtext CHARACTER SET utf8mb4,
  `CustomerPhoneNumber` longtext CHARACTER SET utf8mb4,
  `CustomerCreationDate` datetime(6) NOT NULL,
  `CustomerUpdatedDate` datetime(6) NOT NULL,
  `CustomerDeletedDate` datetime(6) NOT NULL,
  `CustomerState` tinyint(1) NOT NULL,
  PRIMARY KEY (`CustomerID`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `customers`
--

INSERT INTO `customers` (`CustomerID`, `CustomerFirstName`, `CustomerLastName`, `CustomerEmail`, `CustomerPhoneNumber`, `CustomerCreationDate`, `CustomerUpdatedDate`, `CustomerDeletedDate`, `CustomerState`) VALUES
(1, 'Ulrich', 'Pouani', 'pouani@gmail.com', '0699123546', '2021-11-16 16:06:28.904338', '2021-11-16 16:24:16.239364', '2022-02-05 10:59:15.941935', 0),
(2, 'Tiako', 'Cedric', 'tiako@gmail.com', '0699123526', '2021-11-16 16:22:36.986603', '2021-11-16 16:22:36.986603', '2021-11-17 11:18:34.082029', 1),
(3, 'cloe', 'elodie', 'elodie@gmail.com', '0699123526', '2021-11-17 11:17:21.862569', '2021-11-17 11:17:21.862569', '2021-11-17 15:17:00.000000', 1),
(4, 'Fomekong', 'Sandrion', 'sandra@gmail.com', '656982152', '2021-11-17 11:29:08.772562', '2022-02-05 10:57:39.933616', '0001-01-01 00:00:00.000000', 1),
(5, 'Payong', 'Mannuel', 'mannuel@gmail.com', '6795647974', '2021-11-17 18:15:17.330033', '2021-11-17 18:15:17.330033', '0001-01-01 00:00:00.000000', 1);

-- --------------------------------------------------------

--
-- Structure de la table `transactions`
--

DROP TABLE IF EXISTS `transactions`;
CREATE TABLE IF NOT EXISTS `transactions` (
  `TransactionID` int(11) NOT NULL AUTO_INCREMENT,
  `TransactionAmount` int(11) NOT NULL,
  `TransactionCreationDate` datetime(6) NOT NULL,
  `TransactionUpdatedDate` datetime(6) NOT NULL,
  `TransactionDeletedDate` datetime(6) NOT NULL,
  `TransactionState` tinyint(1) NOT NULL,
  `AccountID` int(11) NOT NULL,
  PRIMARY KEY (`TransactionID`),
  KEY `IX_Transactions_AccountID` (`AccountID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20211116133606_firstmigration', '3.1.0');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
