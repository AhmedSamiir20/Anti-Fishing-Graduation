namespace AntiFishing.Core.Features.Lakes.Commands.Models
{
	public class DeleteLakeCommand : IRequest<Response<string>>
	{
		public int Id { get; set; }
	}
}
