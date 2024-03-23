using ACR.Entity.Concrete;

namespace ACR.DataAccess.Abstract
{
	public interface IRoleDal : IRepository<Role>
	{
		IEnumerable<Role> GetRolesWithSameName(string roleName);
	}
}
