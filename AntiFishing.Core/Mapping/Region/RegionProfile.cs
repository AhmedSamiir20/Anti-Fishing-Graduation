namespace AntiFishing.Core.Mapping.Region
{
	public partial class RegionProfile : Profile
	{
		public RegionProfile()
		{
			GetRegionListMapping();
			GetNameRegionListMapping();
			GetRegionByIdMapping();
			AddRegionCommandMapping();
			EditRegionCommandMapping();
			DeleteRegionCommandMapping();
		}
	}
}
