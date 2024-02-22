namespace ASP.WEBUI.Models
{
    public class ReManageReservationModel
    {
        public string machineName { get; set; }
        public string projectName { get; set; }
        public string recipeCode { get; set; }
        public string requestNote { get; set; }
        public DateOnly startDate { get; set; }
        public DateOnly endDate { get; set; }
        public TimeOnly startTime { get; set; }
        public TimeOnly endTime { get; set; }

    }
}
