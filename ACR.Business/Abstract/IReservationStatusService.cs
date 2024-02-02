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
        Task<ReservationStatus> GetReservationStatusAsync(int reservationStatusId);

        // Belirli bir rezervasyon için durumu görüntülemek için
        Task<ReservationStatus> GetReservationStatusByReservationIdAsync(int reservationId);

        // Onaylanmış rezervasyon durumlarını listelemek için
        Task<List<ReservationStatus>> GetConfirmedReservationStatusAsync();

        // İptal edilmiş rezervasyon durumlarını listelemek için
        Task<List<ReservationStatus>> GetCancelledReservationStatusAsync();

        // İptal edilen rezervasyon durumunun iptal notuyla birlikte görüntülenmesi için
        Task<ReservationStatus> GetCancelledReservationStatusWithCancellationNoteAsync(int reservationStatusId);
    }
}
