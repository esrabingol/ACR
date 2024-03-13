using ACR.Business.Models;
using ACR.Entity.Concrete;

namespace ACR.Business.Abstract
{
	public interface IRegisterService
	{
		Task<User> Add(UserRegisterModelDTO register);
		User Update(User register);
		void Delete(User register);
		bool PasswordSignIn(string userEmail, string userPassword, int roleId);
		Task<User> FindUser(UserLoginModelDTO loginModel);
		Task<int?> GetRoleIdByEmail(string email);
	}
}
