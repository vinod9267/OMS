CREATE PROCEDURE `OMS_DeleteOrder`(Orderid BIGINT(20))
BEGIN
delete from tblshippinginformation where tblshippinginformation.Shippingid =(select Shippingid from tblorders 
      where tblorders.OrderId = Orderid);
       delete from tblbuyerinformation where tblbuyerinformation.BuyerId =(select BuyerId from tblorders 
      where tblorders.OrderId = Orderid);
      delete from tblproducts where productid in(select productid from tblorders where tblorders.orderid=Orderid);
      delete from tblorders where orderid= Orderid;
      
      
END