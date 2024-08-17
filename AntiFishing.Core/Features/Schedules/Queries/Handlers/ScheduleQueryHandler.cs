
namespace AntiFishing.Core.Features.Schedules.Queries.Handlers
{
	public class ScheduleQueryHandler : ResponseHandler,
		IRequestHandler<GetScheduleListQuery, Response<IReadOnlyList<Schedule>>>
		, IRequestHandler<GetScheduleByIdQuery, Response<Schedule>> //take the request and give the response
																	//, IRequestHandler<GetSchedulePaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>
	{
		private readonly IScheduleService _scheduleService;
		private readonly IMapper _mapper;

		public ScheduleQueryHandler(IScheduleService scheduleService, IMapper mapper)
		{
			_scheduleService = scheduleService;
			_mapper = mapper;
		}

		public async Task<Response<IReadOnlyList<Schedule>>> Handle(GetScheduleListQuery request, CancellationToken cancellationToken)
		{
			var Schedules = _mapper.Map<IReadOnlyList<Schedule>>(await _scheduleService.GetSchedulesAsync());
			if (Schedules is null)
				return NotFound<IReadOnlyList<Schedule>>("There is no Schedules");
			return Success(Schedules, null, "Successfully Get"); //return Success of the Response Class
		}

		public async Task<Response<Schedule>> Handle(GetScheduleByIdQuery request, CancellationToken cancellationToken)
		{
			var Schedule = await _scheduleService.GetScheduleByIdAsync(request.Id);
			if (Schedule == null)
				return NotFound<Schedule>("There is no Schedule by this id");
			var result = _mapper.Map<Schedule>(Schedule);
			return Success(result, "null", "Successfully Get");
		}

		//public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetSchedulePaginatedListQuery request, CancellationToken cancellationToken)
		//{
		//	Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(e.StudID, e.Name, e.Address, e.Department.DName); //e=Schedule here
		//																																									   //var querable = _ScheduleService.GetStudentsQuerable();
		//	var filterQuery = _ScheduleService.FilterStudentPaginatedQuerable(request.orderingEnum, request.Search);
		//	var paginatedList = await filterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
		//	return paginatedList;
		//}
	}
}
