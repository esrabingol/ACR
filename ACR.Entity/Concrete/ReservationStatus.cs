using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Entity.Concrete
{
    public class ReservationStatus
    {
        public int ReservationStatus_Id { get; set; }
        public int Reservation_Id { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsCancelled { get; set; }
        public string CancellationNote { get; set; }
    }
}
