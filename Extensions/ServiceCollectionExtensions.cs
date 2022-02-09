using Microsoft.Extensions.DependencyInjection;
using NatsStreaming.Interfaces;
using NatsStreaming.Services;

namespace NatsStreaming.Extensions
{
    public static class ServiceCollectionExtensions
    {
         public static IServiceCollection AddStreamingService(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<ICustomSerializer, CustomSerializer>();
            services.AddSingleton<INatsConnectionProvider>(sp => new NatsConnectionProvider(connectionString));
            services.AddScoped<IStreamHandler, StreamHandler>();
            return services;
        }
    }
}
