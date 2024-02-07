using ACR.Business.Abstract;
using ACR.DataAccess.Abstract;
using ACR.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Business.Concrete
{
    public class ReservationStatusManager : IReservationStatusService
    {
        private IReservationStatusDal _reservationStatusDal;
        public ReservationStatusManager(IReservationStatusDal  reservationStatusDal)
        {
            _reservationStatusDal = reservationStatusDal;
        }
        public List<ReservationStatus> GetCancelledReservationStatus()
        {
            List<ReservationStatus> cancelledReservationStatusList;

            if (_reservationStatusDal != null)
            {
                cancelledReservationStatusList = _reservationStatusDal.GetCancelledReservationStatus();
            }
            else
            {
                cancelledReservationStatusList = new List<ReservationStatus>();
            }

            return cancelledReservationStatusList;
        }

        public ReservationStatus GetCancelledReservationStatusWithCancellationNote(int reservationStatusId)
        {
            ReservationStatus cancelledReservationStatus;

            if (_reservationStatusDal != null)
            {
                cancelledReservationStatus = _reservationStatusDal.GetCancelledReservationStatusWithCancellationNote(reservationStatusId);
            }
            else
            {
                cancelledReservationStatus = null;
            }

            return cancelledReservationStatus;
        }

        public List<ReservationStatus> GetConfirmedReservationStatus()
        {
            List<ReservationStatus> confirmedReservationStatusList;

            if (_reservationStatusDal != null)
            {
                confirmedReservationStatusList = _reservationStatusDal.GetConfirmedReservationStatus();
            }
            else
            {
                confirmedReservationStatusList = new List<ReservationStatus>();
            }

            return confirmedReservationStatusList;
        }

        public ReservationStatus GetReservationStatus(int reservationStatusId)
        {
            ReservationStatus reservationStatus;

            if (_reservationStatusDal != null)
            {
                reservationStatus = _reservationStatusDal.GetReservationStatus(reservationStatusId);
            }
            else
            {
                reservationStatus = null;
            }

            return reservationStatus;
        }

        public ReservationStatus GetReservationStatusByReservationId(int reservationId)
        {
              ReservationStatus reservationStatus;

            if (_reservationStatusDal != null)
            {
                reservationStatus = _reservationStatusDal.GetReservationStatusByReservationId(reservationId);
            }
            else
            {
                reservationStatus = null;
            }

            return reservationStatus;
        }
    }
}
