using ACR.Business.Abstract;
using ACR.Business.Models;
using ACR.Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ASP.WEBUI.Controllers
{
	public class AccountController : Controller
	{
		private IHttpContextAccessor _httpContext;
		private IRegisterService _registerService;
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		public AccountController(IHttpContextAccessor httpContext, IRegisterService registerService, UserManager<User> userManager, SignInManager<User> signInManager)
		{
			_httpContext = httpContext;
			_registerService = registerService;
			_userManager = userManager;
			_signInManager= signInManager;
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

		[HttpGet]
		public IActionResult EditPassword()
		{
			return View(new EditPasswordViewModelDTO());
		}

		[HttpPost]
		public async Task<IActionResult> EditPassword(EditPasswordViewModelDTO editPasswordViewModel)
		{
			if(!ModelState.IsValid)
			{
				return View(editPasswordViewModel);
			}
			var user = await _userManager.GetUserAsync(User);
			if( user == null)
			{
				ModelState.AddModelError("", "Mevcut kullanıcı bulunamadı");
				return View(editPasswordViewModel);
			}
			if(await _userManager.CheckPasswordAsync(user, editPasswordViewModel.OldPassword))
			{
				
				var result =  await _userManager.ChangePasswordAsync(user, editPasswordViewModel.OldPassword,editPasswordViewModel.NewPassword);
				if(!result.Succeeded)
				{
					result.Errors.ToList().ForEach(e => ModelState.AddModelError("", e.Description));
					return View(editPasswordViewModel);
				}

				await _userManager.UpdateAsync(user);
				await _signInManager.RefreshSignInAsync(user);

				TempData["SuccessMessage"] = "Şifreniz başarıyla güncellendi.";
				return RedirectToAction("EditPassword");

			}
			return View(editPasswordViewModel);
		}


	}
}
