namespace AntiFishing.Core.Features.Regions.Queries.Models
{
	public class GetRegionByIdQuery : IRequest<Response<Region>>
	{
		public int Id { get; set; }
		public GetRegionByIdQuery(int id)
		{
			Id = id;
		}
	}
}
