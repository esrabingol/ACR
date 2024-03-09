using ACR.Entity.Concrete;

namespace ACR.Business.Models
{
	public class OpReservationFilterModelDTO
	{
		public string MachineName { get; set; }
		public string ProjectName { get; set; }
		public string PartName { get; set; }
		public string RecipeCode { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public IEnumerable<Machine> MachineNames { get; set; } = null!;
		public List<Reservation> Results { get; set; } = new List<Reservation>();
	}
}
