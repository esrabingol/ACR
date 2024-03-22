using Microsoft.AspNetCore.Identity;

namespace ACR.Entity.Concrete
{
    public class Role : IdentityRole<int>
	{
        public int Id { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<User> Users { get; set; } 
    }
}
