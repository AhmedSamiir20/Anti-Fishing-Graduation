
namespace AntiFishing.Core.Mapping.Schedule
{
	public partial class ScheduleProfile
	{
		public void DeleteScheduleCommandMapping()
		{
			CreateMap<DeleteScheduleCommand, Data.Entities.Schedule>();

		}
	}
}
