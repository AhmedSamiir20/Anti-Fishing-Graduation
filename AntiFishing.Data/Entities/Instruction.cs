namespace AntiFishing.Data.Entities
{
	public class Instruction
	{
		public int? Id { get; set; }

		[Required, MaxLength(50)]
		public string Title { get; set; }

		[Required, MaxLength(1000)]
		public string Description { get; set; }

		public int? LakeId { get; set; }

		[ForeignKey("LakeId")]
		public virtual Lake Lake { get; set; }
	}
}
