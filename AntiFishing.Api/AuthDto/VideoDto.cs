namespace AntiFishing.Api.AuthDto
{
	public class VideoDto
	{
		public int? VideoId { get; set; }

		public string Name { get; set; }

		public string VideoUrl { get; set; }

		public int? FishCount { get; set; }

		public string? FishStatus { get; set; }

		public DateTime UploadedAt { get; set; }

		public string CameraName { get; set; }

	}
}
