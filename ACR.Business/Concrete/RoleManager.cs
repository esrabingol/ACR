using ACR.Business.Abstract;
using ACR.DataAccess.Abstract;
using ACR.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Business.Concrete
{
    public class RoleManager : IRoleService
    {
        private IRoleDal _roleDal;
        public RoleManager(IRoleDal roleDal) 
        {
            _roleDal = roleDal;
        }
        public void AddRole(Role role)
        {
            if (role != null)
            {
                _roleDal.Add(role);
                
            }
            else
            {
                throw new ArgumentNullException(nameof(role), "Hata: Role nesnesi null olamaz.");
            }
        }

        public void DeleteRole(int roleId)
        {
            if (roleId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(roleId), "Hata: Geçersiz roleId değeri.");
            }
            else
            {
                _roleDal.Delete(roleId);
            }
        }

        public IEnumerable<Role> GetRolesWithSameName(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                throw new ArgumentException("Hata: roleName boş olamaz veya null olamaz.", nameof(roleName));
            }
            else
            {
                return _roleDal.GetRolesWithSameName(roleName);
            }
        }

        public void UpdateRole(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role), "Hata: Role nesnesi null olamaz.");
            }
            else
            {
                _roleDal.Update(role);
            }
        }
    }
}
