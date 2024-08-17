namespace AntiFishing.Service.Abstracts
{
	public interface IScheduleService
	{
		public Task<IReadOnlyList<Schedule>> GetSchedulesAsync();
		public Task<Schedule> GetScheduleByIdAsync(int id);
		public Task<string> AddAsync(Schedule schedule);
		public Task<string> EditAsync(Schedule schedule);
		public Task<string> DeleteAsync(int scheduleId);
		public Task<bool> IsNameExist(string name);
		public IQueryable<Schedule> GetSchedulesQuerable();
		//public IQueryable<Schedule> FilterStudentPaginatedQuerable(StudentOrderingEnum orderingEnum, string search);
	}
}
