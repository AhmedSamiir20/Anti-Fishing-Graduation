namespace AntiFishing.Infrastructure.Abstracts
{
	public interface ICameraRepository : IGenericRepositoryAsync<Camera>
	{
		public Task<IReadOnlyList<Camera>> GetCamerasAsync();
	}
}
