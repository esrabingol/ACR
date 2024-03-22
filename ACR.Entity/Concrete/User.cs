using Microsoft.AspNetCore.Identity;

namespace ACR.Entity.Concrete
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MailAdress { get; set; }
        public long PhoneNumber { get; set; }
        public string Password { get; set; }
        public virtual Role Role { get; set; }
        public int RoleId { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
