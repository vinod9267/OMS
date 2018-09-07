CREATE PROCEDURE `OMS_InsertShippingInformation`(
  firstName	varchar(50),
lastName	varchar(50),
country	varchar(50),
state	varchar(50),
city	varchar(50),
email	varchar(50),
zip	double,
phone	varchar(50),
mobile	varchar(50),
fax	double,
street	varchar(50))
BEGIN
      INSERT INTO tblShippingInformation(firstName,
lastName,
country,
state,
city,
email,
zip,
phone,
mobile,
fax,
street)
      VALUES (firstName,
lastName,
country,
state,
city,
email,
zip,
phone,
mobile,
fax,
street);

SELECT last_insert_id();
   END