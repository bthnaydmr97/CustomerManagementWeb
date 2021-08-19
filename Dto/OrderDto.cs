using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    [DataContract]
    public class OrderDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public int PaymentId { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string PaymentType { get; set; }
        [DataMember]
        public double OrderPrice { get; set; }


    }
}
