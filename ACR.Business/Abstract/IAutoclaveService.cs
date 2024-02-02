using ACR.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Business.Abstract
{
    public interface IAutoclaveService
    {
        Task<Autoclave> AddAsync(Autoclave autoclave);

        Task<Autoclave> UpdateAsync(Autoclave autoclave);

        void Delete(Autoclave autoclave);

        Autoclave GetById(int Id);

        List<Autoclave> GetList();
        
        //Makine filtreleme durumu işleminde kullanmak için
        List<Autoclave> GetListByCategoryId(int categoryId);
    
    }
}
