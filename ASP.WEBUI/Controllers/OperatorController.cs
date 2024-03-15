using ACR.Business.Abstract;
using ACR.Business.Models;
using ACR.Entity.Concrete;
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
		public IActionResult EditMachineInfo(OpMachineFilterModelDTO editMachine)
		{
			//var machines = _machineService.GetValues();
			//var opEditMachineModelDTO = new OpEditMachineModelDTO { MachineNames = machines };
			//return View(opEditMachineModelDTO);

			var machine = _machineService.GetBySelectedMachine(editMachine);
			if (machine == null)
			{
				return RedirectToAction("ViewMachineInfo");
			}
			return View("EditMachineInfo", machine);

		}
		[HttpPost]
		public IActionResult EditMachineInfo(Machine updatedMachine)
		{
			var machine = _machineService.UpdateMachineInfo(updatedMachine);
			if(machine != null)
			{
				TempData["SuccessMessage"] = "Güncelleme işlemi başarıyla tamamlandı.";
			}
			return View(machine);
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

		[HttpGet]
		public IActionResult GetAllReservations()
		{
			var allreservations = _reservationService.GetAllReservations();
			var opIndexModel = new OpIndexModelDTO
			{
				Results = allreservations
			};
			return View("Index", opIndexModel);
		}

		[HttpGet]
		public IActionResult GetAllMachines()
		{
			var allmachines = _machineService.GetAllMachines();
			var opMachineModel = new OpMachineFilterModelDTO
			{
				Results = allmachines
			};
			return View("ViewMachineInfo", opMachineModel);
		}

		[HttpGet]
		public IActionResult DeleteMachine(OpMachineFilterModelDTO deleteMachine)
		{
			var machine = _machineService.GetBySelectedMachine(deleteMachine);
			if (machine == null)
			{
				return RedirectToAction("ViewMachineInfo");
			}
			return View("DeleteMachine", machine);
		}
		[HttpPost]
		public IActionResult DeleteMachine(int Id)
		{
			var machine = _machineService.GetBySelectedMachineToId(Id);
			return View(machine);
		}
	}
}
