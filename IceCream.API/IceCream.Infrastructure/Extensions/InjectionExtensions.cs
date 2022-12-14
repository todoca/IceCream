using IceCream.Domain.Entities;
using IceCream.Infrastructure.Persistences.Contexts;
using IceCream.Infrastructure.Persistences.Interfaces;
using IceCream.Infrastructure.Persistences.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IceCream.Infrastructure.Extensions;

public static class InjectionExtensions
{
    public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services, 
        IConfiguration configuration)
    {
      
        var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        //var connectionString = $"Data Source= {dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPassword}";

        var assembly = typeof(IceCreamContext).Assembly.FullName;
        //services.AddDbContext<IceCreamContext>(
        //    options => options.UseInMemoryDatabase("IceCream"));
        services.AddDbContext<IceCreamContext>(
      options => options.UseSqlServer(connectionString,
      b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient);

        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>)); 
        services.AddTransient<SeedDb>();
        return services;
    }
}
