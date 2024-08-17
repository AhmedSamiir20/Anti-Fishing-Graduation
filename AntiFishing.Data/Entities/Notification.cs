namespace AntiFishing.Data.Entities;

public class Notification
{
	public int NotificationId { get; set; }

	[Required, MaxLength(50)]
	public string Title { get; set; }

	[Required, MaxLength(500)]
	public string Message { get; set; }

	[Required]
	public DateTime DateTime { get; set; }

	public int? SensorId { get; set; }

	[ForeignKey("SensorId")]
	public virtual Sensor Sensor { get; set; }

	public int? CameraId { get; set; }

	[ForeignKey("CameraId")]
	public virtual Camera Camera { get; set; }
}
