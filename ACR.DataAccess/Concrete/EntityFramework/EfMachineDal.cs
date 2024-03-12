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

		public Machine UpdateMachine(Machine machine)
		{
			_context.Machines.Update(machine);
			_context.SaveChanges();
			return machine;
		}
	}
}
