namespace ASP.WEBUI.Models
{
    
    public class OpReservationFilterModel
    {
        public string machineName { get; set; }
        public string projectName { get; set; }
        public string partName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public TimeOnly startTime { get; set; }
        public TimeOnly endTime { get; set; }

    }
}
