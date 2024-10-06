using Microsoft.Extensions.Caching.Memory;

namespace AntiFishing.Api.Middlewares
{
	public class ThrottlingMiddleware
	{
		private readonly RequestDelegate _next;
		private static readonly MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
		private readonly int _requestLimit = 3;
		private readonly TimeSpan _timePeriod = TimeSpan.FromDays(1);

		public ThrottlingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			//endpoints i want to active this rateLimiting on it
			var rateLimitedEndpoints = new List<string>
		{
			"/api/Video/Count-last-video",
			"/api/Video/status-last-video"
		};


			if (rateLimitedEndpoints.Contains(context.Request.Path.Value!))
			{
				var ipAddress = context.Connection.RemoteIpAddress?.ToString();
				var cacheKey = $"Request_{ipAddress}";

				if (_cache.TryGetValue(cacheKey, out int requestCount))
				{
					if (requestCount >= _requestLimit)
					{
						context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
						await context.Response.WriteAsync("Too many requests. Please try again later.");
						return;
					}

					_cache.Set(cacheKey, ++requestCount, _timePeriod);
				}
				else
				{
					_cache.Set(cacheKey, 1, _timePeriod);
				}
			}

			//to call next pipline in middleware if i have ^^
			await _next(context);
		}
	}
}


