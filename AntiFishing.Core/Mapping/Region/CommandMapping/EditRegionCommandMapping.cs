
namespace AntiFishing.Core.Mapping.Region
{
	public partial class RegionProfile
	{
		public void EditRegionCommandMapping()
		{
			CreateMap<EditRegionCommand, Data.Entities.Region>()
				.ForMember(dist => dist.RegionId, opt => opt.MapFrom(src => src.Id)); ;
		}
	}
}
