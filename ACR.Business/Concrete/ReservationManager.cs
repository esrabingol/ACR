using ACR.Business.Abstract;
using ACR.Business.Models;
using ACR.DataAccess.Abstract;
using ACR.DataAccess.Concrete.EntityFramework;
using ACR.Entity.Concrete;

namespace ACR.Business.Concrete
{
	public class ReservationManager : IReservationService
	{
		private IReservationDal _reservationDal;
		public ReservationManager(IReservationDal reservationDal)
		{
			_reservationDal = reservationDal;
		}
		public Reservation Add(ReCreateReservationModelDTO reReservationFilterModel)
		{

			var reservationAdd = new Reservation
			{
				MachineName = reReservationFilterModel.MachineName,
				ProjectName = reReservationFilterModel.ProjectName,
				PartName = reReservationFilterModel.PartName,
				RecipeCode = reReservationFilterModel.RecipeCode,
				RequestNote = reReservationFilterModel.RequestNote,
				StartDate = reReservationFilterModel.StartDate,
				EndDate = reReservationFilterModel.EndDate,
				RequesterId = 2
			};

			var reservation = _reservationDal.AddReservation(reservationAdd);

			return reservation;
		}
		public void Delete(Reservation rezervation)
		{
			_reservationDal.Delete(rezervation);
		}
		public List<Reservation> GetAllReservations()
		{
			var reservations = _reservationDal.GetAll()
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

			//rezervasyon bilgileri çekilirken onunla ilişkili requester bilgiside çekilir
			var filteredReservations = _reservationDal.GetAll(filters, f => f.Requester);

			//operarator bilgilerinede ihtiyaç varsa böyle kullanabilirsin
			//_reservationDal.GetAll(filters, f => f.Requester,f=>f.Operator);

			var viewModel = new ReIndexModelDTO
			{
				Results = filteredReservations,
			};

			return viewModel.Results;
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

			var filteredReservations = _reservationDal.GetAll(filters, o => o.Operator);

			var viewModel = new ReIndexModelDTO
			{
				Results = filteredReservations,
			};

			return viewModel.Results;
		}
		public Reservation GetRezervationById(int reservationId)
		{
			var reservation = _reservationDal.GetById(reservationId);
			if (reservation == null)
			{
				throw new Exception($"ID'si {reservationId} olan Autoclave bulunamadı.");
			}
			return reservation;
		}
		public Reservation UpdateReservation(ReManageReservationModelDTO reReservationUpdateModel)
		{
			var reservationUpdate = new Reservation
			{
				Id = reReservationUpdateModel.Id,
				MachineName = reReservationUpdateModel.MachineName,
				ProjectName = reReservationUpdateModel.ProjectName,
				RecipeCode = reReservationUpdateModel.RecipeCode,
				RequestNote = reReservationUpdateModel.RequestNote,
				StartDate = reReservationUpdateModel.StartDate,
				EndDate = reReservationUpdateModel.EndDate,
			};
			return _reservationDal.UpdateReservation(reservationUpdate);
		}
	}
}
