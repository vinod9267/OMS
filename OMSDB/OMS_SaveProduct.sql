CREATE  PROCEDURE `OMS_SaveProduct`(OrderId bigint(20),
  Name	varchar(50),
Weight	varchar(50),
Height	varchar(50),
Image	varchar(50),
Sku	varchar(50),
Barcode	varchar(50),
Quantity	float,
Cost	float(20,4)
)
BEGIN
      INSERT INTO tblproducts(
      OrderId,
Name,
Weight,
Height,
Image,
Sku,
Barcode,
Quantity,
Cost)
      VALUES (OrderId, Name,
Weight,
Height,
Image,
Sku,
Barcode,
Quantity,
Cost);

SELECT last_insert_id();
   END