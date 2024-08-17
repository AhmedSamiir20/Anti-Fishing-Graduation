
namespace AntiFishing.Core.Features.Cameras.Queries.Handlers
{
	public class CameraQueryHandler : ResponseHandler,
		IRequestHandler<GetCameraNameListQuery, Response<IReadOnlyList<GetCameraNameListResponse>>>
		, IRequestHandler<GetCameraByIdQuery, Response<Camera>>
		, IRequestHandler<GetCameraListQuery, Response<IReadOnlyList<GetCameraListResponse>>>//take the request and give the response
																							 //, IRequestHandler<GetCameraPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>
	{
		private readonly ICameraService _CameraService;
		private readonly IMapper _mapper;

		public CameraQueryHandler(ICameraService CameraService, IMapper mapper)
		{
			_CameraService = CameraService;
			_mapper = mapper;
		}

		public async Task<Response<IReadOnlyList<GetCameraNameListResponse>>> Handle(GetCameraNameListQuery request, CancellationToken cancellationToken)
		{
			var Cameras = _mapper.Map<IReadOnlyList<GetCameraNameListResponse>>(await _CameraService.GetCamerasAsync());
			if (Cameras is null)
				return NotFound<IReadOnlyList<GetCameraNameListResponse>>("There is no Cameras");
			return Success(Cameras, null, "Successfully Get"); //return Success of the Response Class
		}

		public async Task<Response<Camera>> Handle(GetCameraByIdQuery request, CancellationToken cancellationToken)
		{
			var Camera = await _CameraService.GetCameraByIdAsync(request.Id);
			if (Camera == null)
				return NotFound<Camera>("There is no Camera by this id");
			var result = _mapper.Map<Camera>(Camera);
			return Success(result, "null", "Successfully Get");
		}

		public async Task<Response<IReadOnlyList<GetCameraListResponse>>> Handle(GetCameraListQuery request, CancellationToken cancellationToken)
		{
			var Cameras = _mapper.Map<IReadOnlyList<GetCameraListResponse>>(await _CameraService.GetCamerasAsync());
			if (Cameras is null)
				return NotFound<IReadOnlyList<GetCameraListResponse>>("There is no Cameras");
			return Success(Cameras, null, "Successfully Get"); //return Success of the Response Class
		}

		//public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetCameraPaginatedListQuery request, CancellationToken cancellationToken)
		//{
		//	Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(e.StudID, e.Name, e.Address, e.Department.DName); //e=Camera here
		//																																									   //var querable = _CameraService.GetStudentsQuerable();
		//	var filterQuery = _CameraService.FilterStudentPaginatedQuerable(request.orderingEnum, request.Search);
		//	var paginatedList = await filterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
		//	return paginatedList;
		//}
	}
}
