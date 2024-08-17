using AntiFishing.Core.Features.Instructions.Commands.Models;

namespace AntiFishing.Core.Mapping.Instruction
{
	public partial class InstructionProfile
	{
		public void DeleteInstructionCommandMapping()
		{
			CreateMap<EditInstructionCommand, Data.Entities.Instruction>();
		}
	}
}
