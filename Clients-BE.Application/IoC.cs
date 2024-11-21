using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Clients_BE.Application.Interfaces.Services;
using Clients_BE.Application.Features.Client.Services;
using Clients_BE.Application.Features.Address.Services;

namespace Clients_BE.Application
{
    public static class IoC
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddFluentValidationAutoValidation();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IAddressService, AddressService>();
            return services;
        }
    }
}
