using ACR.Business.Abstract;
using ACR.Business.Models;
using ACR.Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Claims;

namespace ASP.WEBUI.Controllers
{
	public class AdminController : Controller
	{
		private IReservationService _reservationService;
		private IRegisterService _registerService;
		private IMachineService _machineService;
		private IRoleService _roleService;
		private IHttpContextAccessor _httpContext;
		private readonly SignInManager<User> _signInManager;
		private readonly UserManager<User> _userManager;

		public AdminController(IReservationService reservationService, IRegisterService registerService,
			IMachineService machineService, IRoleService roleService, SignInManager<User> signInManager, UserManager<User> userManager, IHttpContextAccessor httpContext)
		{
			_reservationService = reservationService;
			_registerService = registerService;
			_machineService = machineService;
			_roleService = roleService;
			_signInManager = signInManager;
			_userManager = userManager;
			_httpContext = httpContext;
		}

		public IActionResult Index()
		{
			var allReservations = _reservationService.GetAllReservationsToAdmin();
			var reservationsCount = _reservationService.GetAllReservationsToAdmin().Count();
			var allUsersCount = _registerService.GetAllUsers().Count();
			var allMachineCount = _machineService.GetAllMachines().Count();


			ViewBag.reservationsCount = reservationsCount;
			ViewBag.allusersCount = allUsersCount;
			ViewBag.allMachineCount = allMachineCount;

			var reservationCountsByMonth = allReservations
				.GroupBy(r => r.StartDate.Month)
				.OrderBy(g => g.Key)
				.Select(g => new
				{
					Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(g.Key),
					ReservationCount = g.Count()
				})
				.ToList();

			ViewBag.ReservationCountsByMonth = reservationCountsByMonth;

			var allMachines = _machineService.GetAllMachines();
			var onMachineCount = allMachines.Count(u => u.MachineStatus == "Aktif");
			var offMachineCount = allMachines.Count(u => u.MachineStatus == "Pasif");

			ViewBag.onMachineCount = onMachineCount;
			ViewBag.offMachineCount = offMachineCount;

			var allReservation = _reservationService.GetAllReservationsToAdmin();
			var pendingReservations = allReservation.Count(u => u.Status == ReservationStatusType.Pending);
			var confirmedReservations = allReservation.Count(u => u.Status == ReservationStatusType.Confirmed);
			var canceledReservations = allReservation.Count(u => u.Status == ReservationStatusType.Cancelled);

			ViewBag.pendingReservations = pendingReservations;
			ViewBag.confirmedReservations = confirmedReservations;
			ViewBag.canceledReservations = canceledReservations;

			return View();
		}
		public IActionResult Reservations()
		{
			var allreservations = _reservationService.GetAllReservationsToAdmin();

			var adReservationModel = new AdViewReservationModelDTO
			{
				Results = allreservations
			};
			return View("Reservations", adReservationModel);
		}
		public IActionResult Users()
		{
			var allusers = _registerService.GetAllUsers();
			var adUserModel = new AdViewUserModelDTO
			{
				Results = allusers
			};
			return View("Users", adUserModel);
		}
		public IActionResult Machines()
		{
			var allMachines = _machineService.GetAllMachines();
			var adMachineModel = new AdViewMachineModelDTO
			{
				Results = allMachines
			};
			return View("Machines", adMachineModel);
		}
		public IActionResult Statistics()
		{
			var allReservations = _reservationService.GetAllReservationsToAdmin();

			var reservationCountsByMonth = allReservations
				.GroupBy(r => r.StartDate.Month)
				.OrderBy(g => g.Key)
				.Select(g => new
				{
					Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(g.Key),
					ReservationCount = g.Count()
				})
				.ToList();

			var allUsers = _registerService.GetAllUsers();
			var operatorCount = allUsers.Count(u => u.RoleId == 1);
			var engineerCount = allUsers.Count(u => u.RoleId == 2);

			ViewBag.OperatorCount = operatorCount;
			ViewBag.EngineerCount = engineerCount;
			ViewBag.ReservationCountsByMonth = reservationCountsByMonth;

			return View();
		}

		[HttpGet]
		public IActionResult AdminLogin()
		{
			return View(new UserLoginModelDTO());
		}

		[HttpPost]
		public async Task<IActionResult> AdminLogin(UserLoginModelDTO loginModel)
		{
			if (!ModelState.IsValid)
			{
				return View(loginModel);
			}
			var user = await _userManager.FindByEmailAsync(loginModel.MailAdress);
			if (user == null)
			{
				TempData["ErrorMessage"] = "Mevcut Hesap Bulunamadı! Bilgilerinizi kontrol edip tekrar deneyin.";
				return View(loginModel);
			}
			var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);

			if (result.Succeeded)
			{
				var roleId = await _registerService.GetRoleIdByEmail(loginModel.MailAdress);
				switch (roleId.Value)
				{
					case 3:
						return RedirectToAction("Index", "Admin");

					default:
						return RedirectToAction("AdminLogin", "Admin");
				}
			}
			else
			{
				TempData["ErrorMessage"] = "Kullancı Adı veya Parola Yanlış!";
			}
			return View(loginModel);
		}

		[HttpGet]
		public IActionResult AdminRegister()
		{
			var roles = _roleService.GetRoles();
			var userRegisterModelDTO = new UserRegisterModelDTO { Roles = roles };
			return View(userRegisterModelDTO);
		}
		[HttpPost]
		public async Task<IActionResult> AdminRegister(UserRegisterModelDTO registerModel)
		{
			var newAdmin = await _registerService.Add(registerModel);
			if (newAdmin != null)
			{
				TempData["SuccessMessage"] = "Kaydınız Başarıyla Oluşturulmuştur!";
				return RedirectToAction("AdminLogin");
			}
			else
			{
				ModelState.AddModelError("", "Kaydınız oluşturulamadı eksik kısımları tamamlayınız.");
				return View(registerModel);
			}
		}

		//--Autoclaves--//
		[HttpGet]
		public IActionResult ViewMachineInfo()
		{
			var machines = _machineService.GetValues();
			var opMachineFilterModelDTO = new AdMachineFilterModelDTO { MachineNames = machines };
			return View(opMachineFilterModelDTO);
		}
		[HttpPost]
		public IActionResult ViewMachineInfo(AdMachineFilterModelDTO viewMachine)
		{
			var filteredMachines = _machineService.GetFilteredValues(viewMachine);
			viewMachine.Results = filteredMachines;
			return View(viewMachine);
		}


		[HttpGet]
		public IActionResult EditMachineInfo(AdMachineFilterModelDTO editMachine)
		{
			var machine = _machineService.GetBySelectedMachine(editMachine);
			if (machine == null)
			{
				return RedirectToAction("ViewMachineInfo");
			}
			return View("EditMachineInfo", machine);
		}

		[HttpPost]
		public IActionResult EditMachineInfo(Machine updatedMachine)
		{
			var machine = _machineService.UpdateMachineInfo(updatedMachine);
			if (machine != null)
			{
				TempData["SuccessMessage"] = "Güncelleme işlemi başarıyla tamamlandı.";
			}
			return View(machine);
		}

		[HttpGet]
		public IActionResult AddNewMachine()
		{
			return View(new AdAddNewMachineModelDTO());
		}
		[HttpPost]
		public IActionResult AddNewMachine(AdAddNewMachineModelDTO addMachine)
		{
			var addNewMachine = _machineService.AddNewMachineInfo(addMachine);
			return RedirectToAction("ViewMachineInfo", "Admin");
		}

		[HttpGet]
		public IActionResult GetAllMachines()
		{
			var allmachines = _machineService.GetAllMachines();
			var opMachineModel = new AdMachineFilterModelDTO
			{
				Results = allmachines
			};
			return View("ViewMachineInfo", opMachineModel);
		}

		[HttpGet]
		public IActionResult DeleteMachine(AdMachineFilterModelDTO deleteMachine)
		{
			var machine = _machineService.GetBySelectedMachine(deleteMachine);
			if (machine == null)
			{
				return RedirectToAction("ViewMachineInfo");
			}
			return View("DeleteMachine", machine);
		}
		[HttpPost]
		public IActionResult DeleteMachine(int Id)
		{
			var machine = _machineService.GetBySelectedMachineToId(Id);
			if (machine != null)
			{
				TempData["SuccessMessage"] = "Pasife alma işlemi başarıyla tamamlandı.";
			}
			return View(machine);
		}

		//--Reservations--//
		public IActionResult ReservationIndex()
		{
			var machines = _machineService.GetValues();
			var opCreateIndexModelDTO = new ReIndexModelDTO { MachineNames = machines };
			return View(opCreateIndexModelDTO);
		}

		[HttpPost]
		public IActionResult ReservationIndex(ReIndexModelDTO indexModel)
		{
			var filterReservations = _reservationService.GetAllRezervationsRequester(indexModel);
			indexModel.Results = filterReservations;
			return View(indexModel);
		}

		[HttpGet]
		public IActionResult CreateReservation(string machineName = null)
		{
			var machines = _machineService.GetValues();
			var opCreateReservationModelDTO = new ReCreateReservationModelDTO { MachineNames = machines };
			return View(opCreateReservationModelDTO);
		}

		[HttpPost]
		public IActionResult CreateReservation(ReCreateReservationModelDTO reservationModel)
		{
			var reservedDates = _reservationService.GetReservedDatesByMachineName(reservationModel.MachineName);

			var isDateReserved = reservedDates.Any(rd =>
				(rd.StartDate <= reservationModel.StartDate && rd.EndDate >= reservationModel.StartDate) ||
				(rd.StartDate <= reservationModel.EndDate && rd.EndDate >= reservationModel.EndDate) ||
				(reservationModel.StartDate <= rd.StartDate && reservationModel.EndDate >= rd.EndDate));

			if (isDateReserved)
			{
				ModelState.AddModelError("StartDate", "Seçilen tarih aralığı dolu. Lütfen başka bir tarih seçin.");
				return View(reservationModel);
			}

			var reservationInfo = _reservationService.Add(reservationModel);
			if (reservationInfo != null)
			{
				TempData["SuccessMessage"] = "Randevunuz Başarıyla Oluşturulmuştur.";
				TempData["WarningMessage"] = "Sistem üzerinden randevu takip işlemi sağlayabilirsiniz.";
			}
			return RedirectToAction(nameof(ReservationIndex));
		}

		[HttpGet]
		public IActionResult AdCanceledReservation(ReIndexModelDTO manageReservation)
		{
			var canceledReservation = _reservationService.GetBySelectedReservationToAdmin(manageReservation);
			if (canceledReservation == null)
			{
				return RedirectToAction("ReservationIndex");
			}
			return View("AdCanceledReservation", canceledReservation);
		}

		[HttpPost]
		public IActionResult AdCanceledReservation(Reservation canceledReservation)
		{
			var userId = _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
			if (!string.IsNullOrEmpty(userId))
			{
				canceledReservation.RequesterId = Convert.ToInt32(userId);
				canceledReservation.DeletedBy = Convert.ToInt32(userId);
				var reservation = _reservationService.ReCanceledReservation(canceledReservation);

				if (reservation != null)
				{
					TempData["SuccessMessage"] = "Randevu İptal işlemi başarı ile gerçekleştirildi";
				}
				return View(reservation);
			}
			return View();
		}

		[HttpGet]
		public IActionResult ManageReservation(ReIndexModelDTO manageReservationModel)
		{
			var reservation = _reservationService.GetBySelectedReservationToRequester(manageReservationModel);
			if (reservation == null)
			{
				return RedirectToAction("ReservationIndex");
			}
			return View("ManageReservation", reservation);
		}

		[HttpPost]
		public IActionResult ManageReservation(Reservation updateReservation)
		{
			var reservation = _reservationService.UpdateReservation(updateReservation);
			if (reservation != null)
			{
				TempData["SuccessMessage"] = "Güncelleme işlemi başarıyla tamamlandı.";
			}
			return View(reservation);
		}

		[HttpGet]
		public IActionResult GetAllReservations()
		{
			var allReservations = _reservationService.GetAllReservationsToAdmin();
			var reIndexModel = new ReIndexModelDTO
			{
				Results = allReservations
			};
			return View("ReservationIndex", reIndexModel);
		}
	}
}
