namespace AntiFishing.Core.Features.Instructions.Commands.Models
{
	public class DeleteInstructionCommand : IRequest<Response<string>>
	{
		public int Id { get; set; }
	}
}
