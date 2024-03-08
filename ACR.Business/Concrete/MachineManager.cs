using ACR.Business.Abstract;
using ACR.Business.Models;
using ACR.DataAccess.Abstract;
using ACR.Entity.Concrete;

namespace ACR.Business.Concrete
{
    public class MachineManager : IMachineService
    {
        private IMachineDal _autoclaveDal;
        public MachineManager(IMachineDal autoclaveDal)
        {
            _autoclaveDal = autoclaveDal;
        }
        public Machine Add(Machine autoclave)
        {
            _autoclaveDal.Add(autoclave);
            return autoclave;
        }
        public void Delete(Machine autoclave)
        {
            _autoclaveDal.Delete(autoclave);
        }
        public Machine UpdateMachineInfo(OpEditMachineModelDTO editMachine)
        {
            var machineUpdate = new Machine
            {
                MachineName = editMachine.MachineName,
                MachineStatus = editMachine.MachineStatus,
                ItemNo = editMachine.ItemNo,
                TcNumber = editMachine.TcNumber,
                VpNumber = editMachine.VpNumber,

                OperatorNote = editMachine.OperatorNote
            };
            return _autoclaveDal.UpdateMachine(machineUpdate);

        }
        public Machine GetById(int Id)
        {
            var autolave = _autoclaveDal.GetById(Id);
            if (autolave == null)
            {
                throw new Exception($"ID'si {Id} olan Autoclave bulunamadı.");
            }
            return autolave;
        }
        public List<Machine> GetFilteredValues(OpMachineFilterModelDTO opMachineFilterModel)
        {
            var filteredValues = new Machine()
            {
                MachineName = opMachineFilterModel.machineName,
                MachineStatus = opMachineFilterModel.machineStatu,
                TcNumber = opMachineFilterModel.tc,
                VpNumber = opMachineFilterModel.vp,
                ItemNo = opMachineFilterModel.itemNo,
                EndDate = opMachineFilterModel.endDate,
                StartDate = opMachineFilterModel.startDate,
                OperatorNote = opMachineFilterModel.operatorNote,
            };
            return _autoclaveDal.FindFilterResult(filteredValues);
        }
        public IEnumerable<Machine> GetValues()
        {
            var machines = _autoclaveDal.GetAll();
            return machines.ToList();
        }
    }
}
