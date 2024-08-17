namespace AntiFishing.Data.Entities.Identity
{
	public class AddRoleModel
	{
		[Required]
		public string UserId { get; set; }

		[Required]
		public string Role { get; set; }
	}
}
