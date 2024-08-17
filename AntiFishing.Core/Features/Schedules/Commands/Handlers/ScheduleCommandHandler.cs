using AntiFishing.Infrastructure.Abstracts;

namespace AntiFishing.Core.Features.Schedules.Commands.Handlers
{
	public class ScheduleCommandHandler : ResponseHandler,
	IRequestHandler<AddScheduleCommand, Response<string>>,
	IRequestHandler<EditScheduleCommand, Response<string>>,
	IRequestHandler<DeleteScheduleCommand, Response<string>>
	{
		private readonly IScheduleService _scheduleService;
		private readonly IAuthRepository _authRepository;
		private readonly IMapper _mapper;

		public ScheduleCommandHandler(IScheduleService scheduleService, IMapper mapper, IAuthRepository authRepository)
		{
			_scheduleService = scheduleService;
			_mapper = mapper;
			_authRepository = authRepository;
		}

		public async Task<Response<string>> Handle(AddScheduleCommand request, CancellationToken cancellationToken)
		{
			if (request == null)
				return BadRequest<string>("Enter the following Data please");

			var user = await _authRepository.GetUser(request.UserId);
			if (user is null)
				return BadRequest<string>("There is no user by this id");



			var scheduleMapper = _mapper.Map<Schedule>(request);
			scheduleMapper.User = user;
			var result = await _scheduleService.AddAsync(scheduleMapper);
			if (result is "Added Successfully")
				return Created("Add Successfully");
			return BadRequest<string>("this Name is used before");
		}

		public async Task<Response<string>> Handle(EditScheduleCommand request, CancellationToken cancellationToken)
		{
			if (request == null)
				return BadRequest<string>("Enter the following Data please");

			//check if this Schedule is exist or not
			var schedule = await _scheduleService.GetScheduleByIdAsync(request.ScheduleId);
			if (schedule is null)
				return NotFound<string>("Schedule is Not Found");

			var scheduleMapper = _mapper.Map<Schedule>(request);

			var result = await _scheduleService.EditAsync(scheduleMapper);

			if (result is "Updating Successfully")
				return Success($"Updating Successfully{scheduleMapper.ScheduleId}");
			return BadRequest<string>("this Name is used before");
		}

		public async Task<Response<string>> Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
		{
			if (request is null)
				return BadRequest<string>("Enter the ID please");
			var result = await _scheduleService.DeleteAsync(request.Id);
			if (result is "Not Found")
				return BadRequest<string>("This Schedule not exist");
			return Success("Deleted successfully");

		}
	}
}
