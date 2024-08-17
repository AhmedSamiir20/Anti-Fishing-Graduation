namespace AntiFishing.Service.Implementations
{
	internal class RegionService : IRegionService
	{
		private readonly IRegionRepository _regionRepository;

		public RegionService(IRegionRepository regionRepository)
		{
			_regionRepository = regionRepository;
		}

		public async Task<string> AddAsync(Region region)
		{
			var check = await _regionRepository.GetTableNoTracking().Where(s => s.RegionName.Equals(region.RegionName)).FirstOrDefaultAsync();
			if (check != null)
				return "Exist";
			await _regionRepository.AddAsync(region);
			return "Added Successfully";
		}

		public async Task<string> DeleteAsync(int regionId)
		{
			var check = await _regionRepository.GetByIdAsync(regionId);
			if (check is null) return "Not Found";
			await _regionRepository.DeleteAsync(check);
			return "Deleted Successfully";
		}

		public async Task<string> EditAsync(Region region)
		{
			await _regionRepository.UpdateAsync(region);
			return "Updating Successfully";
		}

		public async Task<Region> GetRegionByIdAsync(int id)
		{
			var region = _regionRepository.GetTableNoTracking()
				.Include(s => s.Sensors)
				.Include(c => c.Cameras)
				.Include(f => f.Lake)
				.Where(d => d.RegionId.Equals(id))
				.FirstOrDefault();//we check about null value in the top layer not this layer
			return region;
		}

		public async Task<IReadOnlyList<Region>> GetRegionsAsync()
		{
			return await _regionRepository.GetRegionsAsync();
		}

		public IQueryable<Region> GetRegionsQuerable()
		{
			//Get the Regions Querable to use it in pagination 
			return _regionRepository.GetTableNoTracking()
				.Include(s => s.Sensors)
				.Include(c => c.Cameras)
				.Include(f => f.Lake)
				.AsQueryable();
		}

		public async Task<bool> IsNameExist(string regionName)
		{
			var region = await _regionRepository.GetTableNoTracking().Where(s => s.RegionName == regionName).FirstOrDefaultAsync();
			if (region is null) return false;
			return true;
		}
	}
}
