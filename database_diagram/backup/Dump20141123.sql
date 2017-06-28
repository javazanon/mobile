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
-- Table structure for table `taction`
--

DROP TABLE IF EXISTS `taction`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `taction` (
  `ID` int(11) NOT NULL,
  `ACTION_NAME` varchar(45) DEFAULT NULL,
  `DESCRIPTION` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='الحركات المسموح بها على النظام';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `taction`
--

LOCK TABLES `taction` WRITE;
/*!40000 ALTER TABLE `taction` DISABLE KEYS */;
INSERT INTO `taction` VALUES (1,'CREATE',NULL),(2,'SELECT',NULL),(3,'DELETE',NULL);
/*!40000 ALTER TABLE `taction` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbill_detail`
--

DROP TABLE IF EXISTS `tbill_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbill_detail` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `BILL_ID` int(11) NOT NULL,
  `SOH_ID` int(11) NOT NULL,
  `AMOUNT` float NOT NULL,
  `DESC` varchar(150) DEFAULT NULL,
  `CURRENCY` int(11) DEFAULT NULL,
  `CREATE_DATE` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `BILL_FK_idx` (`BILL_ID`),
  KEY `SOH_ID_idx` (`SOH_ID`),
  CONSTRAINT `BILL_FK` FOREIGN KEY (`BILL_ID`) REFERENCES `tbill_hedr` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `SOH_ID` FOREIGN KEY (`SOH_ID`) REFERENCES `tsoh` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='فاتورة تفاصيل';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbill_detail`
--

LOCK TABLES `tbill_detail` WRITE;
/*!40000 ALTER TABLE `tbill_detail` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbill_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbill_hedr`
--

DROP TABLE IF EXISTS `tbill_hedr`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbill_hedr` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `COMP_ID` int(11) DEFAULT NULL,
  `PAY_MTHOD` int(11) DEFAULT NULL,
  `FISC_PRID` int(11) DEFAULT NULL,
  `CREATE_BY` int(11) DEFAULT NULL,
  `HEADER_TXT` varchar(150) DEFAULT NULL,
  `CREATE_DATE` timestamp NULL DEFAULT NULL,
  `LAST_UPDATE` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `FIS_PRID_FK_idx` (`FISC_PRID`),
  CONSTRAINT `FIS_PRID_FK` FOREIGN KEY (`FISC_PRID`) REFERENCES `tfiscal_prid` (`period_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='فاتورة المقدمة';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbill_hedr`
--

LOCK TABLES `tbill_hedr` WRITE;
/*!40000 ALTER TABLE `tbill_hedr` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbill_hedr` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tcompany`
--

DROP TABLE IF EXISTS `tcompany`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tcompany` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cmp_code` varchar(6) NOT NULL,
  `cmp_nme` varchar(150) NOT NULL,
  `cmp_lng_nme` varchar(500) DEFAULT NULL,
  `address` varchar(500) DEFAULT NULL,
  `create_date` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='جدول الشركات';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tcompany`
--

LOCK TABLES `tcompany` WRITE;
/*!40000 ALTER TABLE `tcompany` DISABLE KEYS */;
INSERT INTO `tcompany` VALUES (1,'kaau','محمد','زنون','شرقية','2014-11-11 18:21:00');
/*!40000 ALTER TABLE `tcompany` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tcountery`
--

DROP TABLE IF EXISTS `tcountery`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tcountery` (
  `ID` int(11) NOT NULL,
  `NAME` varchar(45) NOT NULL,
  `LONG_NAME` varchar(45) DEFAULT NULL,
  `ISO_CODE` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `NAME_UNIQUE` (`NAME`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='الدول';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tcountery`
--

LOCK TABLES `tcountery` WRITE;
/*!40000 ALTER TABLE `tcountery` DISABLE KEYS */;
INSERT INTO `tcountery` VALUES (1,'السعودية','المملكة العربية ','KSA'),(2,'امريكا','االولايات المتحدة الامريكية','USA'),(3,'الصين','جمهورية الصين الشعبية','CH'),(4,'اوروبا','اوروبا','EUROPE');
/*!40000 ALTER TABLE `tcountery` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tcurrency`
--

DROP TABLE IF EXISTS `tcurrency`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tcurrency` (
  `ID` int(11) NOT NULL,
  `CODE` varchar(5) NOT NULL,
  `NAME` varchar(45) NOT NULL,
  `COUNTERY` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `CODE_UNIQUE` (`CODE`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  KEY `COUNTERY_FK_idx` (`COUNTERY`),
  CONSTRAINT `COUNTERY_FK` FOREIGN KEY (`COUNTERY`) REFERENCES `tcountery` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='العملات';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tcurrency`
--

LOCK TABLES `tcurrency` WRITE;
/*!40000 ALTER TABLE `tcurrency` DISABLE KEYS */;
INSERT INTO `tcurrency` VALUES (1,'SAR','ريال سعودي',1),(2,'USD','دولار امريكى',2),(3,'EUR','يورو',4);
/*!40000 ALTER TABLE `tcurrency` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tcust_grp`
--

DROP TABLE IF EXISTS `tcust_grp`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tcust_grp` (
  `ID` int(11) NOT NULL,
  `COMP_ID` int(11) DEFAULT NULL,
  `RNG_ID` int(11) DEFAULT NULL,
  `NAME` varchar(100) DEFAULT NULL,
  `LONG_NAME` varchar(150) DEFAULT NULL,
  `DESCR` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='تصنيفات العملاء';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tcust_grp`
--

LOCK TABLES `tcust_grp` WRITE;
/*!40000 ALTER TABLE `tcust_grp` DISABLE KEYS */;
INSERT INTO `tcust_grp` VALUES (1,1,4,'عملاء مرة  واحده','عملاء مرة واحده فقط','عملاء مرة واحده فقط'),(2,1,5,'عملاء حكومين','عملاء جهات حكومية','عملاء جهات حكومية');
/*!40000 ALTER TABLE `tcust_grp` ENABLE KEYS */;
UNLOCK TABLES;

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

--
-- Table structure for table `tdlvr_mthod`
--

DROP TABLE IF EXISTS `tdlvr_mthod`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tdlvr_mthod` (
  `ID` int(11) NOT NULL,
  `NAME` varchar(45) DEFAULT NULL,
  `LONG_NAME` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='طريقة الاستلام';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tdlvr_mthod`
--

LOCK TABLES `tdlvr_mthod` WRITE;
/*!40000 ALTER TABLE `tdlvr_mthod` DISABLE KEYS */;
INSERT INTO `tdlvr_mthod` VALUES (1,'يدوى','تسليم يدوى فى المحلى'),(2,'شحن','شحن برى'),(3,'دفعات','تسليم البضاعه دفعات');
/*!40000 ALTER TABLE `tdlvr_mthod` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tdod`
--

DROP TABLE IF EXISTS `tdod`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tdod` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `SOH_ID` int(11) DEFAULT NULL,
  `LINE_NO` int(11) DEFAULT NULL,
  `MATERIAL` int(11) DEFAULT NULL,
  `QTY` float DEFAULT NULL,
  `DESCR` varchar(100) DEFAULT NULL,
  `DISCOUNT` float DEFAULT NULL,
  `CREATE_DATE` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `MATERILA_FK_idx` (`MATERIAL`),
  CONSTRAINT `MATERILA_FK` FOREIGN KEY (`MATERIAL`) REFERENCES `tmaterial` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='المبيعات تفاصيل';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tdod`
--

LOCK TABLES `tdod` WRITE;
/*!40000 ALTER TABLE `tdod` DISABLE KEYS */;
/*!40000 ALTER TABLE `tdod` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tfiscal_prid`
--

DROP TABLE IF EXISTS `tfiscal_prid`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tfiscal_prid` (
  `period_id` int(11) NOT NULL AUTO_INCREMENT,
  `code` varchar(3) NOT NULL,
  `name` varchar(100) NOT NULL,
  `fyear` int(11) NOT NULL,
  `long_nme` varchar(250) DEFAULT NULL,
  `start_from` date NOT NULL,
  `end_to` date NOT NULL,
  `create_date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `last_update` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`period_id`),
  KEY `fiscal_year_fk1` (`fyear`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COMMENT='الفترات الماليه';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tfiscal_prid`
--

LOCK TABLES `tfiscal_prid` WRITE;
/*!40000 ALTER TABLE `tfiscal_prid` DISABLE KEYS */;
INSERT INTO `tfiscal_prid` VALUES (1,'1','يناير',1,'الفترة الاولى','2002-01-01','2002-01-30','2014-11-18 16:11:35','2014-11-18 16:11:35'),(2,'2','فبراير',1,'الفترة الثانية','2002-02-01','2002-02-28','2014-11-18 16:25:41','2014-11-18 16:25:41');
/*!40000 ALTER TABLE `tfiscal_prid` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tfiscal_yr`
--

DROP TABLE IF EXISTS `tfiscal_yr`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tfiscal_yr` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cmp_id` int(11) NOT NULL,
  `year` int(11) NOT NULL,
  `name` varchar(120) NOT NULL,
  `status` int(11) NOT NULL DEFAULT '1',
  `create_date` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `last_update` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COMMENT='السنة المالية';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tfiscal_yr`
--

LOCK TABLES `tfiscal_yr` WRITE;
/*!40000 ALTER TABLE `tfiscal_yr` DISABLE KEYS */;
INSERT INTO `tfiscal_yr` VALUES (2,1,2001,'aa',1,'2014-11-11 18:31:44','2014-11-11 18:31:44');
/*!40000 ALTER TABLE `tfiscal_yr` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tinventory`
--

DROP TABLE IF EXISTS `tinventory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tinventory` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cmp_id` int(11) NOT NULL,
  `strg_name` varchar(100) NOT NULL,
  `long_nme` varchar(200) DEFAULT NULL,
  `desc` varchar(250) DEFAULT NULL,
  `address` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `company_code_idx` (`cmp_id`),
  CONSTRAINT `company_code` FOREIGN KEY (`cmp_id`) REFERENCES `tcompany` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COMMENT='المستودعات';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tinventory`
--

LOCK TABLES `tinventory` WRITE;
/*!40000 ALTER TABLE `tinventory` DISABLE KEYS */;
INSERT INTO `tinventory` VALUES (1,1,'مستودع جدة','المستودع الرئيسى',NULL,NULL),(2,1,'مستودع السليمانية','مستودع فرعى',NULL,' ');
/*!40000 ALTER TABLE `tinventory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tmater_prce`
--

DROP TABLE IF EXISTS `tmater_prce`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tmater_prce` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `MATER_ID` int(11) NOT NULL,
  `PRICE` float NOT NULL,
  `CURRENCY` int(11) NOT NULL,
  `FROMDATE` date NOT NULL,
  `TODATE` date NOT NULL,
  `CREATE_DATE` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `CURRENCY_FK_idx` (`CURRENCY`),
  CONSTRAINT `CURRENCY_FK` FOREIGN KEY (`CURRENCY`) REFERENCES `tcurrency` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COMMENT='اسعار الاصناف';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tmater_prce`
--

LOCK TABLES `tmater_prce` WRITE;
/*!40000 ALTER TABLE `tmater_prce` DISABLE KEYS */;
INSERT INTO `tmater_prce` VALUES (1,1,2600,1,'2014-01-18','2099-01-18','2014-11-22 19:19:24'),(3,2,500,1,'2014-01-18','2099-01-18','2014-11-22 19:21:30'),(4,3,120,1,'2014-01-18','2099-01-18','2014-11-22 19:21:47');
/*!40000 ALTER TABLE `tmater_prce` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tmaterial`
--

DROP TABLE IF EXISTS `tmaterial`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tmaterial` (
  `ID` int(11) NOT NULL,
  `COMP_ID` int(11) NOT NULL,
  `NAME` varchar(100) NOT NULL,
  `LONG_NAME` varchar(200) DEFAULT NULL,
  `GRP_ID` int(11) NOT NULL,
  `MEASURE` int(11) NOT NULL,
  `MRP_LOW` int(11) DEFAULT NULL,
  `MRP_HIGH` int(11) DEFAULT NULL,
  `CREATE_DATE` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `active` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  KEY `MEASURE_FK_idx` (`MEASURE`),
  KEY `GRP_FK_idx` (`GRP_ID`),
  KEY `compny_fk_idx` (`COMP_ID`),
  CONSTRAINT `GRP_FK` FOREIGN KEY (`GRP_ID`) REFERENCES `tmatr_grp` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `MEASURE_FK` FOREIGN KEY (`MEASURE`) REFERENCES `tmeasure` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `compny_fk` FOREIGN KEY (`COMP_ID`) REFERENCES `tcompany` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='جدول الاصناف';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tmaterial`
--

LOCK TABLES `tmaterial` WRITE;
/*!40000 ALTER TABLE `tmaterial` DISABLE KEYS */;
INSERT INTO `tmaterial` VALUES (1,1,'مولد كهربائى عالى التشغيل','مولد كهربائى عالى التشغيل',1,1,100,500,'2014-11-18 13:59:39',1),(2,1,'lمروحة قطر 7 بوصه','lمروحة قطر 7 بوصه',1,1,100,500,'2014-11-18 14:44:51',1),(3,1,'مفتاح تنظيم','مفتاح تنظيم',2,1,100,500,'2014-11-18 14:50:43',1);
/*!40000 ALTER TABLE `tmaterial` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tmaterial_card`
--

DROP TABLE IF EXISTS `tmaterial_card`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tmaterial_card` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `FISCAL_YEAR` int(11) NOT NULL,
  `COMP_ID` int(11) NOT NULL,
  `inventory_id` int(11) NOT NULL,
  `MATERIAL_ID` int(11) NOT NULL,
  `INITIAL_QNTY` float NOT NULL,
  `CURRENT_QNTY` float NOT NULL,
  `CREATE_DATE` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `lastupdate` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `FISCAL_FK_idx` (`FISCAL_YEAR`),
  KEY `MATERIAL_FK_idx` (`MATERIAL_ID`),
  CONSTRAINT `FISCAL_FK` FOREIGN KEY (`FISCAL_YEAR`) REFERENCES `tfiscal_yr` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `MATERIAL_FK` FOREIGN KEY (`MATERIAL_ID`) REFERENCES `tmaterial` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COMMENT='كارت الاصناف';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tmaterial_card`
--

LOCK TABLES `tmaterial_card` WRITE;
/*!40000 ALTER TABLE `tmaterial_card` DISABLE KEYS */;
INSERT INTO `tmaterial_card` VALUES (1,2,1,1,1,0,4,'2014-11-18 15:30:07','2014-11-18 17:45:11'),(2,2,1,1,2,0,90,'2014-11-18 16:57:12','2014-11-18 17:45:11');
/*!40000 ALTER TABLE `tmaterial_card` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tmatr_grp`
--

DROP TABLE IF EXISTS `tmatr_grp`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tmatr_grp` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CMP_ID` int(11) DEFAULT NULL,
  `NAME` varchar(100) DEFAULT NULL,
  `LONG_NAME` varchar(250) DEFAULT NULL,
  `RANGE_ID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `COMPANY_FK_idx` (`CMP_ID`),
  KEY `RANGE_FK_idx` (`RANGE_ID`),
  CONSTRAINT `RANGE_FK` FOREIGN KEY (`RANGE_ID`) REFERENCES `tnumb_rng` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='مجموعات الاصناف';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tmatr_grp`
--

LOCK TABLES `tmatr_grp` WRITE;
/*!40000 ALTER TABLE `tmatr_grp` DISABLE KEYS */;
INSERT INTO `tmatr_grp` VALUES (1,1,'المحركات','محركات توربينية',1),(2,1,'المعدات','معدات',1),(3,1,'المفاتيح','المفاتيح',1);
/*!40000 ALTER TABLE `tmatr_grp` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tmatr_mov`
--

DROP TABLE IF EXISTS `tmatr_mov`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tmatr_mov` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `comp_id` int(11) NOT NULL,
  `fisc_priod` int(11) NOT NULL,
  `mov_typ` int(11) NOT NULL,
  `material` int(11) NOT NULL,
  `qnty` float NOT NULL,
  `descr` varchar(200) DEFAULT NULL,
  `create_date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `createdBy` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fisc_fk_idx` (`fisc_priod`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='حركات الاصناف';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tmatr_mov`
--

LOCK TABLES `tmatr_mov` WRITE;
/*!40000 ALTER TABLE `tmatr_mov` DISABLE KEYS */;
INSERT INTO `tmatr_mov` VALUES (1,1,1,4,1,3,'شراء من الشركة  الصينية','2014-11-18 16:53:25',1);
/*!40000 ALTER TABLE `tmatr_mov` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tmeasure`
--

DROP TABLE IF EXISTS `tmeasure`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tmeasure` (
  `id` int(11) NOT NULL,
  `name` varchar(5) DEFAULT NULL,
  `long_nme` varchar(150) DEFAULT NULL,
  `iso_code` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='وحدات القياس';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tmeasure`
--

LOCK TABLES `tmeasure` WRITE;
/*!40000 ALTER TABLE `tmeasure` DISABLE KEYS */;
INSERT INTO `tmeasure` VALUES (1,'EA','عدد الوحدات','EA'),(2,'KG','الكيلو جرام','KG'),(3,'ME','بالمتر','ME'),(4,'HR','الساعه','HOUR');
/*!40000 ALTER TABLE `tmeasure` ENABLE KEYS */;
UNLOCK TABLES;

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

--
-- Table structure for table `tnumb_rng`
--

DROP TABLE IF EXISTS `tnumb_rng`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tnumb_rng` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CMP_ID` int(11) NOT NULL,
  `rng_id` varchar(5) NOT NULL,
  `from` int(11) NOT NULL,
  `to` int(11) NOT NULL,
  `current` int(11) NOT NULL,
  `obj_id` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `objects_fk_idx` (`obj_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COMMENT='مجموعة الاصناف';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tnumb_rng`
--

LOCK TABLES `tnumb_rng` WRITE;
/*!40000 ALTER TABLE `tnumb_rng` DISABLE KEYS */;
INSERT INTO `tnumb_rng` VALUES (1,1,'00001',1,100000,1,1),(3,1,'00002',100001,101000,100001,5),(4,1,'00003',200001,200999,200003,4),(5,1,'00004',201000,202999,201001,4);
/*!40000 ALTER TABLE `tnumb_rng` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tobjects`
--

DROP TABLE IF EXISTS `tobjects`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tobjects` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `objectName` varchar(45) DEFAULT NULL,
  `LongName` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tobjects`
--

LOCK TABLES `tobjects` WRITE;
/*!40000 ALTER TABLE `tobjects` DISABLE KEYS */;
INSERT INTO `tobjects` VALUES (1,'MATERIAL','الاصناف'),(2,'BILL','الفاتورة'),(3,'USER','مستخدم'),(4,'CUSTOMER','العملاء'),(5,'VENDOR','الموردين'),(6,'ROLE','الادوار'),(7,'SALEORDER','طلب بيع'),(8,'NUMBRANGE','الارقام'),(9,'MATERIALGROUP','تصنيف الاصناف'),(10,'CUSTOMERGROUP','تصنيف العملاء'),(11,'PAYMETHOD','طريقة الدفع'),(12,'DELIVERYMETHOD','طريق الشحن'),(13,'FISCALPERIOD','الفترة الماليه'),(14,'FISCALYEAR','السنة الماليه'),(15,'VENDORGROUP','تصنيف العملاء');
/*!40000 ALTER TABLE `tobjects` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tpay_mthod`
--

DROP TABLE IF EXISTS `tpay_mthod`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tpay_mthod` (
  `ID` int(11) NOT NULL,
  `NAME` varchar(45) DEFAULT NULL,
  `LONG_NAME` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='طريقة الدفع';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tpay_mthod`
--

LOCK TABLES `tpay_mthod` WRITE;
/*!40000 ALTER TABLE `tpay_mthod` DISABLE KEYS */;
/*!40000 ALTER TABLE `tpay_mthod` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tpaymenet`
--

DROP TABLE IF EXISTS `tpaymenet`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tpaymenet` (
  `ID` int(11) NOT NULL,
  `COMP_ID` int(11) DEFAULT NULL,
  `FISCAL_YEAR` int(11) DEFAULT NULL,
  `FISC_PRID` int(11) DEFAULT NULL,
  `TBILL_ID` int(11) DEFAULT NULL,
  `CHEQUE_NO` varchar(45) DEFAULT NULL,
  `ONLINE_CODE` varchar(45) DEFAULT NULL,
  `CURRENCY` int(11) DEFAULT NULL,
  `PAY_MTHOD` int(11) DEFAULT NULL,
  `HEADER_TXT` varchar(200) DEFAULT NULL,
  `REFERNCE` varchar(100) DEFAULT NULL,
  `CREATED_BY` int(11) DEFAULT NULL,
  `CREATE_DATE` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='دفع الفواتير';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tpaymenet`
--

LOCK TABLES `tpaymenet` WRITE;
/*!40000 ALTER TABLE `tpaymenet` DISABLE KEYS */;
/*!40000 ALTER TABLE `tpaymenet` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trole_action`
--

DROP TABLE IF EXISTS `trole_action`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `trole_action` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ROLE_ID` int(11) NOT NULL,
  `OBJECT_ID` int(11) NOT NULL,
  `ACTION_ID` int(11) NOT NULL,
  `CREATE_DATE` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `OBJECT_FK_idx` (`OBJECT_ID`),
  KEY `ROLE_FK_idx` (`ROLE_ID`),
  KEY `ACTION_FK_idx` (`ACTION_ID`),
  CONSTRAINT `ACTION_FK` FOREIGN KEY (`ACTION_ID`) REFERENCES `taction` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `OBJECT_FK` FOREIGN KEY (`OBJECT_ID`) REFERENCES `tobjects` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `ROLE_FK` FOREIGN KEY (`ROLE_ID`) REFERENCES `troles` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trole_action`
--

LOCK TABLES `trole_action` WRITE;
/*!40000 ALTER TABLE `trole_action` DISABLE KEYS */;
INSERT INTO `trole_action` VALUES (13,1,1,1,'2014-11-17 16:37:40'),(14,1,1,2,'2014-11-17 16:37:40'),(15,1,1,3,'2014-11-17 16:37:40');
/*!40000 ALTER TABLE `trole_action` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trole_usr`
--

DROP TABLE IF EXISTS `trole_usr`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `trole_usr` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ROLE_ID` int(11) NOT NULL,
  `USER_ID` int(11) NOT NULL,
  `CREATE_DATE` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `ROLES_FK_idx` (`ROLE_ID`),
  KEY `USERS_FK_idx` (`USER_ID`),
  CONSTRAINT `ROLES_FK` FOREIGN KEY (`ROLE_ID`) REFERENCES `troles` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `USERS_FK` FOREIGN KEY (`USER_ID`) REFERENCES `tusers` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='صلاحيات الموظفين';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trole_usr`
--

LOCK TABLES `trole_usr` WRITE;
/*!40000 ALTER TABLE `trole_usr` DISABLE KEYS */;
INSERT INTO `trole_usr` VALUES (1,1,1,'2014-11-17 16:14:57');
/*!40000 ALTER TABLE `trole_usr` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `troles`
--

DROP TABLE IF EXISTS `troles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `troles` (
  `ID` int(11) NOT NULL,
  `ROLE_NAME` varchar(45) NOT NULL,
  `DESCR` varchar(45) DEFAULT NULL,
  `COMP_ID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='الادوار والمجموعات للصلاحيات';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `troles`
--

LOCK TABLES `troles` WRITE;
/*!40000 ALTER TABLE `troles` DISABLE KEYS */;
INSERT INTO `troles` VALUES (1,'MM_MANAGER','انشاء المستودعات والاصناف والاسعار والكميات',1);
/*!40000 ALTER TABLE `troles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tsoh`
--

DROP TABLE IF EXISTS `tsoh`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tsoh` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `COMP_ID` int(11) NOT NULL,
  `CUSTOMER` int(11) NOT NULL,
  `FISCAL` int(11) NOT NULL,
  `F_PERIOD` int(11) NOT NULL,
  `HEADER_TXT` varchar(250) DEFAULT NULL,
  `REFERNCE` varchar(200) DEFAULT NULL,
  `CREATED_BY` int(11) DEFAULT NULL,
  `DLVR_MTHD` int(11) DEFAULT NULL,
  `CREATE_DATE` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `PERIOD_FK_idx` (`F_PERIOD`),
  KEY `DELIVER_MTHOD_FK_idx` (`DLVR_MTHD`),
  CONSTRAINT `DELIVER_MTHOD_FK` FOREIGN KEY (`DLVR_MTHD`) REFERENCES `tdlvr_mthod` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `PERIOD_FK` FOREIGN KEY (`F_PERIOD`) REFERENCES `tfiscal_prid` (`period_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='المبيعات مقدمة';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tsoh`
--

LOCK TABLES `tsoh` WRITE;
/*!40000 ALTER TABLE `tsoh` DISABLE KEYS */;
/*!40000 ALTER TABLE `tsoh` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tusers`
--

DROP TABLE IF EXISTS `tusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tusers` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `USER_ID` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  `NAME` varchar(100) DEFAULT NULL,
  `FULL_NAME` varchar(200) DEFAULT NULL,
  `ID_NUMBER` varchar(45) DEFAULT NULL,
  `PHONE` varchar(45) DEFAULT NULL,
  `ADDRESS` varchar(45) DEFAULT NULL,
  `ACTIVE` int(11) DEFAULT '1',
  `CREATE_DATE` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='الموظفين';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tusers`
--

LOCK TABLES `tusers` WRITE;
/*!40000 ALTER TABLE `tusers` DISABLE KEYS */;
INSERT INTO `tusers` VALUES (1,'07777870','123456','mohamed zanon','mohamed mahmoud ali zanon','2275865109','0541104406','jeddah',1,'2014-11-15 17:22:10');
/*!40000 ALTER TABLE `tusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tvendor`
--

DROP TABLE IF EXISTS `tvendor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tvendor` (
  `ID` int(11) NOT NULL DEFAULT '0',
  `COMP_ID` int(11) NOT NULL,
  `GRP_ID` int(11) NOT NULL,
  `NAME` varchar(150) NOT NULL,
  `LONG_NAME` varchar(200) DEFAULT NULL,
  `OWNER` varchar(150) DEFAULT NULL,
  `COMMECIAL_ID` varchar(20) DEFAULT NULL,
  `ADDRESS` varchar(200) DEFAULT NULL,
  `STATUS` int(11) DEFAULT '1',
  `CREATE_DATE` timestamp NULL DEFAULT NULL,
  `tvendorcol` varchar(45) DEFAULT 'CURRENT_TIMESTAMP',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='الموردين';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tvendor`
--

LOCK TABLES `tvendor` WRITE;
/*!40000 ALTER TABLE `tvendor` DISABLE KEYS */;
/*!40000 ALTER TABLE `tvendor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tvendor_grp`
--

DROP TABLE IF EXISTS `tvendor_grp`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tvendor_grp` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `NAME` varchar(100) NOT NULL,
  `LNG_NAME` varchar(250) DEFAULT NULL,
  `RANG_ID` int(11) NOT NULL,
  `CREATE_DATE` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  KEY `RANG_FK_idx` (`RANG_ID`),
  CONSTRAINT `RANG_FK` FOREIGN KEY (`RANG_ID`) REFERENCES `tnumb_rng` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tvendor_grp`
--

LOCK TABLES `tvendor_grp` WRITE;
/*!40000 ALTER TABLE `tvendor_grp` DISABLE KEYS */;
/*!40000 ALTER TABLE `tvendor_grp` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2014-11-23  6:29:20
