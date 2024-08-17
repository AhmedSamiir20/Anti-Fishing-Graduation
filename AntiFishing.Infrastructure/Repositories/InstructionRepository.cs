namespace AntiFishing.Infrastructure.Repositories
{
	public class InstructionRepository : GenericRepositoryAsync<Instruction>, IInstructionRepository
	{
		private readonly DbSet<Instruction> _instructions;
		public InstructionRepository(ApplicationDbContext _context) : base(_context)
		{
			_instructions = _context.Set<Instruction>();
		}

		public async Task<IReadOnlyList<Instruction>> GetInstructionsAsync()
		{
			return await _instructions.AsNoTracking().Include(l => l.Lake).ToListAsync();
		}
	}
}
