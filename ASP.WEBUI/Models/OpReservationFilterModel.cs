namespace ASP.WEBUI.Models
{
    public class OpReservationFilterModel
    {
        public string MachineName { get; set; }
        public string ProjectName { get; set; }
        public string PartName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
