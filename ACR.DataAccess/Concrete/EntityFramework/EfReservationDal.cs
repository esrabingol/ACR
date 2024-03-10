using ACR.DataAccess.Abstract;
using ACR.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

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
		public List<Reservation> GetByFiltered(List<Func<Reservation, bool>> filters, Expression<Func<Reservation, object>> expression = null)
		{
			IQueryable<Reservation> query = _context.Reservations.AsQueryable();

			foreach (var filter in filters)
			{
				query = query.Where(filter).AsQueryable();
			}

			if(expression != null)
				query = query.Include(expression);

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
