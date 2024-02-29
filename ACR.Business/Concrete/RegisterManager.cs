using ACR.Business.Abstract;
using ACR.Business.Models;
using ACR.DataAccess.Abstract;
using ACR.DataAccess.Concrete;
using ACR.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Win32;
using System.Net;
using System.Net.Mail;

namespace ACR.Business.Concrete
{
	public class RegisterManager : IRegisterService
    {
        private IRegisterDal _registerDal;
        public RegisterManager(IRegisterDal registerDal)
        {
            _registerDal = registerDal;
        }
        public async Task<Users> Add(UserRegisterModelDTO registerModel)
        {
			var newUser = new Users()
			{
				Name = registerModel.Name,
				Surname = registerModel.SurName,
				MailAdress = registerModel.MailAdress,
				Password = registerModel.Password,
				PhoneNumber = registerModel.PhoneNumber,
				RoleId = registerModel.RoleId
			};
			_registerDal.Add(newUser);
			return newUser;
		}

        public void Delete(Users register)
        {
            _registerDal.Delete(register);
        }

		public async Task <Users> FindUser(UserLoginModelDTO loginModel)
		{
			var findUser = new Users()
			{
				MailAdress = loginModel.MailAdress,
				Password = loginModel.Password,
			};
			 return await _registerDal.FindByEmail(findUser.MailAdress);
			
		}

		public bool PasswordSignIn(string userEmail, string userPassword, int roleId)
		{
			return _registerDal.PasswordSignIn(userEmail, userPassword, roleId);
		}

		public Users Update(Users register)
        {
             _registerDal.Update(register);
            return register;
        }

	}
}
