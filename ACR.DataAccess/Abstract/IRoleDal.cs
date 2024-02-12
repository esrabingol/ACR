using ACR.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.DataAccess.Abstract
{
    public interface IRoleDal : IRepository<Role>
    {
      

        // Aynı rolde olanları listeleme
         IEnumerable<Role> GetRolesWithSameName(string roleName);
    }
}
