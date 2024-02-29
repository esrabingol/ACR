using ACR.Entity.Concrete;

namespace ASP.WEBUI.Models
{
    //Operator ViewMachineInfo
    public class OpMachineFilterModel
    {
        public string machineName { get; set; }
        public string machineStatu { get; set; }
        public int itemNo { get; set; }
        public int tc { get; set; }
        public int vp { get; set; }
        public IEnumerable<Autoclave> Autoclaves { get; set; } //Autoclaves sınıfındaki makine adlarını dönücek

    }
}
