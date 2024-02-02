using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Entity.Concrete
{
    public class Reservation
    {
        public int Reservation_Id { get; set; }
        public string Reservation_ProjectName { get; set; }
        public string Reservation_CompositeName { get; set; }
        public string Reservation_PCode { get; set; }
        public DateTime Reservation_StartTime { get; set; }
        public DateTime Reservation_EndTime { get; set; }
        public string Reservation_Note { get; set; }


        // Bir randevunun onaylayan operatörü temsil etmek için
        public int OperatorId { get; set; }
        public Register Operator { get; set; }

        // Bir randevunun talep edeni temsil etmek için
        public int RequesterId { get; set; }
        public Register Requester { get; set; }


    }
}
