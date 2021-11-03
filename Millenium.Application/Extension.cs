using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Millenium.Application.Behaviors;

namespace Millenium.Application
{
    public static class Extension
    {
        public static IServiceCollection AddApplication(this IServiceCollection service)
            => service;

        public static IApplicationBuilder UseApplication(this IApplicationBuilder app)
            => app.UseMiddleware<RequestLoggingMiddleware>();
    }
}