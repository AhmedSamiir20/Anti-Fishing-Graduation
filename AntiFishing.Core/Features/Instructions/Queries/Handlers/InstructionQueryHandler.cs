using AntiFishing.Core.Features.Instructions.Queries.Models;
using AntiFishing.Core.Features.Instructions.Queries.Response;

namespace AntiFishing.Core.Features.Instructions.Queries.Handlers
{
	public class InstructionQueryHandler : ResponseHandler,
		IRequestHandler<GetInstructionsListQuery, Response<IReadOnlyList<GetInstructionsListResponse>>>
		, IRequestHandler<GetInstructionByIdQuery, Response<Instruction>>
	{
		private readonly IInstructionService _instructionService;
		private readonly IMapper _mapper;

		public InstructionQueryHandler(IInstructionService instructionService, IMapper mapper)
		{
			_instructionService = instructionService;
			_mapper = mapper;
		}

		public async Task<Response<IReadOnlyList<GetInstructionsListResponse>>> Handle(GetInstructionsListQuery request, CancellationToken cancellationToken)
		{
			var instructions = _mapper.Map<IReadOnlyList<GetInstructionsListResponse>>(await _instructionService.GetInstructionsAsync());
			if (instructions is null)
				return NotFound<IReadOnlyList<GetInstructionsListResponse>>("There is no instructions");
			return Success(instructions, null, "Successfully Get");
		}

		public async Task<Response<Instruction>> Handle(GetInstructionByIdQuery request, CancellationToken cancellationToken)
		{
			var instruction = await _instructionService.GetInstructionByIdAsync(request.Id);
			if (instruction == null)
				return NotFound<Instruction>("There is no instruction by this id");

			return Success(instruction, "null", "Successfully Get");
		}
	}
}
