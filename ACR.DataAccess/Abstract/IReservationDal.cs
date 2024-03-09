using ACR.Entity.Concrete;

namespace ACR.DataAccess.Abstract
{
	public interface IReservationDal : IRepository<Reservation>
	{
		Reservation AddReservation(Reservation reservation);
		Reservation UpdateReservation(Reservation reservation);
		List<Reservation> GetByFiltered(List<Func<Reservation, bool>> filters);
	}
}
