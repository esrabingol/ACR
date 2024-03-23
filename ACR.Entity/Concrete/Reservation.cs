namespace ACR.Entity.Concrete
{
    public class Reservation
    {
        public int Id { get; set; }
        public string ProjectName { get; set; } = null!;
        public string MachineName { get; set; } = null!;
        public string PartName { get; set; } = null!;
        public string RecipeCode { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? RequestNote { get; set; }
        public string? CancellationNote { get; set; }
        //Rezervasyon durumu kontrol
        public ReservationStatusType Status { get; set; }
        public int? OperatorId { get; set; }
        public virtual User Operator { get; set; }
        // sisteme giriş yapıp randevu oluşturmak istediğinde otomatik olarak
        // hangi kullanıcının giriş yapıp oluşturmak istediği sisteme düşücek randevu ile beraber.
        public int RequesterId { get; set; }
        public virtual User Requester { get; set; }
    }
}
