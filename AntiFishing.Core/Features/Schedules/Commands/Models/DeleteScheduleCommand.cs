namespace AntiFishing.Core.Features.Schedules.Commands.Models
{
	public class DeleteScheduleCommand : IRequest<Response<string>>
	{
		public int Id { get; set; }
	}
}
