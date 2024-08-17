namespace AntiFishing.Data.Entities;

public class Sensor
{
	public int? SensorId { get; set; }

	[Required]
	public string Name { get; set; }

	[Required]
	public string Type { get; set; }

	[Required, MaxLength(50000)]
	public string description { get; set; }

	public int? LakeId { get; set; }

	[ForeignKey("LakeId")]
	public virtual Lake Lake { get; set; }

	public int? RegionId { get; set; }

	[ForeignKey("RegionId")]
	public virtual Region Region { get; set; }

	public virtual ICollection<data>? Data { get; set; }

	public virtual ICollection<Notification>? Notifications { get; set; }

}
