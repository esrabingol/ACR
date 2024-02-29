using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Entity.Concrete
{
    public class ReservationStatus
    {
        public int Id { get; set; }
        public ReservationStatusType StatusType { get; set; }
        public string CancellationNote { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
    public enum ReservationStatusType
    {
        Confirmed,
        Cancelled
    }
}
