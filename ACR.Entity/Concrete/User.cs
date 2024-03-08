namespace ACR.Entity.Concrete
{
    public class User 
    {
        public int Id { get; set; }   
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MailAdress { get; set; }
        public long PhoneNumber { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
