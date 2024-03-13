using ACR.DataAccess.Abstract;
using ACR.Entity.Concrete;

namespace ACR.DataAccess.Concrete.EntityFramework
{
	public class EfMachineDal : EfGenericRepository<Machine>, IMachineDal
	{
		public EfMachineDal(ACRContext context) : base(context)
		{
		}
		public Machine AddMachine(Machine machine)
		{
			_context.Machines.Add(machine);
			_context.SaveChanges();
			return machine;
		}
		public List<Machine> GetByMachineFiltered(List<Func<Machine, bool>> filters)
		{
			IQueryable<Machine> query = _context.Machines.AsQueryable();

			foreach (var filter in filters)
			{
				query = query.Where(filter).AsQueryable();
			}

			return query.ToList();
		}
		public IEnumerable<string> GetMachineNames()
		{
			return _context.Machines.Select(a => a.MachineName).ToList();
		}
		public Machine GetSelectedMachineInfo(Machine findMachine)
		{
			int machineId = findMachine.Id;
			Machine selectedMachine = _context.Set<Machine>().Find(machineId); 
			if(selectedMachine != null)
			{
				return selectedMachine;
			}
			else
			{
				return null;
			}
		}
		public Machine UpdateMachine(Machine machines)
		{
			var machine = _context.Set<Machine>().Find(machines.Id);
			if(machine != null)
			{
				machine.MachineName = machines.MachineName;
				machine.MachineStatus = machines.MachineStatus;
				machine.ItemNo = machines.ItemNo;
				machine.TcNumber = machines.TcNumber;
				machine.VpNumber = machines.VpNumber;
				machine.StartDate = machines.StartDate;
				machine.EndDate = machines.EndDate;
				machine.OperatorNote = machines.OperatorNote;

				_context.Machines.Update(machine);
				_context.SaveChanges();
			}
			return machine;
		}
        public Machine GetByIdToDelete(int Id)
        {
            Machine machine= _context.Set<Machine>().Find(Id); 
			if(machine != null)
			{
				//machine.Deleted = 1; // şeklinde silinenleri belirtmek içi sutün eklenicek 
				machine.MachineStatus = "Pasif";
				_context.SaveChanges();
			}
			return machine;
        }
    }
}
