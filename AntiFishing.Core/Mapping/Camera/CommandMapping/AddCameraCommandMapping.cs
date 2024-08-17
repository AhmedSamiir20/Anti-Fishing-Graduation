

namespace AntiFishing.Core.Mapping.Camera
{
	public partial class CameraProfile
	{
		public void AddCameraCommandMapping()
		{
			CreateMap<AddCameraCommand, Data.Entities.Camera>()
				.ForMember(dest => dest.LakeId, opt => opt.MapFrom(sorc => sorc.LakeId))
				.ForMember(dest => dest.RegionId, opt => opt.MapFrom(sorc => sorc.RegionId)); ;

		}
	}
}




