using ACR.DataAccess.Abstract;
using ACR.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ACR.DataAccess.Concrete.EntityFramework
{
    public class EfAutoclaveDal : EfGenericRepository<Autoclave, ACRContext>, IAutoclaveDal
    {
        ACRContext _context;
       
        public EfAutoclaveDal(ACRContext context) : base(context)
		{
           
		}

        public List<Autoclave> FindFilterResult(Autoclave autoclave)
        {

            using (var context = new ACRContext())
            {
                IQueryable<Autoclave> query = context.Autoclaves;

                if (!string.IsNullOrEmpty(autoclave.MachineName))
                {
                    query = query.Where(a => a.MachineName == autoclave.MachineName);
                }
                if (!string.IsNullOrEmpty(autoclave.MachineStatu))
                {
                    query = query.Where(a => a.MachineStatu == autoclave.MachineStatu);
                }
                if (autoclave.TcNumber != 0)
                {
                    query = query.Where(a => a.TcNumber == autoclave.TcNumber);
                }
                if (autoclave.VpNumber != 0)
                {
                    query = query.Where(a => a.VpNumber == autoclave.VpNumber);
                }
                if (autoclave.ItemNo != 0)
                {
                    query = query.Where(a => a.ItemNo == autoclave.ItemNo);
                }

                // Filtrelenmiş verilere ait makine bilgilerini çek
                var machineInfos = query.Select(a => new Autoclave
                {
                    MachineName = a.MachineName,
                    MachineStatu = a.MachineStatu,
                    ItemNo = a.ItemNo,
                    TcNumber = a.TcNumber,
                    VpNumber = a.VpNumber,
                    StartDate = a.StartDate,
                    EndDate = a.EndDate,
                    OperatorNote = a.OperatorNote,
                }).ToList();

                return machineInfos;
            }


        }
        

        public List<Autoclave> GetListByCategoryId(int categoryId)
        {
            //Aktif- pasif durumunu bu kısımda kullanılıcak
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetMachineNames()
        {
            using (var context = new ACRContext())
            {
             return context.Autoclaves.Select(a => a.MachineName).ToList();
            }
           
        }

        public Autoclave UpdateMachine(Autoclave autoclave)
        {
            _context.Autoclaves.Update(autoclave);
            _context.SaveChanges();
            return autoclave;
        }
    }
}
