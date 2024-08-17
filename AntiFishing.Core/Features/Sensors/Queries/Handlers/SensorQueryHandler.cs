namespace AntiFishing.Core.Features.Sensors.Queries.Handlers
{
	public class SensorQueryHandler : ResponseHandler,
		IRequestHandler<GetSensorListQuery, Response<IReadOnlyList<GetSensorListResponse>>>
		, IRequestHandler<GetSensorByIdQuery, Response<Sensor>>
		, IRequestHandler<GetNameSensorListQuery, Response<IReadOnlyList<GetNameSensorListResponse>>>
		, IRequestHandler<GetSensorListByRegionIdQuery, Response<IReadOnlyList<GetSensorLisByRegionIdResponse>>>//take the request and give the response
																												//, IRequestHandler<GetSensorPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>
	{
		private readonly ISensorService _sensorService;
		private readonly IMapper _mapper;

		public SensorQueryHandler(ISensorService sensorService, IMapper mapper)
		{
			_sensorService = sensorService;
			_mapper = mapper;
		}

		public async Task<Response<IReadOnlyList<GetSensorListResponse>>> Handle(GetSensorListQuery request, CancellationToken cancellationToken)
		{
			var sensors = _mapper.Map<IReadOnlyList<GetSensorListResponse>>(await _sensorService.GetSensorsAsync());
			if (sensors is null)
				return NotFound<IReadOnlyList<GetSensorListResponse>>("There is no Sensors");
			return Success(sensors, null, "Successfully Get"); //return Success of the Response Class
		}

		public async Task<Response<Sensor>> Handle(GetSensorByIdQuery request, CancellationToken cancellationToken)
		{
			var Sensor = await _sensorService.GetSensorByIdAsync(request.Id);
			if (Sensor == null)
				return NotFound<Sensor>("There is no Sensor by this id");
			var result = _mapper.Map<Sensor>(Sensor);
			return Success(result, "null", "Successfully Get");
		}

		public async Task<Response<IReadOnlyList<GetNameSensorListResponse>>> Handle(GetNameSensorListQuery request, CancellationToken cancellationToken)
		{
			var sensors = _mapper.Map<IReadOnlyList<GetNameSensorListResponse>>(await _sensorService.GetSensorsAsync());
			if (sensors is null)
				return NotFound<IReadOnlyList<GetNameSensorListResponse>>("There is no Sensors");
			return Success(sensors, null, "Successfully Get"); //return Success of the Response Class
		}

		public async Task<Response<IReadOnlyList<GetSensorLisByRegionIdResponse>>> Handle(GetSensorListByRegionIdQuery request, CancellationToken cancellationToken)
		{
			var sensors = await _sensorService.GetSensorsByRegionIdAsync(request.RegionId);
			if (sensors == null)
				return NotFound<IReadOnlyList<GetSensorLisByRegionIdResponse>>("There is no Sensor in this region");
			var result = _mapper.Map<IReadOnlyList<GetSensorLisByRegionIdResponse>>(sensors);
			return Success(result, "null", "Successfully Get");
		}

		//public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetSensorPaginatedListQuery request, CancellationToken cancellationToken)
		//{
		//	Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(e.StudID, e.Name, e.Address, e.Department.DName); //e=Sensor here
		//																																									   //var querable = _SensorService.GetStudentsQuerable();
		//	var filterQuery = _SensorService.FilterStudentPaginatedQuerable(request.orderingEnum, request.Search);
		//	var paginatedList = await filterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
		//	return paginatedList;
		//}
	}
}
