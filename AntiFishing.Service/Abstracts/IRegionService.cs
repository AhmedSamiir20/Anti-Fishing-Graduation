namespace AntiFishing.Service.Abstracts
{
	public interface IRegionService
	{
		public Task<IReadOnlyList<Region>> GetRegionsAsync();
		public Task<Region> GetRegionByIdAsync(int id);
		public Task<string> AddAsync(Region region);
		public Task<string> EditAsync(Region region);
		public Task<string> DeleteAsync(int regionId);
		public Task<bool> IsNameExist(string name);
		public IQueryable<Region> GetRegionsQuerable();
		//public IQueryable<Region> FilterStudentPaginatedQuerable(StudentOrderingEnum orderingEnum, string search);
	}
}
