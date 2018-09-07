using System.Runtime.Serialization;

namespace OMS.Datacontracts
{
    public class ShippingInformation
    {
        [DataMember()]
        public string FirstName { get; set; }
        [DataMember()]
        public string LastName { get; set; }
        [DataMember()]
        public string Country { get; set; }
        [DataMember()]
        public string State { get; set; }
        [DataMember()]
        public string City { get; set; }
        [DataMember()]
        public string Email { get; set; }
        [DataMember()]
        public string Zip { get; set; }
        [DataMember()]
        public string Phone { get; set; }
        [DataMember()]
        public string Mobile { get; set; }
        [DataMember()]
        public string Fax { get; set; }
        [DataMember()]
        public string Street { get; set; }
        
    }
}
