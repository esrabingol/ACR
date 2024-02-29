using ACR.Business.Abstract;
using ACR.Business.Models;
using ACR.Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP.WEBUI.Controllers
{
	//Register & Login Kısımları
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
			var userLogin =  _registerService.FindUser(loginModel);

			if (userLogin != null)
			{
				return RedirectToAction("Index", "Operator");
			}
			return View();

		}
	}
}
