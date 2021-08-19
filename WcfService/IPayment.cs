using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfService
{
    [ServiceContract]
    public interface IPayment
    {
        [OperationContract]
        IList<PaymentDto> GetPayment();
        [OperationContract]
        PaymentDto GetPaymentById(int paymentid);
    }
}
