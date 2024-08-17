using System.ComponentModel.DataAnnotations;

namespace AntiFishing.Api.AuthDto
{
	public class ResetPasswordRequestModel
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		public string Token { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string NewPassword { get; set; }
	}
}
