using ACR.Business.Models;
using ACR.Entity.Concrete;

namespace ACR.Business.Abstract
{
    public interface IMachineService
    { 
        Machine UpdateMachineInfo(OpEditMachineModelDTO editMachine);
        Machine AddNewMachineInfo(OpAddNewMachineModelDTO addMachine);
        void Delete(Machine autoclave);
        Machine GetBySelectedMachine(OpMachineFilterModelDTO deleteMachine);
        List<Machine> GetFilteredValues(OpMachineFilterModelDTO viewMachine);
        IEnumerable<Machine> GetValues();
        List<Machine> GetAllMachines();
	}
}
