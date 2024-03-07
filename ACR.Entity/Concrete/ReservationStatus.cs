using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Entity.Concrete
{
    //Tamamlandı 
    public class ReservationStatus
    {
        public int Id { get; set; }
        public ReservationStatusType StatusType { get; set; } = ReservationStatusType.Pending;
        public string? CancellationNote { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
    public enum ReservationStatusType
    {
        Pending, //Beklemede
        Confirmed, //Onaylandı
        Cancelled //İptal Edildi
    }
}
