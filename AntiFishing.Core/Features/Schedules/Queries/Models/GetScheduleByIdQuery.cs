namespace AntiFishing.Core.Features.Schedules.Queries.Models
{
	//instead of default constractor
	public class GetScheduleByIdQuery(int id) : IRequest<Response<Schedule>>
	{
		public int Id { get; set; } = id;

	}
}
