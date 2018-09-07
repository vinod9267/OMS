using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OMS.Datacontracts
{
    public class OrderItem
    {
       [DataMember()]
        public Product Product { get; set; } = new Product();

    }
}
