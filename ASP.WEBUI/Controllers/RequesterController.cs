using ACR.Business.Abstract;
using ACR.Business.Models;
using ACR.Entity.Concrete;
using ASP.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Drawing;

namespace ASP.WEBUI.Controllers
{
    public class RequesterController : Controller
    {
        private IReservationService _reservationService;
        private IAutoclaveService _autoclaveService;
        private IRegisterService _registerService;

		public RequesterController(IAutoclaveService autoclaveService, IReservationService reservationService, IRegisterService registerService)
		{
			_autoclaveService = autoclaveService;
			_reservationService = reservationService;
            _registerService = registerService;
    }
		public IActionResult Index()
        {
            return View(new ReIndexModel());
        }

        [HttpPost]
        public IActionResult Index(ReIndexModel indexModel)
        {
            // TempData içinde SuccessMessage var mı kontrol et
            if (TempData.ContainsKey("SuccessMessageOne"))
            {
                ViewBag.SuccessMessage = TempData["SuccessMessageOne"];
            }
            if (TempData.ContainsKey("SuccessMessageTwo"))
            {
                ViewBag.SuccessMessage = TempData["SuccessMessageTwo"];
            }

            if (ModelState.IsValid)
            {
                var reservationFilter = new Reservation
                {
                    machineName = indexModel.machineName,
                    projectName = indexModel.projectName,
                    partName = indexModel.partName,
                    startDate = indexModel.startDate,
                    endDate = indexModel.endDate,
                    startTime = indexModel.startTime,
                    endTime = indexModel.endTime
                };

                // Business katmanında bulunan bir servis metodu ile verileri filtrele
                var filterReservations = _reservationService.GetAllRezervations(reservationFilter);
                // Filtrelenmiş rezervasyonları model içine ekleyin
                indexModel.Results = filterReservations;
            }

            // Model geçerli değilse, aynı sayfayı tekrar göster
            return View(indexModel);
        }

        //Randevu Oluşturma işlemleri
        [HttpGet]
        public IActionResult CreateReservation()
        {
            //int requesterId = _registerService.GetCurrentUserId(); // bu şekilde mevcut kullanıcı alınıcak
            var machines = _autoclaveService.GetValues();
            var opCreateMachineModelDTO = new ReCreateReservationModelDTO { MachineNames = machines };
            return View(opCreateMachineModelDTO);
        }

        [HttpPost]
        public IActionResult CreateReservation(ReCreateReservationModelDTO reservationModel)
        {
            var reservationMachineInfos = _reservationService.Add(reservationModel);

            return View(reservationMachineInfos);
        }

        //Randevu Düzenleme İşlemleri

        [HttpGet]
        public IActionResult ManageReservation()
        {
            var machines = _autoclaveService.GetValues();
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
