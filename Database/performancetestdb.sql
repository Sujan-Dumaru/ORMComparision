-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               5.7.34-log - MySQL Community Server (GPL)
-- Server OS:                    Win64
-- HeidiSQL Version:             11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for performancetest
CREATE DATABASE IF NOT EXISTS `performancetest` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `performancetest`;

-- Dumping structure for table performancetest.contractsupplementary
CREATE TABLE IF NOT EXISTS `contractsupplementary` (
  `Id` varchar(40) NOT NULL,
  `ContractGroupId` varchar(255) NOT NULL,
  `StartDate` datetime NOT NULL,
  `EndDate` datetime NOT NULL,
  `ChargeNum` int(11) NOT NULL,
  `Section` varchar(255) NOT NULL,
  `ItemCode` varchar(255) NOT NULL,
  `IToU` int(11) NOT NULL,
  `Band` int(11) NOT NULL,
  `Price` decimal(19,5) NOT NULL,
  `Units` varchar(255) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- Data exporting was unselected.

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
