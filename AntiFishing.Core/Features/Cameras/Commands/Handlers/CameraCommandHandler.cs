
namespace AntiFishing.Core.Features.Cameras.Commands.Handlers
{
	public class CameraCommandHandler : ResponseHandler,
	IRequestHandler<AddCameraCommand, Response<string>>,
	IRequestHandler<EditCameraCommand, Response<string>>,
	IRequestHandler<DeleteCameraCommand, Response<string>>
	{
		private readonly ICameraService _cameraService;
		private readonly ILakeService _lakeService;
		private readonly IRegionService _regionService;
		private readonly IMapper _mapper;

		public CameraCommandHandler(ICameraService cameraService, IMapper mapper, ILakeService lakeService, IRegionService regionService)
		{
			_cameraService = cameraService;
			_mapper = mapper;
			_lakeService = lakeService;
			_regionService = regionService;
		}

		public async Task<Response<string>> Handle(AddCameraCommand request, CancellationToken cancellationToken)
		{
			if (request == null)
				return BadRequest<string>("Enter the following Data please");

			var cameraMapper = _mapper.Map<Camera>(request);
			var result = await _cameraService.AddAsync(cameraMapper);
			if (result is "Added Successfully")
				return Created("Add Successfully");
			return BadRequest<string>("this Name is used before");
		}

		public async Task<Response<string>> Handle(EditCameraCommand request, CancellationToken cancellationToken)
		{
			if (request == null)
				return BadRequest<string>("Enter the following Data please");

			//check if this Camera is exist or not
			var camera = await _cameraService.GetCameraByIdAsync(request.Id);
			if (camera is null)
				return NotFound<string>("Camera is Not Found");

			var cameraMapper = _mapper.Map<Camera>(request);
			cameraMapper.Lake = camera.Lake;

			var result = await _cameraService.EditAsync(cameraMapper);

			if (result is "Updating Successfully")
				return Success($"Updating Successfully{cameraMapper.CameraId}");
			return BadRequest<string>("this Name is used before");
		}

		public async Task<Response<string>> Handle(DeleteCameraCommand request, CancellationToken cancellationToken)
		{
			if (request is null)
				return BadRequest<string>("Enter the ID please");
			var result = await _cameraService.DeleteAsync(request.CameraId);
			if (result is "Not Found")
				return BadRequest<string>("This Camera not exist");
			return Success("Deleted successfully");

		}
	}
}
