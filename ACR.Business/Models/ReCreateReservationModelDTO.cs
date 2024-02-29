using ACR.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Business.Models
{
    public class ReCreateReservationModelDTO
    {
        [Required(ErrorMessage = "Makine Adı zorunludur.")]
        public string machineName { get; set; }

        [Required(ErrorMessage = "Proje Adı zorunludur.")]
        public string projectName { get; set; }

        [Required(ErrorMessage = "Proje Kodu zorunludur.")]
        public string recipeCode { get; set; }

        [Required(ErrorMessage = "Parça Adı alanı zorunludur.")]
        public string partName { get; set; }
        public string requestNote { get; set; }

        [Required(ErrorMessage = "Başlangıç Tarihi zorunludur.")]
        public DateTime startDate { get; set; }

        [Required(ErrorMessage = "Bitiş Tarihi zorunludur.")]
        public DateTime endDate { get; set; }

        [Required(ErrorMessage = "Başlangıç zamanı zorunludur.")]
        public DateTime startTime { get; set; }

        [Required(ErrorMessage = "Bitiş zamanı zorunludur.")]
        public DateTime endTime { get; set; }

        public IEnumerable<Autoclave> MachineNames { get; set; }
    }
}
