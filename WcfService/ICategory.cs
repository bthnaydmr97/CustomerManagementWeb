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
    public interface ICategory
    {
        [OperationContract]
        IList<CategoryDto> GetCategroy();

        [OperationContract]
        CategoryDto GetCategoryById(int categoryid);

        [OperationContract]
        Category CreateCategory(CategoryDto ct);

        [OperationContract]
        KeyValuePair<bool, string> UpdateCategory(CategoryDto categoryDto);

        [OperationContract]
        KeyValuePair<bool, string> DeleteCategory(int id);

    }
}
