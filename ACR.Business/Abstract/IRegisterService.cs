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
        Task <Users> Add(Users register);
        Users Update(Users register);
        void Delete(Users register);
    }
}
