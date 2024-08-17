using Microsoft.AspNetCore.Identity;
namespace AntiFishing.Data.Entities.Identity
{
	public class User : IdentityUser
	{
		[Required, MaxLength(50)]
		public string FirstName { get; set; }

		[Required, MaxLength(50)]
		public string LastName { get; set; }

		public string? Address { get; set; }

		public string? Country { get; set; }

		public List<Schedule> Schedules { get; set; }

		public int? LakeId { get; set; }

		[ForeignKey("LakeId")]
		public virtual Lake Lake { get; set; }
	}
}
