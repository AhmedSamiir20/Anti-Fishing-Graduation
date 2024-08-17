using AntiFishing.Data.Entities.Identity;

namespace AntiFishing.Data.Entities;

public class Schedule
{
	public int? ScheduleId { get; set; }

	[Required]
	public string StartDate { get; set; }

	[Required]
	public string EndDate { get; set; }

	[Required]
	public string Year { get; set; }

	[Required]
	public string? Notes { get; set; }

	public int? LakeId { get; set; }

	[ForeignKey("LakeId")]
	public virtual Lake Lake { get; set; }

	//public User? User { get; set; }

	public virtual User? User { get; set; }
}
