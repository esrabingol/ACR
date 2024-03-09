using ACR.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Business.Models
{
	public class ReIndexModelDTO
	{
		public string MachineName { get; set; }
		public string ProjectName { get; set; }
		public string PartName { get; set; }
		public string RecipeCode { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public List<Reservation> Results { get; set; } = new List<Reservation>();
		public IEnumerable<Machine> MachineNames { get; set; } = null!;
	}
}
