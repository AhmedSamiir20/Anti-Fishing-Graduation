//using Microsoft.Extensions.Diagnostics.HealthChecks;

//namespace AntiFishing.Api.Health_Check
//{
//	public class DatabaseHealthCheck : IHealthCheck
//	{
//		public async Task<HealthCheckResult> CheckAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
//		{
//			// Implement your logic to check the database health (e.g., check connection)
//			bool isHealthy = true; // Replace with actual check

//			if (isHealthy)
//			{
//				return HealthCheckResult.Healthy("Database is reachable.");
//			}

//			return HealthCheckResult.Unhealthy("Database is not reachable.");
//		}
//	}
//}
