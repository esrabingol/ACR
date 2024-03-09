using ACR.Entity.Concrete;

namespace ACR.Business.Models
{
	public class OpMachineFilterModelDTO
	{
		public string? MachineName { get; set; }
		public string? MachineStatu { get; set; }
		public int? ItemNo { get; set; }
		public int? Tc { get; set; }
		public int? Vp { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string? OperatorNote { get; set; }
		public IEnumerable<Machine> MachineNames { get; set; } = null!;
		public List<Machine> Results { get; set; } = new List<Machine>();
	}
}
