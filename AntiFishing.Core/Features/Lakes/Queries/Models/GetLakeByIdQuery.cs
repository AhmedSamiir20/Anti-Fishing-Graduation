namespace AntiFishing.Core.Features.Lakes.Queries.Models
{
	public class GetLakeByIdQuery : IRequest<Response<Lake>>
	{
		public int Id { get; set; }
		public GetLakeByIdQuery(int id)
		{
			Id = id;
		}
	}
}
