using ACR.Business.Abstract;
using ACR.Business.Models;
using ACR.Business.Utilities.Messages;
using ACR.DataAccess.Abstract;
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
		public Reservation ConfirmReservation(Reservation confirmReservationModel)
		{
			return _reservationDal.UpdateConfirmReservation(confirmReservationModel);
		}
		public void Delete(Reservation rezervation)
		{
			_reservationDal.Delete(rezervation);
		}
		public List<Reservation> GetAllReservations()
		{
			var reservations = _reservationDal.GetAll(null, o => o.Requester, y => y.Operator)
				.OrderByDescending(r => r.StartDate).ToList();

			return reservations.ToList();
		}
		public List<Reservation> GetAllRezervationsOperator(OpIndexModelDTO indexModel)
		{
			//böyle map etmene gerek yok
			//şu tipteki nesnesyi şuna map et dicen o sana aşağıda yaptıklarını yapıp vercek
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
		public Reservation GetRezervationById(int reservationId)
		{
			var reservation = _reservationDal.GetById(reservationId);
			if (reservation == null)
			{
				//messajlar magic string olarak kodda durmasın böyle staticlere çek daha best practice
				throw new Exception(string.Concat(Message.NotFoundAutoClave, reservationId));
			}
			return reservation;
		}
		public Reservation UpdateReservation(Reservation reReservationUpdateModel)
		{
			return _reservationDal.UpdateReservation(reReservationUpdateModel);
		}

		public Reservation CanceledReservation(Reservation canceledReservationModel)
		{
			return _reservationDal.UpdateCanceledReservation(canceledReservationModel);
		}
	}
}
