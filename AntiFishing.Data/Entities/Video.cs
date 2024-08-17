namespace AntiFishing.Data.Entities;

public class Video
{
	public int? VideoId { get; set; }

	public string Name { get; set; }

	public string VideoUrl { get; set; }

	public int? FishCount { get; set; }

	public string? FishStatus { get; set; }

	public DateTime UploadedAt { get; set; }

	public int? CameraId { get; set; }

	[ForeignKey("CameraId")]
	public virtual Camera Camera { get; set; }


}
