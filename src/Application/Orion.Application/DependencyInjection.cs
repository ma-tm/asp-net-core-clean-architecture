using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace Orion.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(c => c.RegisterServicesFromAssembly(assembly));
            return services;
        }
    }
}
