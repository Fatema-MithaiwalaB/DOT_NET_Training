using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using NET_CORE_DAY_4.Services;
using System.Diagnostics;

namespace NET_CORE_DAY_4.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ITimeService _timeService;

        public RequestLoggingMiddleware(RequestDelegate next, ITimeService timeService)
        {
            _next = next;
            _timeService = timeService;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var requestTime = _timeService.GetCurrentTime();
            Console.WriteLine($"[Request] {httpContext.Request.Method}  {httpContext.Request.Path}  -Time : {requestTime}");

            await _next(httpContext);

            var responseTime = _timeService.GetCurrentTime();
            Console.WriteLine($"[Response] {httpContext.Response.StatusCode}  -Time : {responseTime}");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RequestLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoggingMiddleware>();
        }
    }
}
