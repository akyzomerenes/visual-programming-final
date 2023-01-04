-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 04 Oca 2023, 15:27:00
-- Sunucu sürümü: 10.4.27-MariaDB
-- PHP Sürümü: 8.1.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `stoktakip`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kategoribilgileri`
--

CREATE TABLE `kategoribilgileri` (
  `kategori` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `kategoribilgileri`
--

INSERT INTO `kategoribilgileri` (`kategori`) VALUES
('Çakmak'),
('Bileklik'),
('Anahtarlık'),
('Parfüm'),
('Saat'),
('Kupa Bardak'),
('Doğal Taş'),
('Havlu'),
('Mum'),
('Organik Sabun'),
('Çorap'),
('Çiçek'),
('Uzaktan Kumandalı Araba'),
('Giysi'),
('Ayna'),
('Yüzük');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `markabilgileri`
--

CREATE TABLE `markabilgileri` (
  `kategori` varchar(50) NOT NULL,
  `marka` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `markabilgileri`
--

INSERT INTO `markabilgileri` (`kategori`, `marka`) VALUES
('Çakmak', 'zippo'),
('Çakmak', 'clipper'),
('Parfüm', 'Jagler'),
('Saat', 'Casio'),
('Saat', 'casio'),
('Saat', 'lacoste'),
('Saat', 'seiko'),
('Saat', 'nacar'),
('Kupa Bardak', 'GSSTORE'),
('Çorap', 'Pierre Cardin'),
('Çorap', 'Lacoste'),
('Çorap', 'Nike'),
('Çorap', 'Adidas'),
('Yüzük', 'Diamond'),
('Yüzük', 'Star'),
('Havlu', 'Özdilek'),
('Organik Sabun', 'Sabuncum'),
('Çiçek', 'Çiçekcim'),
('Uzaktan Kumandalı Araba', 'Opel'),
('Giysi', 'Eldiven'),
('Doğal Taş', 'Kehribar'),
('Doğal Taş', 'Sitrin');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `musteri`
--

CREATE TABLE `musteri` (
  `tc` varchar(50) NOT NULL,
  `adsoyad` varchar(50) NOT NULL,
  `telefon` varchar(50) NOT NULL,
  `adres` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `musteri`
--

INSERT INTO `musteri` (`tc`, `adsoyad`, `telefon`, `adres`, `email`) VALUES
('4352435234', 'Fazlı Erdoğan', '543534534', 'fgsdgsdg', 'gfgsdgsdg'),
('254545254625', 'Fazıl Erdoğan', '05562252522', 'gfdsgsfdgda', 'fdsmfdga@fsvs'),
('102102', 'yüziki', '102102102102', '102.sokak mars', 'yüziki@gmail.com');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `satis`
--

CREATE TABLE `satis` (
  `tc` varchar(11) NOT NULL,
  `adsoyad` varchar(50) NOT NULL,
  `telefon` varchar(11) NOT NULL,
  `barkodno` varchar(50) NOT NULL,
  `urunadi` varchar(50) NOT NULL,
  `miktari` int(50) NOT NULL,
  `satisfiyati` decimal(18,2) NOT NULL,
  `toplamfiyati` decimal(18,2) NOT NULL,
  `tarih` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `satis`
--

INSERT INTO `satis` (`tc`, `adsoyad`, `telefon`, `barkodno`, `urunadi`, `miktari`, `satisfiyati`, `toplamfiyati`, `tarih`) VALUES
('', '', '', '109', 'nacar342', 1, '608.00', '608.00', '31.12.2022 14:54:23'),
('', '', '', '999', 'zipponewgumus', 5, '60.00', '300.00', '31.12.2022 14:54:23'),
('', '', '', '1000', 'bardaknew', 1, '13.00', '13.00', '31.12.2022 14:54:23'),
('', '', '', '105', 'redçakmak', 1, '3.00', '3.00', '31.12.2022 14:54:23'),
('', '', '', '101', 'ÇAKMAKCLIİPPER', 1, '40.00', '40.00', '31.12.2022 14:54:23'),
('', '', '', '106', 'redsaat', 1, '550.00', '550.00', '31.12.2022 14:54:23'),
('', '', '', '999', 'zipponewgumus', 4, '60.00', '240.00', '31.12.2022 14:56:00'),
('', '', '', '1000', 'bardaknew', 4, '13.00', '52.00', '1.01.2023 23:15:50'),
('56989571511', 'Ali Mehmet Yüce', '09874896987', '1001', 'newlacosteblack', 5, '1000.00', '5000.00', '1.01.2023 23:16:27'),
('77777777777', 'Yedi Emin ', '0777777777', '200', 'SİTRİNDOĞALTAŞ', 5, '65.00', '325.00', '2.01.2023 21:26:24'),
('77777777777', 'Yedi Emin ', '0777777777', '201', 'Kaliteli Kalın Kışlık Çorap', 1, '35.00', '35.00', '2.01.2023 21:26:25'),
('77777777777', 'Yedi Emin ', '0777777777', '202', 'PapatyaKokuluSabun', 3, '30.00', '90.00', '2.01.2023 21:26:25'),
('55555555555', 'Beşir Beş', '0555555555', '201', 'Kaliteli Kalın Kışlık Çorap', 5, '35.00', '175.00', '2.01.2023 21:52:54'),
('55555555555', 'Beşir Beş', '0555555555', '201', 'Kaliteli Kalın Kışlık Çorap', 1, '35.00', '35.00', '2.01.2023 21:52:54'),
('55555555555', 'Beşir Beş', '0555555555', '205', 'KehribarDoğalTaşı', 10, '55.00', '550.00', '2.01.2023 21:52:54'),
('55555555555', 'Beşir Beş', '0555555555', '205', 'KehribarDoğalTaşı', 100, '55.00', '5500.00', '2.01.2023 21:53:51'),
('55555555555', 'Beşir Beş', '0555555555', '204', 'LacosteEldiven', 10, '150.00', '1500.00', '2.01.2023 21:53:51'),
('55555555555', 'Beşir Beş', '0555555555', '203', 'Astra ', 1, '230.00', '230.00', '2.01.2023 21:53:51'),
('55555555555', 'Beşir Beş', '0555555555', '200', 'SİTRİNDOĞALTAŞ', 1000, '65.00', '65000.00', '2.01.2023 21:53:51'),
('55555555555', 'Beşir Beş', '0555555555', '201', 'Kaliteli Kalın Kışlık Çorap', 50, '35.00', '1750.00', '2.01.2023 21:53:51'),
('55555555555', 'Beşir Beş', '0555555555', '200', 'SİTRİNDOĞALTAŞ', 1, '65.00', '65.00', '2.01.2023 21:53:51'),
('55555555555', 'Beşir Beş', '0555555555', '202', 'PapatyaKokuluSabun', 100, '30.00', '3000.00', '2.01.2023 21:53:51');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `sepet`
--

CREATE TABLE `sepet` (
  `tc` varchar(11) NOT NULL,
  `adsoyad` varchar(50) NOT NULL,
  `telefon` varchar(11) NOT NULL,
  `barkodno` varchar(50) NOT NULL,
  `urunadi` varchar(50) NOT NULL,
  `miktari` int(50) NOT NULL,
  `satisfiyati` decimal(18,2) NOT NULL,
  `toplamfiyati` decimal(18,2) NOT NULL,
  `tarih` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `urun`
--

CREATE TABLE `urun` (
  `barkodno` varchar(50) NOT NULL,
  `kategori` varchar(50) NOT NULL,
  `marka` varchar(50) NOT NULL,
  `urunadi` varchar(50) NOT NULL,
  `miktari` int(50) NOT NULL,
  `alisfiyati` decimal(18,2) NOT NULL,
  `satisfiyati` decimal(18,2) NOT NULL,
  `tarih` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `urun`
--

INSERT INTO `urun` (`barkodno`, `kategori`, `marka`, `urunadi`, `miktari`, `alisfiyati`, `satisfiyati`, `tarih`) VALUES
('965784256856', 'Çakmak', 'clipper', 'Kırmızı Clipper', 30, '5.00', '7.50', '27.12.2022 00:16:10'),
('101', 'Çakmak', 'zippo', 'Zippo Mercedes-Benz logo', 99, '2550.00', '4550.00', '27.12.2022 00:31:31'),
('215', 'Oyuncak', 'oyuncaksatan ltd.sti', 'Tatlı AYI', 30, '45.00', '75.00', '30.12.2022 21:35:20'),
('216', 'Kupa Bardak', 'GSSTORE', 'CİMBOMBOM', 200, '10.00', '85.00', '30.12.2022 21:37:55'),
('105', 'Çakmak', 'clipper', 'redçakmak', 29, '1.00', '3.00', '31.12.2022 03:00:48'),
('106', 'Parfüm', 'Jagler', 'parfumjaglerr', 29, '60.00', '120.00', '31.12.2022 03:02:02'),
('101', 'Çakmak', 'clipper', 'ÇAKMAKCLIİPPER', 29, '30.00', '40.00', '31.12.2022 03:03:50'),
('106', 'Saat', 'lacoste', 'redsaat', 29, '500.00', '550.00', '31.12.2022 03:04:08'),
('43254235243', 'Çakmak', 'clipper', 'fdaaf', 10000, '13.00', '25.00', '31.12.2022 03:06:47'),
('104', 'Saat', 'Casio', 'dsaaer24ewq', 42, '100.00', '200.00', '31.12.2022 03:09:53'),
('109', 'Saat', 'nacar', 'nacar342', 49, '600.00', '608.00', '31.12.2022 03:13:28'),
('3432423', 'Çakmak', 'zippo', 'dafdasdf', 43, '43.00', '54.00', '31.12.2022 03:13:39'),
('4324234', 'Kupa Bardak', 'GSSTORE', 'dfasf', 43, '54.00', '65.00', '31.12.2022 03:13:50'),
('4324234', 'Kupa Bardak', 'GSSTORE', 'rqgsdgg', 76, '87.00', '876.00', '31.12.2022 03:14:11'),
('999', 'Çakmak', 'zippo', 'zipponewgumus', 41, '30.00', '60.00', '31.12.2022 14:51:09'),
('1000', 'Kupa Bardak', 'GSSTORE', 'bardaknew', 45, '10.00', '13.00', '31.12.2022 14:51:24'),
('1001', 'Saat', 'lacoste', 'newlacosteblack', 295, '600.00', '1000.00', '31.12.2022 14:51:45'),
('200', 'Doğal Taş', 'Sitrin', 'SİTRİNDOĞALTAŞ', 109494, '15.00', '65.00', '2.01.2023 20:36:54'),
('201', 'Çorap', 'Pierre Cardin', 'Kaliteli Kalın Kışlık Çorap', 993, '6.00', '35.00', '2.01.2023 20:37:22'),
('202', 'Organik Sabun', 'Sabuncum', 'PapatyaKokuluSabun', 997, '10.00', '30.00', '2.01.2023 20:37:47'),
('203', 'Uzaktan Kumandalı Araba', 'Opel', 'Astra ', 1099, '165.00', '230.00', '2.01.2023 20:38:12'),
('204', 'Giysi', 'Eldiven', 'LacosteEldiven', 10190, '65.00', '150.00', '2.01.2023 20:38:43'),
('205', 'Doğal Taş', 'Kehribar', 'KehribarDoğalTaşı', 9990, '30.00', '55.00', '2.01.2023 20:39:09');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
