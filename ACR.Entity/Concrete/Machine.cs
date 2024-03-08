namespace ACR.Entity.Concrete
{
    public class Machine : BaseEntity
    {
        public string MachineName { get; set; } = null!;
        public string MachineStatus { get; set; } = null!;
        public int? ItemNo { get; set; }
        public int? TcNumber { get; set; }
        public int? VpNumber { get; set; }
        //Bakımda olduğu zaman aralığı girilebilicek ve bu kısıma randevu verilmez
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        //Operatörün varsa Makine Notu, bakımın kalibrasyon mu vs gibi durumları giricek
        public string? OperatorNote { get; set; }
    }
}
