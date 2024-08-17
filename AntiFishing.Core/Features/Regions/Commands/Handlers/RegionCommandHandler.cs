namespace AntiFishing.Core.Features.Regions.Commands.Handlers;

public class RegionCommandHandler : ResponseHandler,
	IRequestHandler<AddRegionCommand, Response<string>>,
	IRequestHandler<EditRegionCommand, Response<string>>,
	IRequestHandler<DeleteRegionCommand, Response<string>>
{
	private readonly IRegionService _regionService;
	private readonly ILakeService _lakeService;
	private readonly IMapper _mapper;

	public RegionCommandHandler(IRegionService regionService, IMapper mapper, ILakeService lakeService)
	{
		_regionService = regionService;
		_mapper = mapper;
		_lakeService = lakeService;
	}

	public async Task<Response<string>> Handle(AddRegionCommand request, CancellationToken cancellationToken)
	{

		if (request == null)
			return BadRequest<string>("Enter the following Data please");

		var regionMapper = _mapper.Map<Region>(request);

		var result = await _regionService.AddAsync(regionMapper);
		if (result is "Added Successfully")
			return Created("Add Successfully");
		return BadRequest<string>("There is something wrong");
	}

	public async Task<Response<string>> Handle(EditRegionCommand request, CancellationToken cancellationToken)
	{
		if (request == null)
			return BadRequest<string>("Enter the following Data please");

		//check if this student is exist or not
		var region = await _regionService.GetRegionByIdAsync(request.Id);
		if (region is null)
			return NotFound<string>("Region is Not Found");

		var regionMapper = _mapper.Map<Region>(request);

		var result = await _regionService.EditAsync(regionMapper);

		if (result is "Updating Successfully")
			return Success($"Updating Successfully{regionMapper.RegionId}");
		return BadRequest<string>("this Name is used before");
	}

	public async Task<Response<string>> Handle(DeleteRegionCommand request, CancellationToken cancellationToken)
	{
		if (request is null)
			return BadRequest<string>("Enter the ID please");
		var result = await _regionService.DeleteAsync(request.Id);
		if (result is "Not Found")
			return BadRequest<string>("This Region not exist");
		return Success("Deleted successfully");

	}
}
