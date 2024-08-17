namespace AntiFishing.Core.Features.Sensors.Commands.Models
{
	public class EditSensorCommand : IRequest<Response<string>>
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string? Type { get; set; }

		[Required, MaxLength(50000)]
		public string? description { get; set; }

		public int? LakeId { get; set; }

		public int? RegionId { get; set; }
	}
}
