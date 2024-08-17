namespace AntiFishing.Infrastructure.AuthDto
{
	public class GetUserResponse
	{
		public Guid Id { get; set; }
		public string UserName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public List<string> Role { get; set; }
	}
}
