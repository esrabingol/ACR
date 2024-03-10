using ACR.Entity.Concrete;
using System.Linq.Expressions;

namespace ACR.DataAccess.Abstract
{
	public interface IReservationDal : IRepository<Reservation>
	{
		Reservation AddReservation(Reservation reservation);
		Reservation UpdateReservation(Reservation reservation);
	}
}
