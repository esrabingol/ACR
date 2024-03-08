using ACR.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.DataAccess.Abstract
{
    public interface IRegisterDal:IRepository<User>
    {

		bool PasswordSignIn(string userEmail, string userPassword, int roleId);
		Task<User> FindByEmail(string email);

    }
}
