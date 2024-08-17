namespace AntiFishing.Core.Mapping.Region
{
	public partial class RegionProfile
	{
		public void GetRegionListMapping()
		{
			CreateMap<Data.Entities.Region, GetRegionListResponse>()
			.ForMember(dest => dest.LakeName, opt => opt.MapFrom(sorc => sorc.Lake.Name))
			.ForMember(dest => dest.SensorName, opt => opt.MapFrom(sorc => sorc.Sensors.Select(s => s.Name)))
			.ForMember(dest => dest.CamerasName, opt => opt.MapFrom(sorc => sorc.Cameras.Select(s => s.Name)));
		}

	}
}
