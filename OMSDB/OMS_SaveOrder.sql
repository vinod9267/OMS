CREATE  PROCEDURE `OMS_SaveOrder`(
  Orderstatus	varchar(50),
BuyerId	bigint(20),
ShippingId	bigint(20)
)
BEGIN
      INSERT INTO tblorders(
Orderstatus,
BuyerId,
ShippingId)
      VALUES (Orderstatus,
BuyerId,
ShippingId);

SELECT last_insert_id();
   END