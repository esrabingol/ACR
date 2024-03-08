using ACR.Entity.Concrete;

namespace ACR.Business.Models
{
    public class OpMachineFilterModelDTO
    {
        public string? machineName { get; set; }
        public string? machineStatu { get; set; }
        public int? itemNo { get; set; }
        public int? tc { get; set; }
        public int? vp { get; set; }
        public DateTime? endDate { get; set; }
        public DateTime? startDate { get; set; }
        public string? operatorNote { get; set; }
        public IEnumerable<Machine> MachineNames { get; set; }
        public List<Machine> MachineInfos { get; set; }
    }
}
