using ACR.Business.Abstract;
using ACR.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.WEBUI.Controllers
{
	public class RequesterController : Controller
	{
		private IReservationService _reservationService;
		private IMachineService _machineService;
		private IRegisterService _registerService;

		public RequesterController(IMachineService machineService, IReservationService reservationService, IRegisterService registerService)
		{
			_machineService = machineService;
			_reservationService = reservationService;
			_registerService = registerService;
		}
		public IActionResult Index()
		{

			var machines = _machineService.GetValues();
			var opCreateIndexModelDTO = new ReIndexModelDTO { MachineNames = machines };
			return View(opCreateIndexModelDTO);
		}

		[HttpPost]
		public IActionResult Index(ReIndexModelDTO indexModel)
		{
			var filterReservations = _reservationService.GetAllRezervationsRequester(indexModel);
			indexModel.Results = filterReservations;
			return View(indexModel);
		}

		[HttpGet]
		public IActionResult CreateReservation()
		{
			var machines = _machineService.GetValues();
			var opCreateReservationModelDTO = new ReCreateReservationModelDTO { MachineNames = machines };
			return View(opCreateReservationModelDTO);
		}

		[HttpPost]
		public IActionResult CreateReservation(ReCreateReservationModelDTO reservationModel)
		{
			var reservationMachineInfos = _reservationService.Add(reservationModel);
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public IActionResult ManageReservation()
		{
			var machines = _machineService.GetValues();
			var opManageMachineModelDTO = new ReManageReservationModelDTO { MachineNames = machines };
			return View(opManageMachineModelDTO);
		}

		[HttpPost]
		public IActionResult ManageReservation(ReManageReservationModelDTO manageReservationModel)
		{
			var updateReservation = _reservationService.UpdateReservation(manageReservationModel);

			return View(updateReservation);
		}

	}
}
