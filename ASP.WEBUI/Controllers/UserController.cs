using ACR.Business.Abstract;
using ACR.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.WEBUI.Controllers
{
    public class UserController : Controller
    {
        private IRegisterService _registerService;
        private IRoleService _roleService;

        public UserController(IRegisterService registerService, IRoleService roleService)
        {
            _registerService = registerService;
            _roleService = roleService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserRegister()
        {
            var roles = _roleService.GetRoles();
            var userRegisterModelDTO = new UserRegisterModelDTO { Roles = roles };
            return View(userRegisterModelDTO);
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterModelDTO registerModel)
        {
            var newUser = await _registerService.Add(registerModel);
            if (newUser != null)
            {
				TempData["SuccessMessage"] = "Kaydınız başarıyla oluşturuldu.";
				return RedirectToAction("UserLogin");
            }
            else
            {
                ModelState.AddModelError("", "Kaydınız oluşturulamadı eksik kısımları tamamlayınız.");
                return View(registerModel);
            }
        }

        [HttpGet]
        public IActionResult UserLogin()
        {
            return View(new UserLoginModelDTO());
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginModelDTO loginModel)
        {
			
			var userLogin = await _registerService.FindUser(loginModel);
            var roleId = await _registerService.GetRoleIdByEmail(loginModel.MailAdress);
            if (roleId.HasValue)
            {
                switch (roleId.Value)
                {
                    case 1:
                        return RedirectToAction("Index", "Operator");
                    case 2:
                        return RedirectToAction("Index", "Requester");
                    default:
                        return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
    }
}
