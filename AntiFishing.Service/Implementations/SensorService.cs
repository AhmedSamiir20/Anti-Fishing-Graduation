namespace AntiFishing.Service.Implementations
{
	internal class SensorSevice : ISensorService
	{
		private readonly ISensorRepository _sensorRepository;

		public SensorSevice(ISensorRepository sensorRepository)
		{
			_sensorRepository = sensorRepository;
		}

		public async Task<string> AddAsync(Sensor sensor)
		{
			var check = await _sensorRepository.GetTableNoTracking().Where(s => s.Name.Equals(sensor.Name)).FirstOrDefaultAsync();
			if (check != null)
				return "Exist";
			await _sensorRepository.AddAsync(sensor);
			return "Added Successfully";
		}

		public async Task<string> DeleteAsync(int sensorId)
		{
			var check = await _sensorRepository.GetByIdAsync(sensorId);
			if (check is null) return "Not Found";
			await _sensorRepository.DeleteAsync(check);
			return "Deleted Successfully";
		}

		public async Task<string> EditAsync(Sensor sensor)
		{
			await _sensorRepository.UpdateAsync(sensor);
			return "Updating Successfully";
		}

		public async Task<Sensor> GetSensorByIdAsync(int id)
		{
			var Sensor = _sensorRepository.GetTableNoTracking()
				.Include(l => l.Lake)
				.Include(r => r.Region)
				.Include(s => s.Notifications)
				.Include(s => s.Data)
				.Where(d => d.SensorId.Equals(id))
				.FirstOrDefault();//we check about null value in the top layer not this layer
			return Sensor;
		}

		public async Task<IReadOnlyList<Sensor>> GetSensorsAsync()
		{
			return await _sensorRepository.GetSensorsAsync();
		}

		public async Task<IReadOnlyList<Sensor>> GetSensorsByRegionIdAsync(int regionId)
		{
			return await _sensorRepository.GetSensorsByRegionIdAsync(regionId);

		}

		public IQueryable<Sensor> GetSensorsQuerable()
		{
			//Get the Sensors Querable to use it in pagination 
			return _sensorRepository.GetTableNoTracking()
				.Include(l => l.Lake)
				.Include(r => r.Region)
				.Include(s => s.Notifications)
				.Include(s => s.Data)
				.AsQueryable();
		}

		public async Task<bool> IsNameExist(string name)
		{
			var Sensor = await _sensorRepository.GetTableNoTracking().Where(s => s.Name == name).FirstOrDefaultAsync();
			if (Sensor is null) return false;
			return true;
		}
	}
}
