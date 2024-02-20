using ACR.Business.Abstract;
using ACR.Entity.Concrete;
using ASP.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.WEBUI.Controllers
{
	public class OperatorController : Controller
	{
		private IAutoclaveService _autoclaveService;

		//Operator anasayfa işlemleri
		public IActionResult Index()
		{
			return View();
		}

		//Makine Bilgilerini Görüntüleme İşlemleri
		//[HttpPost]
		public IActionResult ViewMachineInfo(OpMachineFilterModel opMachineFilterModel)
		{
			if (ModelState.IsValid)
			{
				var machineName = opMachineFilterModel.machineName;
				var filteredAutoclaves = _autoclaveService.GetByName(machineName);

				// Filtrelenmiş Autoclave nesnelerini ViewBag veya Model ile View'e gönder
				ViewBag.FilteredAutoclaves = filteredAutoclaves;

			}
			return View();
		}


		//Makine Bilgileri Düzenleme İşlemleri
		[HttpPost]
		public IActionResult EditMachineInfo(EditMachineModel editMachine)
		{
			if(ModelState.IsValid)
			{
				var autoclaveUpdate = new Autoclave
				{
					MachineName = editMachine.machineName,
					MachineStatu = editMachine.machineStatu,
					ItemNo = editMachine.itemNo,
					TcNumber = editMachine.tcNumber,
					VpNumber = editMachine.vpNumber,
					StartDate = editMachine.startDate,
					EndDate = editMachine.endDate,
					OperatorNote = editMachine.operatorNote
				};
			    var updateAutoclave = _autoclaveService.Update(autoclaveUpdate);
				return RedirectToAction("Index");
			}
		
			return View(editMachine);
		}


		public IActionResult ManageReservation()
		{
		   //Filtrelere uygun rezervasyonu getir

			return View();
		}


    }
}
