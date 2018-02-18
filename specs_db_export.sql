CREATE DATABASE  IF NOT EXISTS `specs` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `specs`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: specs
-- ------------------------------------------------------
-- Server version	5.5.5-10.2.11-MariaDB

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
-- Table structure for table `alexa`
--

DROP TABLE IF EXISTS `alexa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `alexa` (
  `alexaid` int(11) NOT NULL AUTO_INCREMENT,
  `alexa_userid` varchar(256) NOT NULL,
  `accesstoken` varchar(256) DEFAULT NULL,
  `apiaccesstoken` varchar(256) DEFAULT NULL,
  `userid` int(11) NOT NULL,
  PRIMARY KEY (`alexaid`),
  UNIQUE KEY `alexaid_UNIQUE` (`alexaid`),
  UNIQUE KEY `alexa_userid_UNIQUE` (`alexa_userid`),
  UNIQUE KEY `userid_UNIQUE` (`userid`),
  UNIQUE KEY `accesstoken_UNIQUE` (`accesstoken`),
  UNIQUE KEY `apiaccesstoken_UNIQUE` (`apiaccesstoken`),
  CONSTRAINT `user_id` FOREIGN KEY (`userid`) REFERENCES `user` (`userid`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alexa`
--

LOCK TABLES `alexa` WRITE;
/*!40000 ALTER TABLE `alexa` DISABLE KEYS */;
/*!40000 ALTER TABLE `alexa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `family`
--

DROP TABLE IF EXISTS `family`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `family` (
  `familyid` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `memberid` int(11) NOT NULL,
  PRIMARY KEY (`familyid`),
  UNIQUE KEY `familyid_UNIQUE` (`familyid`),
  UNIQUE KEY `memberid_UNIQUE` (`memberid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `family`
--

LOCK TABLES `family` WRITE;
/*!40000 ALTER TABLE `family` DISABLE KEYS */;
/*!40000 ALTER TABLE `family` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `familymembers`
--

DROP TABLE IF EXISTS `familymembers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `familymembers` (
  `familymembersid` int(11) NOT NULL AUTO_INCREMENT,
  `familyid` int(11) NOT NULL,
  `userid` int(11) NOT NULL,
  `relation` varchar(45) DEFAULT NULL,
  `permissions` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`familymembersid`),
  UNIQUE KEY `userid_UNIQUE` (`userid`),
  UNIQUE KEY `familymembersid_UNIQUE` (`familymembersid`),
  KEY `familyid_idx` (`familyid`),
  CONSTRAINT `familyid` FOREIGN KEY (`familyid`) REFERENCES `family` (`familyid`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `userid` FOREIGN KEY (`userid`) REFERENCES `user` (`userid`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `familymembers`
--

LOCK TABLES `familymembers` WRITE;
/*!40000 ALTER TABLE `familymembers` DISABLE KEYS */;
/*!40000 ALTER TABLE `familymembers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pwd`
--

DROP TABLE IF EXISTS `pwd`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pwd` (
  `pwdid` int(11) NOT NULL,
  `hash` varchar(256) NOT NULL,
  `salt` varchar(256) NOT NULL,
  PRIMARY KEY (`pwdid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pwd`
--

LOCK TABLES `pwd` WRITE;
/*!40000 ALTER TABLE `pwd` DISABLE KEYS */;
/*!40000 ALTER TABLE `pwd` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `userid` int(11) NOT NULL,
  `username` varchar(45) NOT NULL,
  `email` varchar(45) NOT NULL,
  `firstname` varchar(45) DEFAULT NULL,
  `lastname` varchar(45) DEFAULT NULL,
  `phone` int(11) DEFAULT NULL,
  `address1` varchar(45) DEFAULT NULL,
  `address2` varchar(45) DEFAULT NULL,
  `city` varchar(45) DEFAULT NULL,
  `state` varchar(2) DEFAULT NULL,
  `country` varchar(45) DEFAULT NULL,
  `pwdid` int(11) DEFAULT NULL,
  `alexaid` int(11) DEFAULT NULL,
  PRIMARY KEY (`userid`),
  UNIQUE KEY `username_UNIQUE` (`username`),
  UNIQUE KEY `iduser_UNIQUE` (`userid`),
  UNIQUE KEY `email_UNIQUE` (`email`),
  KEY `pwdid_idx` (`pwdid`),
  KEY `alexaid_idx` (`alexaid`),
  CONSTRAINT `alexaid` FOREIGN KEY (`alexaid`) REFERENCES `alexa` (`alexaid`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `pwdid` FOREIGN KEY (`pwdid`) REFERENCES `pwd` (`pwdid`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-02-06 18:00:14
