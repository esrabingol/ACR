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
    public class ReservationManager : IReservationService
    {
        private IReservationDal _reservationDal;
        public ReservationManager( IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }
        public Reservation Add(Reservation rezervation)
        {
            _reservationDal.Add(rezervation);
            return rezervation;
        }

        public void Delete(Reservation rezervation)
        {
            _reservationDal.Delete(rezervation);
        }

        public List<Reservation> GetAllRezervations()
        {
            return _reservationDal.GetAll().ToList();
        }

        public Reservation GetRezervationById(int reservationId)
        {
            var reservation = _reservationDal.GetById(reservationId);
            if(reservation== null) 
            {
                throw new Exception($"ID'si {reservationId} olan Autoclave bulunamadı.");
            }
            return reservation;
        }

        public Reservation Update(Reservation rezervation)
        {
            _reservationDal.Update(rezervation);
            return rezervation;
        }
    }
}
