﻿using ACR.Business.Abstract;
using ACR.Business.Models;
using ASP.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.WEBUI.Controllers
{
	public class OperatorController : Controller
	{
		private IMachineService _machineService;
		private IReservationService _reservationService;

		public OperatorController(IMachineService machineService, IReservationService reservationService)
		{
			_machineService = machineService;
			_reservationService = reservationService;
		}

		public IActionResult Index()
		{
			var machines = _machineService.GetValues();
			var opCreateIndexModelDTO = new OpIndexModelDTO { MachineNames = machines };
			return View(opCreateIndexModelDTO); ;
		}

		[HttpPost]
		public IActionResult Index(OpIndexModelDTO indexModel)
		{
			var filterReservations = _reservationService.GetAllRezervationsOperator(indexModel);
			indexModel.Results = filterReservations;
			return View(indexModel);
		}

		[HttpGet]
		public IActionResult ViewMachineInfo()
		{
			var machines = _machineService.GetValues();
			var opMachineFilterModelDTO = new OpMachineFilterModelDTO { MachineNames = machines };
			return View(opMachineFilterModelDTO);
		}

		[HttpPost]
		public IActionResult ViewMachineInfo(OpMachineFilterModelDTO opMachineFilterModel)
		{
			var filteredMachineInfos = _machineService.GetFilteredValues(opMachineFilterModel);
			var opMachineFilterModelDTO = new OpMachineFilterModelDTO
			{
				MachineNames = _machineService.GetValues(),
				MachineInfos = filteredMachineInfos
			};
			return View(opMachineFilterModelDTO);
		}

		[HttpGet]
		public IActionResult EditMachineInfo()
		{
			var machines = _machineService.GetValues();
			var opEditMachineModelDTO = new OpEditMachineModelDTO { MachineNames = machines };
			return View(opEditMachineModelDTO);
		}

		[HttpPost]
		public IActionResult EditMachineInfo(OpEditMachineModelDTO editMachine)
		{
			var updateAutoclave = _machineService.UpdateMachineInfo(editMachine);
			ViewBag.FilteredAutoclaves = updateAutoclave;
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult ManageReservation()
		{
			return View(new OpReservationFilterModel());
		}

		//[HttpPost]
		//public IActionResult ManageReservation(OpReservationFilterModel opReservationFilter)
		//{
		//    if (ModelState.IsValid)
		//    {
		//        var reservationFilter = new Reservation
		//        {
		//            MachineName = opReservationFilter.MachineName,
		//            ProjectName = opReservationFilter.ProjectName,
		//            PartName = opReservationFilter.PartName,
		//            StartDate = opReservationFilter.StartDate,
		//            EndDate = opReservationFilter.EndDate,
		//        };
		//        var filterReservation = _reservationService.GetAllRezervations(reservationFilter);
		//        ViewBag.FilteredReservations = filterReservation;
		//    }
		//    return View();
		//}
	}
}
