namespace AntiFishing.Core.Mapping.Sensor
{
	public partial class SensorProfile
	{
		public void GetSensorByIdMapping()
		{
			CreateMap<Data.Entities.Sensor, GetSingleSensorResponse>();
			//.ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(sorc => sorc.Department.DName));
		}

	}
}
