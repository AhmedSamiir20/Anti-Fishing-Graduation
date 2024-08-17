namespace AntiFishing.Infrastructure.Abstracts
{
	public interface IInstructionRepository : IGenericRepositoryAsync<Instruction>
	{
		public Task<IReadOnlyList<Instruction>> GetInstructionsAsync();
	}
}
