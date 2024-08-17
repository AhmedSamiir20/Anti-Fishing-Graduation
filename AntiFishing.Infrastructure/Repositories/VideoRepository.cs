namespace AntiFishing.Infrastructure.Repositories
{
	public class VideoRepository : IVideoRepository
	{
		private readonly ApplicationDbContext _context;

		public VideoRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Video> AddVideoAsync(Video video)
		{
			await _context.videos.AddAsync(video);
			await _context.SaveChangesAsync();
			return video;
		}

		public async Task<Video> GetVideoByNameAsync(string name)
		{
			return await _context.videos.Where(v => v.Name == name).FirstOrDefaultAsync();
		}

		public async Task<Video> GetLastVideoAsync()
		{
			return await _context.videos.Include(v => v.Camera).OrderByDescending(v => v.CameraId).FirstOrDefaultAsync();
		}

		public async Task UpdateVideoAsync(Video video)
		{
			_context.videos.Update(video);
			await _context.SaveChangesAsync();
		}

		public async Task<IReadOnlyList<Video>> GetAllVideosAsync()
		{
			return await _context.videos.ToListAsync();
		}

		public async Task<string> DeleteVideoAsync(int videoId)
		{
			var video = await _context.videos.Where(v => v.VideoId == videoId).FirstOrDefaultAsync();
			_context.Remove(video);
			_context.SaveChanges();
			return "Successfully Deleted";
		}
	}
}
