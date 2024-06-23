using ACR.Business.Abstract;
using ACR.Business.Models;
using ACR.Business.Utilities.Messages;
using ACR.DataAccess.Abstract;
using ACR.Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;
using System.Security.Claims;

namespace ACR.Business.Concrete
{
	public class ReservationManager : IReservationService
	{
		private IReservationDal _reservationDal;
		private IHttpContextAccessor _httpContext;
		private IUserDal _userDal;

		public ReservationManager(IReservationDal reservationDal, IHttpContextAccessor httpContext, IUserDal userDal)
		{
			_reservationDal = reservationDal;
			_httpContext = httpContext;
			_userDal = userDal;
		}
		public Reservation Add(ReCreateReservationModelDTO reReservationFilterModel)
		{
			var userId = _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
			var reservationAdd = new Reservation
			{
				MachineName = reReservationFilterModel.MachineName,
				ProjectName = reReservationFilterModel.ProjectName,
				PartName = reReservationFilterModel.PartName,
				RecipeCode = reReservationFilterModel.RecipeCode,
				RequestNote = reReservationFilterModel.RequestNote,
				StartDate = reReservationFilterModel.StartDate,
				EndDate = reReservationFilterModel.EndDate,
				RequesterId = Convert.ToInt32(userId),
				CreateDate = DateTime.UtcNow,
				CreatedBy = Convert.ToInt32(userId)
			};

			var reservation = _reservationDal.AddReservation(reservationAdd);
			return reservation;
		}
		public Reservation ConfirmReservation(Reservation confirmReservationModel)
		{
			return _reservationDal.UpdateConfirmReservation(confirmReservationModel);
		}
		public void Delete(Reservation rezervation)
		{
			_reservationDal.Delete(rezervation);
		}
		public List<Reservation> GetAllReservationsToRequester()
		{
			var userId = int.Parse(_httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
			var filters = new List<Func<Reservation, bool>>
			{
				r => r.RequesterId == userId
			};

			Expression<Func<Reservation, object>>[] includes =
			{
				o => o.Requester,
				y => y.Operator
			};

			var allReservations = _reservationDal.GetAll(filters, includes)?.OrderByDescending(r => r.StartDate)?.ToList();
			User responseUser;

			if(allReservations != null)
			{
				foreach (var user in allReservations)
				{
					if (user.UpdatedBy.HasValue)
					{
						responseUser = _userDal.GetById(user.UpdatedBy.Value);
						user.UpdatedUserName = responseUser.Name + " " + responseUser.Surname;
					}
				}
			}

			return allReservations;
		}
		public List<Reservation> GetAllReservationsToOperator()
		{
			var userId = _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

			var reservations = _reservationDal.GetAll(null, o => o.Requester, y => y.Operator)
				.OrderByDescending(r => r.StartDate).ToList();

			return reservations.ToList();
		}
		public List<Reservation> GetAllRezervationsOperator(OpIndexModelDTO indexModel)
		{
			var reservationFilter = new Reservation
			{
				MachineName = indexModel.MachineName,
				ProjectName = indexModel.ProjectName,
				RecipeCode = indexModel.RecipeCode,
				PartName = indexModel.PartName,
				RequestNote = indexModel.RequestNote,
				StartDate = indexModel.StartDate,
				EndDate = indexModel.EndDate,
			};

			var filters = GetFilters(reservationFilter);

			var filteredReservations = _reservationDal.GetAll(filters, f => f.Requester);

			var viewModel = new ReIndexModelDTO
			{
				Results = filteredReservations,
			};

			return viewModel.Results;
		}
		public List<Func<Reservation, bool>> GetFilters(Reservation reservationFilter)
		{
			var filters = new List<Func<Reservation, bool>>();

			if (!string.IsNullOrWhiteSpace(reservationFilter.MachineName))
				filters.Add(r => r.MachineName == reservationFilter.MachineName);

			if (!string.IsNullOrWhiteSpace(reservationFilter.ProjectName))
				filters.Add(r => r.ProjectName == reservationFilter.ProjectName);

			if (!string.IsNullOrWhiteSpace(reservationFilter.PartName))
				filters.Add(r => r.PartName == reservationFilter.PartName);

			if (!string.IsNullOrWhiteSpace(reservationFilter.RecipeCode))
				filters.Add(r => r.RecipeCode == reservationFilter.RecipeCode);

			if (reservationFilter.StartDate != default(DateTime))
				filters.Add(r => r.StartDate == reservationFilter.StartDate);

			if (reservationFilter.EndDate != default(DateTime))
				filters.Add(r => r.EndDate == reservationFilter.EndDate);

			return filters;
		}
		public List<Reservation> GetAllRezervationsRequester(ReIndexModelDTO indexModel)
		{
			var reservationFilter = new Reservation
			{
				MachineName = indexModel.MachineName,
				ProjectName = indexModel.ProjectName,
				RecipeCode = indexModel.RecipeCode,
				PartName = indexModel.PartName,
				StartDate = indexModel.StartDate,
				EndDate = indexModel.EndDate,
			};

			var filters = GetFilters(reservationFilter);

			var filteredReservations = _reservationDal.GetAll(filters, o => o.Operator);

			var viewModel = new ReIndexModelDTO
			{
				Results = filteredReservations,
			};

			return viewModel.Results;
		}
		public Reservation GetBySelectedReservationToOperator(OpIndexModelDTO manageReservationModel)
		{
			var findReservation = new Reservation
			{
				Id = manageReservationModel.Id,
				MachineName = manageReservationModel.MachineName,
				ProjectName = manageReservationModel.ProjectName,
				PartName = manageReservationModel.PartName,
				RecipeCode = manageReservationModel.RecipeCode,
				StartDate = manageReservationModel.StartDate,
				EndDate = manageReservationModel.EndDate,
				RequestNote = manageReservationModel.RequestNote,
			};
			return _reservationDal.GetSelectedReservationInfo(findReservation);
		}
		public Reservation GetBySelectedReservationToRequester(ReIndexModelDTO manageReservationModel)
		{
			var findReservation = new Reservation
			{
				Id = manageReservationModel.Id,
				MachineName = manageReservationModel.MachineName,
				ProjectName = manageReservationModel.ProjectName,
				PartName = manageReservationModel.PartName,
				RecipeCode = manageReservationModel.RecipeCode,
				StartDate = manageReservationModel.StartDate,
				EndDate = manageReservationModel.EndDate,
				RequestNote = manageReservationModel.RequestNote,
			};
			return _reservationDal.GetSelectedReservationInfo(findReservation);
		}
		public Reservation GetBySelectedReservationToAdmin(ReIndexModelDTO manageReservationModel)
		{
			var findReservation = new Reservation
			{
				Id = manageReservationModel.Id,
				MachineName = manageReservationModel.MachineName,
				ProjectName = manageReservationModel.ProjectName,
				PartName = manageReservationModel.PartName,
				RecipeCode = manageReservationModel.RecipeCode,
				StartDate = manageReservationModel.StartDate,
				EndDate = manageReservationModel.EndDate,
				RequestNote = manageReservationModel.RequestNote,
			};
			return _reservationDal.GetSelectedReservationInfo(findReservation);
		}
		public Reservation GetRezervationById(int reservationId)
		{
			var reservation = _reservationDal.GetById(reservationId);
			if (reservation == null)
			{
				throw new Exception(string.Concat(Message.NotFoundAutoClave, reservationId));
			}
			return reservation;
		}
		public Reservation UpdateReservation(Reservation reReservationUpdateModel)
		{
			var userId = _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
			var updateReservationAdd = new Reservation
			{
				Id = reReservationUpdateModel.Id,
				MachineName = reReservationUpdateModel.MachineName,
				ProjectName = reReservationUpdateModel.ProjectName,
				PartName = reReservationUpdateModel.PartName,
				RecipeCode = reReservationUpdateModel.RecipeCode,
				RequestNote = reReservationUpdateModel.RequestNote,
				StartDate = reReservationUpdateModel.StartDate,
				EndDate = reReservationUpdateModel.EndDate,
				UpdateDate = DateTime.UtcNow,
				UpdatedBy = Convert.ToInt32(userId)
			};

			var reservation = _reservationDal.UpdateReservation(updateReservationAdd);
			return reservation;
		}
		public Reservation OpCanceledReservation(Reservation canceledReservationModel)
		{
			return _reservationDal.UpdateCanceledReservationToOperator(canceledReservationModel);
		}
		public Reservation ReCanceledReservation(Reservation canceledReservationModel)
		{
			var userId = _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
			var updateReservationAdd = new Reservation
			{
				Id = canceledReservationModel.Id,
				MachineName = canceledReservationModel.MachineName,
				ProjectName = canceledReservationModel.ProjectName,
				PartName = canceledReservationModel.PartName,
				RecipeCode = canceledReservationModel.RecipeCode,
				StartDate = canceledReservationModel.StartDate,
				EndDate = canceledReservationModel.EndDate,
				UpdateDate = DateTime.UtcNow,
				UpdatedBy = Convert.ToInt32(userId)
			};

			var reservation = _reservationDal.UpdateCanceledReservationToRequester(updateReservationAdd);
			return reservation;


		}
		public List<Reservation> GetReservedDatesByMachineName(string machineName)
		{
			var filteredReservations = _reservationDal.GetAll()
			  .Where(r => r.Status != ReservationStatusType.Cancelled)
			  .ToList();

			return filteredReservations;
		}
		public List<Reservation> GetAllReservationsToAdmin()
		{
			Expression<Func<Reservation, object>>[] includes =
			{
				o => o.Requester,
				y => y.Operator
			};

			var allReservations = _reservationDal.GetAll(null, includes)?.OrderByDescending(r => r.StartDate)?.ToList();
			User responseUser;

			if (allReservations != null)
			{
				foreach (var user in allReservations)
				{
					if (user.UpdatedBy.HasValue)
					{
						responseUser = _userDal.GetById(user.UpdatedBy.Value);
						user.UpdatedUserName = responseUser.Name + " " + responseUser.Surname;
					}
				}
			}

			return allReservations;
		}
	}
}
