using ACR.Entity.Concrete;

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
