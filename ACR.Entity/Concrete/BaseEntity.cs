﻿namespace ACR.Entity.Concrete
{
    public class BaseEntity
    {
        public int Id { get; set; }
		public DateTime? CreateDate { get; set; }
		public DateTime? UpdateDate { get; set; }
		public DateTime? DeleteDate { get; set; }
	}
}
