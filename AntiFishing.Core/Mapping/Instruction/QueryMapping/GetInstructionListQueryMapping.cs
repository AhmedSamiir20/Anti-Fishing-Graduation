using AntiFishing.Core.Features.Instructions.Queries.Response;

namespace AntiFishing.Core.Mapping.Instruction
{
	public partial class InstructionProfile
	{
		public void GetInstructionListQueryMapping()
		{
			CreateMap<Data.Entities.Instruction, GetInstructionsListResponse>()
				.ForMember(dest => dest.LakeName, opt => opt.MapFrom(sorc => sorc.Lake.Name));
		}
	}
}
