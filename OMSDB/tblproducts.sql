CREATE TABLE `tblproducts` (
  `ProductId` bigint(20) NOT NULL AUTO_INCREMENT,
  `OrderId` bigint(20) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Weight` varchar(50) NOT NULL,
  `Height` varchar(50) NOT NULL,
  `Image` varchar(50) NOT NULL,
  `Sku` varchar(50) NOT NULL,
  `Barcode` varchar(50) NOT NULL,
  `Quantity` float NOT NULL,
  `Cost` float(20,4) NOT NULL,
  PRIMARY KEY (`ProductId`),
  KEY `OrderId` (`OrderId`),
  CONSTRAINT `tblproducts_ibfk_1` FOREIGN KEY (`OrderId`) REFERENCES `tblorders` (`OrderId`)
) ENGINE=InnoDB AUTO_INCREMENT=120 DEFAULT CHARSET=utf8