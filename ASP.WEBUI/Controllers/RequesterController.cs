using ACR.Business.Abstract;
using ACR.Business.Models;
using ACR.Entity.Concrete;
using ASP.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.WEBUI.Controllers
{
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
            return View(new ReIndexModel());
        }

        [HttpPost]
        public IActionResult Index(ReIndexModel indexModel)
        {
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
                    MachineName = indexModel.MachineName,
                    ProjectName = indexModel.ProjectName,
                    PartName = indexModel.PartName,
                    StartDate = indexModel.StartDate,
                    EndDate = indexModel.EndDate,
                };
                var filterReservations = _reservationService.GetAllRezervations(reservationFilter);
                indexModel.Results = filterReservations;
            }
            return View(indexModel);
        }

        [HttpGet]
        public IActionResult CreateReservation()
        {
            var machines = _machineService.GetValues();
            var opCreateMachineModelDTO = new ReCreateReservationModelDTO { MachineNames = machines };
            return View(opCreateMachineModelDTO);
        }

        [HttpPost]
        public IActionResult CreateReservation(ReCreateReservationModelDTO reservationModel)
        {
            var reservationMachineInfos = _reservationService.Add(reservationModel);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult ManageReservation()
        {
            var machines = _machineService.GetValues();
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
