using ACR.Business.Models;
using ACR.Entity.Concrete;

namespace ACR.Business.Abstract
{
	public interface IMachineService
	{
		Machine UpdateMachineInfo(Machine updatedMachine);
		Machine AddNewMachineInfo(AdAddNewMachineModelDTO addMachine);
		Machine GetBySelectedMachine(AdMachineFilterModelDTO deleteMachine);
		List<Machine> GetFilteredValues(AdMachineFilterModelDTO viewMachine);
		IEnumerable<Machine> GetValues();
		List<Machine> GetAllMachines();
		Machine GetBySelectedMachineToId(int Id);

	}
}
