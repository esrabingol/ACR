using ACR.Business.Models;
using ACR.Entity.Concrete;

namespace ACR.Business.Abstract
{
    public interface IMachineService
    { 
        Machine Add(Machine autoclave);
        Machine UpdateMachineInfo(OpEditMachineModelDTO editMachine);
        void Delete(Machine autoclave);
        Machine GetById(int Id);
        List<Machine> GetFilteredValues(OpMachineFilterModelDTO opMachineFilterModel);
        IEnumerable<Machine> GetValues();
    }
}
