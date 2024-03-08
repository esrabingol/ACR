using ACR.DataAccess.Abstract;
using ACR.Entity.Concrete;

namespace ACR.DataAccess.Concrete.EntityFramework
{
    public class EfMachineDal : EfGenericRepository<Machine>, IMachineDal
    {
        public EfMachineDal(ACRContext context) : base(context)
        {

        }
        public List<Machine> FindFilterResult(Machine machine)
        {
                IQueryable<Machine> query = _context.Machines;

                if (!string.IsNullOrEmpty(machine.MachineName))
                {
                    query = query.Where(a => a.MachineName == machine.MachineName);
                }
                if (!string.IsNullOrEmpty(machine.MachineStatus))
                {
                    query = query.Where(a => a.MachineStatus == machine.MachineStatus);
                }
                if (machine.TcNumber != 0)
                {
                    query = query.Where(a => a.TcNumber == machine.TcNumber);
                }
                if (machine.VpNumber != 0)
                {
                    query = query.Where(a => a.VpNumber == machine.VpNumber);
                }
                if (machine.ItemNo != 0)
                {
                    query = query.Where(a => a.ItemNo == machine.ItemNo);
                }

                // Filtrelenmiş verilere ait makine bilgilerini çek
                var machineInfos = query.Select(a => new Machine
                {
                    MachineName = a.MachineName,
                    MachineStatus = a.MachineStatus,
                    ItemNo = a.ItemNo,
                    TcNumber = a.TcNumber,
                    VpNumber = a.VpNumber,
                    StartDate = a.StartDate,
                    EndDate = a.EndDate,
                    OperatorNote = a.OperatorNote,
                }).ToList();

                return machineInfos;
        }
        public List<Machine> GetListByCategoryId(int categoryId)
        {
            //Aktif- pasif durumunu bu kısımda kullanılıcak
            throw new NotImplementedException();
        }
        public IEnumerable<string> GetMachineNames()
        {
                return _context.Machines.Select(a => a.MachineName).ToList();
        }
        public Machine UpdateMachine(Machine autoclave)
        {
            _context.Machines.Update(autoclave);
            _context.SaveChanges();
            return autoclave;
        }
    }
}
