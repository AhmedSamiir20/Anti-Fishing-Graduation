namespace AntiFishing.Core.Mapping.Schedule
{
	public partial class ScheduleProfile : Profile
	{
		public ScheduleProfile()
		{
			GetScheduleListMapping();
			GetScheduleByIdMapping();
			AddScheduleCommandMapping();
			EditScheduleCommandMapping();
			DeleteScheduleCommandMapping();
		}
	}
}
