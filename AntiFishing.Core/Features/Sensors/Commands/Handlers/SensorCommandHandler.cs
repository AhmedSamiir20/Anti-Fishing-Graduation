

namespace AntiFishing.Core.Features.Sensors.Commands.Handlers;

public class SensorCommandHandler : ResponseHandler,
	IRequestHandler<AddSensorCommand, Response<string>>,
	IRequestHandler<EditSensorCommand, Response<string>>,
	IRequestHandler<DeleteSensorCommand, Response<string>>
{
	private readonly ISensorService _sensorService;
	private readonly ILakeService _lakeService;
	private readonly IRegionService _regionService;
	private readonly IMapper _mapper;

	public SensorCommandHandler(ISensorService sensorService, IMapper mapper, ILakeService lakeService, IRegionService regionService)
	{
		_sensorService = sensorService;
		_mapper = mapper;
		_lakeService = lakeService;
		_regionService = regionService;
	}

	public async Task<Response<string>> Handle(AddSensorCommand request, CancellationToken cancellationToken)
	{
		if (request == null)
			return BadRequest<string>("Enter the following Data please");

		var sensorMapper = _mapper.Map<Sensor>(request);
		var result = await _sensorService.AddAsync(sensorMapper);
		if (result is "Added Successfully")
			return Created("Add Successfully");
		return BadRequest<string>("this Name is used before");
	}

	public async Task<Response<string>> Handle(EditSensorCommand request, CancellationToken cancellationToken)
	{
		if (request == null)
			return BadRequest<string>("Enter the following Data please");

		//check if this Sensor is exist or not
		var sensor = await _sensorService.GetSensorByIdAsync(request.Id);
		if (sensor is null)
			return NotFound<string>("Sensor is Not Found");

		var sensorMapper = _mapper.Map<Sensor>(request);
		sensorMapper.Lake = sensor.Lake;

		var result = await _sensorService.EditAsync(sensorMapper);

		if (result is "Updating Successfully")
			return Success($"Updating Successfully{sensorMapper.SensorId}");
		return BadRequest<string>("this Name is used before");
	}

	public async Task<Response<string>> Handle(DeleteSensorCommand request, CancellationToken cancellationToken)
	{
		if (request is null)
			return BadRequest<string>("Enter the ID please");
		var result = await _sensorService.DeleteAsync(request.Id);
		if (result is "Not Found")
			return BadRequest<string>("This Sensor not exist");
		return Success("Deleted successfully");

	}
}
