using AntiFishing.Core.Features.Instructions.Queries.Response;

namespace AntiFishing.Core.Features.Instructions.Queries.Models
{
	public class GetInstructionsListQuery : IRequest<Response<IReadOnlyList<GetInstructionsListResponse>>>
	{
	}
}
