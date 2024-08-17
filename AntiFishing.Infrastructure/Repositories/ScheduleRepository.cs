namespace AntiFishing.Infrastructure.Repositories
{
	public class ScheduleRepository : GenericRepositoryAsync<Schedule>, IScheduleRepository
	{
		private readonly DbSet<Schedule> _schedule;
		public ScheduleRepository(ApplicationDbContext _context) : base(_context)
		{
			_schedule = _context.Set<Schedule>();
		}

		public async Task<IReadOnlyList<Schedule>> GetSchedulesAsync()
		{
			return await _schedule.AsNoTracking().Include(l => l.Lake).Include(u => u.User).ToListAsync();
		}
	}

}
