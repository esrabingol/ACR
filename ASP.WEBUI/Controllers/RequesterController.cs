using ACR.Business.Abstract;
using ACR.Entity.Concrete;
using ASP.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace ASP.WEBUI.Controllers
{
    public class RequesterController : Controller
    {
        private IReservationService _reservationService;
        public IActionResult Index()
        {
            // TempData içinde SuccessMessage var mı kontrol et
            if (TempData.ContainsKey("SuccessMessage"))
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
            }

            return View();
        }
        public IActionResult ViewMachineInfo()
        {
            return View();
        }

        //Randevu Oluşturma işlemleri
        [HttpGet]
        public IActionResult CreateReservation()
        {
            return View(new CreateReservationModel());
        }

        [HttpPost]
        public IActionResult CreateReservation(CreateReservationModel reservationModel)
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

                TempData["SuccessMessage"] = "Randevu Başarıyla eklenmiştir.";

                return RedirectToAction("Index"); // Örneğin, bir anasayfaya yönlendirme
            }
            else
            {
                // Geçerlilik ihlali durumunda uygun bir hata mesajıyla geri dön
                return View(reservationModel);
            }
        }

        //

        public IActionResult ManageReservation()
        {
            return View();
        }
    }
}
