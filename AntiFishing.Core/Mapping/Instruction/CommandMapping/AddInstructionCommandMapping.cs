namespace AntiFishing.Core.Mapping.Instruction
{
	public partial class InstructionProfile
	{
		public void AddInstructionCommandMapping()
		{
			CreateMap<AddInstructionCommand, Data.Entities.Instruction>()
				.ForMember(dest => dest.LakeId, opt => opt.MapFrom(sorc => sorc.LakeId));
		}
	}
}
