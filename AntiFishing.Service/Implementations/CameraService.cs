namespace AntiFishing.Service.Implementations
{
	internal class CameraSevice : ICameraService
	{
		private readonly ICameraRepository _cameraRepository;

		public CameraSevice(ICameraRepository cameraRepository)
		{
			_cameraRepository = cameraRepository;
		}

		public async Task<string> AddAsync(Camera camera)
		{
			var check = await _cameraRepository.GetTableNoTracking().Where(s => s.Name.Equals(camera.Name)).FirstOrDefaultAsync();
			if (check != null)
				return "Exist";
			await _cameraRepository.AddAsync(camera);
			return "Added Successfully";
		}

		public async Task<string> DeleteAsync(int id)
		{
			var check = await _cameraRepository.GetByIdAsync(id);
			if (check is null) return "Not Found";
			await _cameraRepository.DeleteAsync(check);
			return "Deleted Successfully";
		}

		public async Task<string> EditAsync(Camera camera)
		{
			await _cameraRepository.UpdateAsync(camera);
			return "Updating Successfully";
		}

		public async Task<Camera> GetCameraByIdAsync(int id)
		{
			var camera = _cameraRepository.GetTableNoTracking()
				.Include(l => l.Lake)
				.Include(r => r.Region)
				.Include(s => s.Notifications)
				.Include(s => s.Videos)
				.Where(d => d.CameraId.Equals(id))
				.FirstOrDefault();//we check about null value in the top layer not this layer
			return camera;
		}

		public async Task<IReadOnlyList<Camera>> GetCamerasAsync()
		{
			return await _cameraRepository.GetCamerasAsync();
		}

		public IQueryable<Camera> GetCamerasQuerable()
		{
			//Get the Cameras Querable to use it in pagination 
			return _cameraRepository.GetTableNoTracking()
				.Include(l => l.Lake)
				.Include(r => r.Region)
				.Include(s => s.Notifications)
				.Include(s => s.Videos)
				.AsQueryable();
		}

		public async Task<bool> IsNameExist(string name)
		{
			var Camera = await _cameraRepository.GetTableNoTracking().Where(s => s.Name == name).FirstOrDefaultAsync();
			if (Camera is null) return false;
			return true;
		}
	}
}
