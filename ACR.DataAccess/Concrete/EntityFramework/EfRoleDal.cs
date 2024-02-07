using ACR.DataAccess.Abstract;
using ACR.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.DataAccess.Concrete.EntityFramework
{
    public class EfRoleDal : EfGenericRepository<Role, ACRContext>, IRoleDal
    {
        public IEnumerable<Role> GetRolesWithSameName(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
