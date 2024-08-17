namespace AntiFishing.Data.Entities.Identity
{
	public class AuthModel
	{
		public string Message { get; set; }

		public bool IsAuthenticated { get; set; }

		public string UserName { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Address { get; set; }

		public string Email { get; set; }

		public string PhoneNumber { get; set; }

		public List<string> Roles { get; set; }

		public string Token { get; set; }

		public DateTime ExpiresOn { get; set; }

		public string LakeName { get; set; }
	}
}
