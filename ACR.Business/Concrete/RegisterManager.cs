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
        IRegisterDal _registerDal;
        public RegisterManager(IRegisterDal registerDal)
        {
            _registerDal = registerDal;
        }
        public async Task<Register> AddAsync(Register register)
        {
            return await _registerDal.AddAsync(register);
        }

        public void Delete(Register register)
        {
            _registerDal.Delete(register);
        }

        public async Task<Register> UpdateAsync(Register register)
        {
            return await _registerDal.UpdateAsync(register);
        }
    }
}
