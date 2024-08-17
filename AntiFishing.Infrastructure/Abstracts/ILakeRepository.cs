namespace AntiFishing.Infrastructure.Abstracts
{
	public interface ILakeRepository : IGenericRepositoryAsync<Lake>
	{
		public Task<IReadOnlyList<Lake>> GetLakesAsync();
	}
}
