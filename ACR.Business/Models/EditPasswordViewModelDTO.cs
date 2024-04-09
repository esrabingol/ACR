using System.ComponentModel.DataAnnotations;

namespace ACR.Business.Models
{
	public class EditPasswordViewModelDTO
	{
		[Display(Name="Mevcut Şifrenizi Giriniz")]
		[Required(ErrorMessage ="Lütfen {0} alanını doldurunuz.")]
		[DataType(DataType.Password)]
		public string OldPassword { get; set; }

		[Display(Name = "Yeni Şifrenizi Giriniz")]
		[Required(ErrorMessage = "Lütfen {0} alanını doldurunuz.")]
		[DataType(DataType.Password)]
		public string NewPassword { get; set; }

		[Display(Name = "Yeni Şifrenizi Tekrar Giriniz")]
		[Required(ErrorMessage = "Lütfen {0} alanını doldurunuz.")]
		[DataType(DataType.Password)]
		[Compare("NewPassword", ErrorMessage ="Yeni şifre tekrarınız Yeni şifrenizle uyuşmuyor")]
		public string ReNewPassword { get; set; }
	}
}
