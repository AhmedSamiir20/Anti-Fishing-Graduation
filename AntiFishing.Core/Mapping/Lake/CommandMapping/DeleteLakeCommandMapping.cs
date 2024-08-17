
namespace AntiFishing.Core.Mapping.Lake
{
	public partial class LakeProfile
	{
		public void DeleteLakeCommandMapping()
		{
			CreateMap<DeleteLakeCommand, Data.Entities.Lake>();

		}
	}
}
