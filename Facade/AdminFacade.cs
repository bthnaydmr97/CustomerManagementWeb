using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class AdminFacade : FacadeBase
    {
        public bool CheckLogin(string pass, string username)
        {
            username = username.ToLower();
            pass = pass.ToLower();
            var login = EntityModel.AdminLogin.Any(x => x.AdminUsername == username && x.AdminPassword == pass);
            return login;
        }
    }
}
