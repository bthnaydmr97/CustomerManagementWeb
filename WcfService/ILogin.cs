using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfService
{
    [ServiceContract]
    public interface ILogin
    {
        [OperationContract]
        bool CheckLogin(string pass, string username);

    }
}
