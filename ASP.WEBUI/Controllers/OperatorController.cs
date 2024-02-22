using ACR.Business.Abstract;
using ACR.Entity.Concrete;
using ASP.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP.WEBUI.Controllers
{
	public class OperatorController : Controller
	{
		private IAutoclaveService _autoclaveService;
		private IReservationService _reservationService;

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

        //public IActionResult ListMachine()
        //{

        //    var machineNames = _autoclaveService.GetList();
        //    ViewBag.MachineNames = machineNames;

        //    return View();
        //}

        [HttpGet]
        public IActionResult ViewMachineInfo()
        {
            return View(new OpMachineFilterModel());
        }

        //Makine Bilgilerini Görüntüleme İşlemleri
        [HttpPost]
		public IActionResult ViewMachineInfo(OpMachineFilterModel opMachineFilterModel)
		{
			if (ModelState.IsValid)
			{
				var machineName = opMachineFilterModel.machineName;
				var filteredAutoclaves = _autoclaveService.GetByName(machineName);

				// Filtrelenmiş Autoclave nesnelerini ViewBag veya Model ile View'e gönder
				ViewBag.FilteredAutoclaves = filteredAutoclaves;
			}
			return View();
		}


        [HttpGet]
        public IActionResult EditMachineInfo()
        {
            //admin ürün ekleme sayfasını görüntüleyecek
            return View(new OpEditMachineModel());
        }

        //Makine Bilgileri Düzenleme İşlemleri
        [HttpPost]
		public IActionResult EditMachineInfo(OpEditMachineModel editMachine)
		{
			if(ModelState.IsValid)
			{
				var autoclaveUpdate = new Autoclave
				{
					MachineName = editMachine.machineName,
					MachineStatu = editMachine.machineStatu,
					ItemNo = editMachine.itemNo,
					TcNumber = editMachine.tcNumber,
					VpNumber = editMachine.vpNumber,
					StartDate = editMachine.startDate,
					EndDate = editMachine.endDate,
					OperatorNote = editMachine.operatorNote
				};
			    var updateAutoclave = _autoclaveService.Update(autoclaveUpdate);
                ViewBag.FilteredAutoclaves = updateAutoclave;
                return RedirectToAction("Index");
			}
		
			return View(editMachine);
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
