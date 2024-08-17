namespace AntiFishing.Api.Controllers;

[ApiController]
public class LakesController : AppControllerBase
{

	[HttpGet(Router.LakeRouting.NamesList)]
	public async Task<IActionResult> GetLakesName()
	{
		var response = await _mediator.Send(new GetLakeNameListQuery());
		return Ok(response);
	}

	[HttpGet(Router.LakeRouting.List)]
	public async Task<IActionResult> GetLakes()
	{
		var response = await _mediator.Send(new GetLakeListQuery());
		return Ok(response);
	}

	//[HttpGet(Router.LakeRouting.Paginated)]
	//public async Task<IActionResult> GetStudentsPaginatedList([FromQuery] GetStudentPaginatedListQuery query)
	//{
	//	var response = await _mediator.Send(query);
	//	return Ok(response);
	//}

	[HttpGet(Router.LakeRouting.Single)]
	public async Task<IActionResult> GetLakeAsync(int id)
	{
		return NewResult(await _mediator.Send(new GetLakeByIdQuery(id)));
	}

	[HttpPost(Router.LakeRouting.Create)]
	public async Task<IActionResult> AddLakeAsync([FromForm] AddLakeCommand command)
	{
		var response = await _mediator.Send(command);
		return NewResult(response);
	}

	[HttpPut(Router.LakeRouting.Update)]
	public async Task<IActionResult> EditLakeAsync([FromForm] EditLakeCommand command)
	{
		var response = await _mediator.Send(command);
		return NewResult(response);
	}
	[HttpDelete(Router.LakeRouting.Delete)]
	public async Task<IActionResult> DeleteLakeAsync([FromBody] DeleteLakeCommand command)
	{
		var response = await _mediator.Send(command);
		return NewResult(response);
	}
}
