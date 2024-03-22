using ACR.Business.Abstract;
using ACR.Business.Models;
using ACR.Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASP.WEBUI.Controllers
{
	public class UserController : Controller
	{
		private IRegisterService _registerService;
		private IRoleService _roleService;
		private readonly SignInManager<User> _signInManager;
		private readonly UserManager<User> _userManager;

		public UserController(IRegisterService registerService, IRoleService roleService, SignInManager<User> signInManager, UserManager<User> userManager)
		{
			_registerService = registerService;
			_roleService = roleService;
			_signInManager = signInManager;
			_userManager = userManager;
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
			if (!ModelState.IsValid)
			{
				return View(loginModel);
			}
			var user = await _userManager.FindByEmailAsync(loginModel.MailAdress);

			if (user == null)
			{
				TempData["ErrorMessage"] = "Mevcut Hesap Bulunamadı! Bilgilerinizi Kontrol Ediniz.";
				return View(loginModel);
			}
			var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);

			if (result.Succeeded)
			{
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
			}
			else
			{
				TempData["ErrorMessage"] = "Kullancı Adı veya Parola Yanlış!";
			}


			return View(loginModel);
		}
	}
}
			
