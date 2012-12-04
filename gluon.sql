-- phpMyAdmin SQL Dump
-- version 3.2.0.1
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: May 14, 2012 at 05:46 AM
-- Server version: 5.1.36
-- PHP Version: 5.3.0

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `gluon`
--

-- --------------------------------------------------------

--
-- Table structure for table `agenda`
--

CREATE TABLE IF NOT EXISTS `agenda` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `color` int(11) NOT NULL,
  `description` varchar(250) NOT NULL,
  `startdate` bigint(20) NOT NULL,
  `duration` bigint(20) NOT NULL,
  `alarm` tinyint(1) NOT NULL,
  `alarmdate` bigint(20) NOT NULL,
  `recur` int(11) NOT NULL DEFAULT '0',
  `dayofweek` int(11) NOT NULL,
  `dayofmonth` int(11) NOT NULL,
  `month` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `duration` (`duration`),
  KEY `startdate_duration` (`startdate`,`duration`),
  KEY `startdate` (`startdate`),
  KEY `alarm_alarmdate` (`alarm`,`alarmdate`),
  KEY `alarm` (`alarm`),
  KEY `alarmdate` (`alarmdate`),
  KEY `recur` (`recur`),
  KEY `dayofweek` (`dayofweek`),
  KEY `dayofmonth` (`dayofmonth`),
  KEY `month` (`month`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=578 ;

-- --------------------------------------------------------

--
-- Table structure for table `groceries`
--

CREATE TABLE IF NOT EXISTS `groceries` (
  `name` varchar(150) NOT NULL,
  `count` bigint(20) NOT NULL,
  `list` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`name`,`list`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `groceries_count`
--

CREATE TABLE IF NOT EXISTS `groceries_count` (
  `name` varchar(150) NOT NULL,
  `count` bigint(20) NOT NULL,
  `lastused` bigint(20) NOT NULL,
  `list` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`name`),
  KEY `count` (`count`),
  KEY `lastused` (`lastused`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `notes`
--

CREATE TABLE IF NOT EXISTS `notes` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `note` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=42 ;
