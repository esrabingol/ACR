using ACR.DataAccess.Abstract;
using ACR.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ACR.DataAccess.Concrete.EntityFramework
{
	public class EfRegisterDal : EfGenericRepository<Users, ACRContext>, IRegisterDal
	{
		public EfRegisterDal(ACRContext context): base(context)
		{

		}
		public async Task<Users> FindByEmail(string email)
		{
			using (var context = new ACRContext())
			{
				var user = await context.Registers
		          .FirstOrDefaultAsync(i => i.MailAdress.ToLower() == email.ToLower());

				return user;

			}
		
		}

		public bool PasswordSignIn(string userEmail, string userPassword, int roleId)
		{
			using (var context = new ACRContext())
			{
				var userLogin = context.Registers
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
}
