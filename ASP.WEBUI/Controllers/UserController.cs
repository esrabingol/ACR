using ACR.Business.Abstract;
using ACR.Entity.Concrete;
using ASP.WEBUI.Models;
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
          
				var newUser = new Users()
				{
					Name = registerModel.Name,
					Surname = registerModel.SurName,
					MailAdress = registerModel.MailAdress,
					Password = registerModel.Password,
					PhoneNumber = registerModel.PhoneNumber,
					RecordData = DateTime.Now.ToShortDateString().ToString(),
					UserRole = registerModel.UserRole
				};

				_registerService.Add(newUser);

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
        public async Task<IActionResult> UserLogin(UserLoginModel LoginModel)
        {
            //view oluşturulucak
			return View();
		}
		#endregion
	}
}
