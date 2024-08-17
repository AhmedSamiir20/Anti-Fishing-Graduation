namespace AntiFishing.Api.Controllers;

[ApiController]
public class RegionController : AppControllerBase
{

	[HttpGet(Router.RegionRouting.ListName)]
	public async Task<IActionResult> GetRegionsName()
	{
		var response = await _mediator.Send(new GetNameRegionListQuery());
		return Ok(response);
	}

	[HttpGet(Router.RegionRouting.List)]
	public async Task<IActionResult> GetRegions()
	{
		var response = await _mediator.Send(new GetRegionListQuery());
		return Ok(response);
	}

	//[HttpGet(Router.LakeRouting.Paginated)]
	//public async Task<IActionResult> GetStudentsPaginatedList([FromQuery] GetStudentPaginatedListQuery query)
	//{
	//	var response = await _mediator.Send(query);
	//	return Ok(response);
	//}

	[HttpGet(Router.RegionRouting.Single)]
	public async Task<IActionResult> GetRegionAsync(int id)
	{
		return NewResult(await _mediator.Send(new GetRegionByIdQuery(id)));
	}

	[HttpPost(Router.RegionRouting.Create)]
	public async Task<IActionResult> AddRegionAsync([FromForm] AddRegionCommand command)
	{
		var response = await _mediator.Send(command);
		return NewResult(response);
	}

	[HttpPut(Router.RegionRouting.Update)]
	public async Task<IActionResult> EditRegionAsync([FromForm] EditRegionCommand command)
	{
		var response = await _mediator.Send(command);
		return NewResult(response);
	}
	[HttpDelete(Router.RegionRouting.Delete)]
	public async Task<IActionResult> DeleteRegionAsync([FromBody] DeleteRegionCommand command)
	{
		var response = await _mediator.Send(command);
		return NewResult(response);
	}
}
