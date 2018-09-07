using System.Runtime.Serialization;
using static OMS.Components.Message;

namespace OMS.Datacontracts
{
    [DataContract]
    public class ResponseMessage
    {
        [DataMember]
        public MessageCode Code { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string OrderID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Order Order { get; set; } = null;

      



    }
}
