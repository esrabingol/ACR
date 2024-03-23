using ACR.Entity.Concrete;
using System.Linq.Expressions;

namespace ACR.DataAccess.Abstract
{
	public interface IReservationDal : IRepository<Reservation>
	{
		Reservation AddReservation(Reservation reservation);
		Reservation UpdateReservation(Reservation updateReservation);
		Reservation UpdateConfirmReservation(Reservation confirmReservation);
		Reservation UpdateCanceledReservation(Reservation canceledReservation);
		Reservation GetSelectedReservationInfo(Reservation reservationFind);
	}
}
