namespace AntiFishing.Infrastructure.Abstracts
{
	public interface IRegionRepository : IGenericRepositoryAsync<Region>
	{
		public Task<IReadOnlyList<Region>> GetRegionsAsync();
	}
}
