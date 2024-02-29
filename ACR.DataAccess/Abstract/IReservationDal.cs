using ACR.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.DataAccess.Abstract
{
    public interface IReservationDal : IRepository<Reservation>
    {
        Reservation AddReservation(Reservation reservation);
        Reservation UpdateReservation (Reservation reservation);
    }
}
