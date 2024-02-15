using Microsoft.AspNetCore.Mvc;

namespace ASP.WEBUI.Controllers
{
    public class RequesterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewMachineInfo()
        {
            return View();
        }

       
        public IActionResult CreateReservation()
        {
            return View();
        }
        public IActionResult ManageReservation()
        {
            return View();
        }
    }
}
