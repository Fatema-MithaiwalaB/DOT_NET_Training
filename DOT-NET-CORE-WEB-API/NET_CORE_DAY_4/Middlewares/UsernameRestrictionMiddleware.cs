using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace NET_CORE_DAY_4.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class UsernameRestrictionMiddleware
    {
        private readonly RequestDelegate _next;

        public UsernameRestrictionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var username = context.Request.Query["username"].ToString();

            if(username.ToLower() == "bacancy")
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Access Denied : User 'bacancy' is restricted");
                return;
            }

            await _next(context);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class UsernameRestrictionMiddlewareExtensions
    {
        public static IApplicationBuilder UseUsernameRestrictionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UsernameRestrictionMiddleware>();
        }
    }
}
