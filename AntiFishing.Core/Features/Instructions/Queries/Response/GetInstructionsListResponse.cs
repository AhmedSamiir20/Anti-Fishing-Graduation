namespace AntiFishing.Core.Features.Instructions.Queries.Response
{
	public class GetInstructionsListResponse
	{
		public int Id { get; set; }

		[Required, MaxLength(50)]
		public string Title { get; set; }

		[Required, MaxLength(1000)]
		public string Description { get; set; }

		public string LakeName { get; set; }
	}
}
