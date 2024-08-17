namespace AntiFishing.Core.Mapping.Sensor
{
	public partial class SensorProfile
	{
		public void GetSensorListByRegionIdMapping()
		{
			CreateMap<Data.Entities.Sensor, GetSensorLisByRegionIdResponse>();
			//.ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(sorc => sorc.Department.DName));
		}

	}
}
