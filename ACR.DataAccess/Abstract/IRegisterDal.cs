using ACR.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.DataAccess.Abstract
{
    public interface IRegisterDal:IRepository<Register>
    {
        public Task<Register> AddAsync(Register register);

        public Task<Register> UpdateAsync(Register register);
    }
}
