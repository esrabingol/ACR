using ACR.Entity.Concrete;
using System.ComponentModel.DataAnnotations;

namespace ACR.Business.Models
{
	public class AdminRegisterModelDTO
	{
		[Required(ErrorMessage = "İsim Alanı Boş Geçilemez!")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Soyisim Alanı Boş Geçilemez!")]
		public string SurName { get; set; }

		[Required(ErrorMessage = "Mail Adres Alanı Boş Geçilemez!")]
		public string MailAdress { get; set; }

		[Required(ErrorMessage = "Telefon Numarası Alanı Boş Geçilemez!")]
		public long PhoneNumber { get; set; }

		[Required(ErrorMessage = "Şifre Alanı Boş Geçilemez!")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

	}
}
