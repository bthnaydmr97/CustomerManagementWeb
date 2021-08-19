using Dto;
using Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfService
{
    [ServiceContract]
    public interface ICustomer
    {
        [OperationContract]
        IList<CustomerDto> GetCustomer();

        [OperationContract]
        CustomerDto GetCustomerById(int customerid);

        [OperationContract]
        Customer CreateCustomer(CustomerDto cstmr);

        [OperationContract]
        KeyValuePair<bool, string> UpdateCustomer(CustomerDto customerDto);

        [OperationContract]
        KeyValuePair<bool, string> DeleteCustomer(int id);

        [OperationContract]
        CustomerDto GetOrderHistoryById(int id);



    }
}
