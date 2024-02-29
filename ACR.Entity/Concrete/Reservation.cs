using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Entity.Concrete
{
    public class Reservation
    {
        public int id { get; set; }
        public string projectName { get; set; }
        public string machineName { get; set; }
        public string partName { get; set; }
        public string recipeCode { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string requestNote { get; set; }

        //Rezervasyon durumu kontrolü için
        public ReservationStatus Status { get; set; }

        // Bir randevunun onaylayan operatörü temsil etmek için
        public int OperatorId { get; set; }
        public virtual  Users Operator { get; set; }

        // Bir randevunun talep edeni temsil etmek için
        public int RequesterId { get; set; }
        public virtual  Users Requester { get; set; }

    }
}
