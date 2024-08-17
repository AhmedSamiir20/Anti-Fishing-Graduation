
namespace AntiFishing.Core.Features.Sensors.Queries.Response
{
	public class GetSensorListResponse
	{
		public int SensorId { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Type { get; set; }

		[Required, MaxLength(500)]
		public string Description { get; set; }

		public string RegionName { get; set; }

		public string LakeName { get; set; }
	}
}
