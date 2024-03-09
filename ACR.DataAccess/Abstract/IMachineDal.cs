using ACR.Entity.Concrete;

namespace ACR.DataAccess.Abstract
{
    public interface IMachineDal : IRepository<Machine>
    {
        List<Machine> GetByMachineFiltered(List<Func<Machine, bool>> filters);
		IEnumerable<string> GetMachineNames();
        Machine UpdateMachine(Machine autoclave);
    }
}
