

namespace AntiFishing.Core.Mapping.Schedule
{
	public partial class ScheduleProfile
	{
		public void AddScheduleCommandMapping()
		{
			CreateMap<AddScheduleCommand, Data.Entities.Schedule>()
				.ForMember(dest => dest.LakeId, opt => opt.MapFrom(sorc => sorc.LakeId));

		}
	}
}




