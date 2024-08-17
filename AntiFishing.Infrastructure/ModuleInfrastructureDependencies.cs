

using AntiFishing.Data.Helpers;

namespace AntiFishing.Infrastructure
{
	public static class ModuleInfrastructureDependencies
	{
		public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
		{
			services.AddTransient<ILakeRepository, LakeRepository>();
			services.AddTransient<ISensorRepository, SensorRepository>();
			services.AddTransient<IRegionRepository, RegionRepository>();
			services.AddTransient<ICameraRepository, CameraRepository>();
			services.AddTransient<IScheduleRepository, ScheduleRepository>();
			services.AddTransient<IInstructionRepository, InstructionRepository>();
			services.AddTransient<IAuthRepository, AuthRepository>();
			services.AddScoped<IVideoRepository, VideoRepository>();
			services.AddHttpClient();
			services.AddTransient<JWT>();

			services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
			return services;
		}
	}
}
