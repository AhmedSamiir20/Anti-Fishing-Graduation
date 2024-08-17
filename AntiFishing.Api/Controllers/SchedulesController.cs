namespace AntiFishing.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SchedulesController : AppControllerBase
	{
		[HttpGet(Router.ScheduleRouting.List)]
		public async Task<IActionResult> GetSchedules()
		{
			var response = await _mediator.Send(new GetScheduleListQuery());
			return Ok(response);
		}

		//[HttpGet(Router.ScheduleRouting.Paginated)]
		//public async Task<IActionResult> GetStudentsPaginatedList([FromQuery] GetStudentPaginatedListQuery query)
		//{
		//	var response = await _mediator.Send(query);
		//	return Ok(response);
		//}

		[HttpGet(Router.ScheduleRouting.Single)]
		public async Task<IActionResult> GetScheduleAsync(int id)
		{
			return NewResult(await _mediator.Send(new GetScheduleByIdQuery(id)));
		}

		[HttpPost(Router.ScheduleRouting.Create)]
		public async Task<IActionResult> AddScheduleAsync([FromForm] AddScheduleCommand command)
		{
			var response = await _mediator.Send(command);
			return NewResult(response);
		}

		[HttpPut(Router.ScheduleRouting.Update)]
		public async Task<IActionResult> EditScheduleAsync([FromForm] EditScheduleCommand command)
		{
			var response = await _mediator.Send(command);
			return NewResult(response);
		}
		[HttpDelete(Router.ScheduleRouting.Delete)]
		public async Task<IActionResult> DeleteScheduleAsync([FromBody] DeleteScheduleCommand command)
		{
			var response = await _mediator.Send(command);
			return NewResult(response);
		}
	}
}
