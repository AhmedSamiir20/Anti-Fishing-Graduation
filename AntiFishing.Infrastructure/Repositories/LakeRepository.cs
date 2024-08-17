namespace AntiFishing.Infrastructure.Repositories
{
	public class LakeRepository : GenericRepositoryAsync<Lake>, ILakeRepository
	{
		private readonly DbSet<Lake> _lake;
		public LakeRepository(ApplicationDbContext _context) : base(_context)
		{
			_lake = _context.Set<Lake>();
		}

		public async Task<IReadOnlyList<Lake>> GetLakesAsync()
		{
			return await _lake.AsNoTracking().Include(s => s.Sensors).Include(c => c.Cameres).Include(f => f.Fishs).Include(r => r.Regions).Include(s => s.Schedules).ToListAsync();
		}
	}
}
