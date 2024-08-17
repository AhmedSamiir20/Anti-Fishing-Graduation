namespace AntiFishing.Data.Entities;

public class data
{
	public int? DataId { get; set; }

	public string Value { get; set; }

	public DateTime? Date { get; set; } = DateTime.Now;

	public int? SensorId { get; set; }

	[ForeignKey("SensorId")]
	public virtual Sensor Sensor { get; set; }
}
