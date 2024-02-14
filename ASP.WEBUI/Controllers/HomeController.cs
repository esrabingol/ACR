using Microsoft.AspNetCore.Mvc;

namespace ASP.WEBUI.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
