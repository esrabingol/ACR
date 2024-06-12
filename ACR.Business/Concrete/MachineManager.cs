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
		public Machine UpdateMachineInfo(Machine updatedMachine)
		{
			return _machineDal.UpdateMachine(updatedMachine);
		}
		public Machine GetBySelectedMachine(AdMachineFilterModelDTO filterModel)
		{
			var machineFind = new Machine
			{
				Id = filterModel.Id,
				MachineName = filterModel.MachineName,
				MachineStatus = filterModel.MachineStatu,
				ItemNo = filterModel.ItemNo,
				TcNumber = filterModel.Tc,
				VpNumber = filterModel.Vp,
				StartDate = filterModel.StartDate,
				EndDate = filterModel.EndDate,
				OperatorNote = filterModel.OperatorNote
			};
			return _machineDal.GetSelectedMachineInfo(machineFind);
		}
		public List<Machine> GetFilteredValues(AdMachineFilterModelDTO viewMachine)
		{
			var machineFilter = new Machine
			{
				MachineName = viewMachine.MachineName,
				MachineStatus = viewMachine.MachineStatu,
				ItemNo = viewMachine.ItemNo,
				TcNumber = viewMachine.Tc,
				VpNumber = viewMachine.Vp,
				StartDate = viewMachine.StartDate,
				EndDate = viewMachine.EndDate,
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

			var viewModel = new AdMachineFilterModelDTO
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
		public Machine AddNewMachineInfo(AdAddNewMachineModelDTO addMachine)
		{
			var machineAdd = new Machine
			{
				MachineName = addMachine.MachineName,
				MachineStatus = addMachine.MachineStatus,
				ItemNo = addMachine.ItemNo,
				TcNumber = addMachine.TcNumber,
				VpNumber = addMachine.VpNumber,
			};
			return _machineDal.AddMachine(machineAdd);
		}
		public List<Machine> GetAllMachines()
		{
			var allMachines = _machineDal.GetAll().OrderByDescending(r => r.StartDate).ToList();
			return allMachines.ToList();
		}
		public Machine GetBySelectedMachineToId(int Id)
		{
			return _machineDal.GetByIdToDelete(Id);
		}
	}
}
