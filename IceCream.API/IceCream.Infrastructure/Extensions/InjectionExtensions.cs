using IceCream.Infrastructure.Persistences.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IceCream.Infrastructure.Extensions;

public static class InjectionExtensions
{
    public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services, 
        IConfiguration configuration)
    {
        var assembly = typeof(IceCreamContext).Assembly.FullName;
        services.AddDbContext<IceCreamContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("IceCreamConnection"),
            b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient);

        return services;
    }
}
