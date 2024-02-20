using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Entity.Concrete
{
    public class Reservation
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string MachineName { get; set; }
        public string ProjectCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ReservationNote { get; set; }

        //Rezervasyon durumu kontrolü için
        public ReservationStatus Status { get; set; }

        // Bir randevunun onaylayan operatörü temsil etmek için
        public int OperatorId { get; set; }
        public Users Operator { get; set; }

        // Bir randevunun talep edeni temsil etmek için
        public int RequesterId { get; set; }
        public Users Requester { get; set; }


    }
}
