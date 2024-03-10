﻿using ACR.Entity.Concrete;
using System.Linq.Expressions;

namespace ACR.DataAccess.Abstract
{
	public interface IReservationDal : IRepository<Reservation>
	{
		Reservation AddReservation(Reservation reservation);
		Reservation UpdateReservation(Reservation reservation);
		List<Reservation> GetByFiltered(List<Func<Reservation, bool>> filters,Expression<Func<Reservation, object>> expression = null!);
	}
}
