using Microsoft.AspNetCore.Mvc;

namespace ASP.WEBUI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult InfoUserID()
        {
            //Kimlik Bilgileri
            return View();
        }
        public IActionResult InfoContact()
        {
            //İletişim Bilgileri
            return View();
        }
        public IActionResult Security()
        {
            return View();
        }
    }
}
