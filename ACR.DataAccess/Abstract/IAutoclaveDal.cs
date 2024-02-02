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
        Task<Autoclave> AddAsync(Autoclave autoclave);
        Task<Autoclave> UpdateAsync(Autoclave autoclave);

        public List<Autoclave> GetListByCategoryId(int categoryId);
    }
}
