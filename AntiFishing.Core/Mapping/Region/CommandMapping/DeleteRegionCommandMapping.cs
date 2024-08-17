
namespace AntiFishing.Core.Mapping.Region
{
	public partial class RegionProfile
	{
		public void DeleteRegionCommandMapping()
		{
			CreateMap<DeleteRegionCommand, Data.Entities.Region>();

		}
	}
}
