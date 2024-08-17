namespace AntiFishing.Core.Features.Sensors.Queries.Response;

public class GetSingleSensorResponse
{
	public int Id { get; set; }

	[Required]
	public string Name { get; set; }

	[Required]
	public string Type { get; set; }

	[Required, MaxLength(500)]
	public string description { get; set; }

	public Lake Lake { get; set; }

	public Region Region { get; set; }

	public ICollection<data>? Data { get; set; }

	public ICollection<Notification>? Notifications { get; set; }
}
