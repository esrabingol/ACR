using System.ComponentModel.DataAnnotations;

namespace ASP.WEBUI.Models
{
    public class CreateReservationModel
    {
        [Required(ErrorMessage = "Makine Adı zorunludur.")]
        public string machineName { get; set; }

        [Required(ErrorMessage = "Proje Adı zorunludur.")]
        public string projectName { get; set; }

        [Required(ErrorMessage = "Proje Kodu zorunludur.")]
        public string recipeCode { get; set; }

        public string requestNote { get; set; }

        [Required(ErrorMessage = "Başlangıç Tarihi zorunludur.")]
        public DateOnly startDate { get; set; }

        [Required(ErrorMessage = "Bitiş Tarihi zorunludur.")]
        public DateOnly endDate { get; set; }

        [Required(ErrorMessage = "Başlangıç zamanı zorunludur.")]
        public TimeOnly startTime { get; set; }

        [Required(ErrorMessage = "Bitiş zamanı zorunludur.")]
        public TimeOnly endTime { get; set; }

        
    }
}
