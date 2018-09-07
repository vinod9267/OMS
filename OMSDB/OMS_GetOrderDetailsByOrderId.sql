CREATE PROCEDURE `OMS_GetOrderDetailsByOrderId`(
  
   OrderId    bigint(20))
BEGIN
select Orderid, Orderstatus as Status from tblorders where tblorders.OrderId= OrderId;
select * from tblBuyerInformation b join tblorders o ON  b.Buyerid=o.Buyerid and o.OrderId= OrderId ;
select * from tblShippingInformation s join tblorders o ON s.ShippingId=o.ShippingId and o.OrderId= OrderId ;
 select p.name, p.Weight, p.Height, p.Image, p.Sku, p.Barcode, p.Quantity, p.Cost from tblproducts  p
 
  join tblorders o
   On o.OrderId = p.OrderId and o.OrderId = OrderId ;
   END