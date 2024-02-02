using ACR.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Business.Abstract
{
    public interface IReservationService
    {

        //filtrelemeye göre listeleme


        Task<List<Reservation>> GetAllRezervationsAsync();

        Task<Reservation> GetRezervationByIdAsync(int reservationId);

        Task<Reservation> UpdateAsync(Reservation rezervation);
        Task<Reservation> AddAsync(Reservation rezervation);

        void Delete(Reservation rezervation);

    }
}
