using Mapster;
using MapsterMapper;
using System.Reflection;

namespace ContactManager.Extensions;

public static class ConfigureMapster
{
    public static IServiceCollection AddMappingServices(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;

        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}
