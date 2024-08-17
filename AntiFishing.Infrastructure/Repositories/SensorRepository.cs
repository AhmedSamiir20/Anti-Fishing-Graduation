namespace AntiFishing.Infrastructure.Repositories
{
	public class SensorRepository : GenericRepositoryAsync<Sensor>, ISensorRepository
	{
		private readonly DbSet<Sensor> _sensor;
		public SensorRepository(ApplicationDbContext _context) : base(_context)
		{
			_sensor = _context.Set<Sensor>();
		}

		public async Task<IReadOnlyList<Sensor>> GetSensorsAsync()
		{
			return await _sensor.AsNoTracking().Include(l => l.Lake).Include(r => r.Region).Include(d => d.Data).Include(n => n.Notifications).ToListAsync();
		}

		public async Task<IReadOnlyList<Sensor>> GetSensorsByRegionIdAsync(int regionId)
		{
			return await _sensor.Where(s => s.Region.RegionId == regionId).AsNoTracking().Include(l => l.Lake).Include(r => r.Region).Include(d => d.Data).Include(n => n.Notifications).ToListAsync();
		}
	}
}
