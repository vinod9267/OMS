CREATE TABLE `tblbuyerinformation` (
  `Buyerid` bigint(20) NOT NULL AUTO_INCREMENT,
  `firstName` varchar(50) NOT NULL,
  `lastName` varchar(50) NOT NULL,
  `country` varchar(50) NOT NULL,
  `countryCode` varchar(50) NOT NULL,
  `state` varchar(50) NOT NULL,
  `city` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `zip` double NOT NULL,
  `phone` varchar(50) NOT NULL,
  `mobile` varchar(50) NOT NULL,
  `fax` double NOT NULL,
  `street` varchar(50) NOT NULL,
  PRIMARY KEY (`Buyerid`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8