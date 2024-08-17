namespace AntiFishing.Core.Mapping.Instruction
{
	public partial class InstructionProfile : Profile
	{
		public InstructionProfile()
		{
			EditInstructionCommandMapping();
			AddInstructionCommandMapping();
			DeleteInstructionCommandMapping();
			GetInstructionListQueryMapping();
		}

	}
}
