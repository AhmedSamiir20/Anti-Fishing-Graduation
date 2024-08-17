﻿namespace AntiFishing.Core.Features.Schedules.Commands.Models
{
	public class EditScheduleCommand : IRequest<Response<string>>
	{
		public int ScheduleId { get; set; }

		public string StartDate { get; set; }

		public string EndDate { get; set; }

		public string Year { get; set; }

		public string? Notes { get; set; }

		public int? LakeId { get; set; }

		public string? UserId { get; set; }
	}
}
