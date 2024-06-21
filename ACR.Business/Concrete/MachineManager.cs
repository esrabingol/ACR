using ACR.Business.Abstract;
using ACR.Business.Models;
using ACR.DataAccess.Abstract;
using ACR.Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ACR.Business.Concrete
{
	public class MachineManager : IMachineService
	{
		private IMachineDal _machineDal;
		private IHttpContextAccessor _httpContext;
		public MachineManager(IMachineDal machineDal, IHttpContextAccessor httpContext)
		{
			_machineDal = machineDal;
			_httpContext = httpContext;
		}
		public Machine UpdateMachineInfo(Machine updatedMachine)
		{
			var userId = _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
			var machineUpdate = new Machine
			{
				Id = updatedMachine.Id,
				MachineName = updatedMachine.MachineName,
				MachineStatus = updatedMachine.MachineStatus,
				ItemNo = updatedMachine.ItemNo,
				TcNumber = updatedMachine.TcNumber,
				VpNumber = updatedMachine.VpNumber,
				UpdateDate = DateTime.Now,
				UpdatedBy = updatedMachine.UpdatedBy
			};
			return _machineDal.UpdateMachine(machineUpdate);
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
			var userId = _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
			var machineAdd = new Machine
			{
				MachineName = addMachine.MachineName,
				MachineStatus = addMachine.MachineStatus,
				ItemNo = addMachine.ItemNo,
				TcNumber = addMachine.TcNumber,
				VpNumber = addMachine.VpNumber,
				CreateDate = DateTime.Now,
				CreatedBy = Convert.ToInt32(userId)
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
			var userId = _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
			var machineAdd = new Machine
			{
				DeleteDate = DateTime.Now,
				DeletedBy = Convert.ToInt32(userId)
			};
			return _machineDal.GetByIdToDelete(Id);
		}
	}
}
