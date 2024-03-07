using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Entity.Concrete
{
    //Tamamlandı
    public class Reservation
    {
        public Reservation()
        {
            Status = new ReservationStatus(); // Varsayılan olarak bir ReservationStatus nesnesi oluştur
        }

        public int id { get; set; } //listeleme ve rezervasyonu çekme işleminde kolaylık sağlayacak.
        public string projectName { get; set; }
        public string machineName { get; set; }
        public string partName { get; set; }
        public string recipeCode { get; set; }
        //datetime olmamalı??
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string? requestNote { get; set; } 

        //Rezervasyon durumu kontrolü için
        public ReservationStatus Status { get; set; } 

        // Bir randevunun onaylayan operatörü temsil etmek için
        public int? OperatorId { get; set; } //operator rezervasyon üzerinde değişiklik yapmak istediğinde ilgili operatörün id si gelicek.
        public virtual  Users Operator { get; set; }

        // Bir randevunun talep edeni temsil etmek için
        public int RequesterId { get; set; } // sisteme giriş yapıp randevu oluşturmak istediğinde otomatik olarak hangi kullanıcının giriş yapıp oluşturmak istediği sisteme düşücek randevu ile beraber.
        public virtual  Users Requester { get; set; }

    }
}
