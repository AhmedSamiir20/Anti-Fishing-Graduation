namespace AntiFishing.Infrastructure.Abstracts
{
	public interface ISensorRepository : IGenericRepositoryAsync<Sensor>
	{
		public Task<IReadOnlyList<Sensor>> GetSensorsAsync();
		public Task<IReadOnlyList<Sensor>> GetSensorsByRegionIdAsync(int regionId);
	}
}
