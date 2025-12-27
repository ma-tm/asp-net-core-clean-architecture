using Microsoft.Extensions.DependencyInjection;
using Orion.Application.StoryAppLayer.Gateway;
using Orion.Repository.StoryRepositories;

namespace Orion.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<StoryDbContext>();
            services.AddScoped<IStoryRepository, StoryRepository>();
            return services;
        }
    }
}
