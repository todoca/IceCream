using FluentValidation.AspNetCore;
using IceCream.Application.Interfaces;
using IceCream.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IceCream.Application.Extensions;

public static class InjectionExtensions
{
    public static IServiceCollection AddInjectionApplication(this IServiceCollection services, 
        IConfiguration configuration) 
    {
        services.AddSingleton(configuration);
        services.AddFluentValidation(options =>
        options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()
        .Where(p => !p.IsDynamic)));
       
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<ICategoryApplication, CategoryApplication>();
        return services;
    }
}
