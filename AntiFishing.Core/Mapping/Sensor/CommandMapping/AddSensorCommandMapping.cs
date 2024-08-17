

namespace AntiFishing.Core.Mapping.Sensor
{
	public partial class SensorProfile
	{
		public void AddSensorCommandMapping()
		{
			CreateMap<AddSensorCommand, Data.Entities.Sensor>()
				.ForMember(dest => dest.LakeId, opt => opt.MapFrom(sorc => sorc.LakeId))
				.ForMember(dest => dest.RegionId, opt => opt.MapFrom(sorc => sorc.RegionId)); ;

		}
	}
}




