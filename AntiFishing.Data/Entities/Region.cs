
namespace AntiFishing.Data.Entities;

public class Region
{
	public int RegionId { get; set; }

	[Required]
	public string RegionName { get; set; }

	public string RegionDescription { get; set; }

	public string RegionWidth { get; set; }

	public int? LakeId { get; set; }

	[ForeignKey("LakeId")]
	public virtual Lake Lake { get; set; }

	public virtual ICollection<Sensor>? Sensors { get; set; }

	public virtual ICollection<Camera>? Cameras { get; set; }
}

