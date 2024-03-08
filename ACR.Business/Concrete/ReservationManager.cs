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
        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }
        public Reservation Add(ReCreateReservationModelDTO reReservationFilterModel)
        {

            var reservationAdd = new Reservation
            {

                MachineName = reReservationFilterModel.MachineName,
                ProjectName = reReservationFilterModel.ProjectName,
                PartName = reReservationFilterModel.PartName,
                RecipeCode = reReservationFilterModel.RecipeCode,
                RequestNote = reReservationFilterModel.RequestNote,
                StartDate = reReservationFilterModel.StartDate,
                EndDate = reReservationFilterModel.EndDate,
            };

            var a = _reservationDal.AddReservation(reservationAdd);

            return a;
        }
        public void Delete(Reservation rezervation)
        {
            _reservationDal.Delete(rezervation);
        }
        public List<Reservation> GetAllRezervations(Reservation reservation)
        {

            var reservations = _reservationDal.GetAll();

            if (!string.IsNullOrWhiteSpace(reservation.MachineName))
            {
                reservations = reservations.Where(r => r.MachineName == reservation.MachineName).ToList();
            }

            if (!string.IsNullOrWhiteSpace(reservation.ProjectName))
            {
                reservations = reservations.Where(r => r.ProjectName == reservation.ProjectName).ToList();
            }
            if (!string.IsNullOrWhiteSpace(reservation.PartName))
            {
                reservations = reservations.Where(r => r.PartName == reservation.PartName).ToList();
            }

            if (!string.IsNullOrWhiteSpace(reservation.RecipeCode))
            {
                reservations = reservations.Where(r => r.RecipeCode == reservation.RecipeCode).ToList();
            }

            if (reservation.StartDate != default(DateTime))
            {
                reservations = reservations.Where(r => r.StartDate == reservation.StartDate).ToList();
            }

            if (reservation.EndDate != default(DateTime))
            {
                reservations = reservations.Where(r => r.EndDate == reservation.EndDate).ToList();
            }

            return reservations.ToList();
        }
        public Reservation GetRezervationById(int reservationId)
        {
            var reservation = _reservationDal.GetById(reservationId);
            if (reservation == null)
            {
                throw new Exception($"ID'si {reservationId} olan Autoclave bulunamadı.");
            }
            return reservation;
        }
        public Reservation UpdateReservation(ReManageReservationModelDTO reReservationUpdateModel)
        {
            var reservationUpdate = new Reservation
            {
                MachineName = reReservationUpdateModel.MachineName,
                ProjectName = reReservationUpdateModel.ProjectName,
                RecipeCode = reReservationUpdateModel.RecipeCode,
                RequestNote = reReservationUpdateModel.RequestNote,
                StartDate = reReservationUpdateModel.StartDate,
                EndDate = reReservationUpdateModel.EndDate,
            };
            return _reservationDal.UpdateReservation(reservationUpdate);
        }
    }
}
