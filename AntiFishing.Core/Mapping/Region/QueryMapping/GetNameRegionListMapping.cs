namespace AntiFishing.Core.Mapping.Region
{
	public partial class RegionProfile
	{
		public void GetNameRegionListMapping()
		{
			CreateMap<Data.Entities.Region, GetNameRegionListResponse>();
			//.ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(sorc => sorc.Department.DName));
		}

	}
}
