using ACR.DataAccess.Abstract;
using ACR.Entity.Concrete;

namespace ACR.DataAccess.Concrete.EntityFramework
{
	public class EfRoleDal : EfGenericRepository<Role>, IRoleDal
	{
		public EfRoleDal(ACRContext context) : base(context)
		{
		}
		public IEnumerable<Role> GetRolesWithSameName(string roleName)
		{
			var rolesWithSameName = _context.Roles
		   .Where(role => role.RoleName == roleName)
		   .ToList();

			return rolesWithSameName;
		}
	}
}
