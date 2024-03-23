using ACR.Business.Abstract;
using ACR.Business.Models;
using ACR.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ASP.WEBUI.Controllers
{
	//[Authorize]
	public class OperatorController : Controller
	{
		private IMachineService _machineService;
		private IReservationService _reservationService;
		private IHttpContextAccessor _httpContext;

		public OperatorController(IMachineService machineService, IReservationService reservationService, IHttpContextAccessor httpContext)
		{
			_machineService = machineService;
			_reservationService = reservationService;
			_httpContext = httpContext;
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
		public IActionResult OpConfirmReservation(OpIndexModelDTO manageReservationModel)
		{
			var confirmReservation = _reservationService.GetBySelectedReservationToOperator(manageReservationModel);
			if (confirmReservation == null)
			{
				return RedirectToAction("Index");
			}
			return View("OpConfirmReservation", confirmReservation);
		}

		[HttpPost]
		public IActionResult OpConfirmReservation(Reservation confirmReservation)
		{
			//operatorId
			var userId = _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);

			if (!string.IsNullOrWhiteSpace(userId))
			{
				confirmReservation.OperatorId = Convert.ToInt32(userId);
				var reservation = _reservationService.ConfirmReservation(confirmReservation);
				if (reservation != null)
				{
					TempData["SuccessMessage"] = "Onaylama işlemi başarıyla tamamlandı.";
				}

				return View(reservation);
			}
			//hata verirsin
			return View();
		}

		[HttpGet]
		public IActionResult OpCanceledReservation(OpIndexModelDTO manageReservationModel)
		{
			var canceledReservation = _reservationService.GetBySelectedReservationToOperator(manageReservationModel);
			if(canceledReservation == null)
			{
				return RedirectToAction("Index");	
			}
			return View("OpCanceledReservation", canceledReservation);
		}

		[HttpPost]
		public IActionResult OpCanceledReservation(Reservation canceledReservation)
		{
			var userId = _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
			if(!string.IsNullOrEmpty(userId))
			{
				canceledReservation.OperatorId = Convert.ToInt32(userId);
				var reservation = _reservationService.CanceledReservation(canceledReservation);

				if(reservation !=null)
				{
					TempData["SuccessMessage"] = "Randevu İptal işlemi başarı ile gerçekleştirildi";
				}
				return View(reservation);
			}
			return View();
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
			if (machine != null)
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
