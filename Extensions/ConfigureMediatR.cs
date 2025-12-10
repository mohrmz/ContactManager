using Asp.Versioning;
using Microsoft.OpenApi;

namespace ContactManager.Extensions;

public static class ConfigureMediatR
{
    public static IServiceCollection AddMediatRServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
        });

        return services;
    }
}

public static class ConfigureApiVersioning
{
    public static IServiceCollection AddApiVersioningServices(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ReportApiVersions = true;
        });

        return services;
    }
}

public static class ConfigureSwagger
{
    public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Contact Manager API",
                Version = "v1",
                Description = "A RESTful API using Vertical Slice Architecture, Carter, EF Core, and .NET 10"
            });
        });

        return services;
    }
}
