using ACR.DataAccess.Abstract;
using ACR.Entity.Concrete;

namespace ACR.DataAccess.Concrete.EntityFramework
{
	public class EfReservationDal : EfGenericRepository<Reservation>, IReservationDal
	{
		public EfReservationDal(ACRContext context) : base(context)
		{

		}
		public Reservation AddReservation(Reservation reservation)
		{
			_context.Reservations.Add(reservation);
			_context.SaveChanges();
			return reservation;
		}
		public Reservation GetSelectedReservationInfo(Reservation findReservation)
		{
			int reservationId = findReservation.Id;
			Reservation selectedReservation = _context.Set<Reservation>().Find(reservationId);
			if (selectedReservation != null)
			{
				return selectedReservation;
			}
			else
			{
				return null;
			}
		}
		public Reservation UpdateCanceledReservationToOperator(Reservation canceledReservation)
		{
			var reservation = _context.Set<Reservation>().Find(canceledReservation.Id);
			if (reservation != null)
			{
				reservation.Id = canceledReservation.Id;
				reservation.MachineName = canceledReservation.MachineName;
				reservation.ProjectName = canceledReservation.ProjectName;
				reservation.PartName = canceledReservation.PartName;
				reservation.StartDate = canceledReservation.StartDate;
				reservation.EndDate = canceledReservation.EndDate;
				reservation.RequestNote = canceledReservation.RequestNote;
				reservation.Status = (ReservationStatusType)2;
				reservation.CancellationNote = canceledReservation.CancellationNote;
				reservation.OperatorId = canceledReservation.OperatorId;

				_context.Reservations.Update(reservation);
				_context.SaveChanges();
			}
			return reservation;
		}
		public Reservation UpdateCanceledReservationToRequester(Reservation canceledReservation)
		{
			var reservation = _context.Set<Reservation>().Find(canceledReservation.Id);
			if (reservation != null)
			{
				reservation.Id = canceledReservation.Id;
				reservation.MachineName = canceledReservation.MachineName;
				reservation.ProjectName = canceledReservation.ProjectName;
				reservation.PartName = canceledReservation.PartName;
				reservation.StartDate = canceledReservation.StartDate;
				reservation.EndDate = canceledReservation.EndDate;
				reservation.RequestNote = canceledReservation.RequestNote;
				reservation.Status = (ReservationStatusType)2;
				reservation.CancellationNote = canceledReservation.CancellationNote;

				_context.Reservations.Update(reservation);
				_context.SaveChanges();
			}
			return reservation;
		}
		public Reservation UpdateConfirmReservation(Reservation confirmReservation)
		{
			var reservation = _context.Set<Reservation>().Find(confirmReservation.Id);
			if (reservation != null)
			{
				reservation.Id = confirmReservation.Id;
				reservation.MachineName = confirmReservation.MachineName;
				reservation.ProjectName = confirmReservation.ProjectName;
				reservation.PartName = confirmReservation.PartName;
				reservation.StartDate = confirmReservation.StartDate;
				reservation.EndDate = confirmReservation.EndDate;
				reservation.RequestNote = confirmReservation.RequestNote;
				reservation.Status = (ReservationStatusType)1;
				reservation.OperatorId = confirmReservation.OperatorId;

				_context.Reservations.Update(reservation);
				_context.SaveChanges();
			}
			return reservation;
		}
		public Reservation UpdateReservation(Reservation updateReservation)
		{
			var reservation = _context.Set<Reservation>().Find(updateReservation.Id);
			if (reservation != null)
			{
				reservation.Id = updateReservation.Id;
				reservation.MachineName = updateReservation.MachineName;
				reservation.ProjectName = updateReservation.ProjectName;
				reservation.PartName = updateReservation.PartName;
				reservation.StartDate = updateReservation.StartDate;
				reservation.EndDate = updateReservation.EndDate;
				reservation.RequestNote = updateReservation.RequestNote;

				_context.Reservations.Update(reservation);
				_context.SaveChanges();
			}
			return reservation;
		}
	}
}
