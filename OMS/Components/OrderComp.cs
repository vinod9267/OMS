using Microsoft.Extensions.Options;
using OMS.Constants;
using OMS.DataAccess;
using OMS.Datacontracts;
using System.Collections.Generic;

namespace OMS.Components
{
    public class OrderComp
    {
        IOptions<OMSConnection> _connectionSettings;
        public OrderComp(IOptions<OMSConnection> connectionSettings)
        {
            _connectionSettings = connectionSettings;
        }

        /// <summary>
        /// Save order
        /// </summary>
        /// <param name="OrderInformation"></param>
        /// <returns></returns>
        public long Saveorder(Order OrderInformation)
        {
            long buyerid = SaveBuyerInformation(OrderInformation.BuyerInformation);
            long shipperid = SaveShippingInformation(OrderInformation.ShippingInformation);
            long orderid = SaveOrderwithBuyerAndShipperid(OrderStatus.Placed, buyerid, shipperid);
            SaveOrderDetails(orderid, OrderInformation.OrderDetails);
            return orderid;
        }

        /// <summary>
        /// SaveBuyerInformation
        /// </summary>
        /// <param name="BuyerInformation"></param>
        /// <returns></returns>
        public long SaveBuyerInformation(BuyerInformation BuyerInformation)
        {
            OrderDB orderDB = new OrderDB(_connectionSettings);
            return orderDB.SaveBuyerInformation(BuyerInformation);

        }

        /// <summary>
        /// SaveShippingInformation
        /// </summary>
        /// <param name="ShippingInformation"></param>
        /// <returns></returns>
        public long SaveShippingInformation(ShippingInformation ShippingInformation)
        {
            OrderDB orderDB = new OrderDB(_connectionSettings);
            return orderDB.SaveShippingInformation(ShippingInformation);


        }

        /// <summary>
        /// SaveOrderwithBuyerAndShipperid
        /// </summary>
        /// <param name="Status"></param>
        /// <param name="BuyerId"></param>
        /// <param name="ShipperID"></param>
        /// <returns></returns>
        public long SaveOrderwithBuyerAndShipperid(OrderStatus Status, long BuyerId, long ShipperID)
        {
            OrderDB orderDB = new OrderDB(_connectionSettings);
            return orderDB.SaveOrder(Status, BuyerId, ShipperID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="OrderId"></param>
        /// <param name="OrderDetails"></param>
        public void SaveOrderDetails(long OrderId, List<OrderItem> OrderDetails)
        {
            OrderDB orderDB = new OrderDB(_connectionSettings);
            foreach (var item in OrderDetails)
            {
                long productId = orderDB.SaveProduct(item.Product, OrderId);

            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        public Order GetOrderDetailsByOrderId(long OrderId)
        {
            OrderDB orderDB = new OrderDB(_connectionSettings);
            Order objOrder = orderDB.GetOrderDetailsByOrderId(OrderId);
            OrderStatus OrderDisplayStatus = (OrderStatus)int.Parse(objOrder.Status);
            string Orderstatus = OrderDisplayStatus.ToString();
            objOrder.Status = Orderstatus;
            return objOrder;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Orderid"></param>
        public void DeleteOrder(long Orderid)
        {
            OrderDB orderDB = new OrderDB(_connectionSettings);
            orderDB.DeleteOrder(Orderid);

        }
    }
}
