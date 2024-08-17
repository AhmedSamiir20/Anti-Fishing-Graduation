
namespace AntiFishing.Core.Mapping.Sensor
{
	public partial class SensorProfile
	{
		public void EditSensorCommandMapping()
		{
			CreateMap<EditSensorCommand, Data.Entities.Sensor>()
				.ForMember(dist => dist.SensorId, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.LakeId, opt => opt.MapFrom(sorc => sorc.LakeId))
				.ForMember(dest => dest.RegionId, opt => opt.MapFrom(sorc => sorc.RegionId)); ; ;
		}
	}
}
