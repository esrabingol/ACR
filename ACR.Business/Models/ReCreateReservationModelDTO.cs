using ACR.Entity.Concrete;

namespace ACR.Business.Models
{
	public class ReCreateReservationModelDTO
	{
		public string MachineName { get; set; } = null!;
		public string ProjectName { get; set; } = null!;
		public string RecipeCode { get; set; } = null!;
		public string PartName { get; set; } = null!;
		public string? RequestNote { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public IEnumerable<Machine> MachineNames { get; set; } = null!;
	}
}
