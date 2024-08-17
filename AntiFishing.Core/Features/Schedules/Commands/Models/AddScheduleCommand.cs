namespace AntiFishing.Core.Features.Schedules.Commands.Models
{
	public class AddScheduleCommand : IRequest<Response<string>>
	{
		public string StartDate { get; set; }

		public string EndDate { get; set; }

		public string Year { get; set; }

		public string? Notes { get; set; }

		public int? LakeId { get; set; }

		public string? UserId { get; set; }
	}
}
