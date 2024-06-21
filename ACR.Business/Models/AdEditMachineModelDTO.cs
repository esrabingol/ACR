﻿using ACR.Entity.Concrete;

namespace ACR.Business.Models
{
    public class AdEditMachineModelDTO
    {
        public string MachineName { get; set; } = null!;
        public string MachineStatus { get; set; } = null!;
        public int ItemNo { get; set; }
        public int TcNumber { get; set; }
        public int VpNumber { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? OperatorNote { get; set; }
        public IEnumerable<Machine> MachineNames { get; set; } = null!;
    }
}