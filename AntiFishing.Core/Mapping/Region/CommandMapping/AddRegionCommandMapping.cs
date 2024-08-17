namespace AntiFishing.Core.Mapping.Region
{
	public partial class RegionProfile
	{
		public void AddRegionCommandMapping()
		{
			CreateMap<AddRegionCommand, Data.Entities.Region>()
			.ForMember(dist => dist.LakeId, opt => opt.MapFrom(src => src.LakeId)); ;

		}
	}
}
