namespace AntiFishing.Service.Implementations
{
	internal class LakeService : ILakeService
	{
		private readonly ILakeRepository _lakeRepository;

		public LakeService(ILakeRepository lakeRepository)
		{
			_lakeRepository = lakeRepository;
		}

		public async Task<string> AddAsync(Lake lake)
		{
			var check = await _lakeRepository.GetTableNoTracking().Where(s => s.Name.Equals(lake.Name)).FirstOrDefaultAsync();
			if (check != null)
				return "Exist";
			await _lakeRepository.AddAsync(lake);
			return "Added Successfully";
		}

		public async Task<string> DeleteAsync(int lakeId)
		{
			var check = await _lakeRepository.GetByIdAsync(lakeId);
			if (check is null) return "Not Found";
			await _lakeRepository.DeleteAsync(check);
			return "Deleted Successfully";
		}

		public async Task<string> EditAsync(Lake lake)
		{
			await _lakeRepository.UpdateAsync(lake);
			return "Updating Successfully";
		}

		public async Task<Lake> GetLakeByIdAsync(int id)
		{
			var lake = _lakeRepository.GetTableNoTracking()
				.Include(s => s.Sensors)
				.Include(c => c.Cameres)
				.Include(f => f.Fishs)
				.Include(r => r.Regions)
				.Include(s => s.Schedules)
				.Where(d => d.LakeId.Equals(id))
				.FirstOrDefault();//we check about null value in the top layer not this layer
			return lake;
		}

		public async Task<IReadOnlyList<Lake>> GetLakesAsync()
		{
			return await _lakeRepository.GetLakesAsync();
		}

		public IQueryable<Lake> GetLakesQuerable()
		{
			//Get the Lakes Querable to use it in pagination 
			return _lakeRepository.GetTableNoTracking()
				.Include(s => s.Sensors)
				.Include(c => c.Cameres)
				.Include(f => f.Fishs)
				.Include(r => r.Regions)
				.Include(s => s.Schedules)
				.AsQueryable();
		}

		public async Task<bool> IsNameExist(string name)
		{
			var lake = await _lakeRepository.GetTableNoTracking().Where(s => s.Name == name).FirstOrDefaultAsync();
			if (lake is null) return false;
			return true;
		}
	}
}
