namespace AntiFishing.Core.Features.Instructions.Queries.Models
{
	public class GetInstructionByIdQuery : IRequest<Response<Instruction>>
	{
		public int Id { get; set; }
		public GetInstructionByIdQuery(int id)
		{
			Id = id;
		}
	}
}
