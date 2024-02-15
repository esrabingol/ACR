using ACR.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ASP.WEBUI.Controllers
{
	public class OperatorController : Controller
	{
		private IAutoclaveService _autoclaveService;
		//Tüm operatör ekranları bu kısımda olucak

		//Operator anasayfa işlemleri
		public IActionResult Index()
		{
			return View();
		}

		//Makine Bilgilerini Görüntüleme İşlemleri

		[HttpGet]
		public IActionResult ViewMachineInfo()
		{
			//tüm makineleri getirmesini sağlıyıcam.
			return View();
		}


		public IActionResult EditMachineInfo()
		{
			//Makine Bilgilerini Düzenle
			return View();
		}


		public IActionResult ManageReservation()
		{
			//Rezervasyon İşlemleri
			return View();
		}


    }
}
