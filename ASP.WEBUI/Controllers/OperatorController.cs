using ACR.Business.Abstract;
using ACR.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.WEBUI.Controllers
{
	public class OperatorController : Controller
	{
		private IMachineService _machineService;
		private IReservationService _reservationService;

		public OperatorController(IMachineService machineService, IReservationService reservationService)
		{
			_machineService = machineService;
			_reservationService = reservationService;
		}
		public IActionResult Index()
		{
			var machines = _machineService.GetValues();
			var opCreateIndexModelDTO = new OpIndexModelDTO { MachineNames = machines };
			return View(opCreateIndexModelDTO); ;
		}

		[HttpPost]
		public IActionResult Index(OpIndexModelDTO indexModel)
		{
			var filterReservations = _reservationService.GetAllRezervationsOperator(indexModel);
			indexModel.Results = filterReservations;
			return View(indexModel);
		}

		[HttpGet]
		public IActionResult ViewMachineInfo()
		{
			var machines = _machineService.GetValues();
			var opMachineFilterModelDTO = new OpMachineFilterModelDTO { MachineNames = machines };
			return View(opMachineFilterModelDTO);
		}

		[HttpPost]
		public IActionResult ViewMachineInfo(OpMachineFilterModelDTO viewMachine)
		{
			var filteredMachines = _machineService.GetFilteredValues(viewMachine);
			viewMachine.Results = filteredMachines;
			return View(viewMachine);
		}

		[HttpGet]
		public IActionResult EditMachineInfo()
		{
			var machines = _machineService.GetValues();
			var opEditMachineModelDTO = new OpEditMachineModelDTO { MachineNames = machines };
			return View(opEditMachineModelDTO);
		}

		[HttpPost]
		public IActionResult EditMachineInfo(OpEditMachineModelDTO editMachine)
		{
			var updateMachine = _machineService.UpdateMachineInfo(editMachine);
			ViewBag.FilteredAutoclaves = updateMachine;
			return RedirectToAction("Index", "Operator");
		}

		[HttpGet]
		public IActionResult AddNewMachine()
		{
			return View(new OpAddNewMachineModelDTO());
		}

		[HttpPost]
		public IActionResult AddNewMachine(OpAddNewMachineModelDTO addMachine)
		{
			var addNewMachine = _machineService.AddNewMachineInfo(addMachine);
			return RedirectToAction("ViewMachineInfo", "Operator");

		}
	}
}
