using ACR.Business.Abstract;
using ACR.Business.Models;
using ACR.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

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
			var allReservations = _reservationService.GetAllReservationsToAdmin();
			var reservationsCount = _reservationService.GetAllReservationsToAdmin().Count();
			var allUsersCount = _registerService.GetAllUsers().Count();
			var allMachineCount = _machineService.GetAllMachines().Count();


			ViewBag.reservationsCount = reservationsCount;
			ViewBag.allusersCount = allUsersCount;
			ViewBag.allMachineCount = allMachineCount;

			var reservationCountsByMonth = allReservations
				.GroupBy(r => r.StartDate.Month)
				.OrderBy(g => g.Key)
				.Select(g => new
				{
					Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(g.Key),
					ReservationCount = g.Count()
				})
				.ToList();

			ViewBag.ReservationCountsByMonth = reservationCountsByMonth;

			var allMachines = _machineService.GetAllMachines();
			var onMachineCount = allMachines.Count(u => u.MachineStatus == "Aktif");
			var offMachineCount = allMachines.Count(u => u.MachineStatus == "Pasif");

			ViewBag.onMachineCount = onMachineCount;
			ViewBag.offMachineCount = offMachineCount;

			var allReservation = _reservationService.GetAllReservationsToAdmin();
			var pendingReservations = allReservation.Count(u => u.Status == ReservationStatusType.Pending);
			var confirmedReservations = allReservation.Count(u => u.Status == ReservationStatusType.Confirmed);
			var canceledReservations = allReservation.Count(u => u.Status == ReservationStatusType.Cancelled);

			ViewBag.pendingReservations = pendingReservations;
			ViewBag.confirmedReservations = confirmedReservations;
			ViewBag.canceledReservations = canceledReservations;

			return View();
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
			var allReservations = _reservationService.GetAllReservationsToAdmin();

			var reservationCountsByMonth = allReservations
				.GroupBy(r => r.StartDate.Month)
				.OrderBy(g => g.Key)
				.Select(g => new
				{
					Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(g.Key),
					ReservationCount = g.Count()
				})
				.ToList();

			var allUsers = _registerService.GetAllUsers();
			var operatorCount = allUsers.Count(u => u.RoleId == 1);
			var engineerCount = allUsers.Count(u => u.RoleId == 2);

			ViewBag.OperatorCount = operatorCount;
			ViewBag.EngineerCount = engineerCount;
			ViewBag.ReservationCountsByMonth = reservationCountsByMonth;

			return View();
		}

		public IActionResult AdminLogin()
		{
			return View();
		}
		public IActionResult AdminRegister()
		{
			return View();
		}

	}
}
