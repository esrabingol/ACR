using ACR.Entity.Concrete;

namespace ASP.WEBUI.Models
{
    public class ReIndexModel
    {
        public string machineName { get; set; }
        public string projectName { get; set; }
        public string partName { get; set; }
        public string recipeCode { get; set; }
        public DateOnly startDate { get; set; }
        public DateOnly endDate { get; set; }
        public TimeOnly startTime { get; set; }
        public TimeOnly endTime { get; set; }

        public List<Reservation> Results { get; set; }
    }
}
