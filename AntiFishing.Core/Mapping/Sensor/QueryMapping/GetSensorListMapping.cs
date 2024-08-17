namespace AntiFishing.Core.Mapping.Sensor
{
	public partial class SensorProfile
	{
		public void GetSensorListMapping()
		{
			CreateMap<Data.Entities.Sensor, GetSensorListResponse>()
			.ForMember(dest => dest.RegionName, opt => opt.MapFrom(sorc => sorc.Region.RegionName))
			.ForMember(dest => dest.LakeName, opt => opt.MapFrom(sorc => sorc.Lake.Name));
		}

	}
}
