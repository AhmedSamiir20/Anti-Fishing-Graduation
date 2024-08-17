namespace AntiFishing.Service.Abstracts
{
	public interface ICameraService
	{
		public Task<IReadOnlyList<Camera>> GetCamerasAsync();
		public Task<Camera> GetCameraByIdAsync(int id);
		public Task<string> AddAsync(Camera camera);
		public Task<string> EditAsync(Camera camera);
		public Task<string> DeleteAsync(int cameraId);
		public Task<bool> IsNameExist(string name);
		public IQueryable<Camera> GetCamerasQuerable();
		//public IQueryable<Camera> FilterStudentPaginatedQuerable(StudentOrderingEnum orderingEnum, string search);
	}
}
