
using AntiFishing.Data.Entities.Identity;

namespace AntiFishing.Infrastructure.Context
{
	public class ApplicationDbContext : IdentityDbContext<User>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
		public DbSet<Lake> lakes { get; set; }
		public DbSet<Camera> cameras { get; set; }
		public DbSet<data> data { get; set; }
		public DbSet<Fish> fish { get; set; }
		public DbSet<Notification> notifications { get; set; }
		public DbSet<Schedule> schedules { get; set; }
		public DbSet<Sensor> sensors { get; set; }
		public DbSet<Video> videos { get; set; }
		public DbSet<Region> regions { get; set; }
		public DbSet<Instruction> instructions { get; set; }
		public DbSet<ChatMessage> ChatMessages { get; set; }
	}

}
