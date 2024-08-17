namespace AntiFishing.Core.Mapping.Schedule
{
	public partial class ScheduleProfile
	{
		public void GetScheduleByIdMapping()
		{
			CreateMap<Data.Entities.Sensor, GetSingleSensorResponse>();
			//.ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(sorc => sorc.Department.DName));
		}

	}
}
