using AntiFishing.Core.Features.Instructions.Commands.Models;
using AntiFishing.Core.Features.Instructions.Queries.Models;

namespace AntiFishing.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class InstructionsController : AppControllerBase
	{

		[HttpGet(Router.InstructionRouting.List)]
		public async Task<IActionResult> GetInstructions()
		{
			var response = await _mediator.Send(new GetInstructionsListQuery());
			return Ok(response);
		}

		//[HttpGet(Router.InstructionRouting.Paginated)]
		//public async Task<IActionResult> GetStudentsPaginatedList([FromQuery] GetStudentPaginatedListQuery query)
		//{
		//	var response = await _mediator.Send(query);
		//	return Ok(response);
		//}

		[HttpGet(Router.InstructionRouting.Single)]
		public async Task<IActionResult> GetInstructionAsync(int id)
		{
			return NewResult(await _mediator.Send(new GetInstructionByIdQuery(id)));
		}

		[HttpPost(Router.InstructionRouting.Create)]
		public async Task<IActionResult> AddInstructionAsync([FromForm] AddInstructionCommand command)
		{
			var response = await _mediator.Send(command);
			return NewResult(response);
		}

		[HttpPut(Router.InstructionRouting.Update)]
		public async Task<IActionResult> EditInstructionAsync([FromForm] EditInstructionCommand command)
		{
			var response = await _mediator.Send(command);
			return NewResult(response);
		}
		[HttpDelete(Router.InstructionRouting.Delete)]
		public async Task<IActionResult> DeleteInstructionAsync([FromBody] DeleteInstructionCommand command)
		{
			var response = await _mediator.Send(command);
			return NewResult(response);
		}
	}
}
