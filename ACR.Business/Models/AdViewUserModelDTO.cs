using ACR.Entity.Concrete;
using System.ComponentModel.DataAnnotations;

namespace ACR.Business.Models
{
	public class AdViewUserModelDTO
	{
		public string Name { get; set; }
		public string SurName { get; set; }
		public string MailAdress { get; set; }
		public long PhoneNumber { get; set; }
		public int RoleId { get; set; }
		public IEnumerable<Role> Roles { get; set; }
		public List<User> Results { get; set; } = new List<User>();



	}
}
