namespace AntiFishing.Core.Features.Sensors.Queries.Response
{
	public class GetSensorLisByRegionIdResponse
	{
		[Required]
		public string Name { get; set; }

		[Required]
		public string Type { get; set; }

		[Required, MaxLength(500)]
		public string description { get; set; }
	}
}
