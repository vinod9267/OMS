CREATE TABLE `tblorders` (
  `OrderId` bigint(20) NOT NULL AUTO_INCREMENT,
  `Orderstatus` char(1) NOT NULL,
  `Buyerid` bigint(20) NOT NULL,
  `Shippingid` bigint(20) NOT NULL,
  PRIMARY KEY (`OrderId`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8