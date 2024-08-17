namespace AntiFishing.Data.Entities;

public class Fish
{
	public int? FishId { get; set; }

	[Required]
	public double NumberOfFish { get; set; }

	public string? FishStatus { get; set; }

	public int? LakeId { get; set; }

	[ForeignKey("LakeId")]
	public virtual Lake Lake { get; set; }
}
