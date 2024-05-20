﻿using ACR.DataAccess.Abstract;
using ACR.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ACR.DataAccess.Concrete.EntityFramework
{
	public class EfRegisterDal : EfGenericRepository<User>, IRegisterDal
	{
		public EfRegisterDal(ACRContext context) : base(context)
		{

		}
		public Task<User> FindByEmail(string email)
		{
			var user = _context.Users.FirstOrDefaultAsync(i => i.MailAdress.ToLower() == email.ToLower());
			return user;
		}
		public bool PasswordSignIn(string userEmail, string userPassword, int roleId)
		{
			var userLogin = _context.Users
				.Where(i => i.MailAdress.ToLower() == userEmail.ToLower())
				.Where(i => i.Password.ToLower() == userPassword.ToLower())
				.Where(i => i.RoleId == roleId)
				.FirstOrDefault();

			if (userLogin != null)
				return true;

			else
				return false;
		}
        public User UpdateUserInfo(User userInfo)
		{
            var user = _context.Set<User>().Find(userInfo.Id);
			if (user != null)
			{
				user.Name = userInfo.Name;
                user.Surname = userInfo.Surname;
                user.Email = userInfo.MailAdress;
				user.MailAdress= userInfo.MailAdress;
				user.PhoneNumber = userInfo.PhoneNumber;
		
                _context.Users.Update(user);
                _context.SaveChanges();
            }
            return user;
        }
	}
}
