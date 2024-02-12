using ACR.Business.Abstract;
using ACR.DataAccess.Abstract;
using ACR.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Business.Concrete
{
    public class RegisterManager : IRegisterService
    {
        private IRegisterDal _registerDal;
        public RegisterManager(IRegisterDal registerDal)
        {
            _registerDal = registerDal;
        }

        public async Task<Users> Add(Users register)
        {
			var newUser = new Users()
			{
				Name = register.Name,
				Surname = register.Surname,
				MailAdress = register.MailAdress,
				Password = register.Password,
				PhoneNumber = register.PhoneNumber,
				RecordData = DateTime.Now.ToShortDateString().ToString(),
				UserRole = register.UserRole
			};

		   _registerDal.Add(newUser); 

			return newUser;
		}

        public void Delete(Users register)
        {
            _registerDal.Delete(register);
        }

        public Users Update(Users register)
        {
             _registerDal.Update(register);
            return register;
        }
    }
}
