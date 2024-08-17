namespace AntiFishing.Core.Features.Regions.Queries.Handlers
{
	public class RegionQueryHandler : ResponseHandler,
		IRequestHandler<GetNameRegionListQuery, Response<IReadOnlyList<GetNameRegionListResponse>>>
		, IRequestHandler<GetRegionByIdQuery, Response<Region>>
		, IRequestHandler<GetRegionListQuery, Response<IReadOnlyList<GetRegionListResponse>>>//take the request and give the response
																							 //, IRequestHandler<GetRegionPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>
	{
		private readonly IRegionService _regionService;
		private readonly IMapper _mapper;

		public RegionQueryHandler(IRegionService regionService, IMapper mapper)
		{
			_regionService = regionService;
			_mapper = mapper;
		}

		public async Task<Response<IReadOnlyList<GetNameRegionListResponse>>> Handle(GetNameRegionListQuery request, CancellationToken cancellationToken)
		{
			var regions = _mapper.Map<IReadOnlyList<GetNameRegionListResponse>>(await _regionService.GetRegionsAsync());
			if (regions is null)
				return NotFound<IReadOnlyList<GetNameRegionListResponse>>("There is no Regions");
			return Success(regions, null, "Successfully Get"); //return Success of the Response Class
		}

		public async Task<Response<Region>> Handle(GetRegionByIdQuery request, CancellationToken cancellationToken)
		{
			var region = await _regionService.GetRegionByIdAsync(request.Id);
			if (region == null)
				return NotFound<Region>("There is no Region by this id");
			var result = _mapper.Map<Region>(region);
			return Success(result, "null", "Successfully Get");
		}

		public async Task<Response<IReadOnlyList<GetRegionListResponse>>> Handle(GetRegionListQuery request, CancellationToken cancellationToken)
		{
			var regions = _mapper.Map<IReadOnlyList<GetRegionListResponse>>(await _regionService.GetRegionsAsync());
			if (regions is null)
				return NotFound<IReadOnlyList<GetRegionListResponse>>("There is no Regions");
			return Success(regions, null, "Successfully Get"); //return Success of the Response Class
		}

		//public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetRegionPaginatedListQuery request, CancellationToken cancellationToken)
		//{
		//	Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(e.StudID, e.Name, e.Address, e.Department.DName); //e=Region here
		//																																									   //var querable = _RegionService.GetStudentsQuerable();
		//	var filterQuery = _RegionService.FilterStudentPaginatedQuerable(request.orderingEnum, request.Search);
		//	var paginatedList = await filterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
		//	return paginatedList;
		//}
	}
}
