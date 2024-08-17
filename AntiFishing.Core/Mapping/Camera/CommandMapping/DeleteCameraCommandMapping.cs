
namespace AntiFishing.Core.Mapping.Camera
{
	public partial class CameraProfile
	{
		public void DeleteCameraCommandMapping()
		{
			CreateMap<DeleteCameraCommand, Data.Entities.Camera>();

		}
	}
}
