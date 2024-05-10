using ACR.Business.Abstract;
using ACR.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.WEBUI.Controllers
{
	public class AdminController : Controller
	{
		private IReservationService _reservationService;
		private IRegisterService _registerService;
		private IMachineService _machineService;

		public AdminController(IReservationService reservationService, IRegisterService registerService, IMachineService machineService)
		{
			_reservationService = reservationService;
			_registerService = registerService;
			_machineService = machineService;
		}

		public IActionResult Index()
		{
			var allusers = _registerService.GetAllUsers();
			var adUserModel = new AdViewUserModelDTO
			{
				Results = allusers
			};
			return View("Index", adUserModel);
		}
		public IActionResult Reservations()
        {
            var allreservations = _reservationService.GetAllReservationsToAdmin();
            var adReservationModel = new AdViewReservationModelDTO
            {
                Results = allreservations
            };
            return View("Reservations", adReservationModel);
        }
		public IActionResult Users()
		{
			var allusers = _registerService.GetAllUsers();
			var adUserModel = new AdViewUserModelDTO
			{
				Results = allusers
			};
			return View("Users", adUserModel);
		}
		public IActionResult Machines()
		{
			var allMachines = _machineService.GetAllMachines();
			var adMachineModel = new AdViewMachineModelDTO
			{
				Results = allMachines
			};
			return View("Machines", adMachineModel);


		}
		public IActionResult Statistics()
		{
			return View();
		}

	}
}
