namespace AntiFishing.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class CamerasController : AppControllerBase
	{


		[HttpGet(Router.CameraRouting.NamesList)]
		public async Task<IActionResult> GetCameras()
		{
			var response = await _mediator.Send(new GetCameraNameListQuery());
			return Ok(response);
		}

		[HttpGet(Router.CameraRouting.List)]
		public async Task<IActionResult> GetCamerasList()
		{
			var response = await _mediator.Send(new GetCameraListQuery());
			return Ok(response);
		}

		//[HttpGet(Router.CameraRouting.Paginated)]
		//public async Task<IActionResult> GetStudentsPaginatedList([FromQuery] GetStudentPaginatedListQuery query)
		//{
		//	var response = await _mediator.Send(query);
		//	return Ok(response);
		//}

		[HttpGet(Router.CameraRouting.Single)]
		public async Task<IActionResult> GetCameraAsync(int id)
		{
			return NewResult(await _mediator.Send(new GetCameraByIdQuery(id)));
		}

		[HttpPost(Router.CameraRouting.Create)]
		public async Task<IActionResult> AddCameraAsync([FromForm] AddCameraCommand command)
		{
			var response = await _mediator.Send(command);
			return NewResult(response);
		}

		[HttpPut(Router.CameraRouting.Update)]
		public async Task<IActionResult> EditCameraAsync([FromForm] EditCameraCommand command)
		{
			var response = await _mediator.Send(command);
			return NewResult(response);
		}
		[HttpDelete(Router.CameraRouting.Delete)]
		public async Task<IActionResult> DeleteCameraAsync([FromBody] DeleteCameraCommand command)
		{
			var response = await _mediator.Send(command);
			return NewResult(response);
		}
	}
}
