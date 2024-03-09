using ACR.Business.Abstract;
using ACR.Business.Models;
using ACR.DataAccess.Abstract;
using ACR.Entity.Concrete;

namespace ACR.Business.Concrete
{
    public class MachineManager : IMachineService
    {
        private IMachineDal _machineDal;
        public MachineManager(IMachineDal machineDal)
        {
            _machineDal = machineDal;
        }
        public Machine Add(Machine autoclave)
        {
            _machineDal.Add(autoclave);
            return autoclave;
        }
        public void Delete(Machine autoclave)
        {
            _machineDal.Delete(autoclave);
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
                StartDate = editMachine.StartDate,
                EndDate = editMachine.EndDate,
                OperatorNote = editMachine.OperatorNote
            };
            return _machineDal.UpdateMachine(machineUpdate);
        }
        public Machine GetById(int Id)
        {
            var autolave = _machineDal.GetById(Id);
            if (autolave == null)
            {
                throw new Exception($"ID'si {Id} olan Autoclave bulunamadı.");
            }
            return autolave;
        }
        public List<Machine> GetFilteredValues(OpMachineFilterModelDTO viewMachine)
        {
			var machineFilter = new Machine
			{
				MachineName = viewMachine.MachineName,
                MachineStatus = viewMachine.MachineStatu,
                ItemNo = viewMachine.ItemNo,
                TcNumber = viewMachine.Tc,
                VpNumber =viewMachine.Vp,
				StartDate = viewMachine.StartDate, //bakım başlangıç zamanı
				EndDate = viewMachine.EndDate, // bakım bitiş zamanı
			};

			var filters = new List<Func<Machine, bool>>();

			if (!string.IsNullOrWhiteSpace(machineFilter.MachineName))
				filters.Add(r => r.MachineName == machineFilter.MachineName);

            if (!string.IsNullOrEmpty(machineFilter.MachineStatus))
                filters.Add(r => r.MachineStatus == machineFilter.MachineStatus);

            if (machineFilter.ItemNo.HasValue)
                filters.Add(r => r.ItemNo == machineFilter.ItemNo);

            if (machineFilter.TcNumber.HasValue)
                filters.Add(r => r.TcNumber == machineFilter.TcNumber);

            if (machineFilter.VpNumber.HasValue)
                filters.Add(r => r.VpNumber == machineFilter.VpNumber);

			if (machineFilter.StartDate != default(DateTime))
				filters.Add(r => r.StartDate == machineFilter.StartDate);

			if (machineFilter.EndDate != default(DateTime))
				filters.Add(r => r.EndDate == machineFilter.EndDate);

			var filteredMachines = _machineDal.GetByMachineFiltered(filters);

			var viewModel = new OpMachineFilterModelDTO
			{
				Results = filteredMachines,
			};

			return viewModel.Results;
		}
        public IEnumerable<Machine> GetValues()
        {
            var machines = _machineDal.GetAll();
            return machines.ToList();
        }
    }
}
