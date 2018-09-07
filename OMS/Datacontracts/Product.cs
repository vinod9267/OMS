using System.Runtime.Serialization;

namespace OMS.Datacontracts
{
    public class Product
    {
        [DataMember()]
        public string Name { get; set; }
        [DataMember()]
        public decimal Weight { get; set; }
        [DataMember()]
        public decimal Height { get; set; }
        [DataMember()]
        public string Image { get; set; }
        [DataMember()]
        public string SKU { get; set; }
        [DataMember()]
        public string Barcode { get; set; }
        [DataMember()]
        public double Quantity { get; set; }
        [DataMember()]
        public decimal Cost { get; set; }
    }
}
