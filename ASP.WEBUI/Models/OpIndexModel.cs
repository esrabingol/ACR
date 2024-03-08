using ACR.Entity.Concrete;

namespace ASP.WEBUI.Models
{
    public class OpIndexModel
    {
        public string MachineName { get; set; }
        public string ProjectName { get; set; }
        public string PartName { get; set; }
        public string RecipeCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Reservation> Results { get; set; }
    }
}
