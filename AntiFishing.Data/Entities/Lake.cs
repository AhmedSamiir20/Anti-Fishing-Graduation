namespace AntiFishing.Data.Entities;

public class Lake
{
	public int? LakeId { get; set; }

	[Required, MaxLength(50)]
	public string Name { get; set; }

	[Required, MaxLength(10000)]
	public string Info { get; set; }

	[Required, MaxLength(100)]
	public string Location { get; set; }

	[Required, MaxLength(1000)]
	public string Area { get; set; }

	[Required, MaxLength(1000)]
	public string Depth { get; set; }

	public virtual ICollection<Camera>? Cameres { get; set; }

	public virtual ICollection<Sensor>? Sensors { get; set; }

	public virtual ICollection<Fish>? Fishs { get; set; }

	public virtual ICollection<Region>? Regions { get; set; }

	public virtual ICollection<Schedule>? Schedules { get; set; }

	public virtual ICollection<Instruction>? Instructions { get; set; }
}
