-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Jul 20, 2024 at 12:28 PM
-- Server version: 10.6.18-MariaDB-cll-lve
-- PHP Version: 8.1.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `test`
-- user: test
-- password: test
-- port: 3306
-- server: localhost

-- --------------------------------------------------------

-- --------------------------------------------------------

--
-- Table structure for table `MANAGE`
--

CREATE TABLE `MANAGE` (
  `id` bigint(20) NOT NULL,
  `name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `MANAGE`
--

INSERT INTO `MANAGE` (`id`, `name`) VALUES
(1, 'Jorge'),
(2, 'Juan'),
(3, 'Carlos'),
(4, 'DDD');

-- --------------------------------------------------------

-- --------------------------------------------------------

--
-- Table structure for table `PRODUCT`
--

CREATE TABLE `PRODUCT` (
  `id` bigint(20) NOT NULL,
  `title` varchar(255) NOT NULL,
  `content` text DEFAULT NULL,
  `update_time` datetime DEFAULT NULL,
  `archived` tinyint(1) DEFAULT 0,
  `manage_id` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `PRODUCT`
--

INSERT INTO `PRODUCT` (`id`, `title`, `content`, `update_time`, `archived`, `manage_id`) VALUES
(2, 'ASD', 'ASDF', NULL, 0, 1),
(16, 'string', 'string', '2024-07-19 19:42:42', 0, 2),
(17, 'Proces', 'proces', NULL, 0, NULL),
(18, 'hhh', 'hhh', NULL, 0, 2),
(19, 'aaaa', 'aaaa', NULL, 0, 3);

-- --------------------------------------------------------


--
-- Indexes for table `MANAGE`
--
ALTER TABLE `MANAGE`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `PRODUCT`
--
ALTER TABLE `PRODUCT`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idx_product_manage_id` (`manage_id`);


--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `MANAGE`
--
ALTER TABLE `MANAGE`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `PRODUCT`
--
ALTER TABLE `PRODUCT`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- Constraints for dumped tables
--
--
-- Constraints for table `PRODUCT`
--
ALTER TABLE `PRODUCT`
  ADD CONSTRAINT `PRODUCT_ibfk_1` FOREIGN KEY (`manage_id`) REFERENCES `MANAGE` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
