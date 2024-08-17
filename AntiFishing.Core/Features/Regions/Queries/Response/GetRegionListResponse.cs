namespace AntiFishing.Core.Features.Regions.Queries.Response
{
	public class GetRegionListResponse
	{
		public int RegionId { get; set; }

		[Required]
		public string RegionName { get; set; }

		public string RegionDescription { get; set; }

		public string RegionWidth { get; set; }

		public string LakeName { get; set; }

		public ICollection<string> SensorName { get; set; }

		public ICollection<string> CamerasName { get; set; }

	}
}
