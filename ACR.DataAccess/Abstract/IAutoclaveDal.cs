using ACR.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.DataAccess.Abstract
{
    public interface IAutoclaveDal :IRepository<Autoclave>
    {
        public List<Autoclave> GetListByCategoryId(int categoryId);
        //IEnumerable<string> GetMachineNames();

        List<Autoclave> FindFilterResult(Autoclave autoclave);

        IEnumerable<string> GetMachineNames();
    }
}
