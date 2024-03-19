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

		public Reservation GetSelectedReservationInfo(Reservation reservationFind)
		{
			int reservationId = reservationFind.Id;
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
