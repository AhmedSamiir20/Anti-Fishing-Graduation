namespace AntiFishing.Core.Features.Cameras.Queries.Models
{
	public class GetCameraByIdQuery : IRequest<Response<Camera>>
	{
		public int Id { get; set; }
		public GetCameraByIdQuery(int id)
		{
			Id = id;
		}
	}
}
