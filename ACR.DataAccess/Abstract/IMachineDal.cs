using ACR.Entity.Concrete;

namespace ACR.DataAccess.Abstract
{
    public interface IMachineDal : IRepository<Machine>
    {
        List<Machine> GetByMachineFiltered(List<Func<Machine, bool>> filters);
		IEnumerable<string> GetMachineNames();
        Machine UpdateMachine(Machine machines);
        Machine AddMachine(Machine machine);
        Machine GetSelectedMachineInfo(Machine findMachine);
        Machine GetByIdToDelete(int Id);
    }
}
