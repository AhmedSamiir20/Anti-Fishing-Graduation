namespace AntiFishing.Core
{
	public static class ModuleCoreDependencies
	{
		public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
		{
			//Configuration of Mediatr
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
			//Configuration of Automapper
			services.AddAutoMapper((Assembly.GetExecutingAssembly()));//block of files such as the ddl

			// Get Validators
			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
			// 
			//services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
			return services;
		}
	}
}
