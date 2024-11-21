using Clients_BE.Application.Interfaces;
using Clients_BE.Infrastructure.Persistence.Context;
using Clients_BE.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Clients_BE.Infrastructure
{
    public static class IoC
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IDbContext, ApplicationDbContext>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            return services;
        }
    }
}
