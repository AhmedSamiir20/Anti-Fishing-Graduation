namespace AntiFishing.Core.Mapping.Instruction
{
	public partial class InstructionProfile
	{
		public void EditInstructionCommandMapping()
		{
			CreateMap<EditInstructionCommand, Data.Entities.Instruction>()
				.ForMember(dist => dist.Id, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.LakeId, opt => opt.MapFrom(sorc => sorc.LakeId));
		}
	}
}
