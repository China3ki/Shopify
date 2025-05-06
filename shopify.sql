-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Maj 06, 2025 at 06:34 PM
-- Wersja serwera: 10.4.32-MariaDB
-- Wersja PHP: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `shopify`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `cart`
--

CREATE TABLE `cart` (
  `cart_id` int(11) NOT NULL,
  `cart_user_id` int(11) DEFAULT NULL,
  `cart_product_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `manufacturers`
--

CREATE TABLE `manufacturers` (
  `manufacturer_id` int(11) NOT NULL,
  `manufacturer_name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Dumping data for table `manufacturers`
--

INSERT INTO `manufacturers` (`manufacturer_id`, `manufacturer_name`) VALUES
(1, 'Apple'),
(2, 'Samsung'),
(3, 'Sony'),
(4, 'LG'),
(5, 'Panasonic'),
(6, 'Dell'),
(7, 'HP'),
(8, 'Lenovo'),
(9, 'Asus'),
(10, 'Acer'),
(11, 'Microsoft'),
(12, 'Intel'),
(13, 'AMD'),
(14, 'NVIDIA'),
(15, 'Qualcomm'),
(16, 'Huawei'),
(17, 'Xiaomi'),
(18, 'Philips'),
(19, 'Toshiba'),
(20, 'Sharp'),
(21, 'Bosch'),
(22, 'Siemens'),
(23, 'Hitachi'),
(24, 'Motorola'),
(25, 'OnePlus'),
(26, 'Realme'),
(27, 'Vizio'),
(28, 'ZTE'),
(29, 'BlackBerry'),
(30, 'Alcatel'),
(31, 'Oppo'),
(32, 'Nokia'),
(33, 'Canon'),
(34, 'Epson'),
(35, 'Fujitsu'),
(36, 'Nothing');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `orders`
--

CREATE TABLE `orders` (
  `order_id` int(11) NOT NULL,
  `order_user_id` int(11) DEFAULT NULL,
  `order_status_id` int(11) DEFAULT NULL,
  `order_date` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `order_products`
--

CREATE TABLE `order_products` (
  `order_product_id` int(11) NOT NULL,
  `order_product_orders_id` int(11) DEFAULT NULL,
  `order_product_products_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `products`
--

CREATE TABLE `products` (
  `product_id` int(11) NOT NULL,
  `product_category_id` int(11) NOT NULL,
  `product_manufacturer_id` int(11) NOT NULL,
  `product_name` varchar(50) DEFAULT NULL,
  `product_desc` varchar(120) NOT NULL,
  `product_amount` int(11) DEFAULT NULL,
  `product_price` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`product_id`, `product_category_id`, `product_manufacturer_id`, `product_name`, `product_desc`, `product_amount`, `product_price`) VALUES
(61, 1, 6, 'Dell XPS 13', 'Laptop Dell XPS 13 z procesorem Intel Core i7, 16GB RAM, 512GB SSD', 44, 5500.50),
(62, 1, 2, 'Samsung Galaxy Book Pro', 'Laptop Samsung Galaxy Book Pro z ekranem AMOLED, procesorem Intel Core i5', 28, 4499.99),
(63, 2, 1, 'Apple iPhone 14', 'Smartfon Apple iPhone 14 z ekranem OLED, procesorem A15 Bionic, 128GB pamięci', 102, 5199.00),
(64, 2, 7, 'HP Spectre x360', 'Smartfon HP Spectre x360 z ekranem 6,8 cala, procesorem Snapdragon 888, 256GB pamięci', 67, 3299.00),
(65, 9, 33, 'Canon EOS 90D', 'Lustrzanka Canon EOS 90D z matrycą APS-C, 32.5 MP, 4K wideo', 35, 5599.99),
(66, 7, 11, 'Intel Core i7-12700K', 'Procesor Intel Core i7-12700K, 12 rdzeni, 20 wątków, 3.6GHz', 58, 2250.00),
(67, 4, 4, 'LG OLED65CXPUA', 'Telewizor LG OLED 65 cali 4K UHD, HDR, Dolby Vision, z systemem webOS', 15, 7499.00),
(68, 5, 13, 'Sony PlayStation 5', 'Konsola Sony PlayStation 5 z kontrolerem DualSense, 825GB SSD', 76, 2399.00),
(69, 10, 16, 'Huawei Mate 10 Pro', 'Smartfon Huawei Mate 10 Pro z ekranem 6 cali, procesorem Kirin 970, 128GB pamięci', 80, 2499.99),
(70, 6, 8, 'Lenovo ThinkPad X1 Carbon', 'Laptop Lenovo ThinkPad X1 Carbon z procesorem Intel Core i5, 8GB RAM, 256GB SSD', 60, 3499.00),
(71, 1, 10, 'Acer Predator Helios 300', 'Laptop Acer Predator Helios 300, 15,6 cala, i7-10750H, GTX 1660 Ti', 50, 6699.00),
(72, 3, 19, 'Toshiba Portege X30L-G', 'Laptop Toshiba Portege X30L-G, 13,3 cala, Intel Core i5, 8GB RAM, 256GB SSD', 18, 3199.00),
(73, 8, 17, 'Xiaomi Mi Band 6', 'Opaska Xiaomi Mi Band 6 z ekranem AMOLED, monitorowaniem tętna i snu', 100, 219.99),
(74, 6, 23, 'Siemens iQ700', 'Lodówka Siemens iQ700 z funkcją NoFrost, pojemność 350L', 34, 2999.00),
(75, 10, 5, 'Panasonic Lumix GH5', 'Aparat Panasonic Lumix GH5 z matrycą Micro Four Thirds, 4K 60fps', 29, 5999.00),
(76, 4, 6, 'LG NanoCell 55NANO90', 'Telewizor LG NanoCell 55 cali, 4K, HDR, Dolby Atmos, webOS', 47, 4999.00),
(77, 2, 4, 'Samsung Galaxy S21', 'Smartfon Samsung Galaxy S21 z ekranem Dynamic AMOLED 2X, 128GB pamięci', 83, 3999.00),
(78, 7, 13, 'AMD Ryzen 9 5900X', 'Procesor AMD Ryzen 9 5900X, 12 rdzeni, 24 wątki, 3.7GHz', 100, 3499.00),
(79, 3, 12, 'Microsoft Surface Go 3', 'Tablet Microsoft Surface Go 3, 10,5 cala, procesor Intel Pentium Gold', 25, 1899.99),
(80, 1, 5, 'Panasonic Toughbook 55', 'Laptop Panasonic Toughbook 55, 14 cali, Intel Core i5, 8GB RAM, 512GB SSD', 12, 7999.00),
(81, 10, 29, 'BlackBerry Key2', 'Smartfon BlackBerry Key2 z fizyczną klawiaturą, ekranem 4.5 cala, Snapdragon 660', 44, 2499.00),
(82, 6, 16, 'Huawei MatePad Pro', 'Tablet Huawei MatePad Pro, 10,8 cala, Kirin 990, 128GB pamięci', 33, 1999.00),
(83, 4, 13, 'Sony Bravia XR A90J', 'Telewizor Sony Bravia XR A90J, OLED 55 cali, 4K, Dolby Vision', 22, 7999.00),
(84, 8, 25, 'OnePlus Watch', 'Zegarek OnePlus Watch z ekranem AMOLED, monitorowaniem tętna i snu', 91, 799.00),
(85, 2, 3, 'Sony Xperia 5 II', 'Smartfon Sony Xperia 5 II z ekranem OLED 6.1 cala, Snapdragon 865', 58, 3899.00),
(86, 9, 33, 'Canon EOS Rebel T7i', 'Aparat Canon EOS Rebel T7i, 24.2 MP, 1080p Full HD, system AF', 72, 3499.00),
(87, 5, 24, 'Motorola Moto G Power', 'Smartfon Motorola Moto G Power z ekranem 6,6 cala, Snapdragon 662', 48, 1099.00),
(88, 6, 9, 'Asus ROG Strix Z590-E', 'Płyta główna ASUS ROG Strix Z590-E, chipset Intel Z590, ATX', 50, 1199.00),
(89, 3, 19, 'Toshiba Excite Pro', 'Tablet Toshiba Excite Pro, 10,1 cala, Android, 16GB pamięci', 23, 799.99),
(90, 7, 8, 'Lenovo Legion 5 Pro', 'Laptop Lenovo Legion 5 Pro, Ryzen 7 5800H, RTX 3070, 16GB RAM', 40, 7899.00),
(91, 5, 18, 'Philips Hue White and Color', 'Zestaw oświetlenia Philips Hue, 2 żarówki LED, możliwość zmiany kolorów', 65, 799.00),
(92, 2, 20, 'Sharp Aquos R5G', 'Smartfon Sharp Aquos R5G z ekranem 6,5 cala, Snapdragon 865, 256GB pamięci', 56, 3299.00),
(93, 4, 7, 'LG 55UK6500', 'Telewizor LG 55UK6500, 55 cali, 4K UHD, HDR, webOS', 39, 3199.00),
(94, 1, 6, 'Dell Alienware m15', 'Laptop Dell Alienware m15 z RTX 3070, Intel Core i7, 16GB RAM', 22, 8999.00),
(95, 5, 22, 'Siemens SX95', 'Konsola do gier Siemens SX95, z obsługą gier 4K, 1TB SSD', 13, 5999.00),
(96, 3, 10, 'Apple iPad Pro', 'Tablet Apple iPad Pro, 12.9 cala, procesor M1, 128GB pamięci', 66, 5399.00),
(97, 7, 14, 'NVIDIA GeForce RTX 3080', 'Karta graficzna NVIDIA GeForce RTX 3080, 10GB GDDR6X', 28, 4999.00),
(98, 10, 11, 'Microsoft Xbox Series X', 'Konsola Microsoft Xbox Series X, 1TB SSD, 4K UHD', 58, 2499.00),
(99, 4, 5, 'Panasonic TX-65HZ1000', 'Telewizor Panasonic TX-65HZ1000, 65 cali, OLED, 4K HDR', 19, 9999.00),
(100, 1, 12, 'Fujitsu LifeBook U937', 'Laptop Fujitsu LifeBook U937, 13,3 cala, Intel Core i5, 8GB RAM, 256GB SSD', 14, 3899.00),
(101, 1, 9, 'Asus ZenBook 13', 'Laptop Asus ZenBook 13, Intel Core i7, 16GB RAM, 512GB SSD, ekran OLED', 35, 5499.00),
(102, 2, 14, 'Qualcomm Snapdragon 888', 'Procesor Qualcomm Snapdragon 888, 8 rdzeni, 2.84GHz, 5G', 68, 799.00),
(103, 6, 7, 'HP Pavilion x360', 'Laptop HP Pavilion x360, Intel Core i5, 8GB RAM, 256GB SSD, 14 cali', 27, 3999.00),
(104, 4, 2, 'Samsung QLED Q80T', 'Telewizor Samsung QLED 65 cali, 4K UHD, HDR, Tizen', 30, 6699.00),
(105, 3, 18, 'Philips 10.1\" MediaPad', 'Tablet Philips 10.1 cala, Android, 32GB pamięci, 2GB RAM', 45, 799.00),
(106, 5, 21, 'Bosch Indego 350', 'Robot koszący Bosch Indego 350, system SmartMowing, 350m²', 50, 3499.00),
(107, 10, 27, 'Vizio Smartcast 55\"', 'Telewizor Vizio Smartcast 55 cali, 4K UHD, HDR, Smart TV', 32, 3999.00),
(108, 6, 13, 'Sony WH-1000XM4', 'Słuchawki Sony WH-1000XM4, Bluetooth, redukcja hałasu, do 30 godzin pracy', 76, 1199.00),
(109, 2, 5, 'Panasonic Eluga X1', 'Smartfon Panasonic Eluga X1, 6,2 cala, procesor MediaTek, 128GB pamięci', 43, 1999.00),
(110, 7, 19, 'AMD Radeon RX 6800 XT', 'Karta graficzna AMD Radeon RX 6800 XT, 16GB GDDR6', 58, 3799.00),
(111, 4, 8, 'Toshiba 50LF621C', 'Telewizor Toshiba 50 cali, 4K UHD, HDR, Android TV', 21, 2699.00),
(112, 3, 22, 'Siemens SIMATIC S7-1200', 'Sterownik PLC Siemens SIMATIC S7-1200, 6ES7214-1AG40-0XB0', 10, 4299.00),
(113, 5, 6, 'LG 55NANO86', 'Telewizor LG NanoCell 55 cali, 4K UHD, HDR, webOS', 17, 4399.00),
(114, 2, 17, 'Xiaomi Mi 11', 'Smartfon Xiaomi Mi 11, 6,81 cala, Snapdragon 888, 128GB pamięci', 84, 3699.00),
(115, 1, 15, 'Fujitsu Stylistic Q7310', 'Tablet Fujitsu Stylistic Q7310, 12.5 cala, Intel Core i5, 8GB RAM', 22, 4999.00),
(116, 9, 34, 'Epson SureShot 10', 'Drukarka Epson SureShot 10, A3, 9600dpi, z funkcją Wi-Fi', 41, 2499.00),
(117, 6, 5, 'Panasonic KX-TG7875', 'Telefon bezprzewodowy Panasonic KX-TG7875, zestaw z 3 słuchawkami', 65, 799.00),
(118, 5, 3, 'Sony PlayStation VR', 'Zestaw VR Sony PlayStation VR, słuchawki, kamera, gry', 52, 2499.00),
(119, 10, 25, 'OnePlus 9 Pro', 'Smartfon OnePlus 9 Pro, 6,7 cala, Snapdragon 888, 128GB pamięci', 70, 3999.00),
(120, 4, 11, 'Sharp LC-50UI7452', 'Telewizor Sharp 50 cali, 4K UHD, HDR, Android TV', 18, 2999.00),
(121, 6, 14, 'NVIDIA Shield TV', 'Urządzenie NVIDIA Shield TV, Android, 4K HDR, gierki strumieniowe', 53, 1399.00),
(122, 7, 9, 'Asus ROG Strix B550-F', 'Płyta główna ASUS ROG Strix B550-F, ATX, chipset B550', 40, 899.00),
(123, 3, 24, 'Motorola Moto G Stylus', 'Smartfon Motorola Moto G Stylus, 6,8 cala, Snapdragon 678', 64, 1499.00),
(124, 2, 18, 'Huawei P40 Pro', 'Smartfon Huawei P40 Pro, 6,58 cala, Kirin 990, 256GB pamięci', 80, 3599.00),
(125, 1, 4, 'Lenovo ThinkPad T14', 'Laptop Lenovo ThinkPad T14, 14 cali, Intel Core i7, 16GB RAM', 90, 4999.00),
(126, 9, 21, 'Bosch VeroAroma 700', 'Ekspres do kawy Bosch VeroAroma 700 z funkcją automatycznego czyszczenia', 50, 3499.00),
(127, 4, 16, 'Philips 65OLED803', 'Telewizor Philips 65 cali, OLED 4K, HDR, Ambilight', 10, 11999.00),
(128, 5, 8, 'Lenovo IdeaPad 5', 'Laptop Lenovo IdeaPad 5, 15,6 cala, Intel Core i5, 8GB RAM', 32, 2999.00),
(129, 6, 20, 'Toshiba Canvio Advance', 'Zewnętrzny dysk twardy Toshiba Canvio Advance 1TB', 71, 229.99),
(130, 7, 25, 'Realme GT 5G', 'Smartfon Realme GT 5G, 6,43 cala, Snapdragon 870', 40, 1999.00),
(131, 8, 12, 'Epson EcoTank ET-2720', 'Drukarka Epson EcoTank ET-2720, atramentowa, z funkcją Wi-Fi', 55, 999.00),
(132, 3, 15, 'Fujitsu Lifebook U937', 'Laptop Fujitsu Lifebook U937, 13,3 cala, Intel Core i5, 8GB RAM', 29, 3499.00),
(133, 1, 10, 'Acer Aspire 7', 'Laptop Acer Aspire 7 z procesorem Ryzen 5 3550H, 8GB RAM, GTX 1650', 38, 4299.00),
(134, 2, 16, 'Huawei Nova 9', 'Smartfon Huawei Nova 9, 6,57 cala, Snapdragon 778G, 128GB pamięci', 74, 2299.00),
(135, 4, 14, 'Sony XBR-65X900F', 'Telewizor Sony XBR-65X900F, 65 cali, 4K UHD, HDR, Android TV', 22, 4999.00),
(136, 5, 1, 'Apple AirPods Pro', 'Słuchawki Apple AirPods Pro z funkcją aktywnej redukcji hałasu', 62, 999.00),
(137, 3, 2, 'Samsung Galaxy Tab S7', 'Tablet Samsung Galaxy Tab S7, 11 cala, Snapdragon 865+, 128GB pamięci', 53, 2999.00),
(138, 7, 17, 'Xiaomi Mi 10T Pro', 'Smartfon Xiaomi Mi 10T Pro, 6,67 cala, Snapdragon 865, 128GB pamięci', 72, 2399.00),
(139, 6, 11, 'Intel NUC 11', 'Mini komputer Intel NUC 11, Intel Core i7, 16GB RAM, 512GB SSD', 15, 3199.00),
(140, 10, 5, 'Panasonic Lumix FZ300', 'Aparat Panasonic Lumix FZ300, 12MP, 4K, 24x zoom', 27, 2199.00),
(141, 1, 7, 'HP Elite Dragonfly', 'Laptop HP Elite Dragonfly, 13,3 cala, Intel Core i5, 8GB RAM, 256GB SSD', 23, 8999.00),
(142, 5, 30, 'BlackBerry KEYone', 'Smartfon BlackBerry KEYone, 4,5 cala, Snapdragon 625, klawiatura QWERTY', 45, 1699.00),
(143, 3, 21, 'Siemens Gigaset DX800A', 'Telefon stacjonarny Siemens Gigaset DX800A, dotykowy ekran, 4 linie', 12, 1199.00),
(144, 7, 4, 'LG UltraGear 27GN950', 'Monitor LG UltraGear 27GN950, 27 cali, 4K, 144Hz, HDR', 17, 4299.00),
(145, 2, 25, 'OnePlus 8T', 'Smartfon OnePlus 8T, 6,55 cala, Snapdragon 865, 256GB pamięci', 59, 2999.00),
(146, 6, 13, 'Sony Xperia 1 II', 'Smartfon Sony Xperia 1 II, 6,5 cala, Snapdragon 865, 256GB pamięci', 36, 4799.00),
(147, 10, 6, 'Lenovo Smart Display', 'Lenovo Smart Display z Google Assistant, 8 cali', 41, 549.00),
(148, 4, 28, 'ZTE AXON 20 5G', 'Smartfon ZTE AXON 20 5G, 6,92 cala, Snapdragon 765G', 27, 1799.00),
(149, 7, 23, 'Hitachi Deskstar 7K6000', 'Dysk twardy Hitachi Deskstar 7K6000, 6TB, SATA III', 55, 999.00),
(150, 8, 11, 'Canon EOS M50', 'Aparat Canon EOS M50, 24.1 MP, 4K, z obiektywem 15-45mm', 33, 2699.00),
(151, 1, 13, 'Fujitsu Lifebook E5', 'Laptop Fujitsu Lifebook E5, 15,6 cala, Intel Core i5, 8GB RAM', 48, 2799.00),
(152, 3, 24, 'Motorola Edge', 'Smartfon Motorola Edge, 6,7 cala, Snapdragon 765G, 128GB pamięci', 59, 2599.00),
(153, 6, 3, 'Dell Inspiron 14 5000', 'Laptop Dell Inspiron 14 5000, Intel Core i3, 8GB RAM, 256GB SSD', 49, 2499.00),
(154, 7, 9, 'Asus TUF Gaming Z590-Plus', 'Płyta główna ASUS TUF Gaming Z590-Plus, chipset Z590, ATX', 40, 999.00),
(155, 4, 12, 'Sharp LC-40LE185', 'Telewizor Sharp LC-40LE185, 40 cali, LED, Full HD', 25, 1499.00),
(156, 2, 6, 'Lenovo Z6 Pro', 'Smartfon Lenovo Z6 Pro, 6,39 cala, Snapdragon 855, 128GB pamięci', 52, 1999.00),
(157, 10, 27, 'Vizio 4K UHD Smart TV', 'Telewizor Vizio 55 cali, 4K UHD, Smart TV, HDR', 38, 3299.00),
(158, 1, 5, 'Panasonic CF-20', 'Laptop Panasonic Toughbook CF-20, 10,1 cala, Intel Core i5, 8GB RAM', 18, 7999.00),
(159, 6, 2, 'Samsung Odyssey G7', 'Monitor Samsung Odyssey G7, 32 cale, 2560x1440, 240Hz, HDR', 39, 2699.00),
(160, 5, 20, 'Toshiba Dynabook Tecra', 'Laptop Toshiba Dynabook Tecra, 15,6 cala, Intel Core i7, 16GB RAM', 28, 4499.00);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `products_category`
--

CREATE TABLE `products_category` (
  `category_id` int(11) NOT NULL,
  `category_name` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Dumping data for table `products_category`
--

INSERT INTO `products_category` (`category_id`, `category_name`) VALUES
(1, 'Laptopy'),
(2, 'Smartfony'),
(3, 'Tablety'),
(4, 'Telewizory'),
(5, 'Konsole do gier'),
(6, 'Akcesoria komputerowe'),
(7, 'Podzespoły PC'),
(8, 'Sprzęt audio'),
(9, 'Kamery i aparaty'),
(10, 'Inteligentne urządzenia');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `status`
--

CREATE TABLE `status` (
  `status_id` int(11) NOT NULL,
  `status_name` varchar(15) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `users`
--

CREATE TABLE `users` (
  `user_id` int(11) NOT NULL,
  `user_type_id` int(11) DEFAULT NULL,
  `user_nickname` varchar(30) DEFAULT NULL,
  `user_name` varchar(30) DEFAULT NULL,
  `user_surname` varchar(40) DEFAULT NULL,
  `user_password` varchar(100) DEFAULT NULL,
  `user_adress` varchar(50) DEFAULT NULL,
  `user_adress_nr` int(11) DEFAULT NULL,
  `user_address_local_nr` int(11) DEFAULT NULL,
  `user_phone` int(9) DEFAULT NULL,
  `user_email` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`user_id`, `user_type_id`, `user_nickname`, `user_name`, `user_surname`, `user_password`, `user_adress`, `user_adress_nr`, `user_address_local_nr`, `user_phone`, `user_email`) VALUES
(12, 1, 'abc', NULL, NULL, '9AJXDSxUFdJBAT4OJJXLC3eyLtRnTSfgyD8xVQBymBDslBYSe9QLLFYSUeWHVwIi', NULL, NULL, NULL, NULL, NULL),
(13, 1, 'limon', NULL, NULL, '9AJXDSxUFdJBAT4OJJXLC3eyLtRnTSfgyD8xVQBymBDslBYSe9QLLFYSUeWHVwIi', NULL, NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `user_type`
--

CREATE TABLE `user_type` (
  `type_id` int(11) NOT NULL,
  `type_name` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Dumping data for table `user_type`
--

INSERT INTO `user_type` (`type_id`, `type_name`) VALUES
(1, 'User'),
(2, 'Admin');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `cart`
--
ALTER TABLE `cart`
  ADD PRIMARY KEY (`cart_id`),
  ADD KEY `fk_cart_user` (`cart_user_id`),
  ADD KEY `fk_cart_product` (`cart_product_id`);

--
-- Indeksy dla tabeli `manufacturers`
--
ALTER TABLE `manufacturers`
  ADD PRIMARY KEY (`manufacturer_id`);

--
-- Indeksy dla tabeli `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`order_id`),
  ADD KEY `fk_order_status` (`order_status_id`),
  ADD KEY `fk_order_user` (`order_user_id`);

--
-- Indeksy dla tabeli `order_products`
--
ALTER TABLE `order_products`
  ADD PRIMARY KEY (`order_product_id`),
  ADD KEY `fk_product_orders` (`order_product_orders_id`),
  ADD KEY `fk_order_product_product` (`order_product_products_id`);

--
-- Indeksy dla tabeli `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`product_id`),
  ADD KEY `fk_product_category_id` (`product_category_id`),
  ADD KEY `fk_manufacturer` (`product_manufacturer_id`);

--
-- Indeksy dla tabeli `products_category`
--
ALTER TABLE `products_category`
  ADD PRIMARY KEY (`category_id`);

--
-- Indeksy dla tabeli `status`
--
ALTER TABLE `status`
  ADD PRIMARY KEY (`status_id`);

--
-- Indeksy dla tabeli `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`),
  ADD KEY `fk_user_type` (`user_type_id`);

--
-- Indeksy dla tabeli `user_type`
--
ALTER TABLE `user_type`
  ADD PRIMARY KEY (`type_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `cart`
--
ALTER TABLE `cart`
  MODIFY `cart_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `manufacturers`
--
ALTER TABLE `manufacturers`
  MODIFY `manufacturer_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

--
-- AUTO_INCREMENT for table `orders`
--
ALTER TABLE `orders`
  MODIFY `order_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `order_products`
--
ALTER TABLE `order_products`
  MODIFY `order_product_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `product_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=161;

--
-- AUTO_INCREMENT for table `products_category`
--
ALTER TABLE `products_category`
  MODIFY `category_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `status`
--
ALTER TABLE `status`
  MODIFY `status_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `user_type`
--
ALTER TABLE `user_type`
  MODIFY `type_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `cart`
--
ALTER TABLE `cart`
  ADD CONSTRAINT `fk_cart_product` FOREIGN KEY (`cart_product_id`) REFERENCES `products` (`product_id`),
  ADD CONSTRAINT `fk_cart_user` FOREIGN KEY (`cart_user_id`) REFERENCES `users` (`user_id`);

--
-- Constraints for table `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `fk_order_status` FOREIGN KEY (`order_status_id`) REFERENCES `status` (`status_id`),
  ADD CONSTRAINT `fk_order_user` FOREIGN KEY (`order_user_id`) REFERENCES `users` (`user_id`);

--
-- Constraints for table `order_products`
--
ALTER TABLE `order_products`
  ADD CONSTRAINT `fk_order_product_product` FOREIGN KEY (`order_product_products_id`) REFERENCES `products` (`product_id`),
  ADD CONSTRAINT `fk_product_orders` FOREIGN KEY (`order_product_orders_id`) REFERENCES `orders` (`order_id`);

--
-- Constraints for table `products`
--
ALTER TABLE `products`
  ADD CONSTRAINT `fk_manufacturer` FOREIGN KEY (`product_manufacturer_id`) REFERENCES `manufacturers` (`manufacturer_id`),
  ADD CONSTRAINT `fk_product_category_id` FOREIGN KEY (`product_category_id`) REFERENCES `products_category` (`category_id`);

--
-- Constraints for table `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `fk_user_type` FOREIGN KEY (`user_type_id`) REFERENCES `user_type` (`type_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
