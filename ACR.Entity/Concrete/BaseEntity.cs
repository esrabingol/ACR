namespace ACR.Entity.Concrete
{
    public class BaseEntity
    {
        public int Id { get; set; }
		public DateTime? CreateDate { get; set; }
		public DateTime? UpdateDate { get; set; }
		public DateTime? DeleteDate { get; set; }
		public int? CreatedBy { get; set; }
		public int? UpdatedBy { get; set; }
		public int? DeletedBy { get; set; }

	}
}
