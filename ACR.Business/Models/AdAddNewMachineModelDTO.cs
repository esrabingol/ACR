namespace ACR.Business.Models
{
	public class AdAddNewMachineModelDTO
	{
		public string MachineName { get; set; } = null!;
		public string MachineStatus { get; set; } = null!;
		public int ItemNo { get; set; }
		public int TcNumber { get; set; }
		public int VpNumber { get; set; }
	}
}
