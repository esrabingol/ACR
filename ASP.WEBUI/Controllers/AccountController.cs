using ACR.Business.Abstract;
using ACR.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ASP.WEBUI.Controllers
{
    public class AccountController : Controller
    {
        private IHttpContextAccessor _httpContext;
        private IRegisterService _registerService;
        public AccountController(IHttpContextAccessor httpContext, IRegisterService registerService)
        {
            _httpContext = httpContext;
            _registerService = registerService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult InfoUserID()
        {
            var userId = _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (int.TryParse(userId, out int Id))
            {
                var user = _registerService.FindUserById(Id);
                if (user != null)
                {
                    return View("InfoUserID", user);
                }
                else
                {
                    RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult InfoUserID(User updateUser)
        {
                var user = _registerService.UpdateUserInfo(updateUser);
                if (user != null)
                {
                    TempData["SuccessMessage"] = "Kimlik Bilgileri başarıyla güncellendi.";
                    return RedirectToAction("InfoUserID"); // Bu, sayfanın tekrar yüklenmesini sağlar.
                }
                else
                {
                    TempData["ErrorMessage"] = "Kullanıcı bilgileri güncellenirken bir hata oluştu.";
                }
                // Eğer ModelState geçersizse veya kullanıcı güncellenemezse, aynı View'i tekrar gösterin.
            return View("InfoUserID", updateUser);
        }

    }
}
