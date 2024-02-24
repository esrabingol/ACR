using ACR.Entity.Concrete;

namespace ASP.WEBUI.Models
{
    public class ReIndexModel
    {
        public string machineName { get; set; }
        public string projectName { get; set; }
        public string partName { get; set; }
        public string recipeCode { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }

        public List<Reservation> Results { get; set; }
    }
}
