using ACR.Business.Models;
using ACR.Entity.Concrete;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Business.Abstract
{
    public interface IRegisterService
    {
		Task<User> Add(UserRegisterModelDTO register);
		User Update(User register);
        void Delete(User register);
		bool PasswordSignIn(string userEmail, string userPassword,int roleId);
		Task<User> FindUser(UserLoginModelDTO loginModel);
        Task<int?> GetRoleIdByEmail(string email);

	}
}
