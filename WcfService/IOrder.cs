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
    public interface IOrder
    {
        [OperationContract]
        IList<OrderDto> GetOrder();
        [OperationContract]
        OrderDto GetOrderById(int orderid);
        [OperationContract]
        KeyValuePair<bool, string> CreateOrder(OrderDto order);
        [OperationContract]
        KeyValuePair<bool, string> DeleteOrder(int id);
    }
}
