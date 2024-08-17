
namespace AntiFishing.Core.Mapping.Camera
{
	public partial class CameraProfile
	{
		public void EditCameraCommandMapping()
		{
			CreateMap<EditCameraCommand, Data.Entities.Camera>()
				.ForMember(dist => dist.CameraId, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.LakeId, opt => opt.MapFrom(sorc => sorc.LakeId))
				.ForMember(dest => dest.RegionId, opt => opt.MapFrom(sorc => sorc.RegionId)); ; ;
		}
	}
}
