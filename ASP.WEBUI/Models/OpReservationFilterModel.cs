namespace ASP.WEBUI.Models
{
    //ManageReservation Sekmesi
    public class OpReservationFilterModel
    {
        public string machineName { get; set; }
        public string projectName { get; set; }
        public string partName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }

    }
}
