using ACR.Entity.Concrete;

namespace ACR.DataAccess.Abstract
{
	public interface IRegisterDal : IRepository<User>
	{
		bool PasswordSignIn(string userEmail, string userPassword, int roleId);
		Task<User> FindByEmail(string email);
        User UpdateUserInfo(User userInfo);
    }
}
