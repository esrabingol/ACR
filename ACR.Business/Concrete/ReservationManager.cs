using ACR.Business.Abstract;
using ACR.Business.Models;
using ACR.DataAccess.Abstract;
using ACR.DataAccess.Concrete.EntityFramework;
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
        private IAutoclaveDal _autoclaveDal;

        public ReservationManager( IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }
        public Reservation Add(ReCreateReservationModelDTO reReservationFilterModel)
        {

            var reservationAdd = new Reservation
            {

                machineName = reReservationFilterModel.machineName,
                projectName = reReservationFilterModel.projectName,
                partName = reReservationFilterModel.partName,
                recipeCode = reReservationFilterModel.recipeCode,
                requestNote = reReservationFilterModel.requestNote,
                startDate = reReservationFilterModel.startDate,
                endDate = reReservationFilterModel.endDate,
                startTime = reReservationFilterModel.startTime,
                endTime = reReservationFilterModel.endTime,
                //RequesterId = requesterId // bu şekilde alan dolucak
            };

            return _reservationDal.AddReservation(reservationAdd);
        }

        public void Delete(Reservation rezervation)
        {
            _reservationDal.Delete(rezervation);
        }

        public List<Reservation> GetAllRezervations(Reservation reservation)
        {
  
            var reservations = _reservationDal.GetAll();

       
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

        public Reservation UpdateReservation(ReManageReservationModelDTO reReservationUpdateModel)
        {
            var reservationUpdate = new Reservation
            {
                machineName = reReservationUpdateModel.machineName,
                projectName = reReservationUpdateModel.projectName,
                recipeCode = reReservationUpdateModel.recipeCode,
                requestNote = reReservationUpdateModel.requestNote,
                startDate = reReservationUpdateModel.startDate,
                endDate = reReservationUpdateModel.endDate,
                startTime = reReservationUpdateModel.startTime,
                endTime = reReservationUpdateModel.endTime
            };
            return _reservationDal.UpdateReservation(reservationUpdate);
        }
    }
}
