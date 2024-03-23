using ACR.Business.Models;
using ACR.Entity.Concrete;

namespace ACR.Business.Abstract
{
	public interface IMachineService
	{
		Machine UpdateMachineInfo(Machine updatedMachine);
		Machine AddNewMachineInfo(OpAddNewMachineModelDTO addMachine);
		Machine GetBySelectedMachine(OpMachineFilterModelDTO deleteMachine);
		List<Machine> GetFilteredValues(OpMachineFilterModelDTO viewMachine);
		IEnumerable<Machine> GetValues();
		List<Machine> GetAllMachines();
		Machine GetBySelectedMachineToId(int Id);

	}
}
