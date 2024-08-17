
namespace AntiFishing.Core.Features.Lakes.Queries.Response
{
	public class GetLakeNameListResponse
	{
		public int LakeId { get; set; }
		[Required, MaxLength(50)]
		public string Name { get; set; }
	}
}
