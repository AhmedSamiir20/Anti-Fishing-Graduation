
namespace AntiFishing.Core.Features.Instructions.Commands.Handlers
{
	public class InstructionCommandHandler : ResponseHandler,
		IRequestHandler<AddInstructionCommand, Response<string>>,
		IRequestHandler<EditInstructionCommand, Response<string>>,
		IRequestHandler<DeleteInstructionCommand, Response<string>>
	{

		private readonly IInstructionService _instructionService;
		private readonly IMapper _mapper;

		public InstructionCommandHandler(IMapper mapper, IInstructionService instructionService)
		{
			_mapper = mapper;
			_instructionService = instructionService;
		}

		public async Task<Response<string>> Handle(AddInstructionCommand request, CancellationToken cancellationToken)
		{
			var instructionMapper = _mapper.Map<Instruction>(request);
			var result = await _instructionService.AddAsync(instructionMapper);
			if (result is "Added Successfully")
				return Created("Add Successfully");
			return BadRequest<string>("this Name is used before");
		}

		public async Task<Response<string>> Handle(EditInstructionCommand request, CancellationToken cancellationToken)
		{
			if (request == null)
				return BadRequest<string>("Enter the following Data please");

			var instruction = await _instructionService.GetInstructionByIdAsync(request.Id);
			if (instruction is null)
				return NotFound<string>("Instruction is Not Found");

			var instructionMapper = _mapper.Map<Instruction>(request);

			var result = await _instructionService.EditAsync(instructionMapper);

			if (result is "Updating Successfully")
				return Success($"Updating Successfully{instructionMapper.Id}");
			return BadRequest<string>("this Name is used before");
		}

		public async Task<Response<string>> Handle(DeleteInstructionCommand request, CancellationToken cancellationToken)
		{
			if (request is null)
				return BadRequest<string>("Enter the ID please");
			var result = await _instructionService.DeleteAsync(request.Id);
			if (result is "Not Found")
				return BadRequest<string>("This Lake not exist");
			return Success("Deleted successfully");
		}
	}
}
