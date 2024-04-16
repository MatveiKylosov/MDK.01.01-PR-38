CREATE TABLE `Categories` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Description` varchar(45) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE `Items` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Description` varchar(1000) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Img` varchar(500) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Price` varchar(45) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `IdCategories` varchar(45) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;