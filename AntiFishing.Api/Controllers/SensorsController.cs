namespace AntiFishing.Api.Controllers;

[ApiController]
public class SensorsController : AppControllerBase
{

	[HttpGet(Router.SensorRouting.List)]
	public async Task<IActionResult> GetSensors()
	{
		var response = await _mediator.Send(new GetSensorListQuery());
		return Ok(response);
	}

	[HttpGet(Router.SensorRouting.NameList)]
	public async Task<IActionResult> GetSensorsName()
	{
		var response = await _mediator.Send(new GetNameSensorListQuery());
		return Ok(response);
	}

	[HttpGet(Router.SensorRouting.ListByRegion)]
	public async Task<IActionResult> GetSensorsName(int id)
	{
		var response = await _mediator.Send(new GetSensorListByRegionIdQuery(id));
		return Ok(response);
	}

	//[HttpGet(Router.SensorRouting.Paginated)]
	//public async Task<IActionResult> GetStudentsPaginatedList([FromQuery] GetStudentPaginatedListQuery query)
	//{
	//	var response = await _mediator.Send(query);
	//	return Ok(response);
	//}

	[HttpGet(Router.SensorRouting.Single)]
	public async Task<IActionResult> GetSensorAsync(int id)
	{
		return NewResult(await _mediator.Send(new GetSensorByIdQuery(id)));
	}

	[HttpPost(Router.SensorRouting.Create)]
	public async Task<IActionResult> AddSensorAsync([FromForm] AddSensorCommand command)
	{
		var response = await _mediator.Send(command);
		return NewResult(response);
	}

	[HttpPut(Router.SensorRouting.Update)]
	public async Task<IActionResult> EditSensorAsync([FromForm] EditSensorCommand command)
	{
		var response = await _mediator.Send(command);
		return NewResult(response);
	}
	[HttpDelete(Router.SensorRouting.Delete)]
	public async Task<IActionResult> DeleteSensorAsync([FromBody] DeleteSensorCommand command)
	{
		var response = await _mediator.Send(command);
		return NewResult(response);
	}
}
