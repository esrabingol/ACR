using ACR.Business.Abstract;
using ACR.Business.Models;
using ACR.DataAccess.Abstract;
using ACR.DataAccess.Concrete;
using ACR.Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Win32;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;

namespace ACR.Business.Concrete
{
	public class RegisterManager : IRegisterService
    {
        private IRegisterDal _registerDal;
		private readonly UserManager<User> _userManager;
        public RegisterManager(IRegisterDal registerDal, UserManager<User> userManager)
        {
            _registerDal = registerDal;
			_userManager = userManager;
        }
        public async Task<User> Add(UserRegisterModelDTO registerModel)
        {
			var newUser = new User()
			{
				Name = registerModel.Name,
				UserName = registerModel.MailAdress,
				Surname = registerModel.SurName,
				MailAdress = registerModel.MailAdress,
				Email= registerModel.MailAdress,
				Password = registerModel.Password,
				PhoneNumber = registerModel.PhoneNumber,
				RoleId = registerModel.RoleId
			};

			var result= await _userManager.CreateAsync(newUser, registerModel.Password);
			if (result.Succeeded)
			{
				return newUser;
			}
			else
			{
				return null;
			}
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
			var user = await _registerDal.FindByEmail(findUser.MailAdress);
			return user;
		}
        public async Task<int?> GetRoleIdByEmail(string email)
        {
            var user = await _registerDal.FindByEmail(email);
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
