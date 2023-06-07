-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 07, 2023 at 02:37 PM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `foodinfo`
--

-- --------------------------------------------------------

--
-- Table structure for table `foodcategory`
--

CREATE TABLE `foodcategory` (
  `name` varchar(100) NOT NULL,
  `status` tinyint(4) NOT NULL,
  `region` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `foodcategory`
--

INSERT INTO `foodcategory` (`name`, `status`, `region`) VALUES
('Adobo', 0, 'Pinoy Classics'),
('Bagnet', 0, 'Region I'),
('Bopis', 0, 'Region IV-A'),
('Buko Pie', 0, 'Region IV-A'),
('Bulalo', 0, 'Region IV-A'),
('Dinuguan', 0, 'Pinoy Classics'),
('Inasal', 0, 'Region VI'),
('Kare-Kare', 0, 'Region III'),
('Laing', 0, 'Region V'),
('Lechon', 0, 'Region VII'),
('Pancit Palabok', 1, 'NCR'),
('Pinakbet', 0, 'Region I'),
('Sinigang', 1, 'Pinoy Classics'),
('Sisig', 0, 'Region III'),
('Tapa', 1, 'Pinoy Classics');

-- --------------------------------------------------------

--
-- Table structure for table `fooddesc`
--

CREATE TABLE `fooddesc` (
  `name` varchar(100) NOT NULL,
  `imgfile` varchar(100) NOT NULL,
  `description` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `fooddesc`
--

INSERT INTO `fooddesc` (`name`, `imgfile`, `description`) VALUES
('Adobo', 'ADOBO', 'Considered as the Philippine\'s national dish because of popularity.It is made by marinated chicken / pork mixed in vinegar, soy sauce, garlic and spices thus making it savory and tangy with a hint of sweetnes.'),
('Bagnet', 'BAGNET', 'It\'s a dish originated from the Ilocos region in the Philippines. It is a deep-fried pork belly dish known for its crispy and flavorful texture. Bagnet is a versatile dish and can be enjoyed in different ways. It can be served as a main dish with rice, paired with vegetables or salad, or used as an ingredient in other Filipino dishes like pinakbet or kare-kare.'),
('Bopis', 'BOPIS', 'It\'s a dish made from minced pork lungs and heart, cooked with various spices and vegetables. It is known for its bold and spicy flavors.Bopis is commonly enjoyed as a pulutan (appetizer or beer match) or as a main dish with steamed rice. Its bold flavors make it a popular choice in gatherings and celebrations, particularly during festivities or drinking sessions. Bopis showcases the creative use of offal in Filipino cuisine, offering a unique and flavorful experience.'),
('Buko Pie', 'BUKO_PIE', 'It\'s a pastry type food made with buko. It\'s also a popular dessert or snack in the Philippines, especially in the areas where coconuts are abundant. It has a flaky crust filled with a mixture of buko, sugar, and condensed milk. Buko pie can be enjoyed on its own or with a scoop of vanilla ice cream for an extra indulgent treat. It is a beloved dessert in Filipino cuisine and is a must-try for coconut lovers and pastry enthusiasts.'),
('Bulalo', 'BULALO', 'It\'s a beef soup dish that is often enjoyed during cool weather. It is made by cooking beef shanks and bone marrow along with various vegetables and seasonings.'),
('Dinuguan', 'DINUGUAN', 'It\'s a pork stew primarily made from pork parts I.e.lungs, kidneys,intestines,ears,heart, snout and its blood. Famously known as \'chocolate meat\' / \'blood stew\'. It\'s enjoyed along with steamed rice and it\'s usually can be a filling for \'puto\'. Despite of it being a unique dish, it\'s still beloved and widely enjoyed by Filipino people.'),
('Inasal', 'INASAL', 'Inasal is a grilled chicken dish that hails from the province of Bacolod in the Philippines. It is known for its distinct flavor, which comes from a combination of tanginess and smokiness. Inasal is often served with a side of sinamak, a spicy vinegar dip, which adds an extra kick of flavor. It is commonly enjoyed with steamed rice and a side of pickled papaya or atchara.'),
('Kare-Kare', 'KARE_KARE', 'It\'s a stew dish made with oxtail, tripe, and beef, along with various vegetables. It\'s famous for having a flavorful peanut sauce that is made of a combination of ingredients I.e. ground peanuts, shrimp paste, garlic, onions, and annatto oil. It is a beloved dish that showcases the rich culinary heritage of the Philippines.'),
('Laing', 'LAING', 'It\'s a famous dish known as being flavorful and spicy, it\'s primarily made with meat / seafood, taro leaves, coconut milk, and various aromatics. The combination of coconut milk and shrimp paste gives laing its distinct flavor, thus making it creamy, savory and spicy. It\'s commonly served as a main dish or a side dish and beloved by Bicol people where the dish originated.'),
('Lechon', 'LECHON', 'It\'s a roasted whole pig that\'s slowly-roasted on a large bamboo spit over an open fire and it\'s usually stuffed  with a mixture of herbs, spices, and aromatics. It\'s usually served on festive occassions such as weddings, birthdays, and holidays.'),
('Pancit Palabok', 'PANCIT_PALABOK', 'A noodle type dish that is served during special occasions and celebrations and it\'s also known as \'Pancit Luglug or Pancit Malabon\'. It\'s made with rice noodles, palabok sauce and garnished with different toppings I.e. smoked fish, eggs, chicharon and shrimps.'),
('Pinakbet', 'PINAKBET', 'It\'s a famous vegetable dish made from a variety of vegetables. It hails from the Ilocos region of the Philippines and is known for its use of bagoong (shrimp paste) as a key ingredient. It\'s beloved by its vibrant colors, flavorful combinations of vegetables, and the umami richness brought by the shrimp paste.'),
('Sinigang', 'SINIGANG', 'It\'s a soup known for its sour and savory flavor primarily made with tamarind-based soup with various meat / seafood along with vegetables. It\'s often considered as comfort food and enjoyed during cool weather.'),
('Sisig', 'SISIG', 'Made from parts of a pig\'s head I.e. cheeks, ears, and snout. Often cooked with onions and garlic to enhance its aroma and topped with a raw egg. It\'s also commonly served as a main course / appetizer (pulutan).'),
('Tapa', 'TAPA', 'Tapa is a popular dish made from marinated thinly sliced variety of meats i.e. beef, pork, and horse. It\'s often served in any \'Karinderya\' as tapsilog (tapa alongside with sunny side up egg) with sinigang soup. It\'s commonly enjoyed as a breakfast or brunch. ');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `foodcategory`
--
ALTER TABLE `foodcategory`
  ADD PRIMARY KEY (`name`);

--
-- Indexes for table `fooddesc`
--
ALTER TABLE `fooddesc`
  ADD PRIMARY KEY (`name`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
