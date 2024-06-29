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
				//var user = _registerService.FindUserById(Id);
				//if (user != null)
				//{
				//	return View("InfoUserID", user);
				//}
				//else
				//{
				//	RedirectToAction("Index", "Home");
				//}

				var result = _registerService.FindUserById(Id);
				if(result.Success && result.Data !=null)
				{
					return View("InfoUserId", result.Data);
				}
				else
				{
					TempData["ErrorMessage"] = "Kullanıcı bulunamadı.";
					return RedirectToAction("Index", "Home");
				}
			}
			TempData["ErrorMessage"] = "Geçersiz kullanıcı ID.";
			return RedirectToAction("Index", "Home");

		}

		[HttpPost]
		public IActionResult InfoUserID(User updateUser)
		{
			var result = _registerService.UpdateUserInfo(updateUser);
			if (result.Success)
			{
				TempData["SuccessMessage"] = "Kimlik Bilgileri başarıyla güncellendi.";
				return RedirectToAction("InfoUserID");
			}
			else
			{
				TempData["ErrorMessage"] = "Kullanıcı bilgileri güncellenirken bir hata oluştu.";
			}

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
