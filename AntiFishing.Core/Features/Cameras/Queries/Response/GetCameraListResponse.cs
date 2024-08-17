namespace AntiFishing.Core.Features.Cameras.Queries.Response
{
	public class GetCameraListResponse
	{
		public int CameraId { get; set; }

		[Required, MaxLength(100)]
		public string Name { get; set; }

		[Required, MaxLength(500)]
		public string Info { get; set; }

		public string RegionName { get; set; }

		public string LakeName { get; set; }
	}
}
