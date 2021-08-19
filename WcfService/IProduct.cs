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
    public interface IProduct
    {
        [OperationContract]
        IList<ProductDto> GetProduct();
        [OperationContract]
        ProductDto GetProductById(int productid);
        [OperationContract]
        KeyValuePair<bool, string> CreateProduct(ProductDto prodct);
        [OperationContract]
        KeyValuePair<bool, string> UpdateProduct(ProductDto productDto);
        [OperationContract]
        KeyValuePair<bool, string> DeleteProduct(int id);



    }
}
