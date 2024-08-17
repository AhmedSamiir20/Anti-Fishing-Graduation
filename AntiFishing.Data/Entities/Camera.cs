


namespace AntiFishing.Data.Entities;

public class Camera
{
	[Key]
	public int? CameraId { get; set; }


	[Required, MaxLength(100)]
	public string Name { get; set; }

	[Required, MaxLength(500)]
	public string Info { get; set; }

	public int? LakeId { get; set; }

	[ForeignKey("LakeId")]
	public virtual Lake Lake { get; set; }

	public int? RegionId { get; set; }

	[ForeignKey("RegionId")]
	public virtual Region Region { get; set; }

	public virtual ICollection<Video>? Videos { get; set; }

	public virtual ICollection<Notification>? Notifications { get; set; }

}
