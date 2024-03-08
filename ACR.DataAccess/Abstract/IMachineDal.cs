using ACR.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.DataAccess.Abstract
{
    public interface IMachineDal :IRepository<Machine>
    {
        public List<Machine> GetListByCategoryId(int categoryId);

        List<Machine> FindFilterResult(Machine autoclave);

        IEnumerable<string> GetMachineNames();
        Machine UpdateMachine(Machine autoclave);
    }
}
