using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using FluentValidation;
using Orion.Application.SeedWork.PipelineBehaviors;

namespace Orion.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddValidatorsFromAssembly(assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddMediatR(c => c.RegisterServicesFromAssembly(assembly));
            return services;
        }
    }
}
