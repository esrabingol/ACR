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
		Task<Users> Add(UserRegisterModelDTO register);
		Users Update(Users register);
        void Delete(Users register);
		bool PasswordSignIn(string userEmail, string userPassword, int roleId);
		Task<Users> FindUser(UserLoginModelDTO loginModel);


	}
}
