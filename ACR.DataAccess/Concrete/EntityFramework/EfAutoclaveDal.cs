using ACR.DataAccess.Abstract;
using ACR.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.DataAccess.Concrete.EntityFramework
{
    public class EfAutoclaveDal : EfGenericRepository<Autoclave, ACRContext>, IAutoclaveDal
    {
        public List<Autoclave> GetListByCategoryId(int categoryId)
        {
            //Aktif- pasif durumunu bu kısımda kullanılıcak
            throw new NotImplementedException();
        }
    }
}
