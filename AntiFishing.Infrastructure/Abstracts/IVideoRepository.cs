namespace AntiFishing.Infrastructure.Abstracts
{
	public interface IVideoRepository
	{
		Task<Video> AddVideoAsync(Video video);
		Task<Video> GetVideoByNameAsync(string name);
		Task<IReadOnlyList<Video>> GetAllVideosAsync();
		Task<Video> GetLastVideoAsync();
		Task UpdateVideoAsync(Video video);
		Task<string> DeleteVideoAsync(int videoId);
	}
}
