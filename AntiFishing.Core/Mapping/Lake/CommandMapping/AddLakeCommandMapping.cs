

namespace AntiFishing.Core.Mapping.Lake
{
	public partial class LakeProfile
	{
		public void AddLakeCommandMapping()
		{
			CreateMap<AddLakeCommand, Data.Entities.Lake>();

		}
	}
}
