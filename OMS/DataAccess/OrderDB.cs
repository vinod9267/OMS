using Microsoft.Extensions.Options;
using OMS.Components;
using MySql.Data.MySqlClient;
using OMS.Datacontracts;
using System.Data;
using Dapper;
using System.Linq;
using OMS.Constants;
using System.Collections.Generic;

namespace OMS.DataAccess
{
    public class OrderDB
    {
        static MySqlConnection mysqlConnection;
        IOptions<OMSConnection> _connectionSettings;
       
        public OrderDB(IOptions<OMSConnection> connectionSettings)
        {
            _connectionSettings = connectionSettings;
            mysqlConnection = new MySqlConnection(_connectionSettings.Value.DefaultConnection);
        }

        #region Save
        /// <summary>
        /// Save Buyer Information
        /// </summary>
        /// <param name="BuyerInformation"></param>
        /// <returns></returns>
        public long SaveBuyerInformation(BuyerInformation BuyerInformation)
        {
            long Buyerid = 0;
            using (mysqlConnection)
            {
                if (mysqlConnection.State != ConnectionState.Open)
                { mysqlConnection.Open(); }
                var p = new DynamicParameters();

                p.Add("@firstName", dbType: DbType.String, value: BuyerInformation.FirstName);
                p.Add("@lastName", dbType: DbType.String, value: BuyerInformation.LastName);
                p.Add("@country", dbType: DbType.String, value: BuyerInformation.Country);
                p.Add("@state", dbType: DbType.String, value: BuyerInformation.State);
                p.Add("@city", dbType: DbType.String, value: BuyerInformation.City);
                p.Add("@email", dbType: DbType.String, value: BuyerInformation.Email);
                p.Add("@zip", dbType: DbType.Double, value: BuyerInformation.Zip);
                p.Add("@phone", dbType: DbType.String, value: BuyerInformation.Phone);
                p.Add("@mobile", dbType: DbType.String, value: BuyerInformation.Mobile);
                p.Add("@fax", dbType: DbType.Double, value: BuyerInformation.Fax);
                p.Add("@street", dbType: DbType.String, value: BuyerInformation.Street);

                var result = mysqlConnection.Query<long>("OMS_InsertBuyerInformation", p, commandType: CommandType.StoredProcedure);
                if (result != null && result.Count() > 0)
                {
                    Buyerid = result.FirstOrDefault();
                }
                return Buyerid;
            }
        }

        /// <summary>
        /// Save Shipping Information
        /// </summary>
        /// <param name="ShippingInformation"></param>
        /// <returns></returns>
        public long SaveShippingInformation(ShippingInformation ShippingInformation)
        {
            long ShippingId = 0;
            using (mysqlConnection)
            {
                if (mysqlConnection.State != ConnectionState.Open)
                { mysqlConnection.Open(); }
                var p = new DynamicParameters();

                p.Add("@firstName", dbType: DbType.String, value: ShippingInformation.FirstName);
                p.Add("@lastName", dbType: DbType.String, value: ShippingInformation.LastName);
                p.Add("@country", dbType: DbType.String, value: ShippingInformation.Country);
                p.Add("@state", dbType: DbType.String, value: ShippingInformation.State);
                p.Add("@city", dbType: DbType.String, value: ShippingInformation.City);
                p.Add("@email", dbType: DbType.String, value: ShippingInformation.Email);
                p.Add("@zip", dbType: DbType.Double, value: ShippingInformation.Zip);
                p.Add("@phone", dbType: DbType.String, value: ShippingInformation.Phone);
                p.Add("@mobile", dbType: DbType.String, value: ShippingInformation.Mobile);
                p.Add("@fax", dbType: DbType.Double, value: ShippingInformation.Fax);
                p.Add("@street", dbType: DbType.String, value: ShippingInformation.Street);

                var result = mysqlConnection.Query<long>("OMS_InsertShippingInformation", p, commandType: CommandType.StoredProcedure);
                if (result != null && result.Count() > 0)
                {
                    ShippingId = result.FirstOrDefault();
                }
                return ShippingId;
            }
        }

        /// <summary>
        /// Save Order
        /// </summary>
        /// <param name="Status"></param>
        /// <param name="BuyerId"></param>
        /// <param name="ShipperID"></param>
        /// <returns></returns>
        public long SaveOrder(OrderStatus Status, long BuyerId, long ShipperID)
        {
            long OrderId = 0;
            using (mysqlConnection)
            {
                if (mysqlConnection.State != ConnectionState.Open)
                { mysqlConnection.Open(); }
                var p = new DynamicParameters();

                p.Add("@Orderstatus", dbType: DbType.String, value: Status);
                p.Add("@BuyerId", dbType: DbType.Int64, value: BuyerId);
                p.Add("@ShippingId", dbType: DbType.Int64, value: ShipperID);


                var result = mysqlConnection.Query<long>("OMS_SaveOrder", p, commandType: CommandType.StoredProcedure);
                if (result != null && result.Count() > 0)
                {
                    OrderId = result.FirstOrDefault();
                }
                return OrderId;
            }
        }

        /// <summary>
        /// Save Product
        /// </summary>
        /// <param name="Product"></param>
        /// <returns></returns>
        public long SaveProduct(Product Product, long OrderId)
        {
            long ProductId = 0;
            using (mysqlConnection)
            {
                if (mysqlConnection.State != ConnectionState.Open)
                { mysqlConnection.Open(); }
                var p = new DynamicParameters();

                p.Add("@OrderId", dbType: DbType.String, value: OrderId);
                p.Add("@Name", dbType: DbType.String, value: Product.Name);
                p.Add("@Weight", dbType: DbType.String, value: Product.Weight);
                p.Add("@Height", dbType: DbType.String, value: Product.Height);
                p.Add("@Image", dbType: DbType.String, value: Product.Image);
                p.Add("@Sku", dbType: DbType.String, value: Product.SKU);
                p.Add("@Barcode", dbType: DbType.String, value: Product.Barcode);
                p.Add("@Quantity", dbType: DbType.Double, value: Product.Quantity);
                p.Add("@Cost", dbType: DbType.Decimal, value: Product.Cost);


                var result = mysqlConnection.Query<long>("OMS_SaveProduct", p, commandType: CommandType.StoredProcedure);
                if (result != null && result.Count() > 0)
                {
                    ProductId = result.FirstOrDefault();
                }
                return ProductId;
            }
        }
        #endregion

        #region Retrieve
        /// <summary>
        /// Get Order Details By OrderId
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        public Order GetOrderDetailsByOrderId(long OrderId)
        {
            Order Orderinfo;
            using (mysqlConnection)
            {
                if (mysqlConnection.State != ConnectionState.Open)
                {
                    mysqlConnection.Open();
                }


                var p = new DynamicParameters();
                p.Add("@OrderId", dbType: DbType.Int64, value: OrderId);


                var multi = mysqlConnection.QueryMultiple("OMS_GetOrderDetailsByOrderId", p, commandTimeout: 120, commandType: CommandType.StoredProcedure);
                Orderinfo = multi.Read<Order>().FirstOrDefault();
                if (Orderinfo != null)
                {
                    Orderinfo.BuyerInformation = multi.Read<BuyerInformation>().FirstOrDefault();
                    Orderinfo.ShippingInformation = multi.Read<ShippingInformation>().FirstOrDefault();
                    List<OrderItem> OrderDetails = new List<OrderItem>();

                    var prod = multi.Read<Product>().ToList();

                    for (int i = 0; i < prod.Count; i++)
                    {
                        OrderItem orderItem = new OrderItem();
                        orderItem.Product = prod[i];
                        OrderDetails.Add(orderItem);
                    }
                    Orderinfo.OrderDetails = OrderDetails;
                }
            }
            return Orderinfo;
        }

        #endregion
        
        #region Delete
        /// <summary>
        /// Delete Order by order id
        /// </summary>
        /// <param name="Orderid"></param>
        public void DeleteOrder(long Orderid)
        {

            using (mysqlConnection)
            {

                if (mysqlConnection.State != ConnectionState.Open)
                { mysqlConnection.Open(); }

                var p = new DynamicParameters();
                p.Add("@Orderid", dbType: DbType.Int64, value: Orderid);


                long id = mysqlConnection.Execute("OMS_DeleteOrder", p, commandType: CommandType.StoredProcedure);

            }
            #endregion
        }
    }
}
