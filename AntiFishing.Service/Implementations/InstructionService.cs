namespace AntiFishing.Service.Implementations
{
	internal class InstructionService : IInstructionService
	{
		private readonly IInstructionRepository _instructionRepository;

		public InstructionService(IInstructionRepository instructionRepository)
		{
			_instructionRepository = instructionRepository;
		}

		public async Task<string> AddAsync(Instruction instruction)
		{
			var check = await _instructionRepository.GetTableNoTracking().Where(s => s.Description.Equals(instruction.Description)).FirstOrDefaultAsync();
			if (check != null)
				return "Exist";
			await _instructionRepository.AddAsync(instruction);
			return "Added Successfully";
		}

		public async Task<string> DeleteAsync(int instructionId)
		{
			var check = await _instructionRepository.GetByIdAsync(instructionId);
			if (check is null) return "Not Found";
			await _instructionRepository.DeleteAsync(check);
			return "Deleted Successfully";
		}

		public async Task<string> EditAsync(Instruction instruction)
		{
			await _instructionRepository.UpdateAsync(instruction);
			return "Updating Successfully";
		}

		public async Task<Instruction> GetInstructionByIdAsync(int id)
		{
			var instruction = _instructionRepository.GetTableNoTracking()
				.Where(d => d.Id.Equals(id))
				.FirstOrDefault();//we check about null value in the top layer not this layer
			return instruction;
		}

		public async Task<IReadOnlyList<Instruction>> GetInstructionsAsync()
		{
			return await _instructionRepository
				.GetInstructionsAsync();
		}

		public IQueryable<Instruction> GetInstructionsQuerable()
		{
			//Get the Regions Querable to use it in pagination 
			return _instructionRepository.GetTableNoTracking()
				.AsQueryable();
		}

		public async Task<bool> IsNameExist(string name)
		{
			var instruction = await _instructionRepository.GetTableNoTracking().Where(s => s.Title == name).FirstOrDefaultAsync();
			if (instruction is null) return false;
			return true;
		}
	}
}
