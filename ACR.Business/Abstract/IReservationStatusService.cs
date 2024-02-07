using ACR.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Business.Abstract
{
    public interface IReservationStatusService
    {
        // Belirli bir rezervasyon durumunu görüntülemek için
        ReservationStatus GetReservationStatus(int reservationStatusId);

        // Belirli bir rezervasyon için durumu görüntülemek için
        ReservationStatus GetReservationStatusByReservationId(int reservationId);

        // Onaylanmış rezervasyon durumlarını listelemek için
        List<ReservationStatus> GetConfirmedReservationStatus();

        // İptal edilmiş rezervasyon durumlarını listelemek için
        List<ReservationStatus> GetCancelledReservationStatus();

        // İptal edilen rezervasyon durumunun iptal notuyla birlikte görüntülenmesi için
        ReservationStatus GetCancelledReservationStatusWithCancellationNote(int reservationStatusId);
    }
}
