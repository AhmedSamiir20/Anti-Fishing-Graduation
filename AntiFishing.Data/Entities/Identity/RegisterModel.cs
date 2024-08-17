namespace AntiFishing.Data.Entities.Identity
{
	public class RegisterModel
	{
		[Required, StringLength(100)]
		public string FirstName { get; set; }

		[Required, StringLength(100)]
		public string LastName { get; set; }

		[Required, StringLength(50)]
		public string Username { get; set; }

		[StringLength(100)]
		public string? Address { get; set; }

		[StringLength(50)]
		public string? Country { get; set; }

		[Required, StringLength(128)]
		public string Email { get; set; }

		[Required, StringLength(256)]
		public string Password { get; set; }

		[Required, StringLength(20), Phone]
		public string PhoneNumber { get; set; }


	}
}
