using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class FacadeBase
    {
        private readonly CustomerManagementDBEntities _entityModel;

        public CustomerManagementDBEntities EntityModel
        {
            get
            {
                return _entityModel ?? new CustomerManagementDBEntities();
            }
        }

        public FacadeBase()
        {
            _entityModel = new CustomerManagementDBEntities();
        }
    }
}
