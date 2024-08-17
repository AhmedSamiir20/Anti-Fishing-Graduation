namespace AntiFishing.Service.Abstracts
{
	public interface ISensorService
	{
		public Task<IReadOnlyList<Sensor>> GetSensorsAsync();
		public Task<IReadOnlyList<Sensor>> GetSensorsByRegionIdAsync(int regionId);
		public Task<Sensor> GetSensorByIdAsync(int id);
		public Task<string> AddAsync(Sensor sensor);
		public Task<string> EditAsync(Sensor sensor);
		public Task<string> DeleteAsync(int sensorId);
		public Task<bool> IsNameExist(string name);
		public IQueryable<Sensor> GetSensorsQuerable();
		//public IQueryable<Sensor> FilterStudentPaginatedQuerable(StudentOrderingEnum orderingEnum, string search);
	}
}
