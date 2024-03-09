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
		//public async Task<int> GetUserIdFromAuthentication(int id)
		//{
		//	var user = await _context.Users.FirstOrDefaultAsync(i => i.Id == id);

		//	if (user != null)
		//	{
		//		return user.Id;
		//	}

		//	// Kullanıcı bulunamazsa -1 veya başka bir değer dönebilirsiniz.
		//	return -1;
		//}

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
    }
}
