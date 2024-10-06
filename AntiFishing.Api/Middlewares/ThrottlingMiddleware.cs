using Microsoft.Extensions.Caching.Memory;

namespace AntiFishing.Api.Middlewares
{
	public class ThrottlingMiddleware
	{
		private readonly RequestDelegate _next;
		private static readonly MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
		private readonly int _requestLimit = 3; // Limit per endpoint
		private readonly TimeSpan _timePeriod = TimeSpan.FromDays(1);

		public ThrottlingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			var rateLimitedCount = "/api/Video/Count-last-video";
			var rateLimitedStatus = "/api/Video/status-last-video";

			var ipAddress = context.Connection.RemoteIpAddress?.ToString();
			if (ipAddress == null)
			{
				await _next(context);
				return; // Don't proceed if there's no IP address
			}

			// Determine which endpoint is being accessed
			string cacheKey = null;
			if (context.Request.Path.Value == rateLimitedCount)
			{
				cacheKey = $"Request_Count_{ipAddress}";
			}
			else if (context.Request.Path.Value == rateLimitedStatus)
			{
				cacheKey = $"Request_Status_{ipAddress}";
			}

			// If the request is to a rate-limited endpoint
			if (cacheKey != null)
			{
				if (_cache.TryGetValue(cacheKey, out int requestCount))
				{
					if (requestCount >= _requestLimit)
					{
						context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
						await context.Response.WriteAsync("Too many requests. Please try again later.");
						return;
					}

					// Increment request count for the specific endpoint
					_cache.Set(cacheKey, requestCount + 1, _timePeriod);
				}
				else
				{
					// First request for this endpoint
					_cache.Set(cacheKey, 1, _timePeriod);
				}
			}

			// Call the next middleware in the pipeline
			await _next(context);
		}
	}
}
