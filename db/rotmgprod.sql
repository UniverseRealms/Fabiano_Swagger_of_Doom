-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               5.6.17 - MySQL Community Server (GPL)
-- Server OS:                    Win64
-- HeidiSQL Version:             9.2.0.4981
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- Dumping database structure for rotmgprod
DROP DATABASE IF EXISTS `rotmgprod`;
CREATE DATABASE IF NOT EXISTS `rotmgprod` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `rotmgprod`;


-- Dumping structure for table rotmgprod.accounts
DROP TABLE IF EXISTS `accounts`;
CREATE TABLE IF NOT EXISTS `accounts` (
  `id` bigint(255) NOT NULL AUTO_INCREMENT,
  `uuid` varchar(128) NOT NULL,
  `password` varchar(256) NOT NULL,
  `name` varchar(64) NOT NULL DEFAULT 'DEFAULT',
  `rank` int(1) NOT NULL DEFAULT '0',
  `namechosen` tinyint(1) NOT NULL DEFAULT '0',
  `verified` tinyint(1) NOT NULL DEFAULT '1',
  `guild` int(11) NOT NULL,
  `guildRank` int(11) NOT NULL,
  `guildFame` int(11) NOT NULL DEFAULT '0',
  `lastip` varchar(128) NOT NULL DEFAULT '',
  `vaultCount` int(11) NOT NULL DEFAULT '1',
  `maxCharSlot` int(11) NOT NULL DEFAULT '2',
  `regTime` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `guest` tinyint(1) NOT NULL DEFAULT '0',
  `warnings` int(11) NOT NULL DEFAULT '0',
  `banned` tinyint(1) NOT NULL DEFAULT '0',
  `publicMuledump` int(1) NOT NULL DEFAULT '1',
  `muted` tinyint(1) NOT NULL,
  `prodAcc` tinyint(1) NOT NULL DEFAULT '0',
  `locked` varchar(512) NOT NULL,
  `ignored` varchar(512) NOT NULL,
  `gifts` text NOT NULL,
  `isAgeVerified` tinyint(1) NOT NULL DEFAULT '0',
  `petYardType` int(11) NOT NULL DEFAULT '1',
  `ownedSkins` varchar(2048) NOT NULL,
  `authToken` varchar(128) NOT NULL DEFAULT '',
  `acceptedNewTos` tinyint(1) NOT NULL DEFAULT '1',
  `lastSeen` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `accountInUse` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`,`uuid`,`guild`,`lastip`,`banned`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table rotmgprod.arenalb
DROP TABLE IF EXISTS `arenalb`;
CREATE TABLE IF NOT EXISTS `arenalb` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `wave` int(11) NOT NULL,
  `accid` int(11) NOT NULL,
  `charid` int(11) NOT NULL,
  `petid` int(11) DEFAULT NULL,
  `time` varchar(256) NOT NULL,
  `date` datetime NOT NULL,
  PRIMARY KEY (`id`,`wave`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table rotmgprod.backpacks
DROP TABLE IF EXISTS `backpacks`;
CREATE TABLE IF NOT EXISTS `backpacks` (
  `accId` int(11) NOT NULL,
  `charId` int(11) NOT NULL,
  `items` varchar(128) NOT NULL DEFAULT '-1, -1, -1, -1, -1, -1, -1, -1',
  PRIMARY KEY (`accId`,`charId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table rotmgprod.boards
DROP TABLE IF EXISTS `boards`;
CREATE TABLE IF NOT EXISTS `boards` (
  `guildId` int(11) NOT NULL,
  `text` varchar(1024) NOT NULL,
  PRIMARY KEY (`guildId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table rotmgprod.characters
DROP TABLE IF EXISTS `characters`;
CREATE TABLE IF NOT EXISTS `characters` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `accId` int(11) NOT NULL,
  `charId` int(11) NOT NULL,
  `charType` int(11) NOT NULL DEFAULT '782',
  `level` int(11) NOT NULL DEFAULT '1',
  `exp` int(11) NOT NULL DEFAULT '0',
  `fame` int(11) NOT NULL DEFAULT '0',
  `items` varchar(128) NOT NULL DEFAULT '-1, -1, -1, -1',
  `hpPotions` int(11) NOT NULL DEFAULT '0',
  `mpPotions` int(11) NOT NULL DEFAULT '0',
  `hp` int(11) NOT NULL DEFAULT '1',
  `mp` int(11) NOT NULL DEFAULT '1',
  `stats` varchar(128) NOT NULL DEFAULT '1, 1, 1, 1, 1, 1, 1, 1',
  `dead` tinyint(1) NOT NULL DEFAULT '0',
  `tex1` int(11) NOT NULL DEFAULT '0',
  `tex2` int(11) NOT NULL DEFAULT '0',
  `pet` int(11) NOT NULL DEFAULT '-1',
  `petId` int(11) NOT NULL DEFAULT '-1',
  `hasBackpack` int(11) NOT NULL DEFAULT '0',
  `skin` int(11) NOT NULL DEFAULT '0',
  `xpBoosterTime` int(11) NOT NULL DEFAULT '0',
  `ldTimer` int(11) NOT NULL DEFAULT '0',
  `ltTimer` int(11) NOT NULL DEFAULT '0',
  `fameStats` varchar(512) NOT NULL,
  `createTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `deathTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `totalFame` int(11) NOT NULL DEFAULT '0',
  `lastSeen` datetime NOT NULL,
  `lastLocation` varchar(128) NOT NULL,
  PRIMARY KEY (`id`,`accId`,`dead`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table rotmgprod.classstats
DROP TABLE IF EXISTS `classstats`;
CREATE TABLE IF NOT EXISTS `classstats` (
  `accId` int(11) NOT NULL,
  `objType` int(11) NOT NULL,
  `bestLv` int(11) NOT NULL DEFAULT '1',
  `bestFame` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`accId`,`objType`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table rotmgprod.dailyquests
DROP TABLE IF EXISTS `dailyquests`;
CREATE TABLE IF NOT EXISTS `dailyquests` (
  `accId` int(11) NOT NULL,
  `goals` varchar(512) NOT NULL,
  `tier` int(11) NOT NULL DEFAULT '1',
  `time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`accId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table rotmgprod.death
DROP TABLE IF EXISTS `death`;
CREATE TABLE IF NOT EXISTS `death` (
  `accId` int(11) NOT NULL,
  `chrId` int(11) NOT NULL,
  `name` varchar(64) NOT NULL DEFAULT 'DEFAULT',
  `charType` int(11) NOT NULL DEFAULT '782',
  `tex1` int(11) NOT NULL DEFAULT '0',
  `tex2` int(11) NOT NULL DEFAULT '0',
  `skin` int(11) NOT NULL DEFAULT '0',
  `items` varchar(128) NOT NULL DEFAULT '-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1',
  `fame` int(11) NOT NULL DEFAULT '0',
  `exp` int(11) NOT NULL,
  `fameStats` varchar(256) NOT NULL,
  `totalFame` int(11) NOT NULL DEFAULT '0',
  `firstBorn` tinyint(1) NOT NULL,
  `killer` varchar(128) NOT NULL,
  `time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`accId`,`chrId`,`time`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table rotmgprod.giftcodes
DROP TABLE IF EXISTS `giftcodes`;
CREATE TABLE IF NOT EXISTS `giftcodes` (
  `accId` int(11) NOT NULL DEFAULT '0',
  `code` varchar(128) NOT NULL,
  `content` varchar(512) NOT NULL,
  PRIMARY KEY (`code`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table rotmgprod.globalnews
DROP TABLE IF EXISTS `globalnews`;
CREATE TABLE IF NOT EXISTS `globalnews` (
  `slot` int(11) NOT NULL,
  `linkType` int(11) NOT NULL,
  `title` varchar(65) NOT NULL,
  `image` mediumtext NOT NULL,
  `priority` int(11) NOT NULL,
  `linkDetail` mediumtext NOT NULL,
  `platform` varchar(128) NOT NULL DEFAULT 'kabam.com,kongregate,steam,rotmg',
  `startTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `endTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  PRIMARY KEY (`slot`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table rotmgprod.guilds
DROP TABLE IF EXISTS `guilds`;
CREATE TABLE IF NOT EXISTS `guilds` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(128) NOT NULL DEFAULT 'DEFAULT_GUILD',
  `members` varchar(128) NOT NULL,
  `guildFame` int(11) NOT NULL,
  `totalGuildFame` int(11) NOT NULL,
  `level` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`,`members`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table rotmgprod.mysteryboxes
DROP TABLE IF EXISTS `mysteryboxes`;
CREATE TABLE IF NOT EXISTS `mysteryboxes` (
  `id` int(11) NOT NULL,
  `title` varchar(128) NOT NULL,
  `weight` int(11) NOT NULL,
  `description` varchar(128) NOT NULL,
  `contents` mediumtext NOT NULL,
  `priceAmount` int(11) NOT NULL,
  `priceCurrency` int(11) NOT NULL,
  `image` mediumtext NOT NULL,
  `icon` mediumtext NOT NULL,
  `salePrice` int(11) NOT NULL,
  `saleCurrency` int(11) NOT NULL,
  `saleEnd` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `startTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `boxEnd` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table rotmgprod.news
DROP TABLE IF EXISTS `news`;
CREATE TABLE IF NOT EXISTS `news` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `icon` varchar(16) NOT NULL DEFAULT 'info',
  `title` varchar(128) NOT NULL DEFAULT 'Default news title',
  `text` varchar(128) NOT NULL DEFAULT 'Default news text',
  `link` varchar(256) NOT NULL DEFAULT 'http://mmoe.net/',
  `date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`,`text`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table rotmgprod.packages
DROP TABLE IF EXISTS `packages`;
CREATE TABLE IF NOT EXISTS `packages` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(128) NOT NULL,
  `maxPurchase` int(11) NOT NULL DEFAULT '-1',
  `weight` int(11) NOT NULL DEFAULT '0',
  `contents` varchar(512) NOT NULL DEFAULT '{"items":[],"charSlots":0,"vaultChests":0}',
  `bgUrl` varchar(512) NOT NULL,
  `price` int(11) NOT NULL,
  `quantity` int(11) NOT NULL DEFAULT '-1',
  `endDate` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table rotmgprod.pets
DROP TABLE IF EXISTS `pets`;
CREATE TABLE IF NOT EXISTS `pets` (
  `accId` int(11) NOT NULL,
  `petId` int(11) NOT NULL AUTO_INCREMENT,
  `objType` smallint(5) NOT NULL,
  `skinName` varchar(128) NOT NULL,
  `skin` int(11) NOT NULL,
  `family` int(11) NOT NULL,
  `rarity` int(11) NOT NULL,
  `maxLevel` int(11) NOT NULL DEFAULT '30',
  `abilities` varchar(128) NOT NULL,
  `levels` varchar(128) NOT NULL,
  `xp` varchar(128) NOT NULL DEFAULT '0, 0, 0',
  PRIMARY KEY (`accId`,`petId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table rotmgprod.realmeye_descriptions
DROP TABLE IF EXISTS `realmeye_descriptions`;
CREATE TABLE IF NOT EXISTS `realmeye_descriptions` (
  `accId` int(11) NOT NULL,
  `line1` varchar(105) DEFAULT NULL,
  `line2` varchar(105) DEFAULT 'You can edit this.',
  `line3` varchar(105) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- Data exporting was unselected.


-- Dumping structure for table rotmgprod.stats
DROP TABLE IF EXISTS `stats`;
CREATE TABLE IF NOT EXISTS `stats` (
  `accId` int(11) NOT NULL,
  `fame` int(11) NOT NULL,
  `totalFame` int(11) NOT NULL,
  `credits` int(11) NOT NULL,
  `totalCredits` int(11) NOT NULL,
  `fortuneTokens` int(11) NOT NULL,
  `totalFortuneTokens` int(11) NOT NULL,
  PRIMARY KEY (`accId`,`fame`,`totalFame`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table rotmgprod.thealchemist
DROP TABLE IF EXISTS `thealchemist`;
CREATE TABLE IF NOT EXISTS `thealchemist` (
  `id` int(11) NOT NULL,
  `title` varchar(512) NOT NULL,
  `description` varchar(512) DEFAULT NULL,
  `image` varchar(512) NOT NULL,
  `icon` varchar(512) NOT NULL,
  `contents` mediumtext NOT NULL,
  `priceFirstInGold` int(11) NOT NULL DEFAULT '51',
  `priceFirstInToken` int(11) NOT NULL DEFAULT '1',
  `priceSecondInGold` int(11) NOT NULL DEFAULT '75',
  `startTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `endTime` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table rotmgprod.unlockedclasses
DROP TABLE IF EXISTS `unlockedclasses`;
CREATE TABLE IF NOT EXISTS `unlockedclasses` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `accId` int(11) NOT NULL,
  `class` varchar(128) NOT NULL,
  `available` varchar(128) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table rotmgprod.vaults
DROP TABLE IF EXISTS `vaults`;
CREATE TABLE IF NOT EXISTS `vaults` (
  `accId` int(11) NOT NULL,
  `chestId` int(11) NOT NULL AUTO_INCREMENT,
  `items` varchar(128) NOT NULL,
  PRIMARY KEY (`accId`,`chestId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table rotmgprod.warnings
DROP TABLE IF EXISTS `warnings`;
CREATE TABLE IF NOT EXISTS `warnings` (
  `accId` int(11) NOT NULL,
  `warningId` int(11) NOT NULL AUTO_INCREMENT,
  `warning` varchar(50) DEFAULT 'Credits',
  `date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`warningId`,`accId`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
