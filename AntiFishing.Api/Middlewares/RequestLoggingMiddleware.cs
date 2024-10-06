using System.Diagnostics;

namespace AntiFishing.Api.Middlewares
{
	public class RequestLoggingMiddleware
	{
		private readonly RequestDelegate _next;

		public RequestLoggingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			Debug.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");

			await _next(context);

			Debug.WriteLine($"Response: {context.Response.StatusCode}");
		}
	}
}
