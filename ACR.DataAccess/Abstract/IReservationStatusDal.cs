using ACR.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.DataAccess.Abstract
{
    public interface IReservationStatusDal : IRepository<ReservationStatus>
    {
        public List<ReservationStatus> GetCancelledReservationStatus();
        public ReservationStatus GetCancelledReservationStatusWithCancellationNote(int reservationStatusId);
        public List<ReservationStatus> GetConfirmedReservationStatus();
        public ReservationStatus GetReservationStatus(int reservationStatusId);
        public ReservationStatus GetReservationStatusByReservationId(int reservationId);
    }
}
