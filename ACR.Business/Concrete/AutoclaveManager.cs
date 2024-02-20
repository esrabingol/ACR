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
    //Otoklav Makinesine ait bilgilerin tutulduğu ve kontrol edildiği işlemler
    public class AutoclaveManager : IAutoclaveService
    {
       private IAutoclaveDal _autoclaveDal;
        public AutoclaveManager(IAutoclaveDal autoclaveDal)
        {
            _autoclaveDal = autoclaveDal;
        }

        public Autoclave Add(Autoclave autoclave)
        {
            _autoclaveDal.Add(autoclave);
            return autoclave;
        }

        public void Delete(Autoclave autoclave)
        {
             _autoclaveDal.Delete(autoclave);
        }

        //Makine Bilgilerini Güncelleme İşlemi
        public Autoclave Update(Autoclave autoclave)
        {
            _autoclaveDal.Update(autoclave);
            return autoclave;
        }
        public Autoclave GetById(int Id)
        {
            var autolave = _autoclaveDal.GetById(Id);
            if(autolave == null)
            {
                throw new Exception($"ID'si {Id} olan Autoclave bulunamadı.");
            }
            return autolave;
        }

        public List<Autoclave> GetList()
        { 
            return _autoclaveDal.GetAll().ToList();
        }

        public List<Autoclave> GetByName(string machineName)
        {
            var autoclaves = _autoclaveDal.GetAll();
            var filteredAutoclaves = autoclaves.Where(a => a.MachineName == machineName).ToList();
            return filteredAutoclaves;
        }
    }
}
