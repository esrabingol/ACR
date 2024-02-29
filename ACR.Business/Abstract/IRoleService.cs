using ACR.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Business.Abstract
{
    public interface IRoleService
    {
        void AddRole(Role role);

        void UpdateRole(Role role);

        IEnumerable<Role> GetRolesWithSameName(string roleName);

		IEnumerable<Role> GetRoles();
		
	}
}
