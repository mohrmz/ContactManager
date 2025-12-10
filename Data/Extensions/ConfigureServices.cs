using ContactManager.Data.Abstractions;
using ContactManager.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Data.Extensions;

public static class ConfigureServices
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
       IConfiguration configuration)
    {

        AddDbContext(services, configuration);

        AddServiceScopes(services);

        return services;
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ContactDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("ContactDbContext"),
                builder =>
                {
                    builder.MigrationsAssembly(typeof(ContactDbContext).Assembly.FullName);
                    builder.CommandTimeout(180);
                });
        }, ServiceLifetime.Scoped);

    }

    private static void AddServiceScopes(IServiceCollection services)
    {
        services.AddScoped<IContactRepository, ContactRepository>();
    }
}
