using ACR.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Business.Models
{
    public class ReManageReservationModelDTO
    {
        public string machineName { get; set; }
        public string projectName { get; set; }
        public string recipeCode { get; set; }
        public string requestNote { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public IEnumerable<Autoclave> MachineNames { get; set; }
    }
}
