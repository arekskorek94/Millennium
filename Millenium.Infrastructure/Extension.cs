using Microsoft.Extensions.DependencyInjection;
using Millenium.Application.IRepository;
using Millenium.Infrastructure.Repository;

namespace Millenium.Infrastructure
{
    public static class Extension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service)
            => service.AddTransient<IUserRepository, UserRepository>();
    }
}