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
    public class AutoclaveManager : IAutoclaveService
    {
        IAutoclaveDal _autoclaveDal;
        public AutoclaveManager(IAutoclaveDal autoclaveDal)
        {
            _autoclaveDal = autoclaveDal;
        }

        public async Task<Autoclave> AddAsync(Autoclave autoclave)
        {
            return await _autoclaveDal.AddAsync(autoclave);


        }

        public void Delete(Autoclave autoclave)
        {
             _autoclaveDal.Delete(autoclave);
        }

        public Autoclave GetById(int Id)
        {
            return _autoclaveDal.GetById(Id);
        }

        public List<Autoclave> GetList()
        {
            return _autoclaveDal.GetAll().ToList();
        }

        public List<Autoclave> GetListByCategoryId(int categoryId)
        {
           return _autoclaveDal.GetListByCategoryId(categoryId).ToList();
        }

        public async Task<Autoclave> UpdateAsync(Autoclave autoclave)
        {
            return await _autoclaveDal.UpdateAsync(autoclave);
        }
    }
}
