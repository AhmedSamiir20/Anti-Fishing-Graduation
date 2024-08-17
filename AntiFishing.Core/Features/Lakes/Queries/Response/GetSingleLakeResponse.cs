namespace AntiFishing.Core.Features.Lakes.Queries.Response;

public class GetSingleLakeResponse
{
	public int Id { get; set; }

	[Required, MaxLength(50)]
	public string Name { get; set; }

	[Required, MaxLength(500)]
	public string Info { get; set; }

	[Required, MaxLength(100)]
	public string Location { get; set; }

	[Required]
	public double Area { get; set; }

	[Required]
	public double Depth { get; set; }

	public ICollection<Camera>? Cameres { get; set; }

	public ICollection<Sensor>? Sensors { get; set; }

	public ICollection<Fish>? Fishs { get; set; }

	public ICollection<Region>? Regions { get; set; }

	public List<Schedule> Schedules { get; set; }
}
