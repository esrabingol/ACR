using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Entity.Concrete
{
    public class Users
    {
       //Tamamlandı
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname{ get; set; }
        public string MailAdress { get; set; }
        public long PhoneNumber { get; set; }
        public string Password { get; set; }
		public Role Role { get; set; }
		public int RoleId { get; set; }
		public virtual  ICollection<Reservation> Reservations { get; set; }

      
	}

}
