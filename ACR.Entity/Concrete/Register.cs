using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Entity.Concrete
{
    public class Register
    {
        public int Register_Id { get; set; }
        public string R_Name { get; set; }
        public string R_Surname{ get; set; }
        public string R_MailAdress { get; set; }
        public long R_PhoneNumber { get; set; }
        public string R_Password { get; set; }
        public string R_Role { get; set;}

        // Bir kullanıcının birden çok onayladığı randevuları temsil etmek için
        public ICollection<Reservation> ConfirmedReservations { get; set; }

        // Bir kullanıcının birden çok talep ettiği randevuları temsil etmek için
        public ICollection<Reservation> RequestedReservations { get; set; }
    }
}
