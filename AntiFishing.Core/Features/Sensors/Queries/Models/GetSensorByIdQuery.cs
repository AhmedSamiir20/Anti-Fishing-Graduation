namespace AntiFishing.Core.Features.Sensors.Queries.Models
{
	public class GetSensorByIdQuery : IRequest<Response<Sensor>>
	{
		public int Id { get; set; }
		public GetSensorByIdQuery(int id)
		{
			Id = id;
		}
	}
}
