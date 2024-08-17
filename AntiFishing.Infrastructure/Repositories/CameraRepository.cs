namespace AntiFishing.Infrastructure.Repositories
{
	public class CameraRepository : GenericRepositoryAsync<Camera>, ICameraRepository
	{
		private readonly DbSet<Camera> _camera;
		public CameraRepository(ApplicationDbContext _context) : base(_context)
		{
			_camera = _context.Set<Camera>();
		}

		public async Task<IReadOnlyList<Camera>> GetCamerasAsync()
		{
			return await _camera.AsNoTracking().Include(l => l.Lake).Include(r => r.Region).Include(d => d.Videos).Include(n => n.Notifications).ToListAsync();
		}
	}
}
