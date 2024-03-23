using ACR.Entity.Concrete;

namespace ACR.Business.Models
{
    public class ReManageReservationModelDTO
    {
        public int Id { get; set; }
        public string MachineName { get; set; }
        public string ProjectName { get; set; }
        public string RecipeCode { get; set; }
        public string PartName { get; set; }
        public string? RequestNote { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<Machine> MachineNames { get; set; }
    }
}
