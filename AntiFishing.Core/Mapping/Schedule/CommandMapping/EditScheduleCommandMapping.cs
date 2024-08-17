
namespace AntiFishing.Core.Mapping.Schedule
{
	public partial class ScheduleProfile
	{
		public void EditScheduleCommandMapping()
		{
			CreateMap<EditScheduleCommand, Data.Entities.Schedule>()
				.ForMember(dist => dist.ScheduleId, opt => opt.MapFrom(src => src.ScheduleId))
				.ForMember(dest => dest.LakeId, opt => opt.MapFrom(sorc => sorc.LakeId)); ;
		}
	}
}
