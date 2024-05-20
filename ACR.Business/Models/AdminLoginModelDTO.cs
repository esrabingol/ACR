using System.ComponentModel.DataAnnotations;

namespace ACR.Business.Models
{
	public class AdminLoginModelDTO
	{
		[Required(ErrorMessage = "Mail Adresi Alanı Boş Geçilemez!")]
		[DataType(DataType.EmailAddress, ErrorMessage = "Lütfen geçerli bir E-posta adresi giriniz.")]
		public string MailAdress { get; set; }

		[Required(ErrorMessage = "Şifre Alanı Boş Geçilemez!")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
