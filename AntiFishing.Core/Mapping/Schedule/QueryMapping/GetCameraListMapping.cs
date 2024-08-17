namespace AntiFishing.Core.Mapping.Schedule
{
	public partial class ScheduleProfile
	{
		public void GetScheduleListMapping()
		{
			CreateMap<Data.Entities.Schedule, GetScheduleListQuery>();
			//.ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(sorc => sorc.Department.DName));
		}

	}
}
