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
		public List<Reservation> GetByFiltered(List<Func<Reservation, bool>> filters)
		{
			IQueryable<Reservation> query = _context.Reservations.AsQueryable();

			foreach (var filter in filters)
			{
				query = query.Where(filter).AsQueryable();
			}

			return query.ToList();
		}
		public Reservation UpdateReservation(Reservation reservation)
		{
			_context.Reservations.Update(reservation);
			_context.SaveChanges();
			return reservation;
		}
	}
}
