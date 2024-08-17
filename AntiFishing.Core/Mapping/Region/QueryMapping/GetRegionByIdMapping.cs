
namespace AntiFishing.Core.Mapping.Region
{
	public partial class RegionProfile
	{
		public void GetRegionByIdMapping()
		{
			CreateMap<Data.Entities.Region, GetSingleRegionResponse>();
			//.ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(sorc => sorc.Department.DName));
		}

	}
}
