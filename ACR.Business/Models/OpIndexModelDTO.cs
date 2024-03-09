using ACR.Entity.Concrete;

namespace ACR.Business.Models
{
	public class OpIndexModelDTO
	{
		public string MachineName { get; set; }
		public string ProjectName { get; set; }
		public string PartName { get; set; }
		public string RecipeCode { get; set; }
		public string RequestNote { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public List<Reservation> Results { get; set; } = new List<Reservation>();
		public IEnumerable<Machine> MachineNames { get; set; } = null!;
	}
}
