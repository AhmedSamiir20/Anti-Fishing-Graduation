namespace AntiFishing.Service.Abstracts
{
	public interface ILakeService
	{
		public Task<IReadOnlyList<Lake>> GetLakesAsync();
		public Task<Lake> GetLakeByIdAsync(int id);
		public Task<string> AddAsync(Lake lake);
		public Task<string> EditAsync(Lake lake);
		public Task<string> DeleteAsync(int lakeId);
		public Task<bool> IsNameExist(string name);
		public IQueryable<Lake> GetLakesQuerable();
		//public IQueryable<Lake> FilterStudentPaginatedQuerable(StudentOrderingEnum orderingEnum, string search);
	}
}
