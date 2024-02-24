using ACR.Business.Abstract;
using ACR.DataAccess.Abstract;
using ACR.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
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

        public List<Reservation> GetAllRezervations(Reservation reservation)
        {
            // Filtreleme işlemlerini gerçekleştir
            var reservations = _reservationDal.GetAll();

            // Örnek: Makine adına göre filtrele
            if (!string.IsNullOrWhiteSpace(reservation.machineName))
            {
                reservations = reservations.Where(r => r.machineName == reservation.machineName).ToList();
            }

            if (!string.IsNullOrWhiteSpace(reservation.projectName))
            {
                reservations = reservations.Where(r => r.projectName == reservation.projectName).ToList();
            }
            if (!string.IsNullOrWhiteSpace(reservation.partName))
            {
                reservations = reservations.Where(r => r.partName == reservation.partName).ToList();
            }

            if (!string.IsNullOrWhiteSpace(reservation.recipeCode))
            {
                reservations = reservations.Where(r => r.recipeCode == reservation.recipeCode).ToList();
            }

            if (reservation.startDate != default(DateTime))
            {
                reservations = reservations.Where(r => r.startDate == reservation.startDate).ToList();
            }

            if (reservation.endDate != default(DateTime))
            {
                reservations = reservations.Where(r => r.endDate == reservation.endDate).ToList();
            }

            if (reservation.startTime != default(DateTime))
            {
                reservations = reservations.Where(r => r.startTime == reservation.startTime).ToList();
            }

            if (reservation.endTime != default(DateTime))
            {
                reservations = reservations.Where(r => r.endTime == reservation.endTime).ToList();
            }
            return reservations.ToList();
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
