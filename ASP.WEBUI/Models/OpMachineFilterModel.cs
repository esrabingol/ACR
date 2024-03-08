using ACR.Entity.Concrete;

namespace ASP.WEBUI.Models
{
    public class OpMachineFilterModel
    {
        public string MachineName { get; set; } = null!;
        public string MachineStatus { get; set; } = null!;
        public int ItemNo { get; set; }
        public int TcNumber { get; set; }
        public int VpNumber { get; set; }
        public IEnumerable<Machine> Machines { get; set; } = null!;
    }
}
