using ACR.Business.Models;
using ACR.Entity.Concrete;

namespace ACR.Business.Abstract
{
    public interface IReservationService
    {
        List<Reservation> GetAllRezervations(Reservation rezervation);
        Reservation GetRezervationById(int reservationId);
        Reservation Add(ReCreateReservationModelDTO reReservationFilterModel);
        void Delete(Reservation rezervation);
        Reservation UpdateReservation(ReManageReservationModelDTO reReservationUpdateModel);

	}
}
