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
        public async Task<User> Add(UserRegisterModelDTO registerModel)
        {
			var newUser = new User()
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

        public void Delete(User register)
        {
            _registerDal.Delete(register);
        }

		public async Task <User> FindUser(UserLoginModelDTO loginModel)
		{
			var findUser = new User()
			{
				MailAdress = loginModel.MailAdress,
				Password = loginModel.Password,
			};
			 var a = await _registerDal.FindByEmail(findUser.MailAdress);
			return a;
		}
        public async Task<int?> GetRoleIdByEmail(string email)
        {
            var user = await _registerDal.FindByEmail(email);

            // Eğer kullanıcı bulunursa, RoleId'yi döndür; bulunamazsa null döndür
            return user?.RoleId;
        }
        public bool PasswordSignIn(string userEmail, string userPassword, int roleId)
		{
			return _registerDal.PasswordSignIn(userEmail, userPassword, roleId);
		}

		public User Update(User register)
        {
             _registerDal.Update(register);
            return register;
        }

	}
}
