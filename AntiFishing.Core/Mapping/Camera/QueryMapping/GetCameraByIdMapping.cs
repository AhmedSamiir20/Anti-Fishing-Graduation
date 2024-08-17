namespace AntiFishing.Core.Mapping.Camera
{
	public partial class CameraProfile
	{
		public void GetCameraByIdMapping()
		{
			CreateMap<Data.Entities.Sensor, GetSingleSensorResponse>();
			//.ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(sorc => sorc.Department.DName));
		}

	}
}
