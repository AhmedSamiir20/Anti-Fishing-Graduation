namespace AntiFishing.Core.Mapping.Lake
{
	public partial class LakeProfile : Profile
	{
		public LakeProfile()
		{
			GetLakeListMapping();
			GetLakeByIdMapping();
			AddLakeCommandMapping();
			EditLakeCommandMapping();
			DeleteLakeCommandMapping();
		}
	}
}
