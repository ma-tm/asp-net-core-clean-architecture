using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orion.Application.CommonAppLayer.Interfaces;
using Orion.ThirdPartyServices.AzureServices;
using Orion.ThirdPartyServices.AzureServices.Settings;

namespace Orion.ThirdPartyServices
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddThirdPartyServices(this IServiceCollection services, IConfiguration configuration)
        {
            var blobStorageSettings = new BlobStorageSettings();
            configuration.GetSection(blobStorageSettings.SettingName).Bind(blobStorageSettings);
            services.AddSingleton(x => new BlobServiceClient(blobStorageSettings.ConnectionString));
            services.AddScoped<IFileStorageService, BlobStorageService>();
            return services;
        }
    }
}
