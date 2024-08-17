namespace AntiFishing.Core.Mapping.Camera
{
	public partial class CameraProfile
	{
		public void GetCameraNameListMapping()
		{
			CreateMap<Data.Entities.Camera, GetCameraNameListResponse>();
			//.ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(sorc => sorc.Department.DName));
		}

	}
}
