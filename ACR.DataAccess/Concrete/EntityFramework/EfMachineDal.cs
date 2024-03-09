using ACR.DataAccess.Abstract;
using ACR.Entity.Concrete;

namespace ACR.DataAccess.Concrete.EntityFramework
{
	public class EfMachineDal : EfGenericRepository<Machine>, IMachineDal
	{
		public EfMachineDal(ACRContext context) : base(context)
		{
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
		public Machine UpdateMachine(Machine autoclave)
		{
			_context.Machines.Update(autoclave);
			_context.SaveChanges();
			return autoclave;
		}
	}
}
