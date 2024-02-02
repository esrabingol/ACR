using ACR.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Business.Abstract
{
    public interface IRegisterService
    {
 
        Task<Register> AddAsync(Register register);
        Task<Register> UpdateAsync(Register register);
        void Delete(Register register);

        
    }
}
