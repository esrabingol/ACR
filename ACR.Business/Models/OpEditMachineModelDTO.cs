using ACR.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Business.Models
{
    public class OpEditMachineModelDTO
    {
        public string machineName { get; set; }
        public string machineStatu { get; set; }
        public int itemNo { get; set; }
        public int tcNumber { get; set; }
        public int vpNumber { get; set; }
        //Bakımda olduğu zaman aralığı girilebilicek
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string operatorNote { get; set; }
        public IEnumerable<Autoclave> MachineNames { get; set; }
    }
}
