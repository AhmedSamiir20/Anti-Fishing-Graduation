namespace AntiFishing.Core.Features.Lakes.Commands.Handlers;

public class LakeCommandHandler : ResponseHandler,
	IRequestHandler<AddLakeCommand, Response<string>>,
	IRequestHandler<EditLakeCommand, Response<string>>,
	IRequestHandler<DeleteLakeCommand, Response<string>>
{
	private readonly ILakeService _lakeService;
	private readonly IMapper _mapper;

	public LakeCommandHandler(ILakeService lakeService, IMapper mapper)
	{
		_lakeService = lakeService;
		_mapper = mapper;
	}

	public async Task<Response<string>> Handle(AddLakeCommand request, CancellationToken cancellationToken)
	{
		var lakeMapper = _mapper.Map<Lake>(request);
		var result = await _lakeService.AddAsync(lakeMapper);
		if (result is "Added Successfully")
			return Created("Add Successfully");
		return BadRequest<string>("this Name is used before");
	}

	public async Task<Response<string>> Handle(EditLakeCommand request, CancellationToken cancellationToken)
	{
		if (request == null)
			return BadRequest<string>("Enter the following Data please");

		//check if this Lake is exist or not
		var lake = await _lakeService.GetLakeByIdAsync(request.Id);
		if (lake is null)
			return NotFound<string>("Lake is Not Found");

		var lakeMapper = _mapper.Map<Lake>(request);

		var result = await _lakeService.EditAsync(lakeMapper);

		if (result is "Updating Successfully")
			return Success($"Updating Successfully{lakeMapper.LakeId}");
		return BadRequest<string>("this Name is used before");
	}

	public async Task<Response<string>> Handle(DeleteLakeCommand request, CancellationToken cancellationToken)
	{
		if (request is null)
			return BadRequest<string>("Enter the ID please");
		var result = await _lakeService.DeleteAsync(request.Id);
		if (result is "Not Found")
			return BadRequest<string>("This Lake not exist");
		return Success("Deleted successfully");

	}
}
