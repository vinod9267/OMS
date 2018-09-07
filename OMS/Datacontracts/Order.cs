using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OMS.Datacontracts
{

    public class Order
    {
        [DataMember()]
        public int Orderid { get; set; } = 0;
        [DataMember()]
        public string Status { get; set; }
        /// <summary>
        /// Buyer Information
        /// </summary>
        [DataMember()]
        public BuyerInformation BuyerInformation { get; set; } = new BuyerInformation();

        /// <summary>
        /// Shipping Information
        /// </summary>
        [DataMember()]
        public ShippingInformation ShippingInformation { get; set; } = new ShippingInformation();

        /// <summary>
        /// Order Details
        /// </summary>
        [DataMember()]
        public List<OrderItem> OrderDetails { get; set; } = new List<OrderItem>();

        /// <summary>
        /// OrderStatus
        /// </summary>
        
    }


}
