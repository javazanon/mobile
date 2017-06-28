CREATE DATABASE  IF NOT EXISTS `pos` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `pos`;
-- MySQL dump 10.13  Distrib 5.6.21, for Win32 (x86)
--
-- Host: localhost    Database: pos
-- ------------------------------------------------------
-- Server version	5.6.21-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tcustomer`
--

DROP TABLE IF EXISTS `tcustomer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tcustomer` (
  `ID` int(11) NOT NULL,
  `COMP_ID` int(11) DEFAULT NULL,
  `GRP_ID` int(11) NOT NULL,
  `NAME` varchar(100) NOT NULL,
  `LONG_NAME` varchar(100) DEFAULT NULL,
  `DESC` varchar(100) DEFAULT NULL,
  `COUNTERY` int(11) DEFAULT NULL,
  `ADDRESS` varchar(100) DEFAULT NULL,
  `OWNER` varchar(45) DEFAULT NULL,
  `PHONE` varchar(45) DEFAULT NULL,
  `STATUS` int(11) DEFAULT '1',
  `CREATE_DATE` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `CUST_GRP_FK_idx` (`GRP_ID`),
  CONSTRAINT `CUST_GRP_FK` FOREIGN KEY (`GRP_ID`) REFERENCES `tcust_grp` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='العملاء';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tcustomer`
--

LOCK TABLES `tcustomer` WRITE;
/*!40000 ALTER TABLE `tcustomer` DISABLE KEYS */;
INSERT INTO `tcustomer` VALUES (200001,1,1,'عملاء جدة','عملاء محافظة جدة','عملاء محافظة جدة',1,NULL,NULL,NULL,1,'2014-11-22 17:33:30'),(200002,1,1,'عملاء مكة','عملاء محافظة مكة','عملاء محافظة مكة',1,NULL,NULL,NULL,1,'2014-11-22 17:34:09'),(200003,1,1,'عملاء المدينة','عملاء المدينة','عملاء المدينة',1,NULL,NULL,NULL,1,'2014-11-22 17:34:34'),(201001,1,2,'الجريسى','الجريسى لخدمات الكمبيوتر والاتصالات','الجريسى لخدمات الكمبيوتر والاتصالات',1,NULL,NULL,NULL,1,'2014-11-22 17:37:45');
/*!40000 ALTER TABLE `tcustomer` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2014-11-23  6:30:01
