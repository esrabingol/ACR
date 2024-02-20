using ACR.Business.Abstract;
using ACR.Entity.Concrete;
using ASP.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.WEBUI.Controllers
{
	public class OperatorController : Controller
	{
		private IAutoclaveService _autoclaveService;
		private IReservationService _reservationService;

		//Operator anasayfa işlemleri
		public IActionResult Index()
		{
			return View();
		}

        public IActionResult ListMachine()
        {
            var machineNames = _autoclaveService.GetList();
            ViewBag.MachineNames = machineNames;

            return View();
        }

        [HttpGet]
        public IActionResult ViewMachineInfo()
        {
            //admin ürün ekleme sayfasını görüntüleyecek
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
            return View(new EditMachineModel());
        }

        //Makine Bilgileri Düzenleme İşlemleri
        [HttpPost]
		public IActionResult EditMachineInfo(EditMachineModel editMachine)
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
					MachineName = opReservationFilter.machineName,
					ProjectName = opReservationFilter.projectName,
					PartName = opReservationFilter.partName,
					StartDate= opReservationFilter.startDate,
					EndDate = opReservationFilter.endDate,
					StartTime = opReservationFilter.startTime,
					EndTime= opReservationFilter.endTime
				};

				var filterReservation = _reservationService.GetAllRezervations(reservationFilter);
                ViewBag.FilteredReservations = filterReservation;
            }

            return View();
		}


    }
}
