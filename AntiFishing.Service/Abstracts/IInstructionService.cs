namespace AntiFishing.Service.Abstracts
{
	public interface IInstructionService
	{
		public Task<IReadOnlyList<Instruction>> GetInstructionsAsync();
		public Task<Instruction> GetInstructionByIdAsync(int id);
		public Task<string> AddAsync(Instruction instruction);
		public Task<string> EditAsync(Instruction instruction);
		public Task<string> DeleteAsync(int instructionId);
		public Task<bool> IsNameExist(string name);
		public IQueryable<Instruction> GetInstructionsQuerable();
	}
}
