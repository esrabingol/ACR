using ACR.Business.Abstract;
using ACR.Business.Models;
using ACR.Entity.Concrete;
using ASP.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.PortableExecutable;

namespace ASP.WEBUI.Controllers
{
	public class OperatorController : Controller
	{
		private IAutoclaveService _autoclaveService;
		private IReservationService _reservationService;

		public OperatorController(IAutoclaveService autoclaveService, IReservationService reservationService)
		{
			_autoclaveService = autoclaveService;
			_reservationService = reservationService;	
		}

		//Operator anasayfa işlemleri
		public IActionResult Index()
		{
			return View(new OpIndexModel());
		}

        [HttpPost]
        public IActionResult Index(OpIndexModel indexModel)
        {
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

        [HttpGet]
        public IActionResult ViewMachineInfo()
        {
            var machines = _autoclaveService.GetValues();
            var opMachineFilterModelDTO = new OpMachineFilterModelDTO { MachineNames = machines };
            return View(opMachineFilterModelDTO);
        }

        //Makine Bilgilerini Görüntüleme İşlemleri
        [HttpPost]
		public IActionResult ViewMachineInfo(OpMachineFilterModelDTO opMachineFilterModel)
		{
            // Filtreleme işlemini gerçekleştir
            var filteredMachineInfos = _autoclaveService.GetFilteredValues(opMachineFilterModel);

            // View'e filtrelenmiş bilgileri gönder
            var opMachineFilterModelDTO = new OpMachineFilterModelDTO
            {
                MachineNames = _autoclaveService.GetValues(), // Tüm makine isimlerini al
                MachineInfos = filteredMachineInfos // Filtrelenmiş bilgileri gönder
            };

            return View(opMachineFilterModelDTO);

        }


        [HttpGet]
        public IActionResult EditMachineInfo()
        {
            var machines = _autoclaveService.GetValues();
            var opEditMachineModelDTO = new OpEditMachineModelDTO { MachineNames = machines };
            return View(opEditMachineModelDTO);
        }

        //Makine Bilgileri Düzenleme İşlemleri
        [HttpPost]
		public IActionResult EditMachineInfo(OpEditMachineModelDTO editMachine)
		{
			    var updateAutoclave = _autoclaveService.UpdateMachineInfo(editMachine);
                ViewBag.FilteredAutoclaves = updateAutoclave;
                return RedirectToAction("Index");
		}

        [HttpGet]
        public IActionResult ManageReservation()
        {
            //admin ürün ekleme sayfasını görüntüleyecek
            return View(new OpReservationFilterModel());
        }

        //Rezervasyon Düzenleme İşlemi
        [HttpPost]
		public IActionResult ManageReservation(OpReservationFilterModel opReservationFilter)
		{
		   if(ModelState.IsValid)
			{
				var reservationFilter = new Reservation
				{
					machineName = opReservationFilter.machineName,
					projectName = opReservationFilter.projectName,
					partName = opReservationFilter.partName,
					startDate= opReservationFilter.startDate,
					endDate = opReservationFilter.endDate,
					startTime = opReservationFilter.startTime,
					endTime= opReservationFilter.endTime
				};

				var filterReservation = _reservationService.GetAllRezervations(reservationFilter);
                ViewBag.FilteredReservations = filterReservation;
            }

            return View();
		}


    }
}
