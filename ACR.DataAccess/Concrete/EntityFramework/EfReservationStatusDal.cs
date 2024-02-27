using ACR.DataAccess.Abstract;
using ACR.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.DataAccess.Concrete.EntityFramework
{
    public class EfReservationStatusDal : EfGenericRepository<ReservationStatus, ACRContext>, IReservationStatusDal
    {
		public EfReservationStatusDal(ACRContext context) : base(context)
		{

		}
		private ACRContext _context;
        public List<ReservationStatus> GetCancelledReservationStatus()
        {
            // İptal edilmiş rezervasyon durumlarını getir
            return _context.ReservationStatuses
                .Where(r => r.StatusType == ReservationStatusType.Cancelled)
                .ToList();
        }

        public ReservationStatus GetCancelledReservationStatusWithCancellationNote(int reservationStatusId)
        {   
            // İptal edilmiş rezervasyon durumu ve iptal notuyla birlikte getir
            return _context.ReservationStatuses
                .Include(r => r.CancellationNote) // İptal notunu include et
                .FirstOrDefault(r => r.Id == reservationStatusId && r.StatusType == ReservationStatusType.Cancelled);
        
        }

        public List<ReservationStatus> GetConfirmedReservationStatus()
        {
            // Onaylanmış rezervasyon durumlarını getir
            return _context.ReservationStatuses
                .Where(r => r.StatusType == ReservationStatusType.Confirmed)
                .ToList();
        }

        public ReservationStatus GetReservationStatus(int reservationStatusId)
        {
            // Belirli bir rezervasyon durumunu getir
            return _context.ReservationStatuses.FirstOrDefault(r => r.Id == reservationStatusId);
        }

        public ReservationStatus GetReservationStatusByReservationId(int reservationId)
        {
            // Belirli bir rezervasyon ID'sine ait durumu getir
            return _context.ReservationStatuses.FirstOrDefault(r => r.ReservationId == reservationId);
        }
    }
}
