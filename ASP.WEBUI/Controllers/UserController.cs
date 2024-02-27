using ACR.Business.Abstract;
using ACR.Business.Models;
using ACR.Entity.Concrete;
using ASP.WEBUI.Models;
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
				ModelState.AddModelError("", "Registration failed. Please check your information and try again.");
				return View(registerModel);
			}

		}


		[HttpGet]
		public IActionResult UserLogin()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UserLogin(UserLoginModel loginModel, int roleId)
		{
			if (ModelState.IsValid)
			{
				var user = _registerService.FindByEmail(loginModel.Email);

				if (user == null)
				{
					ModelState.AddModelError("", "Bu Email adresi ile eşleşen bir Email Adresi Bulunamadı");
				}
				else
				{
					var userLogin = _registerService.PasswordSignIn(loginModel.Email, loginModel.Password, roleId);
					if (userLogin)
					{
						if (roleId == 1)
						{
							return RedirectToAction("Index", "Operator");
						}
						else if (roleId == 2)
						{
							return RedirectToAction("Index", "Requester");
						}
					}
				}



			}

			return View();
		}
	}
}
