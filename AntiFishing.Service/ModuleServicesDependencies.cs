

namespace AntiFishing.Service
{
	public static class ModuleServicesDependencies
	{
		public static IServiceCollection AddServicesDependencies(this IServiceCollection services)
		{
			services.AddTransient<ILakeService, LakeService>();
			services.AddTransient<ISensorService, SensorSevice>();
			services.AddTransient<IRegionService, RegionService>();
			services.AddTransient<ICameraService, CameraSevice>();
			services.AddTransient<IScheduleService, ScheduleSevice>();
			services.AddTransient<IInstructionService, InstructionService>();
			return services;
		}
	}
}
