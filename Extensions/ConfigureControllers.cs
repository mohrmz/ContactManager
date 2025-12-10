namespace ContactManager.Extensions;

public static class ConfigureControllers
{
    public static IServiceCollection AddControllerServices(this IServiceCollection services)
    {
        services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
        options.JsonSerializerOptions.WriteIndented = true;
    });

        return services;
    }
}
