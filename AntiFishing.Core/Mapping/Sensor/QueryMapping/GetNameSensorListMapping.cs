namespace AntiFishing.Core.Mapping.Sensor
{
	public partial class SensorProfile
	{
		public void GetNameSensorListMapping()
		{
			CreateMap<Data.Entities.Sensor, GetNameSensorListResponse>();
			//.ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(sorc => sorc.Department.DName));
		}

	}
}
