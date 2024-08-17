namespace AntiFishing.Service.Implementations
{
	internal class ScheduleSevice : IScheduleService
	{
		private readonly IScheduleRepository _scheduleRepository;

		public ScheduleSevice(IScheduleRepository scheduleRepository)
		{
			_scheduleRepository = scheduleRepository;
		}

		public async Task<string> AddAsync(Schedule schedule)
		{
			var check = await _scheduleRepository.GetTableNoTracking().Where(s => s.StartDate.Equals(schedule.StartDate)).FirstOrDefaultAsync();
			if (check != null)
				return "Exist";
			await _scheduleRepository.AddAsync(schedule);
			return "Added Successfully";
		}

		public async Task<string> DeleteAsync(int scheduleId)
		{
			var check = await _scheduleRepository.GetByIdAsync(scheduleId);
			if (check is null) return "Not Found";
			await _scheduleRepository.DeleteAsync(check);
			return "Deleted Successfully";
		}

		public async Task<string> EditAsync(Schedule schedule)
		{
			await _scheduleRepository.UpdateAsync(schedule);
			return "Updating Successfully";
		}

		public async Task<Schedule> GetScheduleByIdAsync(int id)
		{
			var schedule = _scheduleRepository.GetTableNoTracking()
				.Include(l => l.Lake)
				.Where(d => d.ScheduleId.Equals(id))
				.FirstOrDefault();//we check about null value in the top layer not this layer
			return schedule;
		}

		public async Task<IReadOnlyList<Schedule>> GetSchedulesAsync()
		{
			return await _scheduleRepository.GetSchedulesAsync();
		}

		public IQueryable<Schedule> GetSchedulesQuerable()
		{
			//Get the Schedules Querable to use it in pagination 
			return _scheduleRepository.GetTableNoTracking()
				.Include(l => l.Lake)
				.AsQueryable();
		}

		public async Task<bool> IsNameExist(string name)
		{
			//var Schedule = await _scheduleRepository.GetTableNoTracking().Where(s => s. == name).FirstOrDefaultAsync();
			//if (Schedule is null) return false;
			return true;
		}
	}
}
