using ACR.Business.Models;
using ACR.Entity.Concrete;

namespace ACR.Business.Abstract
{
	public interface IRegisterService
	{
		Task<User> Add(UserRegisterModelDTO register);
		User UpdateUserInfo(User updateInfo);
		void Delete(User register);
		bool PasswordSignIn(string userEmail, string userPassword, int roleId);
		Task<int?> GetRoleIdByEmail(string email);
		User FindUserById(int Id);
		List<User> GetAllUsers();
	}
}
