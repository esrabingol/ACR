using ACR.Business.Abstract;
using ACR.Business.Models;
using ACR.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ASP.WEBUI.Controllers
{
	//[Authorize]
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
			var reservationInfo = _reservationService.Add(reservationModel);
			if (reservationInfo != null)
			{
				TempData["SuccessMessage"] = "Randevunuz Başarıyla Oluşturulmuştur.";
				TempData["WarningMessage"] = "Sistem üzerinden randevu takip işlemi sağlayabilirsiniz.";
			}
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public IActionResult ManageReservation(ReIndexModelDTO manageReservationModel)
		{
			var reservation = _reservationService.GetBySelectedReservationToRequester(manageReservationModel);
			if (reservation == null)
			{
				return RedirectToAction("Index");
			}
			return View("ManageReservation", reservation);

		}

		[HttpPost]
		public IActionResult ManageReservation(Reservation updateReservation)
		{
			var reservation = _reservationService.UpdateReservation(updateReservation);
			if (reservation != null)
			{
				TempData["SuccessMessage"] = "Güncelleme işlemi başarıyla tamamlandı.";
			}
			return View(reservation);
		}

		[HttpGet]
		public IActionResult GetAllReservations()
		{
			//Bilgi Getir
			var allReservations = _reservationService.GetAllReservationsToRequester();
			var reIndexModel = new ReIndexModelDTO
			{
				Results = allReservations
			};
			return View("Index", reIndexModel);
		}
	}
}
