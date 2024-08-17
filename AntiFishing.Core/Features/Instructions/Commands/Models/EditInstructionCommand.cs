namespace AntiFishing.Core.Features.Instructions.Commands.Models
{
	public class EditInstructionCommand : IRequest<Response<string>>
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public int LakeId { get; set; }
	}
}
