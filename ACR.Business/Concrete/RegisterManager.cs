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

        public Users Add(Users register)
        {
           
            _registerDal.Add(register);
            return register;
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
