namespace AntiFishing.Core.Mapping.Camera
{
	public partial class CameraProfile
	{
		public void GetCameraListMapping()
		{
			CreateMap<Data.Entities.Camera, GetCameraListResponse>()
			.ForMember(dest => dest.RegionName, opt => opt.MapFrom(sorc => sorc.Region.RegionName))
			.ForMember(dest => dest.LakeName, opt => opt.MapFrom(sorc => sorc.Lake.Name));
		}

	}
}
