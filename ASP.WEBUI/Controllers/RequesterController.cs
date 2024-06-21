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
		private IHttpContextAccessor _httpContext;
		public RequesterController(IMachineService machineService, IReservationService reservationService,
			IRegisterService registerService, IHttpContextAccessor httpContext)
		{
			_machineService = machineService;
			_reservationService = reservationService;
			_registerService = registerService;
			_httpContext = httpContext;
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
		public IActionResult CreateReservation(string machineName = null)
		{
			var machines = _machineService.GetValues();
			var opCreateReservationModelDTO = new ReCreateReservationModelDTO { MachineNames = machines };
			return View(opCreateReservationModelDTO);
		}

		[HttpPost]
		public IActionResult CreateReservation(ReCreateReservationModelDTO reservationModel)
		{
			var reservedDates = _reservationService.GetReservedDatesByMachineName(reservationModel.MachineName);

			var isDateReserved = reservedDates.Any(rd =>
				(rd.StartDate <= reservationModel.StartDate && rd.EndDate >= reservationModel.StartDate) ||
				(rd.StartDate <= reservationModel.EndDate && rd.EndDate >= reservationModel.EndDate) ||    
				(reservationModel.StartDate <= rd.StartDate && reservationModel.EndDate >= rd.EndDate)); 

			if (isDateReserved)
			{
				ModelState.AddModelError("StartDate", "Seçilen tarih aralığı dolu. Lütfen başka bir tarih seçin.");
				return View(reservationModel);
			}

			var reservationInfo = _reservationService.Add(reservationModel);
			if (reservationInfo != null)
			{
				TempData["SuccessMessage"] = "Randevunuz Başarıyla Oluşturulmuştur.";
				TempData["WarningMessage"] = "Sistem üzerinden randevu takip işlemi sağlayabilirsiniz.";
			}
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public IActionResult ReCanceledReservation(ReIndexModelDTO manageReservation)
		{
			var canceledReservation = _reservationService.GetBySelectedReservationToRequester(manageReservation);
			if(canceledReservation == null)
			{
				return RedirectToAction("Index");
			}
			return View("ReCanceledReservation", canceledReservation);
		}

		[HttpPost]
		public IActionResult ReCanceledReservation(Reservation canceledReservation)
		{
			var userId = _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
			if(!string.IsNullOrEmpty(userId))
			{
				canceledReservation.RequesterId = Convert.ToInt32(userId);
				canceledReservation.DeletedBy = Convert.ToInt32(userId);
				var reservation = _reservationService.ReCanceledReservation(canceledReservation);

				if (reservation != null)
				{
					TempData["SuccessMessage"] = "Randevu İptal işlemi başarı ile gerçekleştirildi";
				}
				return View(reservation);
			}
			return View();
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
			var allReservations = _reservationService.GetAllReservationsToRequester();
			var reIndexModel = new ReIndexModelDTO
			{
				Results = allReservations
			};
			return View("Index", reIndexModel);
		}


	}
}
