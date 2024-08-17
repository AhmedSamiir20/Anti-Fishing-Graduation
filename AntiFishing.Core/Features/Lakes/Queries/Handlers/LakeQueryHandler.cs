namespace AntiFishing.Core.Features.Lakes.Queries.Handlers
{
	public class LakeQueryHandler : ResponseHandler,
		IRequestHandler<GetLakeNameListQuery, Response<IReadOnlyList<GetLakeNameListResponse>>>
		, IRequestHandler<GetLakeByIdQuery, Response<Lake>>
		, IRequestHandler<GetLakeListQuery, Response<IReadOnlyList<Lake>>>
	{
		private readonly ILakeService _lakeService;
		private readonly IMapper _mapper;

		public LakeQueryHandler(ILakeService lakeService, IMapper mapper)
		{
			_lakeService = lakeService;
			_mapper = mapper;
		}

		public async Task<Response<IReadOnlyList<GetLakeNameListResponse>>> Handle(GetLakeNameListQuery request, CancellationToken cancellationToken)
		{
			var lakes = _mapper.Map<IReadOnlyList<GetLakeNameListResponse>>(await _lakeService.GetLakesAsync());
			if (lakes is null)
				return NotFound<IReadOnlyList<GetLakeNameListResponse>>("There is no lakes");
			return Success(lakes, null, "Successfully Get"); //return Success of the Response Class
		}

		public async Task<Response<Lake>> Handle(GetLakeByIdQuery request, CancellationToken cancellationToken)
		{
			var lake = await _lakeService.GetLakeByIdAsync(request.Id);
			if (lake == null)
				return NotFound<Lake>("There is no Lake by this id");
			var result = _mapper.Map<Lake>(lake);
			return Success(result, "null", "Successfully Get");
		}

		public async Task<Response<IReadOnlyList<Lake>>> Handle(GetLakeListQuery request, CancellationToken cancellationToken)
		{
			var lakes = _mapper.Map<IReadOnlyList<Lake>>(await _lakeService.GetLakesAsync());
			if (lakes is null)
				return NotFound<IReadOnlyList<Lake>>("There is no lakes");
			return Success(lakes, null, "Successfully Get"); //return Success of the Response Class
		}

	}
}
