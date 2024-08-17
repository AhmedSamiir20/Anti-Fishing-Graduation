//using AntiFishing.Data.Entities.Identity;
//using Microsoft.AspNetCore.Identity;

//namespace AntiFishing.Infrastructure
//{
//	public static class ServiceRegisteration
//	{
//		public static IServiceCollection AddServiceRegisteration(this IServiceCollection services)
//		{
//			services.AddIdentity<User, IdentityRole>(options =>
//			{
//				//Identity Option like the shape of password or anything
//				// Password settings.
//				options.Password.RequireDigit = true;
//				options.Password.RequireLowercase = true;
//				options.Password.RequireNonAlphanumeric = true;
//				options.Password.RequireUppercase = true;
//				options.Password.RequiredLength = 6;
//				options.Password.RequiredUniqueChars = 1;

//				// Lockout settings.
//				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
//				options.Lockout.MaxFailedAccessAttempts = 5;
//				options.Lockout.AllowedForNewUsers = true;

//				// User settings.
//				options.User.AllowedUserNameCharacters =
//				"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
//				options.User.RequireUniqueEmail = false;
//			}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
//			return services;
//		}
//	}
//}
