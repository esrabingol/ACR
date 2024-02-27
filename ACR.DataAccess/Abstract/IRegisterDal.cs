﻿using ACR.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.DataAccess.Abstract
{
    public interface IRegisterDal:IRepository<Users>
    {
		bool PasswordSignIn(string userEmail, string userPassword, int roleId);
		List<Users> FindByEmail(string email);
	}
}
