using ACR.DataAccess.Abstract;
using ACR.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.DataAccess.Concrete.EntityFramework
{
    public class EfReservationDal : EfGenericRepository<Reservation, ACRContext>, IReservationDal
    {
        
    }
}
