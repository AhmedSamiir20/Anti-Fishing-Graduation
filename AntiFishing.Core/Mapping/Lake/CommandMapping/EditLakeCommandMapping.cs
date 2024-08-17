
namespace AntiFishing.Core.Mapping.Lake
{
	public partial class LakeProfile
	{
		public void EditLakeCommandMapping()
		{
			CreateMap<EditLakeCommand, Data.Entities.Lake>()
				.ForMember(dist => dist.LakeId, opt => opt.MapFrom(src => src.Id));
		}
	}
}
