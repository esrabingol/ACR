namespace ASP.WEBUI.Models
{
    //Operatör Makine Bilgileri Düzenleme Ekranı
    public class EditMachineModel
    {
        public string machineName { get; set; }
        public string machineStatu { get; set; }
        public int itemNo { get; set; }
        public int tcNumber { get; set; }
        public int vpNumber { get; set; }
        //Bakımda olduğu zaman aralığı girilebilicek
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string operatorNote { get; set; }
    }
}
