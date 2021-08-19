using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    [DataContract]
    public class PaymentDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string PaymentType { get; set; }
    }
}
