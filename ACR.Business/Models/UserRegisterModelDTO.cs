using ACR.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Business.Models
{
	public class UserRegisterModelDTO
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
