namespace AntiFishing.Infrastructure.Repositories
{
	public class RegionRepository : GenericRepositoryAsync<Region>, IRegionRepository
	{
		private readonly DbSet<Region> _Region;
		public RegionRepository(ApplicationDbContext _context) : base(_context)
		{
			_Region = _context.Set<Region>();
		}

		public async Task<IReadOnlyList<Region>> GetRegionsAsync()
		{
			return await _Region.AsNoTracking().Include(s => s.Sensors).Include(l => l.Lake).Include(c => c.Cameras).ToListAsync();
		}
	}
}
