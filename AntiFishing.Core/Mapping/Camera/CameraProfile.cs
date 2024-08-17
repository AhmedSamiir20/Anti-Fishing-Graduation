namespace AntiFishing.Core.Mapping.Camera
{
	public partial class CameraProfile : Profile
	{
		public CameraProfile()
		{
			GetCameraListMapping();
			GetCameraByIdMapping();
			GetCameraNameListMapping();
			AddCameraCommandMapping();
			EditCameraCommandMapping();
			DeleteCameraCommandMapping();
		}
	}
}
