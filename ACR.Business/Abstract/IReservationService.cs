using ACR.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Business.Abstract
{
    public interface IReservationService
    {
        List<Reservation> GetAllRezervations(Reservation rezervation);
        Reservation GetRezervationById(int reservationId);
        Reservation Update(Reservation rezervation);
        Reservation Add(Reservation rezervation);
        void Delete(Reservation rezervation);


    }
}
