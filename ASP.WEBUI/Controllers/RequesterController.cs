using ACR.Business.Abstract;
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

        //public IActionResult ListMachine()
        //{

        //    var machineNames = _autoclaveService.GetList();
        //    ViewBag.MachineNames = machineNames;

        //    return View();
        //}
        public IActionResult ViewMachineInfo()
        {
            return View();
        }

        //Randevu Oluşturma işlemleri
        [HttpGet]
        public IActionResult CreateReservation()
        {
            return View(new ReCreateReservationModel());
        }

        [HttpPost]
        public IActionResult CreateReservation(ReCreateReservationModel reservationModel)
        {
            if (ModelState.IsValid)
            {
                var reservationCreate = new Reservation
                {
                    machineName = reservationModel.machineName,
                    projectName = reservationModel.projectName,
                    recipeCode = reservationModel.recipeCode,
                    startDate = reservationModel.startDate,
                    endDate = reservationModel.endDate,
                    startTime = reservationModel.startTime,
                    endTime = reservationModel.endTime
                };

                var createReservation = _reservationService.Add(reservationCreate);

                TempData["SuccessMessageOne"] = "Randevu Başarıyla eklenmiştir.";

                return RedirectToAction("Index"); 
            }
            else
            {
                // Geçerlilik ihlali durumunda uygun bir hata mesajıyla geri dön
                return View(reservationModel);
            }
        }

        //

        //Randevu Düzenleme İşlemleri

        [HttpGet]
        public IActionResult ManageReservation()
        {
            return View(new ReManageReservationModel());
        }

        [HttpPost]
        public IActionResult ManageReservation(ReManageReservationModel manageReservationModel)
        {
            if(ModelState.IsValid)
            {
                var reservationUpdate = new Reservation
                {
                    machineName = manageReservationModel.machineName,
                    projectName = manageReservationModel.projectName,
                    recipeCode = manageReservationModel.recipeCode,
                    requestNote = manageReservationModel.requestNote,
                    startDate = manageReservationModel.startDate,
                    endDate = manageReservationModel.endDate,
                    startTime = manageReservationModel.startTime,
                    endTime = manageReservationModel.endTime
                };
                var updateReservation = _reservationService.Update(reservationUpdate);

                TempData["SuccessMessageTwo"] = "Randevu Başarıyla Güncellenmiştir.";

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
