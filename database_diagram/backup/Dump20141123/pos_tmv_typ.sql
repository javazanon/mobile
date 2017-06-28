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
-- Table structure for table `tmv_typ`
--

DROP TABLE IF EXISTS `tmv_typ`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tmv_typ` (
  `id` int(11) NOT NULL,
  `cmp_id` int(11) NOT NULL,
  `code` varchar(4) NOT NULL,
  `name` varchar(100) NOT NULL,
  `lng_name` varchar(200) DEFAULT NULL,
  `positive` int(11) NOT NULL DEFAULT '1',
  `status` int(11) DEFAULT '1',
  `create_date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  KEY `company_fk_idx` (`cmp_id`),
  CONSTRAINT `company_fk` FOREIGN KEY (`cmp_id`) REFERENCES `tcompany` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='انواع حركات المخازن';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tmv_typ`
--

LOCK TABLES `tmv_typ` WRITE;
/*!40000 ALTER TABLE `tmv_typ` DISABLE KEYS */;
INSERT INTO `tmv_typ` VALUES (1,1,'100','استلام ','استلام بضاعة من مورد',1,1,'2014-11-18 15:28:35'),(2,1,'101','ارجاع','ارجاع بضاة للمورد',-1,1,'2014-11-18 15:29:21'),(3,1,'200','بيع','بيع للعميل',-1,1,'2014-11-18 15:30:07'),(4,1,'900','رصيد افتتاحى','رصيد افتتاحى اول السنة',1,1,'2014-11-18 15:30:44'),(5,1,'300','اهلاك تالف','اهلاك بضاعة تالفة',-1,1,'2014-11-18 15:31:11');
/*!40000 ALTER TABLE `tmv_typ` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2014-11-23  6:30:00
