using ACR.Business.Abstract;
using ACR.Entity.Concrete;
using ASP.WEBUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASP.WEBUI.Controllers
{
	//Register & Login Kısımları
	public class UserController : Controller
	{
		private IRegisterService _registerService; // iş katmanına göndermemi sağlayacak
		public IActionResult Index()
		{
			return View();
		}


		#region Kullanıcı Kaydı

		[HttpGet]
		public IActionResult UserRegister()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UserRegister(UserRegisterModel registerModel)
		{
			if (ModelState.IsValid)
			{
				var newUser = new Users()
				{
					Name = registerModel.Name,
					Surname = registerModel.SurName,
					MailAdress = registerModel.MailAdress,
					Password = registerModel.Password,
					PhoneNumber = registerModel.PhoneNumber,
					UserRole = registerModel.UserRole
				};

				_registerService.Add(newUser);

				// Kullanıcı başarıyla eklenirse UserLogin action'ına yönlendir
				return RedirectToAction("UserLogin");
			}

			// Eğer ModelState geçerli değilse, hata mesajlarını göster ve aynı sayfada kal
			ModelState.AddModelError("", "Kullanıcı eklenirken bir hata oluştu. Lütfen bilgilerinizi kontrol edin.");
			return View();
		}

		#endregion

		#region Giris Yap

		[HttpGet]
		public IActionResult UserLogin()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UserLogin(UserLoginModel loginModel, string userRole)
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
                    var userLogin = _registerService.PasswordSignIn(loginModel.Email, loginModel.Password, userRole);
					if(userLogin)
					{
						if(userRole == "OPERATÖR")
						{
							return RedirectToAction("Index", "Operator");
						}
						else if(userRole =="ÜRETİM MÜHENDİSİ")
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

#endregion