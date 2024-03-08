using ACR.Entity.Concrete;

namespace ASP.WEBUI.Models
{
    //Operator ViewMachineInfo
    public class OpMachineFilterModel
    {
        public string machineName { get; set; } = null!;
        public string machineStatu { get; set; } = null!;
        public int itemNo { get; set; }
        public int tc { get; set; }
        public int vp { get; set; }
        public IEnumerable<Machine> Machines { get; set; } = null!; //Autoclaves sınıfındaki makine adlarını dönücek

    }
}
