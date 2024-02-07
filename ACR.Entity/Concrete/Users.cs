using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Entity.Concrete
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname{ get; set; }
        public string MailAdress { get; set; }
        public long PhoneNumber { get; set; }
        public string Password { get; set; }

        // Bir kullanıcının birden çok onayladığı randevuları temsil etmek için -Operatöre özgü
        public ICollection<Reservation> ConfirmedReservations { get; set; }

        // Bir kullanıcının birden çok talep ettiği randevuları temsil etmek için - Talep edene özgü
        public ICollection<Reservation> RequestedReservations { get; set; }
        
        //Arayüzden seçilen kullanıcı rolü bu kısma atanır
        public int RoleId { get; set; }

        // Navigation Property - Kullanıcının seçtiği rolü temsil eder
        public Role SelectedRole { get; set; }
    }

}
