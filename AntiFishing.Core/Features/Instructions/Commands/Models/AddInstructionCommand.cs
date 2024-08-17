namespace AntiFishing.Core.Features.Instructions.Commands.Models
{
	public class AddInstructionCommand : IRequest<Response<string>>
	{

		public string Title { get; set; }

		public string Description { get; set; }

		public int LakeId { get; set; }
	}
}
