using Application.Data;
using Domain.Entities.Persons;
using Domain.Primitives;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(configuration);
        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DB")));

        services.AddScoped<IApplicationDbContext>(options =>
            options.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IUnitOfWork>(options =>
            options.GetRequiredService<ApplicationDbContext>());

        // Add scoped repositores

        services.AddScoped<IPersonRepository, PersonRepository>();

        return services;
    }
}