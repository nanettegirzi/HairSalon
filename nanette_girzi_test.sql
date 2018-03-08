-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Mar 08, 2018 at 05:29 PM
-- Server version: 5.6.35
-- PHP Version: 7.0.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `nanette_girzi_test`
--
CREATE DATABASE IF NOT EXISTS `nanette_girzi_test` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `nanette_girzi_test`;

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

CREATE TABLE `clients` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  `stylist_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `specialties`
--

CREATE TABLE `specialties` (
  `id` bigint(20) NOT NULL,
  `specialty` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `specialty_stylists`
--

CREATE TABLE `specialty_stylists` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `specialty_id` int(11) NOT NULL,
  `stylist_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `specialty_stylists`
--

INSERT INTO `specialty_stylists` (`id`, `specialty_id`, `stylist_id`) VALUES
(1, 1, 58),
(2, 2, 58),
(3, 3, 59),
(4, 5, 65),
(5, 6, 65),
(6, 7, 66),
(7, 9, 72),
(8, 10, 72),
(9, 11, 73),
(10, 13, 79),
(12, 15, 80),
(13, 18, 86),
(14, 19, 86),
(15, 20, 87),
(16, 23, 93),
(18, 25, 94),
(19, 30, 100),
(20, 31, 100),
(21, 32, 101),
(22, 38, 107),
(23, 39, 107),
(24, 40, 108),
(25, 46, 109),
(26, 47, 115),
(27, 48, 115),
(28, 49, 116),
(29, 55, 117),
(30, 56, 118),
(31, 57, 125),
(32, 58, 125),
(33, 59, 126),
(34, 65, 127),
(35, 66, 128),
(36, 67, 135),
(37, 68, 135),
(38, 69, 136),
(39, 75, 137),
(40, 76, 138),
(41, 77, 145),
(42, 78, 145),
(43, 79, 146),
(44, 85, 147),
(45, 86, 148),
(46, 87, 155),
(47, 88, 155),
(48, 89, 156),
(49, 95, 157),
(50, 96, 158),
(51, 97, 165),
(52, 98, 165),
(53, 99, 166),
(54, 105, 167),
(55, 106, 168),
(56, 107, 175),
(57, 108, 175),
(58, 109, 176),
(59, 115, 177),
(60, 116, 178),
(61, 117, 185),
(62, 118, 185),
(63, 119, 186),
(64, 125, 187),
(65, 126, 188),
(66, 127, 195),
(67, 128, 195),
(68, 129, 196),
(69, 5, 1),
(70, 6, 2),
(71, 7, 9),
(72, 8, 9),
(73, 9, 10),
(74, 15, 11),
(75, 16, 12),
(76, 17, 19),
(77, 18, 19),
(78, 19, 20),
(79, 25, 21),
(80, 26, 22),
(81, 27, 29),
(82, 28, 29),
(83, 29, 30),
(84, 35, 31),
(85, 36, 32),
(86, 37, 39),
(87, 38, 39),
(88, 39, 40);

-- --------------------------------------------------------

--
-- Table structure for table `stylists`
--

CREATE TABLE `stylists` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `stylist_name` varchar(255) DEFAULT NULL,
  `stylist_rate` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- Indexes for table `specialties`
--
ALTER TABLE `specialties`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `specialty_stylists`
--
ALTER TABLE `specialty_stylists`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stylists`
--
ALTER TABLE `stylists`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clients`
--
ALTER TABLE `clients`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `specialties`
--
ALTER TABLE `specialties`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `specialty_stylists`
--
ALTER TABLE `specialty_stylists`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=89;
--
-- AUTO_INCREMENT for table `stylists`
--
ALTER TABLE `stylists`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
