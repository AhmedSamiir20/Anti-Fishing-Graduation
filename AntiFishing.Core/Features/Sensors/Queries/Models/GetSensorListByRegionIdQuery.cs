namespace AntiFishing.Core.Features.Sensors.Queries.Models
{
	public class GetSensorListByRegionIdQuery : IRequest<Response<IReadOnlyList<GetSensorLisByRegionIdResponse>>>
	{
		public int RegionId { get; set; }
		public GetSensorListByRegionIdQuery(int id)
		{
			RegionId = id;
		}
	}
}
