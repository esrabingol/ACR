using ACR.DataAccess.Abstract;
using ACR.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.DataAccess.Concrete.EntityFramework
{
	public class EfRegisterDal : EfGenericRepository<Users, ACRContext>, IRegisterDal
	{
		public List<Users> FindByEmail(string email)
		{
			using (var context = new ACRContext())
			{
				var user = context.Registers
					.Where(i => i.MailAdress.ToLower() == email.ToLower()).AsNoTracking().ToList();

				return user;
			}
		}

		public bool PasswordSignIn(string userEmail, string userPassword, string userRole)
		{
			using (var context = new ACRContext())
			{
				var userLogin = context.Registers
					.Where(i => i.MailAdress.ToLower() == userEmail.ToLower())
					.Where(i => i.Password.ToLower() == userPassword.ToLower())
					.Where(i => i.UserRole == userRole)
					.FirstOrDefault();

				if (userLogin != null)
					return true;

				else
					return false;
			}
		}
	}
}
