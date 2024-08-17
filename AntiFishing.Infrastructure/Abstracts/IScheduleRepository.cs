namespace AntiFishing.Infrastructure.Abstracts
{
	public interface IScheduleRepository : IGenericRepositoryAsync<Schedule>
	{
		public Task<IReadOnlyList<Schedule>> GetSchedulesAsync();
	}
}
