using Microsoft.AspNetCore.Mvc;

namespace ASP.WEBUI.Controllers
{
	public class OperatorController : Controller
	{
		//Tüm operatör ekranları bu kısımda olucak

		//Operator anasayfa işlemleri
		public IActionResult Index()
		{
			return View();
		}

		
	}
}
