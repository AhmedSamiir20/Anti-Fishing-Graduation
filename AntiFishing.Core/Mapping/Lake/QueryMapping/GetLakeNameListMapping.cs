namespace AntiFishing.Core.Mapping.Lake
{
	public partial class LakeProfile
	{
		public void GetLakeListMapping()
		{
			CreateMap<Data.Entities.Lake, GetLakeNameListResponse>();
			//.ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(sorc => sorc.Department.DName));
		}

	}
}
