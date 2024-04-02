using ACR.Business.Models;
using ACR.Entity.Concrete;

namespace ACR.Business.Abstract
{
	public interface IReservationService
	{
		List<Reservation> GetAllRezervationsRequester(ReIndexModelDTO indexModel);
		List<Reservation> GetAllRezervationsOperator(OpIndexModelDTO indexModel);
		Reservation GetRezervationById(int reservationId);
		Reservation Add(ReCreateReservationModelDTO reReservationFilterModel);
		void Delete(Reservation rezervation);
		Reservation UpdateReservation(Reservation updateReservation);
		Reservation ConfirmReservation(Reservation confirmReservation);
		Reservation OpCanceledReservation(Reservation canceledReservation);
		Reservation ReCanceledReservation(Reservation canceledReservation);
		List<Reservation> GetAllReservationsToRequester();
		List<Reservation> GetAllReservationsToOperator();
		Reservation GetBySelectedReservationToRequester(ReIndexModelDTO manageReservationModel);
		Reservation GetBySelectedReservationToOperator(OpIndexModelDTO manageReservationModel);
		List<Reservation> GetReservedDatesByMachineName(string machineName);

	}
}
