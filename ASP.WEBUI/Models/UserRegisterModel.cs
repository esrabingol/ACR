using ACR.Entity.Concrete;

namespace ASP.WEBUI.Models
{
    public class UserRegisterModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string MailAdress { get; set; }
        public long PhoneNumber { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public IEnumerable<Role> Roles { get; set; }
    }
}
