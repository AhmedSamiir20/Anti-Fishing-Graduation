namespace AntiFishing.Core.Mapping.Lake
{
	public partial class LakeProfile
	{
		public void GetLakeByIdMapping()
		{
			CreateMap<Data.Entities.Lake, GetSingleLakeResponse>();
			//.ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(sorc => sorc.Department.DName));
		}

	}
}
